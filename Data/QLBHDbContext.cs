using System.Configuration; // Cần cài NuGet System.Configuration.ConfigurationManager
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LTQL_QLBHDongHo.Data
{
    public class QLBHDbContext : DbContext
    {
        public DbSet<LoaiDongHo> LoaiDongHo { get; set; }
        public DbSet<ThuongHieu> ThuongHieu { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<ThongSoKyThuat> ThongSoKyThuat { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhanQuyen> PhanQuyen { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiet { get; set; }
        public DbSet<NhatKyHoatDong> NhatKyHoatDong { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Khớp với name="ChuoiKetNoi" trong App.config của bạn
                string conn = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasOne(x => x.KhachHang)
                    .WithMany(x => x.HoaDon)
                    .HasForeignKey(x => x.KhachHangID)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false);

                entity.HasOne(x => x.NhanVien)
                    .WithMany(x => x.HoaDon)
                    .HasForeignKey(x => x.NhanVienID)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false);
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.Property(x => x.TenSanPhamSnapshot)
                    .HasMaxLength(200)
                    .HasDefaultValue(string.Empty);

                entity.HasOne(x => x.SanPham)
                    .WithMany(x => x.HoaDonChiTiet)
                    .HasForeignKey(x => x.SanPhamID)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false);
            });

            modelBuilder.Entity<NhatKyHoatDong>(entity =>
            {
                entity.ToTable("NhatKyHoatDong");
                entity.Property(x => x.TenDangNhap).HasMaxLength(100).HasDefaultValue(string.Empty);
                entity.Property(x => x.TenNhanVien).HasMaxLength(150).HasDefaultValue(string.Empty);
                entity.Property(x => x.VaiTro).HasMaxLength(100).HasDefaultValue(string.Empty);
                entity.Property(x => x.HanhDong).HasMaxLength(120).HasDefaultValue(string.Empty);
                entity.Property(x => x.ChiTiet).HasMaxLength(1000).HasDefaultValue(string.Empty);
            });
        }

        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return SaveChangesWithAudit(() => base.SaveChanges(acceptAllChangesOnSuccess));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(true, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return SaveChangesWithAuditAsync(() => base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken));
        }

        private int SaveChangesWithAudit(Func<int> baseSave)
        {
            var auditItems = ThuThapThayDoiChoNhatKy();
            var userCtx = CanGhiAudit(auditItems) ? ActivityLogger.LayThongTinNguoiDungHienTai() : null;

            var result = baseSave();

            if (CanGhiAudit(auditItems))
            {
                GhiAuditSauKhiLuu(auditItems, userCtx);
            }

            return result;
        }

        private async Task<int> SaveChangesWithAuditAsync(Func<Task<int>> baseSave)
        {
            var auditItems = ThuThapThayDoiChoNhatKy();
            var userCtx = CanGhiAudit(auditItems) ? ActivityLogger.LayThongTinNguoiDungHienTai() : null;

            var result = await baseSave();

            if (CanGhiAudit(auditItems))
            {
                GhiAuditSauKhiLuu(auditItems, userCtx);
            }

            return result;
        }

        private List<AuditItem> ThuThapThayDoiChoNhatKy()
        {
            ChangeTracker.DetectChanges();

            var ds = new List<AuditItem>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State is not (EntityState.Added or EntityState.Modified or EntityState.Deleted))
                {
                    continue;
                }

                if (entry.Entity is NhatKyHoatDong)
                {
                    continue;
                }

                var entityName = entry.Metadata.ClrType.Name;
                var hanhDong = entry.State switch
                {
                    EntityState.Added => $"THÊM {entityName.ToUpperInvariant()}",
                    EntityState.Modified => $"SỬA {entityName.ToUpperInvariant()}",
                    EntityState.Deleted => $"XÓA {entityName.ToUpperInvariant()}",
                    _ => string.Empty
                };

                var chiTiet = TaoChiTietAudit(entry, entityName);
                ds.Add(new AuditItem { HanhDong = hanhDong, ChiTiet = chiTiet });
            }

            return ds;
        }

        private static string TaoChiTietAudit(EntityEntry entry, string entityName)
        {
            var keyInfo = string.Join(", ",
                entry.Properties
                    .Where(p => p.Metadata.IsPrimaryKey())
                    .Select(p => $"{p.Metadata.Name}={(entry.State == EntityState.Added ? p.CurrentValue : p.OriginalValue)}"));

            return entry.State switch
            {
                EntityState.Added =>
                    $"Thêm mới {entityName} ({(string.IsNullOrWhiteSpace(keyInfo) ? "chưa có khóa" : keyInfo)}).",

                EntityState.Deleted =>
                    $"Xóa {entityName} ({(string.IsNullOrWhiteSpace(keyInfo) ? "không rõ khóa" : keyInfo)}).",

                EntityState.Modified => TaoChiTietSua(entry, entityName, keyInfo),

                _ => $"Cập nhật {entityName}."
            };
        }

        private static string TaoChiTietSua(EntityEntry entry, string entityName, string keyInfo)
        {
            var thayDoi = entry.Properties
                .Where(p => p.IsModified)
                .Select(p =>
                {
                    var laThongTinNhayCam = p.Metadata.Name.Contains("MatKhau", StringComparison.OrdinalIgnoreCase)
                                          || p.Metadata.Name.Contains("Password", StringComparison.OrdinalIgnoreCase);

                    var truoc = laThongTinNhayCam ? "***" : (p.OriginalValue?.ToString() ?? "null");
                    var sau = laThongTinNhayCam ? "***" : (p.CurrentValue?.ToString() ?? "null");
                    return $"{p.Metadata.Name}: '{CatNgan(truoc, 80)}' -> '{CatNgan(sau, 80)}'";
                })
                .ToList();

            var textThayDoi = thayDoi.Count == 0
                ? "không có trường thay đổi chi tiết"
                : string.Join("; ", thayDoi);

            return $"Sửa {entityName} ({(string.IsNullOrWhiteSpace(keyInfo) ? "không rõ khóa" : keyInfo)}). {textThayDoi}.";
        }

        private static string CatNgan(string text, int maxLen)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLen)
            {
                return text;
            }

            return text[..maxLen] + "...";
        }

        private static bool CanGhiAudit(List<AuditItem> ds)
        {
            return ds.Count > 0;
        }

        private static void GhiAuditSauKhiLuu(List<AuditItem> ds, ActivityLogger.UserLogContext? userCtx)
        {
            foreach (var item in ds)
            {
                ActivityLogger.GhiNhatKy(userCtx, item.HanhDong, item.ChiTiet);
            }
        }

        private sealed class AuditItem
        {
            public string HanhDong { get; init; } = string.Empty;
            public string ChiTiet { get; init; } = string.Empty;
        }
    }
}