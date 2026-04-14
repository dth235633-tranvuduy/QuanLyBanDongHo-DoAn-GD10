using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Data
{
    public sealed class HoaDonSnapshotData
    {
        public string NhanVienTen { get; set; } = string.Empty;
        public string KhachHangTen { get; set; } = string.Empty;
        public string KhachHangSoDienThoai { get; set; } = string.Empty;
    }

    public static class HoaDonSnapshotHelper
    {
        private const string TrangThaiDaThanhToan = "Đã thanh toán";
        private const string TrangThaiChuaThanhToan = "Chưa thanh toán";
        private const string TrangThaiDaThanhToanKhongDau = "da thanh toan";
        private const string TrangThaiChuaThanhToanKhongDau = "chua thanh toan";
        private const string TrangThaiDaThanhToanLoiMa = "?� thanh to�n";
        private const string TrangThaiChuaThanhToanLoiMa = "ch?a thanh to�n";
        private const string MetaPrefix = " ||META:";

        public static string TaoGhiChuHoaDon(bool daThanhToan, string? ghiChuNguoiDung, string? tenNhanVien, string? tenKhachHang, string? sdtKhachHang)
        {
            var trangThai = daThanhToan ? TrangThaiDaThanhToan : TrangThaiChuaThanhToan;
            var noiDung = (ghiChuNguoiDung ?? string.Empty).Trim();
            var core = string.IsNullOrWhiteSpace(noiDung)
                ? trangThai
                : $"{trangThai} | {noiDung}";

            var snapshot = new HoaDonSnapshotData
            {
                NhanVienTen = (tenNhanVien ?? string.Empty).Trim(),
                KhachHangTen = (tenKhachHang ?? string.Empty).Trim(),
                KhachHangSoDienThoai = (sdtKhachHang ?? string.Empty).Trim()
            };

            var json = JsonSerializer.Serialize(snapshot);
            var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            return core + MetaPrefix + encoded;
        }

        public static bool LaHoaDonDaThanhToan(string? ghiChuHoaDon)
        {
            var core = LayPhanCore(ghiChuHoaDon);
            if (string.IsNullOrWhiteSpace(core))
            {
                // Dữ liệu cũ chưa có trạng thái: mặc định xem như đã thanh toán để không ẩn mất dữ liệu dashboard.
                return true;
            }

            var coreLower = core.ToLowerInvariant();
            if (coreLower.StartsWith(TrangThaiDaThanhToan.ToLowerInvariant())
                || coreLower.StartsWith(TrangThaiDaThanhToanKhongDau)
                || coreLower.StartsWith(TrangThaiDaThanhToanLoiMa))
            {
                return true;
            }

            if (coreLower.StartsWith(TrangThaiChuaThanhToan.ToLowerInvariant())
                || coreLower.StartsWith(TrangThaiChuaThanhToanKhongDau)
                || coreLower.StartsWith(TrangThaiChuaThanhToanLoiMa))
            {
                return false;
            }

            // Ghi chú tự do không theo mẫu cũ/mới: mặc định xem như đã thanh toán (tương thích dữ liệu lịch sử).
            return true;
        }

        public static bool CoSnapshot(string? ghiChuHoaDon)
        {
            return LaySnapshot(ghiChuHoaDon) != null;
        }

        public static int BackfillSnapshotChoHoaDonCu(QLBHDbContext context)
        {
            var ds = context.HoaDon
                .Include(x => x.NhanVien)
                .Include(x => x.KhachHang)
                .Where(x => x.GhiChuHoaDon == null || !x.GhiChuHoaDon.Contains(MetaPrefix))
                .ToList();

            if (ds.Count == 0)
            {
                return 0;
            }

            foreach (var hd in ds)
            {
                var snapshot = new HoaDonSnapshotData
                {
                    NhanVienTen = hd.NhanVien?.HoVaTen ?? string.Empty,
                    KhachHangTen = hd.KhachHang?.HoVaTen ?? string.Empty,
                    KhachHangSoDienThoai = hd.KhachHang?.DienThoai ?? string.Empty
                };

                hd.GhiChuHoaDon = GhepSnapshotVaoGhiChu(hd.GhiChuHoaDon, snapshot);
            }

            context.SaveChanges();
            return ds.Count;
        }

        public static int BackfillTenSanPhamSnapshotChoChiTietHoaDonCu(QLBHDbContext context)
        {
            var ds = context.HoaDonChiTiet
                .Include(x => x.SanPham)
                .Where(x => string.IsNullOrWhiteSpace(x.TenSanPhamSnapshot) && x.SanPham != null)
                .ToList();

            if (ds.Count == 0)
            {
                return 0;
            }

            foreach (var ct in ds)
            {
                ct.TenSanPhamSnapshot = ct.SanPham?.TenSanPham ?? string.Empty;
            }

            context.SaveChanges();
            return ds.Count;
        }

        public static string LayNoiDungGhiChuNguoiDung(string? ghiChuHoaDon)
        {
            var core = LayPhanCore(ghiChuHoaDon);
            var idx = core.IndexOf('|');
            if (idx < 0) return string.Empty;

            return core[(idx + 1)..].Trim();
        }

        public static string TaoGhiChuTheoTrangThai(string? ghiChuHoaDonHienTai, bool daThanhToan)
        {
            var trangThai = daThanhToan ? TrangThaiDaThanhToan : TrangThaiChuaThanhToan;
            var noiDung = LayNoiDungGhiChuNguoiDung(ghiChuHoaDonHienTai);
            var coreMoi = string.IsNullOrWhiteSpace(noiDung)
                ? trangThai
                : $"{trangThai} | {noiDung}";

            var snapshot = LaySnapshot(ghiChuHoaDonHienTai);
            if (snapshot == null)
            {
                return coreMoi;
            }

            var json = JsonSerializer.Serialize(snapshot);
            var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            return coreMoi + MetaPrefix + encoded;
        }

        public static HoaDonSnapshotData? LaySnapshot(string? ghiChuHoaDon)
        {
            var raw = ghiChuHoaDon ?? string.Empty;
            var idx = raw.IndexOf(MetaPrefix, StringComparison.Ordinal);
            if (idx < 0) return null;

            var encoded = raw[(idx + MetaPrefix.Length)..].Trim();
            if (string.IsNullOrWhiteSpace(encoded)) return null;

            try
            {
                var bytes = Convert.FromBase64String(encoded);
                var json = Encoding.UTF8.GetString(bytes);
                return JsonSerializer.Deserialize<HoaDonSnapshotData>(json);
            }
            catch
            {
                return null;
            }
        }

        private static string GhepSnapshotVaoGhiChu(string? ghiChuHoaDon, HoaDonSnapshotData snapshot)
        {
            var core = LayPhanCore(ghiChuHoaDon);
            if (string.IsNullOrWhiteSpace(core))
            {
                // Hóa đơn lịch sử chưa có trạng thái thường là hóa đơn đã chốt từ phiên bản cũ.
                core = TrangThaiDaThanhToan;
            }

            var json = JsonSerializer.Serialize(snapshot);
            var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            return core + MetaPrefix + encoded;
        }

        private static string LayPhanCore(string? ghiChuHoaDon)
        {
            var raw = ghiChuHoaDon ?? string.Empty;
            var idx = raw.IndexOf(MetaPrefix, StringComparison.Ordinal);
            return idx < 0 ? raw.Trim() : raw[..idx].Trim();
        }
    }
}
