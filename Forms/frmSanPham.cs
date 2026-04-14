using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmSanPham : Form
    {
        private class SanPhamViewModel
        {
            public int ID { get; set; }
            public string MaSP { get; set; } = string.Empty;
            public string TenSanPham { get; set; } = string.Empty;
            public string ThuongHieu { get; set; } = string.Empty;
            public string KieuDang { get; set; } = string.Empty;
            public int DonGia { get; set; }
            public string DonGiaHienThi => DonGia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
            public int SoLuong { get; set; }
            public string? HinhAnh { get; set; }
            public int ThuongHieuID { get; set; }
        }

        private static readonly Color PrimaryColor = Color.FromArgb(37, 99, 235);
        private static readonly Color TealColor = Color.FromArgb(13, 148, 136);
        private static readonly Color SurfaceColor = Color.FromArgb(248, 250, 252);
        private static readonly Color BorderColor = Color.FromArgb(203, 213, 225);

        private readonly QLBHDbContext context = new QLBHDbContext();
        private bool isThemMoi = false;
        private bool isCheDoSua = false;
        private bool isFormattingGia = false;
        private string duongDanAnhTaiLen = "";
        private frmThongSoKyThuat.ThongSoKyThuatInput? thongSoTamChoSanPhamMoi;
        private readonly string thuMucAnh = Path.Combine(Application.StartupPath, "Images");
        private readonly BindingSource bindingSource = new BindingSource();
        private readonly System.Windows.Forms.Timer timKiemTimer = new System.Windows.Forms.Timer();
        private readonly VaiTroNguoiDung _vaiTro;

        public frmSanPham(VaiTroNguoiDung? vaiTro = null)
        {
            InitializeComponent();
            _vaiTro = vaiTro ?? AppSession.VaiTro;
            if (!Directory.Exists(thuMucAnh)) Directory.CreateDirectory(thuMucAnh);

            Load += frmSanPham_Load;
            Resize += frmSanPham_Resize;
            dgvDanhSach.SelectionChanged += DgvDanhSach_SelectionChanged;
            dgvDanhSach.CellContentClick += dgvDanhSach_CellContentClick;
            btnChonAnh.Click += btnChonAnh_Click;
            btnDoiAnh.Click += btnDoiAnh_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnNhapThongSoKyThuat.Click += btnNhapThongSoKyThuat_Click;
            txtGiaBan.TextChanged += txtGiaBan_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.TextChanged += textBox1_TextChanged;

            timKiemTimer.Interval = 300;
            timKiemTimer.Tick += timKiemTimer_Tick;
        }

        private void frmSanPham_Load(object? sender, EventArgs e)
        {
            AnNutXemCuNeuCo();
            AnNutXoayAnhNeuConTonTai();
            ApplyModernTheme();
            LoadComboBox();
            LoadKieuDang();
            ConfigureDanhSachGrid();
            LoadDanhSach();
            BatTatChucNang(false);
            ApDungQuyenTheoVaiTro();
            ApplyResponsiveLayout();
        }

        private bool LaAdmin => _vaiTro == VaiTroNguoiDung.Admin;
        private bool LaQuanLy => _vaiTro == VaiTroNguoiDung.QuanLyCuaHang;
        private bool LaBanHang => _vaiTro == VaiTroNguoiDung.NhanVienBanHang;

        private void ApDungQuyenTheoVaiTro()
        {
            if (LaBanHang)
            {
                btnThemSp.Enabled = false;
                btnSuaSP.Enabled = false;
                btnXoaSP.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnTimKiem.Enabled = true;
                textBox1.Enabled = true;

                cboThuongHieu.Enabled = false;
                cboKieuDang.Enabled = false;
                txtTenSP.Enabled = false;
                numSoLuong.Enabled = false;
                txtGiaBan.Enabled = false;
                btnChonAnh.Enabled = false;
                btnDoiAnh.Enabled = false;
                btnNhapThongSoKyThuat.Enabled = false;
                dgvDanhSach.Enabled = true;
                return;
            }

            if (!LaBanHang)
            {
                btnXoaSP.Enabled = true;
                btnXoaSP.Text = "Xóa (YC mật khẩu Admin)";
            }
        }

        private void AnNutXemCuNeuCo()
        {
            var btnXemCu = TimControlTheoTen(this, "btnXem") as Button;
            if (btnXemCu == null) return;

            btnXemCu.Visible = false;
            if (btnXemCu.Parent != null)
            {
                btnXemCu.Parent.Controls.Remove(btnXemCu);
            }

            btnXemCu.Dispose();
        }

        private void AnNutXoayAnhNeuConTonTai()
        {
            // Một số bản cũ có nút xoay ảnh; ẩn hẳn để chỉ giữ 2 nút ảnh theo yêu cầu.
            var btnXoay = TimControlTheoTen(this, "btnXoayAnh") as Button;
            if (btnXoay != null)
            {
                btnXoay.Visible = false;
                btnXoay.Enabled = false;
                if (btnXoay.Parent != null)
                {
                    btnXoay.Parent.Controls.Remove(btnXoay);
                }

                btnXoay.Dispose();
            }

            foreach (var button in panelImage.Controls.OfType<Button>().Where(b => b.Text.Trim().Contains("Xoay", StringComparison.OrdinalIgnoreCase)).ToList())
            {
                button.Visible = false;
                button.Enabled = false;
                panelImage.Controls.Remove(button);
                button.Dispose();
            }
        }

        private static Control? TimControlTheoTen(Control parent, string controlName)
        {
            foreach (Control control in parent.Controls)
            {
                if (string.Equals(control.Name, controlName, StringComparison.Ordinal))
                {
                    return control;
                }

                var timDuoc = TimControlTheoTen(control, controlName);
                if (timDuoc != null)
                {
                    return timDuoc;
                }
            }

            return null;
        }

        private void frmSanPham_Resize(object? sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyModernTheme()
        {
            panelActions.BackColor = SurfaceColor;
            panelListTop.BackColor = SurfaceColor;
            groupInfo.ForeColor = Color.FromArgb(30, 41, 59);

            tableLayoutInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutInfo.Padding = new Padding(0, 4, 0, 0);

            txtMaSP.BackColor = SurfaceColor;
            txtTenSP.BackColor = Color.White;
            txtGiaBan.BackColor = Color.White;
            cboThuongHieu.BackColor = Color.White;
            cboKieuDang.BackColor = Color.White;
            numSoLuong.BackColor = Color.White;
            textBox1.BackColor = Color.White;

            picHinhAnh.BackColor = SurfaceColor;

            foreach (Control c in flowButtons.Controls)
            {
                c.Margin = new Padding(0, 0, 10, 0);
            }

            CapNhatMauNutTheoTrangThai();
        }

        private void ApplyResponsiveLayout()
        {
            if (IsDisposed) return;

            const int margin = 16;
            const int spacing = 12;
            const int minInfoWidth = 500;

            var imageWidth = Math.Clamp(groupInfo.ClientSize.Width / 3, 340, 460);
            panelImage.Width = imageWidth;
            CanhDeuNutAnh();

            var infoWidth = groupInfo.ClientSize.Width - panelImage.Width - (margin * 2) - spacing;
            tableLayoutInfo.Left = margin;
            tableLayoutInfo.Width = Math.Max(minInfoWidth, infoWidth);

            btnNhapThongSoKyThuat.Left = margin;
            btnNhapThongSoKyThuat.Width = tableLayoutInfo.Width;
            btnNhapThongSoKyThuat.Top = groupInfo.ClientSize.Height - btnNhapThongSoKyThuat.Height - 12;
        }

        private void CanhDeuNutAnh()
        {
            const int left = 12;
            const int right = 12;
            const int gap = 12;
            const int btnHeight = 40;
            const int bottom = 6;
            const int topImage = 5;

            var yButton = panelImage.ClientSize.Height - bottom - btnHeight;
            var available = panelImage.ClientSize.Width - left - right - gap;
            var btnWidth = Math.Max(120, available / 2);

            btnChonAnh.SetBounds(left, yButton, btnWidth, btnHeight);
            btnDoiAnh.SetBounds(left + btnWidth + gap, yButton, btnWidth, btnHeight);

            btnChonAnh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDoiAnh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            var imageHeight = Math.Max(120, yButton - topImage - 8);
            picHinhAnh.SetBounds(left, topImage, panelImage.ClientSize.Width - left - right, imageHeight);
            picHinhAnh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void ConfigureDanhSachGrid()
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DamBaoCotXemSauCotAnh();

            dgvDanhSach.EnableHeadersVisualStyles = false;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);

            dgvDanhSach.DefaultCellStyle.BackColor = Color.White;
            dgvDanhSach.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvDanhSach.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dgvDanhSach.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDanhSach.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);

            dgvDanhSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvDanhSach.GridColor = Color.FromArgb(226, 232, 240);
            dgvDanhSach.RowTemplate.Height = 36;

            if (dgvDanhSach.Columns.Contains("cThuongHieu") && dgvDanhSach.Columns.Contains("cKd"))
            {
                dgvDanhSach.Columns["cKd"].DisplayIndex = dgvDanhSach.Columns["cThuongHieu"].DisplayIndex + 1;
            }

            if (dgvDanhSach.Columns.Contains("cKd"))
            {
                dgvDanhSach.Columns["cKd"].DataPropertyName = "KieuDang";
                dgvDanhSach.Columns["cKd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvDanhSach.Columns.Contains("cGia"))
            {
                dgvDanhSach.Columns["cGia"].DataPropertyName = "DonGiaHienThi";
                dgvDanhSach.Columns["cGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvDanhSach.Columns.Contains("cSoLuong"))
            {
                dgvDanhSach.Columns["cSoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvDanhSach.Columns.Contains("cStt"))
            {
                dgvDanhSach.Columns["cStt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDanhSach.RowPostPaint -= dgvDanhSach_RowPostPaint;
                dgvDanhSach.RowPostPaint += dgvDanhSach_RowPostPaint;
            }
        }

        private void DamBaoCotXemSauCotAnh()
        {
            if (!dgvDanhSach.Columns.Contains("cXem"))
            {
                dgvDanhSach.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "cXem",
                    HeaderText = "Xem",
                    Text = "Xem",
                    UseColumnTextForButtonValue = true,
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 10
                });
            }

            var cotXem = dgvDanhSach.Columns["cXem"];
            cotXem.HeaderText = "Xem";

            if (dgvDanhSach.Columns.Contains("Anh"))
            {
                cotXem.DisplayIndex = dgvDanhSach.Columns["Anh"].DisplayIndex + 1;
            }
        }

        private void LoadComboBox()
        {
            try
            {
                cboThuongHieu.DataSource = context.ThuongHieu.AsNoTracking().OrderBy(x => x.TenThuongHieu).ToList();
                cboThuongHieu.DisplayMember = "TenThuongHieu";
                cboThuongHieu.ValueMember = "ID";
                cboThuongHieu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu combo: " + ex.Message);
            }
        }

        private void LoadKieuDang()
        {
            cboKieuDang.DataSource = new List<string> { "Nam", "Nữ", "Unisex" };
            cboKieuDang.SelectedIndex = -1;
        }

        private void LoadDanhSach(string? keyword = null)
        {
            try
            {
                var duLieu = (
                    from s in context.SanPham.AsNoTracking()
                    join th in context.ThuongHieu.AsNoTracking()
                        on s.ThuongHieuID equals th.ID into thGroup
                    from th in thGroup.DefaultIfEmpty()
                    select new
                    {
                        s.ID,
                        s.TenSanPham,
                        s.KieuDang,
                        s.DonGia,
                        s.SoLuong,
                        s.HinhAnh,
                        s.ThuongHieuID,
                        TenThuongHieu = th != null ? th.TenThuongHieu : null
                    })
                    .OrderBy(s => s.ID)
                    .ToList();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var q = keyword.Trim().ToLowerInvariant();
                    var qMa = q.StartsWith("sp") ? q[2..] : q;

                    duLieu = duLieu.Where(s =>
                            (s.TenSanPham ?? string.Empty).ToLowerInvariant().Contains(q) ||
                            (s.TenThuongHieu ?? string.Empty).ToLowerInvariant().Contains(q) ||
                            (s.KieuDang ?? string.Empty).ToLowerInvariant().Contains(q) ||
                            ("sp" + s.ID.ToString("D3")).ToLowerInvariant().Contains(q) ||
                            s.ID.ToString().Contains(qMa))
                        .ToList();
                }

                var ds = duLieu
                    .Select(s => new SanPhamViewModel
                    {
                        ID = s.ID,
                        MaSP = "SP" + s.ID.ToString("D3"),
                        TenSanPham = s.TenSanPham,
                        ThuongHieu = string.IsNullOrWhiteSpace(s.TenThuongHieu) ? $"(ID: {s.ThuongHieuID})" : s.TenThuongHieu,
                        KieuDang = s.KieuDang,
                        DonGia = s.DonGia,
                        SoLuong = s.SoLuong,
                        HinhAnh = s.HinhAnh,
                        ThuongHieuID = s.ThuongHieuID
                    }).ToList();

                bindingSource.DataSource = ds;
                dgvDanhSach.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void BatTatChucNang(bool isEditing)
        {
            // Khi thêm mới: bắt buộc nhập thông số kỹ thuật trước mới cho lưu
            btnLuu.Enabled = isEditing && (!isThemMoi || thongSoTamChoSanPhamMoi != null);

            // Khi sửa: chỉ để nút Lưu, khóa các nút còn lại theo yêu cầu
            btnHuy.Enabled = isEditing && !isCheDoSua;

            cboThuongHieu.Enabled = isEditing;
            cboKieuDang.Enabled = isEditing;
            txtTenSP.Enabled = isEditing;
            numSoLuong.Enabled = isEditing;
            txtGiaBan.Enabled = isEditing;
            btnChonAnh.Enabled = isEditing;
            btnDoiAnh.Enabled = isEditing;

            // Khi đang nhập/sửa thì khóa bảng để tránh người dùng chọn sản phẩm khác gây lệch ID
            dgvDanhSach.Enabled = !isEditing;

            if (isEditing)
            {
                btnThemSp.Enabled = false;
                btnSuaSP.Enabled = false;
                btnXoaSP.Enabled = false;
                btnTimKiem.Enabled = false;
                textBox1.Enabled = false;

                // Chỉ cho nhập/sửa thông số kỹ thuật khi đang ở chế độ Thêm hoặc Sửa.
                btnNhapThongSoKyThuat.Enabled = true;
            }
            else
            {
                btnThemSp.Enabled = true;
                btnSuaSP.Enabled = true;
                btnXoaSP.Enabled = !LaBanHang;
                btnTimKiem.Enabled = true;
                textBox1.Enabled = true;
                btnNhapThongSoKyThuat.Enabled = false;
            }

            CapNhatTrangThaiNutXem();

            if (LaQuanLy && !isEditing)
            {
                btnXoaSP.Text = "Xóa (YC mật khẩu Admin)";
            }

            panelActions.BackColor = isEditing ? Color.FromArgb(241, 245, 249) : SurfaceColor;

            CapNhatMauNutTheoTrangThai();
        }

        private void CapNhatTrangThaiNutXem()
        {
            var dangNhapLieu = btnLuu.Enabled || txtTenSP.Enabled;
            if (dgvDanhSach.Columns.Contains("cXem"))
            {
                dgvDanhSach.Columns["cXem"].Visible = !dangNhapLieu;
            }
        }

        private void CapNhatMauNutTheoTrangThai()
        {
            DimButton(btnThemSp);
            DimButton(btnSuaSP);
            DimButton(btnXoaSP);
            DimButton(btnLuu);
            DimButton(btnHuy);
            DimButton(btnTimKiem);
            DimButton(btnNhapThongSoKyThuat);
            DimButton(btnChonAnh);
            DimButton(btnDoiAnh);
         
        }

        private static void DimButton(Button btn)
        {
            var borderColor = BorderColor;
            var enabledBack = Color.White;
            var enabledFore = Color.FromArgb(30, 41, 59);

            if (btn.Name is "btnLuu" or "btnChonAnh")
            {
                enabledBack = PrimaryColor;
                enabledFore = Color.White;
                borderColor = PrimaryColor;
            }
            else if (btn.Name == "btnNhapThongSoKyThuat")
            {
                enabledBack = TealColor;
                enabledFore = Color.White;
                borderColor = TealColor;
            }
            else if (btn.Name == "btnXoaSP")
            {
                enabledFore = Color.FromArgb(185, 28, 28);
            }

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;

            if (btn.Enabled)
            {
                btn.BackColor = enabledBack;
                btn.ForeColor = enabledFore;
                btn.FlatAppearance.BorderColor = borderColor;
                return;
            }

            btn.BackColor = Color.FromArgb(241, 245, 249);
            btn.ForeColor = Color.FromArgb(148, 163, 184);
            btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
        }

        private void ResetO_Nhap()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
            numSoLuong.Value = 1;
            picHinhAnh.ImageLocation = null;
            duongDanAnhTaiLen = "";
            cboThuongHieu.SelectedIndex = -1;
            cboKieuDang.SelectedIndex = -1;
        }

        private string TaoMaSanPhamMoi()
        {
            int nextId = (context.SanPham.AsNoTracking().Select(x => (int?)x.ID).Max() ?? 0) + 1;
            return "SP" + nextId.ToString("D3");
        }

        private int? ParseGiaBan()
        {
            var so = new string((txtGiaBan.Text ?? string.Empty).Where(char.IsDigit).ToArray());
            if (!int.TryParse(so, out int giaBan) || giaBan <= 0) return null;
            return giaBan;
        }

        private void btnThemSp_Click(object? sender, EventArgs e)
        {
            if (LaBanHang)
            {
                MessageBox.Show("Nhân viên bán hàng chỉ được tìm kiếm và xem thông tin sản phẩm.");
                return;
            }

            isThemMoi = true;
            isCheDoSua = false;
            thongSoTamChoSanPhamMoi = null;
            ResetO_Nhap();
            txtMaSP.Text = TaoMaSanPhamMoi();
            BatTatChucNang(true);
            txtTenSP.Focus();
        }

        private void btnSuaSP_Click(object? sender, EventArgs e)
        {
            if (LaBanHang)
            {
                MessageBox.Show("Nhân viên bán hàng không có quyền sửa sản phẩm.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm dưới bảng để sửa!");
                return;
            }

            isThemMoi = false;
            isCheDoSua = true;
            BatTatChucNang(true);
            txtTenSP.Focus();
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            isThemMoi = false;
            isCheDoSua = false;
            thongSoTamChoSanPhamMoi = null;
            BatTatChucNang(false);
            ResetO_Nhap();
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            if (LaBanHang)
            {
                MessageBox.Show("Nhân viên bán hàng không có quyền lưu thay đổi sản phẩm.");
                return;
            }

            if (isThemMoi && thongSoTamChoSanPhamMoi == null)
            {
                MessageBox.Show("Khi thêm sản phẩm mới, bạn phải nhấn 'Nhập thông số kỹ thuật' và lưu thông số trước.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm!");
                txtTenSP.Focus();
                return;
            }

            var giaBan = ParseGiaBan();
            if (!giaBan.HasValue)
            {
                MessageBox.Show("Vui lòng nhập Giá bán hợp lệ (số lớn hơn 0)!");
                txtGiaBan.Focus();
                return;
            }

            if (cboThuongHieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Thương hiệu!");
                cboThuongHieu.Focus();
                return;
            }

            if (cboKieuDang.SelectedItem == null || string.IsNullOrWhiteSpace(cboKieuDang.Text))
            {
                MessageBox.Show("Vui lòng chọn Kiểu dáng!");
                cboKieuDang.Focus();
                return;
            }

            try
            {
                SanPham? sp;
                if (isThemMoi)
                {
                    sp = new SanPham();
                    context.SanPham.Add(sp);
                }
                else
                {
                    int id = int.Parse(txtMaSP.Text.Replace("SP", ""));
                    sp = context.SanPham.Find(id);
                    if (sp == null)
                    {
                        MessageBox.Show("Sản phẩm không tồn tại!");
                        return;
                    }
                }

                sp!.TenSanPham = txtTenSP.Text.Trim();
                sp.KieuDang = cboKieuDang.Text.Trim();
                sp.DonGia = giaBan.Value;
                sp.SoLuong = (int)numSoLuong.Value;
                sp.ThuongHieuID = (int)cboThuongHieu.SelectedValue;

                if (!string.IsNullOrEmpty(duongDanAnhTaiLen))
                {
                    string extension = Path.GetExtension(duongDanAnhTaiLen);
                    string tenFileAnh = Guid.NewGuid() + extension;
                    string duongDanDich = Path.Combine(thuMucAnh, tenFileAnh);
                    File.Copy(duongDanAnhTaiLen, duongDanDich, true);
                    sp.HinhAnh = tenFileAnh;
                    duongDanAnhTaiLen = "";
                }

                context.SaveChanges();

                if (isThemMoi && thongSoTamChoSanPhamMoi != null)
                {
                    var ts = context.ThongSoKyThuat.FirstOrDefault(x => x.SanPhamID == sp.ID);
                    if (ts == null)
                    {
                        ts = new ThongSoKyThuat { SanPhamID = sp.ID };
                        context.ThongSoKyThuat.Add(ts);
                    }

                    ts.LoaiKinh = thongSoTamChoSanPhamMoi.LoaiKinh;
                    ts.DoChiuNuoc = thongSoTamChoSanPhamMoi.DoChiuNuoc;
                    ts.LoaiDay = thongSoTamChoSanPhamMoi.LoaiDay;
                    ts.KichThuocMat = thongSoTamChoSanPhamMoi.KichThuocMat;
                    ts.TenThuongHieu = thongSoTamChoSanPhamMoi.TenThuongHieu;
                    ts.LoaiDongHoID = thongSoTamChoSanPhamMoi.LoaiDongHoID;

                    context.SaveChanges();
                }

                MessageBox.Show("Lưu thành công!");
                isThemMoi = false;
                isCheDoSua = false;
                thongSoTamChoSanPhamMoi = null;
                BatTatChucNang(false);
                LoadDanhSach();
                ChonDongTheoSanPham(sp.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnXoaSP_Click(object? sender, EventArgs e)
        {
            if (LaBanHang)
            {
                MessageBox.Show("Nhân viên bán hàng không có quyền xóa sản phẩm.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!");
                return;
            }

            if (!AppSession.YeuCauXacNhanMatKhauAdmin(this))
            {
                MessageBox.Show("Mật khẩu Admin không đúng hoặc bạn đã hủy xác nhận. Không thể xóa sản phẩm.", "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtMaSP.Text.Replace("SP", ""));
                    var sp = context.SanPham.Find(id);
                    if (sp != null)
                    {
                        context.SanPham.Remove(sp);
                        context.SaveChanges();
                        LoadDanhSach();
                        ResetO_Nhap();
                        MessageBox.Show("Xóa thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                duongDanAnhTaiLen = ofd.FileName;
                picHinhAnh.ImageLocation = duongDanAnhTaiLen;
            }
        }

        private void btnDoiAnh_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) && !isThemMoi)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để đổi ảnh!");
                return;
            }

            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                duongDanAnhTaiLen = ofd.FileName;
                picHinhAnh.ImageLocation = duongDanAnhTaiLen;
            }
        }

        private void DgvDanhSach_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                if (btnLuu.Enabled) return; // đang nhập/sửa => không đổi dữ liệu theo dòng bảng
                if (dgvDanhSach.CurrentRow == null) return;

                var item = dgvDanhSach.CurrentRow.DataBoundItem as SanPhamViewModel;
                if (item == null) return;

                txtMaSP.Text = item.MaSP;
                txtTenSP.Text = item.TenSanPham;
                txtGiaBan.Text = item.DonGiaHienThi;

                decimal soLuongHopLe = item.SoLuong;
                if (soLuongHopLe < numSoLuong.Minimum) soLuongHopLe = numSoLuong.Minimum;
                if (soLuongHopLe > numSoLuong.Maximum) soLuongHopLe = numSoLuong.Maximum;
                numSoLuong.Value = soLuongHopLe;

                cboThuongHieu.SelectedValue = item.ThuongHieuID;

                var indexKieuDang = cboKieuDang.FindStringExact(item.KieuDang ?? string.Empty);
                cboKieuDang.SelectedIndex = indexKieuDang;

                if (!string.IsNullOrEmpty(item.HinhAnh))
                {
                    string fullPath = Path.Combine(thuMucAnh, item.HinhAnh);
                    picHinhAnh.ImageLocation = File.Exists(fullPath) ? fullPath : null;
                }
                else
                {
                    picHinhAnh.ImageLocation = null;
                }

                btnNhapThongSoKyThuat.Enabled = btnLuu.Enabled || txtTenSP.Enabled;
                CapNhatTrangThaiNutXem();
                CapNhatMauNutTheoTrangThai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            LoadDanhSach(textBox1.Text);
        }

        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
            if (!textBox1.Enabled) return;
            timKiemTimer.Stop();
            timKiemTimer.Start();
        }

        private void timKiemTimer_Tick(object? sender, EventArgs e)
        {
            timKiemTimer.Stop();
            LoadDanhSach(textBox1.Text);
        }

        private void textBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                timKiemTimer.Stop();
                LoadDanhSach(textBox1.Text);
            }
        }

        private void btnNhapThongSoKyThuat_Click(object? sender, EventArgs e)
        {
            if (isThemMoi)
            {
                var maSpTam = txtMaSP.Text.Trim();
                if (string.IsNullOrWhiteSpace(maSpTam))
                {
                    MessageBox.Show("Không xác định được mã sản phẩm tạm. Vui lòng bấm 'Thêm mới' lại.");
                    return;
                }

                var tenThuongHieu = cboThuongHieu.Text?.Trim() ?? string.Empty;
                using var fThem = new frmThongSoKyThuat(0, tenThuongHieu, thongSoTamChoSanPhamMoi, true, maSpTam);
                if (fThem.ShowDialog(this) == DialogResult.OK)
                {
                    thongSoTamChoSanPhamMoi = fThem.KetQuaNhap;
                    BatTatChucNang(true); // bật nút Lưu sau khi đã nhập thông số
                    MessageBox.Show("Đã nhập thông số kỹ thuật tạm. Bạn có thể bấm Lưu sản phẩm.");
                }
                return;
            }

            if (!int.TryParse(txtMaSP.Text.Replace("SP", ""), out int sanPhamId) || sanPhamId <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi nhập/sửa thông số kỹ thuật.");
                return;
            }

            MoFormThongSoKyThuat(sanPhamId);
        }

        private void MoFormThongSoKyThuat(int sanPhamId)
        {
            using var f = new frmThongSoKyThuat(sanPhamId);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadDanhSach(textBox1.Text);
                ChonDongTheoSanPham(sanPhamId);
            }
        }

        private void txtGiaBan_TextChanged(object? sender, EventArgs e)
        {
            if (isFormattingGia || !txtGiaBan.Enabled) return;

            var so = new string((txtGiaBan.Text ?? string.Empty).Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(so))
            {
                return;
            }

            if (!decimal.TryParse(so, out var number)) return;

            isFormattingGia = true;
            txtGiaBan.Text = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0}", number);
            txtGiaBan.SelectionStart = txtGiaBan.Text.Length;
            isFormattingGia = false;
        }

        private void dgvDanhSach_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            var stt = (e.RowIndex + 1).ToString();
            dgvDanhSach.Rows[e.RowIndex].Cells["cStt"].Value = stt;
        }

        private void ChonDongTheoSanPham(int sanPhamId)
        {
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.DataBoundItem is SanPhamViewModel item && item.ID == sanPhamId)
                {
                    row.Selected = true;
                    dgvDanhSach.CurrentCell = row.Cells["cMaSP"];
                    break;
                }
            }
        }

        private void dgvDanhSach_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDanhSach.Columns[e.ColumnIndex].Name != "cXem") return;

            if (dgvDanhSach.Rows[e.RowIndex].DataBoundItem is not SanPhamViewModel item) return;

            using var frm = new frmXemThongTinSanPham(item.ID);
            frm.ShowDialog(this);
        }
    }
}
