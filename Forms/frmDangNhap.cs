using System;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmDangNhap : Form
    {
        public bool LaAdmin { get; private set; }
        public VaiTroNguoiDung VaiTro { get; private set; } = VaiTroNguoiDung.KhongXacDinh;
        public string TenDangNhap { get; private set; } = string.Empty;

        public frmDangNhap()
        {
            InitializeComponent();

            lblBrandTitle.Text = "DUY WATCHES";
            Text = "Đăng nhập - DUY WATCHES";

            txtPass.KeyDown += txtPass_KeyDown;
            txtUser.KeyDown += txtUser_KeyDown;
            chkRemember.CheckedChanged += chkRemember_CheckedChanged;
        }

        private void txtUser_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            btnLogin_Click(sender, e);
        }

        private void txtPass_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            btnLogin_Click(sender, e);
        }

        private void chkRemember_CheckedChanged(object? sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkRemember.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text.Trim();
            var pass = txtPass.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = new QLBHDbContext();

                var taiKhoan = context.NhanVien
                    .AsNoTracking()
                    .Include(x => x.PhanQuyen)
                    .FirstOrDefault(x => x.TenDangNhap == user && x.MatKhau == pass);

                if (taiKhoan == null)
                {
                    ActivityLogger.GhiNhatKy(
                        new ActivityLogger.UserLogContext
                        {
                            TenDangNhap = user,
                            TenNhanVien = user,
                            VaiTro = "Khách"
                        },
                        "ĐĂNG NHẬP THẤT BẠI",
                        $"Đăng nhập thất bại với tài khoản '{user}'.");

                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var tenQuyen = taiKhoan.PhanQuyen?.TenQuyen ?? string.Empty;
                VaiTro = AppSession.XacDinhVaiTro(tenQuyen);
                LaAdmin = VaiTro == VaiTroNguoiDung.Admin;

                TenDangNhap = taiKhoan.TenDangNhap;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

