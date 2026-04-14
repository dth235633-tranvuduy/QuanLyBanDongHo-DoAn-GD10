using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Windows.Forms;

namespace LTQL_QLBHDongHo.Data
{
    public enum VaiTroNguoiDung
    {
        KhongXacDinh = 0,
        Admin = 1,
        QuanLyCuaHang = 2,
        NhanVienBanHang = 3
    }

    public sealed class GioHangItemSession
    {
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; } = string.Empty;
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public long ThanhTien => (long)DonGia * SoLuong;
    }

    public sealed class HoaDonDraftSession
    {
        public List<GioHangItemSession> SanPhamDaChon { get; set; } = new();
        public string SoDienThoaiKhachHang { get; set; } = string.Empty;
        public long GiamGia { get; set; }
        public string GhiChu { get; set; } = string.Empty;
    }

    public static class AppSession
    {
        public static string TenDangNhap { get; set; } = string.Empty;
        public static bool LaAdmin { get; set; }
        public static VaiTroNguoiDung VaiTro { get; set; } = VaiTroNguoiDung.KhongXacDinh;

        public static HoaDonDraftSession HoaDonDangLap { get; set; } = new HoaDonDraftSession();

        public static bool LaQuanLyCuaHang => VaiTro == VaiTroNguoiDung.QuanLyCuaHang;
        public static bool LaNhanVienBanHang => VaiTro == VaiTroNguoiDung.NhanVienBanHang;

        public static VaiTroNguoiDung XacDinhVaiTro(string? tenQuyen)
        {
            var role = (tenQuyen ?? string.Empty).Trim().ToLowerInvariant();

            if (role.Contains("admin") || role.Contains("quản trị") || role.Contains("quan tri"))
            {
                return VaiTroNguoiDung.Admin;
            }

            if (role.Contains("quản lý") || role.Contains("quan ly") || role.Contains("manager"))
            {
                return VaiTroNguoiDung.QuanLyCuaHang;
            }

            if (role.Contains("bán") || role.Contains("ban") || role.Contains("sale"))
            {
                return VaiTroNguoiDung.NhanVienBanHang;
            }

            return VaiTroNguoiDung.NhanVienBanHang;
        }

        public static bool KiemTraMatKhauAdmin(string? adminPassword)
        {
            var matKhau = (adminPassword ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                return false;
            }

            try
            {
                using var context = new QLBHDbContext();
                return context.NhanVien
                    .AsNoTracking()
                    .Include(nv => nv.PhanQuyen)
                    .Where(nv => nv.MatKhau == matKhau)
                    .AsEnumerable()
                    .Any(nv => XacDinhVaiTro(nv.PhanQuyen?.TenQuyen) == VaiTroNguoiDung.Admin);
            }
            catch
            {
                return false;
            }
        }

        public static bool YeuCauXacNhanMatKhauAdmin(IWin32Window? owner)
        {
            using var frm = new Form
            {
                Text = "Xác nhận mật khẩu Admin",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowInTaskbar = false,
                ClientSize = new Size(500, 180),
                AutoScaleMode = AutoScaleMode.Font
            };

            var lbl = new Label
            {
                Text = "Nhập mật khẩu Admin để xác nhận xóa:",
                AutoSize = true,
                Left = 16,
                Top = 16
            };

            var txtPassword = new TextBox
            {
                Left = 16,
                Top = 44,
                Width = frm.ClientSize.Width - 32,
                UseSystemPasswordChar = true
            };

            const int btnWidth = 120;
            const int btnHeight = 36;
            const int rightMargin = 16;
            const int btnGap = 12;
            const int btnTop = 120;

            var btnOk = new Button
            {
                Text = "Xác nhận",
                DialogResult = DialogResult.OK,
                Width = btnWidth,
                Height = btnHeight,
                Left = frm.ClientSize.Width - rightMargin - btnWidth * 2 - btnGap,
                Top = btnTop
            };

            var btnCancel = new Button
            {
                Text = "Hủy",
                DialogResult = DialogResult.Cancel,
                Width = btnWidth,
                Height = btnHeight,
                Left = frm.ClientSize.Width - rightMargin - btnWidth,
                Top = btnTop
            };

            frm.Controls.Add(lbl);
            frm.Controls.Add(txtPassword);
            frm.Controls.Add(btnOk);
            frm.Controls.Add(btnCancel);
            frm.AcceptButton = btnOk;
            frm.CancelButton = btnCancel;

            if (frm.ShowDialog(owner) != DialogResult.OK)
            {
                return false;
            }

            return KiemTraMatKhauAdmin(txtPassword.Text);
        }
    }
}
