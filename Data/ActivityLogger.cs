using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Data
{
    public static class ActivityLogger
    {
        public sealed class UserLogContext
        {
            public string TenDangNhap { get; init; } = string.Empty;
            public string TenNhanVien { get; init; } = string.Empty;
            public string VaiTro { get; init; } = string.Empty;
        }

        public static void DamBaoBangNhatKyTonTai()
        {
            try
            {
                using var context = new QLBHDbContext();
                DamBaoBangNhatKyTonTai(context);
            }
            catch
            {
                // Không làm gián đoạn luồng nghiệp vụ nếu không tạo được bảng.
            }
        }

        public static void DamBaoBangNhatKyTonTai(QLBHDbContext context)
        {
            context.Database.ExecuteSqlRaw(@"
IF OBJECT_ID(N'[dbo].[NhatKyHoatDong]', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[NhatKyHoatDong]
    (
        [ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [TenDangNhap] NVARCHAR(100) NOT NULL DEFAULT N'',
        [TenNhanVien] NVARCHAR(150) NOT NULL DEFAULT N'',
        [VaiTro] NVARCHAR(100) NOT NULL DEFAULT N'',
        [HanhDong] NVARCHAR(120) NOT NULL DEFAULT N'',
        [ChiTiet] NVARCHAR(1000) NOT NULL DEFAULT N'',
        [ThoiGian] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
    )
END");
        }

        public static void GhiNhatKy(string hanhDong, string chiTiet)
        {
            var userCtx = LayThongTinNguoiDungHienTai();
            GhiNhatKy(userCtx, hanhDong, chiTiet);
        }

        public static void GhiNhatKy(UserLogContext? userCtx, string hanhDong, string chiTiet)
        {
            try
            {
                using var context = new QLBHDbContext();
                DamBaoBangNhatKyTonTai(context);

                var resolved = userCtx ?? LayThongTinNguoiDungHienTai(context);

                context.NhatKyHoatDong.Add(new NhatKyHoatDong
                {
                    TenDangNhap = string.IsNullOrWhiteSpace(resolved.TenDangNhap) ? "(Không rõ)" : resolved.TenDangNhap,
                    TenNhanVien = string.IsNullOrWhiteSpace(resolved.TenNhanVien) ? "(Không rõ)" : resolved.TenNhanVien,
                    VaiTro = string.IsNullOrWhiteSpace(resolved.VaiTro) ? "Nhân viên" : resolved.VaiTro,
                    HanhDong = (hanhDong ?? string.Empty).Trim(),
                    ChiTiet = (chiTiet ?? string.Empty).Trim(),
                    ThoiGian = DateTime.Now
                });

                context.SaveChanges();
            }
            catch
            {
                // Không làm gián đoạn thao tác chính nếu ghi log lỗi.
            }
        }

        public static UserLogContext LayThongTinNguoiDungHienTai()
        {
            try
            {
                using var context = new QLBHDbContext();
                return LayThongTinNguoiDungHienTai(context);
            }
            catch
            {
                return new UserLogContext
                {
                    TenDangNhap = (AppSession.TenDangNhap ?? string.Empty).Trim(),
                    TenNhanVien = (AppSession.TenDangNhap ?? string.Empty).Trim(),
                    VaiTro = LayVaiTroTheoSession()
                };
            }
        }

        private static UserLogContext LayThongTinNguoiDungHienTai(QLBHDbContext context)
        {
            var tenDangNhap = (AppSession.TenDangNhap ?? string.Empty).Trim();
            var thongTinNguoiDung = context.NhanVien
                .AsNoTracking()
                .Include(x => x.PhanQuyen)
                .FirstOrDefault(x => x.TenDangNhap == tenDangNhap);

            var tenNhanVien = thongTinNguoiDung?.HoVaTen ?? tenDangNhap;
            var vaiTro = thongTinNguoiDung?.PhanQuyen?.TenQuyen ?? LayVaiTroTheoSession();

            return new UserLogContext
            {
                TenDangNhap = tenDangNhap,
                TenNhanVien = tenNhanVien,
                VaiTro = vaiTro
            };
        }

        private static string LayVaiTroTheoSession()
        {
            return AppSession.VaiTro switch
            {
                VaiTroNguoiDung.Admin => "Admin",
                VaiTroNguoiDung.QuanLyCuaHang => "Nhân viên quản lý",
                VaiTroNguoiDung.NhanVienBanHang => "Nhân viên",
                _ => "Nhân viên"
            };
        }
    }
}
