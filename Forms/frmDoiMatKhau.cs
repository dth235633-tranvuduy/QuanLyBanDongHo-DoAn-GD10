using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            txtCurrentPassword.KeyDown += PasswordFields_KeyDown;
            txtNewPassword.KeyDown += PasswordFields_KeyDown;
            txtConfirmPassword.KeyDown += PasswordFields_KeyDown;
        }

        private void PasswordFields_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            btnSave_Click(sender, e);
        }

        private void chkShowPassword_CheckedChanged(object? sender, EventArgs e)
        {
            var showPassword = chkShowPassword.Checked;
            txtCurrentPassword.UseSystemPasswordChar = !showPassword;
            txtNewPassword.UseSystemPasswordChar = !showPassword;
            txtConfirmPassword.UseSystemPasswordChar = !showPassword;
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            var currentPassword = txtCurrentPassword.Text;
            var newPassword = txtNewPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;
            var tenDangNhap = AppSession.TenDangNhap?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Không xác định được tài khoản đăng nhập hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(currentPassword)
                || string.IsNullOrWhiteSpace(newPassword)
                || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (!string.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (string.Equals(currentPassword, newPassword, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            try
            {
                using var context = new QLBHDbContext();

                var taiKhoanDangNhap = context.NhanVien
                    .FirstOrDefault(x => x.TenDangNhap == tenDangNhap);

                if (taiKhoanDangNhap == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản đang đăng nhập trong dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.Equals(taiKhoanDangNhap.MatKhau, currentPassword, StringComparison.Ordinal))
                {
                    MessageBox.Show("Mật khẩu cũ không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCurrentPassword.Focus();
                    return;
                }

                taiKhoanDangNhap.MatKhau = newPassword;

                context.SaveChanges();

                ActivityLogger.GhiNhatKy(
                    "ĐỔI MẬT KHẨU",
                    $"Tài khoản '{tenDangNhap}' đã đổi mật khẩu.");

                MessageBox.Show($"Đổi mật khẩu thành công cho tài khoản {tenDangNhap}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            chkShowPassword.Checked = false;
            txtCurrentPassword.Focus();
        }
    }
}
