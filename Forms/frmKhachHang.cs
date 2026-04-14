using System;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmKhachHang : Form
    {
        private readonly QLBHDbContext context = new QLBHDbContext();
        private readonly BindingSource bindingSource = new BindingSource();

        private bool xuLyThem = false;
        private int idDangSua = 0;

        private const string TenKhachVangLai = "Khách hàng vãng lai";
        private const int TyLeQuyDoiDiemRaTien = 10_000; // 1 điểm = 10.000 VNĐ
        private const int MucTichDiemTheoTien = 1_000_000; // Mỗi 1.000.000 VNĐ = 1 điểm

        private readonly VaiTroNguoiDung _vaiTro;
        private bool LaAdmin => _vaiTro == VaiTroNguoiDung.Admin;
        private bool LaQuanLy => _vaiTro == VaiTroNguoiDung.QuanLyCuaHang;
        private bool LaBanHang => _vaiTro == VaiTroNguoiDung.NhanVienBanHang;

        public frmKhachHang(VaiTroNguoiDung? vaiTro = null)
        {
            InitializeComponent();
            _vaiTro = vaiTro ?? AppSession.VaiTro;
            ChuyenNutTimKiemRaKhuVucTim();
            ApDungMauNutDongNhat();

            Load += frmKhanhHang_Load;
            Resize += frmKhachHang_Resize;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuyBo.Click += btnHuyBo_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnThoat.Visible = false;

            dataGridView.SelectionChanged += dataGridView_SelectionChanged;

            // Ô tìm kiếm nằm ở Designer là textBox1
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;

            txtDienThoai.TextChanged += txtDienThoai_TextChanged;
            txtHoVaTen.TextChanged += txtHoVaTen_TextChanged;
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

        private void txtHoVaTen_TextChanged(object? sender, EventArgs e)
        {
            if (!txtHoVaTen.Enabled) return;

            var original = txtHoVaTen.Text;
            var filtered = LocTenKhachHangHopLe(original);
            if (original == filtered) return;

            var oldSelectionStart = txtHoVaTen.SelectionStart;
            txtHoVaTen.Text = filtered;
            txtHoVaTen.SelectionStart = Math.Min(oldSelectionStart, txtHoVaTen.Text.Length);
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

        private static bool CoKyTuDacBietKhongHopLeTrongTen(string input)
        {
            return input.Any(c => ":!@#$%^&".Contains(c));
        }

        private static string LocTenKhachHangHopLe(string input)
        {
            return new string((input ?? string.Empty).Where(c => !":!@#$%^&".Contains(c)).ToArray());
        }

        private static bool LaKhachVangLai(KhachHang k)
        {
            return k.HoVaTen == TenKhachVangLai && string.IsNullOrWhiteSpace(k.DienThoai);
        }

        private void frmKhachHang_Resize(object? sender, EventArgs e)
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
            var btnRight = groupBox1.ClientSize.Width - 24 - btnSearchWidth;

            label4.Left = btnRight - gap - searchWidth;
            label4.Top = actionTop - 26;

            textBox1.Left = btnRight - gap - searchWidth;
            textBox1.Top = actionTop + (actionHeight - textBox1.Height) / 2;
            textBox1.Width = searchWidth;

            btnTimKiem.SetBounds(btnRight, textBox1.Top - 1, btnSearchWidth, textBox1.Height + 2);

            var actionMaxWidth = Math.Max(420, textBox1.Left - left - gap);
            flpPrimaryActions.Left = left;
            flpPrimaryActions.Width = actionMaxWidth;
        }

        private void BatTatChucNang(bool dangNhapLieu)
        {
            btnLuu.Enabled = dangNhapLieu;
            btnHuyBo.Enabled = dangNhapLieu;

            txtHoVaTen.Enabled = dangNhapLieu;
            txtDienThoai.Enabled = dangNhapLieu;
            txtDiaChi.Enabled = dangNhapLieu;

            btnThem.Enabled = !dangNhapLieu;
            btnSua.Enabled = !dangNhapLieu;
            btnTimKiem.Enabled = !dangNhapLieu;

            // Admin được xóa trực tiếp; Quản lý cần mật khẩu Admin; Bán hàng không được xóa.
            btnXoa.Enabled = !dangNhapLieu && !LaBanHang;

            dataGridView.Enabled = !dangNhapLieu;
        }

        private void frmKhanhHang_Load(object? sender, EventArgs e)
        {
            CauHinhLuoi();
            BatTatChucNang(false);
            DongBoDiemTichLuyTuHoaDonDaThanhToan();
            LoadData();
            KiemSoatQuyenXoa();
            ApplyResponsiveLayout();
        }

        private void DongBoDiemTichLuyTuHoaDonDaThanhToan()
        {
            try
            {
                var dsHoaDon = context.HoaDon
                    .AsNoTracking()
                    .Where(x => x.KhachHangID.HasValue)
                    .Select(x => new
                    {
                        KhachHangId = x.KhachHangID!.Value,
                        x.GhiChuHoaDon,
                        x.SoTienGiamDiem,
                        TongTienHang = x.HoaDonChiTiet.Sum(ct => (long?)ct.SoLuongBan * ct.DonGiaBan) ?? 0
                    })
                    .ToList();

                var diemTheoKhach = dsHoaDon
                    .Where(x => HoaDonSnapshotHelper.LaHoaDonDaThanhToan(x.GhiChuHoaDon))
                    .GroupBy(x => x.KhachHangId)
                    .ToDictionary(
                        g => g.Key,
                        g =>
                        {
                            long tongDiem = 0;
                            foreach (var hd in g)
                            {
                                var soTienGiam = (long)Math.Clamp(hd.SoTienGiamDiem, 0m, (decimal)long.MaxValue);
                                var tongSauGiam = Math.Max(0L, hd.TongTienHang - soTienGiam);
                                var diemCongThem = MucTichDiemTheoTien > 0 ? tongSauGiam / MucTichDiemTheoTien : 0;
                                var diemDaDung = TyLeQuyDoiDiemRaTien > 0 ? soTienGiam / TyLeQuyDoiDiemRaTien : 0;
                                tongDiem += diemCongThem - diemDaDung;
                            }

                            return (int)Math.Clamp(tongDiem, 0L, int.MaxValue);
                        });

                var dsKhach = context.KhachHang.ToList();
                var coThayDoi = false;

                foreach (var kh in dsKhach)
                {
                    var diemMoi = diemTheoKhach.TryGetValue(kh.ID, out var diem) ? diem : 0;
                    if (kh.DiemTichLuy == diemMoi) continue;

                    kh.DiemTichLuy = diemMoi;
                    coThayDoi = true;
                }

                if (coThayDoi)
                {
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đồng bộ điểm tích lũy từ hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhLuoi()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;

            if (!dataGridView.Columns.Contains("DiemTichLuy"))
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "DiemTichLuy",
                    DataPropertyName = nameof(KhachHang.DiemTichLuy),
                    HeaderText = "Điểm tích lũy",
                    FillWeight = 70,
                    ReadOnly = true,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
                });
            }
        }

        private void KiemSoatQuyenXoa()
        {
            if (LaAdmin || LaQuanLy)
            {
                btnXoa.Text = "Xóa (YC mật khẩu Admin)";
                return;
            }

            if (!LaAdmin)
            {
                btnXoa.Enabled = false;
                btnXoa.Text = "Xóa (Admin)";
            }
        }

        private void LoadData(string? tuKhoa = null)
        {
            try
            {
                var query = context.KhachHang.AsNoTracking().AsQueryable();

                // Không hiển thị khách hàng vãng lai trong danh sách quản lý khách hàng
                query = query.Where(k => !(k.HoVaTen == TenKhachVangLai && (k.DienThoai == null || k.DienThoai == "")));

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    var q = tuKhoa.Trim().ToLower();
                    query = query.Where(k =>
                        k.HoVaTen.ToLower().Contains(q) ||
                        (k.DienThoai ?? string.Empty).ToLower().Contains(q) ||
                        (k.DiaChi ?? string.Empty).ToLower().Contains(q) ||
                        k.DiemTichLuy.ToString().Contains(q) ||
                        k.ID.ToString().Contains(q));
                }

                var list = query.OrderBy(k => k.ID).ToList();
                bindingSource.DataSource = list;
                dataGridView.DataSource = bindingSource;

                HienThiDongDangChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDongDangChon()
        {
            if (bindingSource.Current is not KhachHang kh)
            {
                txtHoVaTen.Text = string.Empty;
                txtDienThoai.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                return;
            }

            txtHoVaTen.Text = kh.HoVaTen;
            txtDienThoai.Text = kh.DienThoai ?? string.Empty;
            txtDiaChi.Text = kh.DiaChi ?? string.Empty;
        }

        private void dataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (btnLuu.Enabled) return; // đang nhập liệu thì không đổi theo chọn dòng
            HienThiDongDangChon();
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            xuLyThem = true;
            idDangSua = 0;

            BatTatChucNang(true);
            txtHoVaTen.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtHoVaTen.Focus();
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is not KhachHang kh)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            xuLyThem = false;
            idDangSua = kh.ID;
            BatTatChucNang(true);
            txtHoVaTen.Focus();
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (LaBanHang)
            {
                MessageBox.Show("Bạn không có quyền xóa khách hàng. Chỉ Admin mới được xóa.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!AppSession.YeuCauXacNhanMatKhauAdmin(this))
            {
                MessageBox.Show("Mật khẩu Admin không đúng hoặc bạn đã hủy xác nhận. Không thể xóa khách hàng.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bindingSource.Current is not KhachHang dongDangChon)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng '{dongDangChon.HoVaTen}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                var kh = context.KhachHang.Find(dongDangChon.ID);
                if (kh == null)
                {
                    MessageBox.Show("Khách hàng không tồn tại hoặc đã bị xóa trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(textBox1.Text);
                    return;
                }

                context.KhachHang.Remove(kh);
                context.SaveChanges();

                MessageBox.Show("Đã xóa khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            var hoVaTen = txtHoVaTen.Text.Trim();
            var dienThoai = txtDienThoai.Text.Trim();
            var diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoVaTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoVaTen.Focus();
                return;
            }

            if (CoKyTuDacBietKhongHopLeTrongTen(hoVaTen))
            {
                MessageBox.Show("Tên khách hàng không được chứa ký tự đặc biệt: : ! @ # $ % ^ &",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoVaTen.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(dienThoai))
            {
                if (!dienThoai.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return;
                }

                if (dienThoai.Length > 10)
                {
                    MessageBox.Show("Số điện thoại tối đa 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return;
                }

                var trungKhachHang = context.KhachHang.Any(k =>
                    k.DienThoai != null &&
                    k.DienThoai == dienThoai &&
                    k.ID != idDangSua);

                if (trungKhachHang)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại ở khách hàng khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return;
                }

                var trungNhanVien = context.NhanVien.Any(n =>
                    n.DienThoai != null &&
                    n.DienThoai == dienThoai);

                if (trungNhanVien)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại ở nhân viên. Mỗi người chỉ được dùng 1 số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDienThoai.Focus();
                    return;
                }
            }

            // Chặn tạo bản ghi khách vãng lai trong danh sách khách hàng
            if (hoVaTen.Equals(TenKhachVangLai, StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(dienThoai))
            {
                MessageBox.Show("Không lưu khách hàng vãng lai trong danh sách khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoVaTen.Focus();
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    var khMoi = new KhachHang
                    {
                        HoVaTen = hoVaTen,
                        DienThoai = string.IsNullOrWhiteSpace(dienThoai) ? null : dienThoai,
                        DiaChi = string.IsNullOrWhiteSpace(diaChi) ? null : diaChi
                    };

                    context.KhachHang.Add(khMoi);
                    context.SaveChanges();

                    MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var kh = context.KhachHang.Find(idDangSua);
                    if (kh == null)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (LaKhachVangLai(kh))
                    {
                        MessageBox.Show("Không chỉnh sửa khách hàng vãng lai trong màn hình quản lý khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(textBox1.Text);
                        return;
                    }

                    kh.HoVaTen = hoVaTen;
                    kh.DienThoai = string.IsNullOrWhiteSpace(dienThoai) ? null : dienThoai;
                    kh.DiaChi = string.IsNullOrWhiteSpace(diaChi) ? null : diaChi;

                    context.SaveChanges();

                    MessageBox.Show("Cập nhật khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                xuLyThem = false;
                idDangSua = 0;
                BatTatChucNang(false);
                LoadData(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object? sender, EventArgs e)
        {
            xuLyThem = false;
            idDangSua = 0;
            BatTatChucNang(false);
            LoadData(textBox1.Text);
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            LoadData(textBox1.Text);
        }

        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
            if (!btnTimKiem.Enabled) return;
            LoadData(textBox1.Text);
        }

        private void textBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadData(textBox1.Text);
            }
        }

        private void frmKhanhHang_Load_1(object sender, EventArgs e)
        {
            // giữ hàm rỗng để tương thích Designer
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            // giữ hàm rỗng để tương thích Designer
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // giữ hàm rỗng để tương thích Designer
        }
    }
}
