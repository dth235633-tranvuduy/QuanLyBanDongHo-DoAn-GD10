using System;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmNhanVien : Form
    {
        private sealed class NhanVienViewModel
        {
            public int ID { get; set; }
            public string HoVaTen { get; set; } = string.Empty;
            public string DienThoai { get; set; } = string.Empty;
            public string DiaChi { get; set; } = string.Empty;
            public string TenDangNhap { get; set; } = string.Empty;
            public string MatKhau { get; set; } = string.Empty;
            public int PhanQuyenID { get; set; }
            public string QuyenHan { get; set; } = string.Empty;
        }

        private readonly QLBHDbContext context = new QLBHDbContext();
        private readonly BindingSource bindingSource = new BindingSource();

        private bool dangThemMoi = false;
        private int idDangSua = 0;
        private readonly bool laAdmin;

        public frmNhanVien(bool laAdmin = false)
        {
            InitializeComponent();
            this.laAdmin = laAdmin;
            ChuyenNutTimKiemRaKhuVucTim();
            ApDungMauNutDongNhat();

            Load += frmNhanVien_Load;
            FormClosed += frmNhanVien_FormClosed;
            Resize += frmNhanVien_Resize;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuyBo.Click += btnHuyBo_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnThoat.Visible = false;

            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            txtTim.KeyDown += txtTim_KeyDown;
            txtDienThoai.TextChanged += txtDienThoai_TextChanged;
        }

        private void ChuyenNutTimKiemRaKhuVucTim()
        {
            if (btnTimKiem.Parent != groupBox1)
            {
                flpPrimaryActions.Controls.Remove(btnTimKiem);
                groupBox1.Controls.Add(btnTimKiem);
            }

            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.BringToFront();
        }

        private void ApDungMauNutDongNhat()
        {
            var dsNutTrang = new[] { btnThem, btnSua, btnXoa, btnHuyBo, btnTimKiem };
            foreach (var btn in dsNutTrang)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(148, 163, 184);
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(51, 65, 85);
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }

            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.BackColor = Color.FromArgb(32, 99, 155);
            btnLuu.ForeColor = Color.White;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void txtDienThoai_TextChanged(object? sender, EventArgs e)
        {
            GioiHanNhapSoDienThoai(txtDienThoai);
        }

        private static void GioiHanNhapSoDienThoai(TextBox textBox)
        {
            var original = textBox.Text;
            var filtered = new string(original.Where(char.IsDigit).Take(10).ToArray());
            if (original == filtered) return;

            var oldSelectionStart = textBox.SelectionStart;
            textBox.Text = filtered;
            textBox.SelectionStart = Math.Min(oldSelectionStart, textBox.Text.Length);
        }

        private void frmNhanVien_Resize(object? sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (IsDisposed) return;

            const int left = 24;
            const int gap = 12;

            var actionTop = flpPrimaryActions.Top;
            var actionHeight = flpPrimaryActions.Height;
            var btnSearchWidth = 94;
            var searchWidth = Math.Clamp(groupBox1.ClientSize.Width / 3, 220, 340);
            var btnRight = groupBox1.ClientSize.Width - 16 - btnSearchWidth;

            label7.Left = btnRight - gap - searchWidth;
            label7.Top = actionTop - 26;

            txtTim.Left = btnRight - gap - searchWidth;
            txtTim.Top = actionTop + (actionHeight - txtTim.Height) / 2;
            txtTim.Width = searchWidth;

            btnTimKiem.SetBounds(btnRight, txtTim.Top - 1, btnSearchWidth, txtTim.Height + 2);

            var actionMaxWidth = Math.Max(420, txtTim.Left - left - gap);
            flpPrimaryActions.Left = left;
            flpPrimaryActions.Width = actionMaxWidth;
        }

        private void frmNhanVien_Load(object? sender, EventArgs e)
        {
            if (!laAdmin)
            {
                MessageBox.Show("Bạn không có quyền truy cập form Nhân viên. Chỉ Admin mới được phép vào.",
                    "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(new Action(Close));
                return;
            }

            CauHinhLuoi();
            LoadComboQuyenHan();
            BatTatChucNang(false);
            LoadData();
            btnXoa.Text = "Xóa (YC mật khẩu Admin)";
            ApplyResponsiveLayout();
        }

        private void frmNhanVien_FormClosed(object? sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }

        private void CauHinhLuoi()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;
            dataGridView.DataSource = bindingSource;
        }

        private void LoadComboQuyenHan()
        {
            try
            {
                var dsQuyen = context.PhanQuyen
                    .AsNoTracking()
                    .OrderBy(x => x.TenQuyen)
                    .ToList();

                cboQuyenHan.DataSource = dsQuyen;
                cboQuyenHan.DisplayMember = "TenQuyen";
                cboQuyenHan.ValueMember = "ID";
                cboQuyenHan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BatTatChucNang(bool dangNhapLieu)
        {
            btnLuu.Enabled = dangNhapLieu;
            btnHuyBo.Enabled = dangNhapLieu;

            txtHoVaTen.Enabled = dangNhapLieu;
            txtDienThoai.Enabled = dangNhapLieu;
            txtDiaChi.Enabled = dangNhapLieu;
            txtTenDangNhap.Enabled = dangNhapLieu;
            txtMatKhau.Enabled = dangNhapLieu;
            cboQuyenHan.Enabled = dangNhapLieu;

            btnThem.Enabled = !dangNhapLieu;
            btnSua.Enabled = !dangNhapLieu;
            btnXoa.Enabled = !dangNhapLieu;
            btnTimKiem.Enabled = !dangNhapLieu;
            txtTim.Enabled = !dangNhapLieu;

            dataGridView.Enabled = !dangNhapLieu;
        }

        private void LoadData(string? tuKhoa = null)
        {
            try
            {
                var query = context.NhanVien
                    .AsNoTracking()
                    .Include(n => n.PhanQuyen)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    var q = tuKhoa.Trim().ToLower();
                    query = query.Where(n =>
                        n.ID.ToString().Contains(q) ||
                        n.HoVaTen.ToLower().Contains(q) ||
                        n.TenDangNhap.ToLower().Contains(q) ||
                        n.DienThoai.ToLower().Contains(q) ||
                        n.DiaChi.ToLower().Contains(q) ||
                        n.PhanQuyen.TenQuyen.ToLower().Contains(q));
                }

                var ds = query
                    .OrderBy(n => n.ID)
                    .Select(n => new NhanVienViewModel
                    {
                        ID = n.ID,
                        HoVaTen = n.HoVaTen,
                        DienThoai = n.DienThoai,
                        DiaChi = n.DiaChi,
                        TenDangNhap = n.TenDangNhap,
                        MatKhau = n.MatKhau,
                        PhanQuyenID = n.PhanQuyenID,
                        QuyenHan = n.PhanQuyen.TenQuyen
                    })
                    .ToList();

                bindingSource.DataSource = ds;
                HienThiDongDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDongDangChon()
        {
            if (bindingSource.Current is not NhanVienViewModel nv)
            {
                XoaTrangThongTinNhap();
                return;
            }

            txtHoVaTen.Text = nv.HoVaTen;
            txtDienThoai.Text = nv.DienThoai;
            txtDiaChi.Text = nv.DiaChi;
            txtTenDangNhap.Text = nv.TenDangNhap;
            txtMatKhau.Text = nv.MatKhau;

            if (cboQuyenHan.DataSource != null)
            {
                cboQuyenHan.SelectedValue = nv.PhanQuyenID;
            }
        }

        private void XoaTrangThongTinNhap()
        {
            txtHoVaTen.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            cboQuyenHan.SelectedIndex = -1;
        }

        private bool KiemTraDuLieuNhap()
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoVaTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return false;
            }

            if (cboQuyenHan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn quyền hạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboQuyenHan.Focus();
                return false;
            }

            var dienThoai = txtDienThoai.Text.Trim();
            if (!string.IsNullOrWhiteSpace(dienThoai))
            {
                if (!dienThoai.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return false;
                }

                if (dienThoai.Length > 10)
                {
                    MessageBox.Show("Số điện thoại tối đa 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return false;
                }

                var trungNhanVien = context.NhanVien.Any(n =>
                    n.DienThoai != null &&
                    n.DienThoai == dienThoai &&
                    n.ID != idDangSua);

                if (trungNhanVien)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại ở nhân viên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return false;
                }

                var trungKhachHang = context.KhachHang.Any(k =>
                    k.DienThoai != null &&
                    k.DienThoai == dienThoai);

                if (trungKhachHang)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại ở khách hàng. Mỗi người chỉ được dùng 1 số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return false;
                }
            }

            var tenDangNhap = txtTenDangNhap.Text.Trim();
            var daTonTai = context.NhanVien.Any(n =>
                n.TenDangNhap.ToLower() == tenDangNhap.ToLower() &&
                n.ID != idDangSua);

            if (daTonTai)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return false;
            }

            return true;
        }

        private void dataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (btnLuu.Enabled) return;
            HienThiDongDangChon();
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            dangThemMoi = true;
            idDangSua = 0;
            BatTatChucNang(true);
            XoaTrangThongTinNhap();
            txtHoVaTen.Focus();
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is not NhanVienViewModel nv)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dangThemMoi = false;
            idDangSua = nv.ID;
            BatTatChucNang(true);
            txtHoVaTen.Focus();
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!AppSession.YeuCauXacNhanMatKhauAdmin(this))
            {
                MessageBox.Show("Mật khẩu Admin không đúng hoặc bạn đã hủy xác nhận. Không thể xóa nhân viên.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bindingSource.Current is not NhanVienViewModel nv)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên '{nv.HoVaTen}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                var entity = context.NhanVien.Find(nv.ID);
                if (entity == null)
                {
                    MessageBox.Show("Nhân viên không tồn tại hoặc đã bị xóa trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(txtTim.Text);
                    return;
                }

                context.NhanVien.Remove(entity);
                context.SaveChanges();

                MessageBox.Show("Đã xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(txtTim.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieuNhap()) return;

            try
            {
                var hoVaTen = txtHoVaTen.Text.Trim();
                var dienThoai = txtDienThoai.Text.Trim();
                var diaChi = txtDiaChi.Text.Trim();
                var tenDangNhap = txtTenDangNhap.Text.Trim();
                var matKhau = txtMatKhau.Text;
                var phanQuyenId = (int)cboQuyenHan.SelectedValue;

                if (dangThemMoi)
                {
                    var nvMoi = new NhanVien
                    {
                        HoVaTen = hoVaTen,
                        DienThoai = dienThoai,
                        DiaChi = diaChi,
                        TenDangNhap = tenDangNhap,
                        MatKhau = matKhau,
                        PhanQuyenID = phanQuyenId
                    };

                    context.NhanVien.Add(nvMoi);
                    context.SaveChanges();
                    MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var nv = context.NhanVien.Find(idDangSua);
                    if (nv == null)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    nv.HoVaTen = hoVaTen;
                    nv.DienThoai = dienThoai;
                    nv.DiaChi = diaChi;
                    nv.TenDangNhap = tenDangNhap;
                    nv.MatKhau = matKhau;
                    nv.PhanQuyenID = phanQuyenId;

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dangThemMoi = false;
                idDangSua = 0;
                BatTatChucNang(false);
                LoadData(txtTim.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object? sender, EventArgs e)
        {
            dangThemMoi = false;
            idDangSua = 0;
            BatTatChucNang(false);
            LoadData(txtTim.Text);
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            LoadData(txtTim.Text);
        }

        private void txtTim_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadData(txtTim.Text);
            }
        }
    }
}
