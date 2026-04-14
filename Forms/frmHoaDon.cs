using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmHoaDon : Form
    {
        private sealed class SanPhamHoaDonVm
        {
            public int ID { get; set; }
            public string TenSanPham { get; set; } = string.Empty;
            public int DonGia { get; set; }
            public int SoLuong { get; set; }
            public long ThanhTien => (long)DonGia * SoLuong;
        }

        private sealed class HoaDonGanDayVm
        {
            public int ID { get; set; }
            public string TenKhachHang { get; set; } = string.Empty;
            public string NguoiLap { get; set; } = string.Empty;
            public string NgayLap { get; set; } = string.Empty;
            public string TongTien { get; set; } = string.Empty;
            public string TrangThai { get; set; } = string.Empty;
        }

        private const string TrangThaiDaThanhToan = "Đã thanh toán";
        private const string TrangThaiChuaThanhToan = "Chưa thanh toán";
        private const int TyLeQuyDoiDiemRaTien = 10_000; // 1 điểm = 10.000 VNĐ
        private const int MucTichDiemTheoTien = 1_000_000; // Mỗi 1.000.000 VNĐ = 1 điểm
        private const int DiemToiThieuDeSuDung = 100;

        private readonly QLBHDbContext _context = new QLBHDbContext();
        private readonly BindingSource _sanPhamBs = new BindingSource();
        private readonly BindingSource _hoaDonBs = new BindingSource();

        private int? _khachHangIdDangChon;
        private bool _laKhachMoi;
        private long _giamGia;
        private int _diemTichLuyKhachDangChon;
        private int? _hoaDonChuaThanhToanDangChonId;
        private int? _hoaDonDangNapDeThanhToanLaiId;
        private bool _dangDongForm;

        private readonly Label _lblTienGiamTheoDiem = new Label();
        private readonly CheckBox _chkSuDungDiem = new CheckBox();
        private readonly Label _lblThongTinDiem = new Label();

        public frmHoaDon()
        {
            InitializeComponent();
            KhoiTaoNhapGiamGiaTheoDiem();

            Load += frmHoaDon_Load;
            FormClosing += frmHoaDon_FormClosing;
            Resize += frmHoaDon_Resize;
            FormClosed += frmHoaDon_FormClosed;

            btnThemSP.Click += btnThemSP_Click;
            btnLuu.Click += btnLuu_Click;
            btnThanhToan.Click += btnThanhToan_Click;
            btnHuy.Click += btnHuy_Click;
            btnThemKh.Click += button1_Click;

            textNhapSDTKH.KeyDown += textNhapSDTKH_KeyDown;
            textNhapSDTKH.Leave += textNhapSDTKH_Leave;
            textNhapSDTKH.TextChanged += textNhapSDTKH_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;

            dgvHoaDonGanDay.CellContentClick += dgvHoaDonGanDay_CellContentClick;
            dgvHoaDonGanDay.SelectionChanged += dgvHoaDonGanDay_SelectionChanged;
        }

        private void textNhapSDTKH_TextChanged(object? sender, EventArgs e)
        {
            GioiHanNhapSoDienThoai(textNhapSDTKH);
        }

        private void chkSuDungDiem_CheckedChanged(object? sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void textBox2_TextChanged(object? sender, EventArgs e)
        {
            if (textBox2.ReadOnly || _dangDongForm) return;

            var original = textBox2.Text;
            var filtered = LocTenKhachHangHopLe(original);
            if (original == filtered) return;

            var oldSelectionStart = textBox2.SelectionStart;
            textBox2.Text = filtered;
            textBox2.SelectionStart = Math.Min(oldSelectionStart, textBox2.Text.Length);
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

        private void KhoiTaoNhapGiamGiaTheoDiem()
        {
            _lblTienGiamTheoDiem.AutoSize = true;
            _lblTienGiamTheoDiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblTienGiamTheoDiem.Text = "Điểm tích lũy (1 điểm = 10.000 VNĐ)";

            _chkSuDungDiem.AutoSize = true;
            _chkSuDungDiem.Text = "Sử dụng điểm (tối đa 50% tiền hàng)";
            _chkSuDungDiem.CheckedChanged += chkSuDungDiem_CheckedChanged;

            _lblThongTinDiem.AutoSize = true;
            _lblThongTinDiem.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            _lblThongTinDiem.ForeColor = Color.FromArgb(71, 85, 105);

            panel3.Controls.Add(_lblTienGiamTheoDiem);
            panel3.Controls.Add(_chkSuDungDiem);
            panel3.Controls.Add(_lblThongTinDiem);

            CapNhatHienThiNhapGiamGiaTheoDiem();
        }

        private void frmHoaDon_Load(object? sender, EventArgs e)
        {
            ApplyTheme();
            CauHinhLuoi();
            NapThongTinNhanVien();
            NapDuLieuHoaDonDangLap();
            TaiHoaDonGanDay();
            ApplyResponsiveLayout();
        }

        private void frmHoaDon_Resize(object? sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void frmHoaDon_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _dangDongForm = true;
            _context.Dispose();
        }

        private void frmHoaDon_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _dangDongForm = true;
        }

        private void CauHinhLuoi()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.DataSource = _sanPhamBs;

            if (dataGridView2.Columns.Contains("colDonGia"))
            {
                dataGridView2.Columns["colDonGia"].DefaultCellStyle.Format = "N0";
            }

            if (dataGridView2.Columns.Contains("colThanhTien"))
            {
                dataGridView2.Columns["colThanhTien"].DefaultCellStyle.Format = "N0";
            }

            dgvHoaDonGanDay.AutoGenerateColumns = false;
            dgvHoaDonGanDay.ReadOnly = true;
            dgvHoaDonGanDay.MultiSelect = false;
            dgvHoaDonGanDay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDonGanDay.DataSource = _hoaDonBs;
        }

        private void NapThongTinNhanVien()
        {
            var tenDangNhap = AppSession.TenDangNhap?.Trim() ?? string.Empty;
            var nv = _context.NhanVien
                .AsNoTracking()
                .FirstOrDefault(x => x.TenDangNhap == tenDangNhap);

            txtNhanVien.Text = nv?.HoVaTen ?? tenDangNhap;
        }

        private void NapDuLieuHoaDonDangLap()
        {
            var draft = AppSession.HoaDonDangLap ?? new HoaDonDraftSession();

            var ds = draft.SanPhamDaChon
                .Select(x => new SanPhamHoaDonVm
                {
                    ID = x.SanPhamID,
                    TenSanPham = x.TenSanPham,
                    DonGia = x.DonGia,
                    SoLuong = x.SoLuong
                })
                .ToList();

            _sanPhamBs.DataSource = ds;
            _giamGia = draft.GiamGia;
            _hoaDonDangNapDeThanhToanLaiId = null;

            textNhapSDTKH.Text = draft.SoDienThoaiKhachHang;
            textBox1.Text = draft.GhiChu;
            textMaHĐ.Text = TaoMaHoaDonHienThi();

            TraCuuKhachHangTheoSoDienThoai(false);
            _chkSuDungDiem.Checked = draft.GiamGia > 0;
            CapNhatTongTien();
            HienThiNgayVietNam();
            CapNhatKhoaDanhSachHoaDonTheoSanPhamDangChon();
            CapNhatTrangThaiNutThanhToan();
        }

        private void LuuHoaDonDangLapVaoPhien()
        {
            var ds = (_sanPhamBs.DataSource as List<SanPhamHoaDonVm>) ?? new List<SanPhamHoaDonVm>();

            AppSession.HoaDonDangLap = new HoaDonDraftSession
            {
                SanPhamDaChon = ds.Select(x => new GioHangItemSession
                {
                    SanPhamID = x.ID,
                    TenSanPham = x.TenSanPham,
                    DonGia = x.DonGia,
                    SoLuong = x.SoLuong
                }).ToList(),
                SoDienThoaiKhachHang = ChuanHoaDienThoai(textNhapSDTKH.Text),
                GiamGia = _giamGia,
                GhiChu = textBox1.Text.Trim()
            };
        }

        private string TaoMaHoaDonHienThi()
        {
            var idTiepTheo = (_context.HoaDon.AsNoTracking().Select(x => (int?)x.ID).Max() ?? 0) + 1;
            return $"HD{idTiepTheo:D6}";
        }

        private static DateTime LayGioVietNamHienTai()
        {
            var tzId = OperatingSystem.IsWindows() ? "SE Asia Standard Time" : "Asia/Ho_Chi_Minh";
            var vnTz = TimeZoneInfo.FindSystemTimeZoneById(tzId);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnTz);
        }

        private void HienThiNgayVietNam()
        {
            var ngayVn = LayGioVietNamHienTai();
            Text = $"Lập hóa đơn - {ngayVn:HH:mm:ss dd/MM/yyyy} (VN)";
        }

        private void textNhapSDTKH_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            TraCuuKhachHangTheoSoDienThoai();
        }

        private void textNhapSDTKH_Leave(object? sender, EventArgs e)
        {
            TraCuuKhachHangTheoSoDienThoai();
        }

        private void TraCuuKhachHangTheoSoDienThoai(bool hienThongBao = true)
        {
            if (_dangDongForm || IsDisposed)
            {
                return;
            }

            var sdt = ChuanHoaDienThoai(textNhapSDTKH.Text);

            if (string.IsNullOrWhiteSpace(sdt))
            {
                _khachHangIdDangChon = null;
                _laKhachMoi = false;
                _diemTichLuyKhachDangChon = 0;
                _giamGia = 0;
                textBox2.ReadOnly = true;
                textBox2.Text = "Khách hàng vãng lai";
                CapNhatTrangThaiNutThemKh();
                CapNhatHienThiNhapGiamGiaTheoDiem();
                CapNhatTongTien();
                return;
            }

            var kh = _context.KhachHang
                .AsNoTracking()
                .FirstOrDefault(x => x.DienThoai != null && x.DienThoai.Trim() == sdt);

            if (kh != null)
            {
                _khachHangIdDangChon = kh.ID;
                _laKhachMoi = false;
                _diemTichLuyKhachDangChon = TinhDiemTichLuyTuHoaDonDaThanhToan(kh.ID);
                textBox2.ReadOnly = true;
                textBox2.Text = kh.HoVaTen;
                CapNhatTrangThaiNutThemKh();
                CapNhatHienThiNhapGiamGiaTheoDiem();
                CapNhatTongTien();
                return;
            }

            _khachHangIdDangChon = null;
            _laKhachMoi = true;
            _diemTichLuyKhachDangChon = 0;
            _giamGia = 0;
            textBox2.ReadOnly = false;
            textBox2.Text = string.Empty;
            textBox2.Focus();
            CapNhatTrangThaiNutThemKh();
            CapNhatHienThiNhapGiamGiaTheoDiem();
            CapNhatTongTien();

            if (hienThongBao)
            {
                MessageBox.Show("Không tìm thấy khách hàng theo SĐT. Vui lòng nhập tên khách hàng mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static string ChuanHoaDienThoai(string? input)
        {
            return new string((input ?? string.Empty).Where(char.IsDigit).ToArray());
        }

        private static bool CoKyTuDacBietKhongHopLeTrongTen(string input)
        {
            return input.Any(c => ":!@#$%^&".Contains(c));
        }

        private static string LocTenKhachHangHopLe(string input)
        {
            return new string((input ?? string.Empty).Where(c => !":!@#$%^&".Contains(c)).ToArray());
        }

        private void btnThemSP_Click(object? sender, EventArgs e)
        {
            LuuHoaDonDangLapVaoPhien();
            using var frm = new frmBanHang(true);
            var ketQua = frm.ShowDialog(this);
            if (ketQua == DialogResult.OK)
            {
                NapDuLieuHoaDonDangLap();
            }
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            LuuHoaDon(daThanhToan: false);
        }

        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            if (_hoaDonDangNapDeThanhToanLaiId.HasValue)
            {
                ThanhToanLaiHoaDonDaLuu(_hoaDonDangNapDeThanhToanLaiId.Value);
                return;
            }

            if (_hoaDonChuaThanhToanDangChonId.HasValue && !CoSanPhamDangChon())
            {
                NapHoaDonChuaThanhToanLenKhungSanPham(_hoaDonChuaThanhToanDangChonId.Value);
                return;
            }

            LuuHoaDon(daThanhToan: true);
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            AppSession.HoaDonDangLap = new HoaDonDraftSession();
            _hoaDonDangNapDeThanhToanLaiId = null;
            NapDuLieuHoaDonDangLap();
        }

        private void LuuHoaDon(bool daThanhToan)
        {
            var dsSanPham = (_sanPhamBs.DataSource as List<SanPhamHoaDonVm>) ?? new List<SanPhamHoaDonVm>();
            if (dsSanPham.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất 1 sản phẩm vào hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nhanVienId = LayNhanVienDangNhapId();
                if (nhanVienId <= 0)
                {
                    MessageBox.Show("Không xác định được nhân viên đang đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var khachHangId = LayHoacTaoKhachHangId();
                if (khachHangId <= 0)
                {
                    return;
                }

                var tamTinh = dsSanPham.Sum(x => x.ThanhTien);

                using var trans = _context.Database.BeginTransaction();

                var kh = _context.KhachHang.FirstOrDefault(x => x.ID == khachHangId);
                if (kh == null)
                {
                    throw new InvalidOperationException("Không tìm thấy khách hàng để lập hóa đơn.");
                }

                var diemHienTai = TinhDiemTichLuyTuHoaDonDaThanhToan(khachHangId);
                kh.DiemTichLuy = diemHienTai;

                var dangChonDungDiem = _chkSuDungDiem.Visible && _chkSuDungDiem.Checked;
                var soTienGiam = dangChonDungDiem
                    ? TinhTienGiamToiDaTheoDiem(tamTinh, diemHienTai)
                    : 0L;
                var diemSuDung = TyLeQuyDoiDiemRaTien > 0
                    ? (int)Math.Clamp(soTienGiam / TyLeQuyDoiDiemRaTien, 0, int.MaxValue)
                    : 0;
                _giamGia = soTienGiam;

                if (daThanhToan && diemSuDung > diemHienTai)
                {
                    throw new InvalidOperationException("Điểm tích lũy của khách hàng không đủ để áp dụng mức giảm hiện tại.");
                }

                if (daThanhToan && diemSuDung > 0 && diemHienTai < DiemToiThieuDeSuDung)
                {
                    throw new InvalidOperationException($"Khách hàng cần có tối thiểu {DiemToiThieuDeSuDung} điểm mới được sử dụng điểm.");
                }

                var hd = new HoaDon
                {
                    NhanVienID = nhanVienId,
                    KhachHangID = khachHangId,
                    NgayLap = LayGioVietNamHienTai(),
                    GhiChuHoaDon = TaoGhiChuHoaDon(daThanhToan),
                    DiemSuDung = diemSuDung,
                    SoTienGiamDiem = soTienGiam
                };

                _context.HoaDon.Add(hd);
                _context.SaveChanges();

                var ids = dsSanPham.Select(x => x.ID).Distinct().ToList();
                var spMap = _context.SanPham
                    .Where(x => ids.Contains(x.ID))
                    .ToDictionary(x => x.ID, x => x);

                foreach (var item in dsSanPham)
                {
                    if (!spMap.TryGetValue(item.ID, out var sp))
                    {
                        throw new InvalidOperationException($"Không tìm thấy sản phẩm ID={item.ID}.");
                    }

                    if (daThanhToan)
                    {
                        if (sp.SoLuong < item.SoLuong)
                        {
                            throw new InvalidOperationException($"Sản phẩm '{sp.TenSanPham}' không đủ tồn kho.");
                        }

                        sp.SoLuong -= item.SoLuong;
                    }

                    _context.HoaDonChiTiet.Add(new HoaDonChiTiet
                    {
                        HoaDonID = hd.ID,
                        SanPhamID = item.ID,
                        TenSanPhamSnapshot = sp.TenSanPham,
                        SoLuongBan = item.SoLuong,
                        DonGiaBan = item.DonGia
                    });
                }

                _context.SaveChanges();

                if (daThanhToan)
                {
                    kh.DiemTichLuy = TinhDiemTichLuyTuHoaDonDaThanhToan(khachHangId);
                    _diemTichLuyKhachDangChon = kh.DiemTichLuy;
                    _context.SaveChanges();
                }

                trans.Commit();

                MessageBox.Show(
                    daThanhToan ? "Thanh toán hóa đơn thành công." : "Đã lưu hóa đơn (chưa thanh toán).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AppSession.HoaDonDangLap = new HoaDonDraftSession();
                NapDuLieuHoaDonDangLap();
                TaiHoaDonGanDay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int LayNhanVienDangNhapId()
        {
            var tenDangNhap = AppSession.TenDangNhap?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(tenDangNhap)) return 0;

            var nv = _context.NhanVien
                .AsNoTracking()
                .FirstOrDefault(x => x.TenDangNhap == tenDangNhap);

            return nv?.ID ?? 0;
        }

        private int LayHoacTaoKhachHangId()
        {
            var sdt = ChuanHoaDienThoai(textNhapSDTKH.Text);

            if (string.IsNullOrWhiteSpace(sdt))
            {
                var khVangLai = _context.KhachHang.FirstOrDefault(x => x.HoVaTen == "Khách hàng vãng lai" && string.IsNullOrEmpty(x.DienThoai));
                if (khVangLai != null)
                {
                    _diemTichLuyKhachDangChon = Math.Max(0, khVangLai.DiemTichLuy);
                    return khVangLai.ID;
                }

                var khMoi = new KhachHang
                {
                    HoVaTen = "Khách hàng vãng lai",
                    DienThoai = null,
                    DiaChi = null,
                    DiemTichLuy = 0
                };
                _context.KhachHang.Add(khMoi);
                _context.SaveChanges();
                _diemTichLuyKhachDangChon = 0;
                return khMoi.ID;
            }

            if (_khachHangIdDangChon.HasValue && _khachHangIdDangChon.Value > 0)
            {
                return _khachHangIdDangChon.Value;
            }

            var tenKhMoi = textBox2.Text.Trim();
            if (!_laKhachMoi || string.IsNullOrWhiteSpace(tenKhMoi))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return 0;
            }

            if (CoKyTuDacBietKhongHopLeTrongTen(tenKhMoi))
            {
                MessageBox.Show("Tên khách hàng không được chứa ký tự đặc biệt: : ! @ # $ % ^ &",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return 0;
            }

            var khTheoSdt = _context.KhachHang.FirstOrDefault(x => x.DienThoai != null && x.DienThoai.Trim() == sdt);
            if (khTheoSdt != null)
            {
                _khachHangIdDangChon = khTheoSdt.ID;
                _diemTichLuyKhachDangChon = Math.Max(0, khTheoSdt.DiemTichLuy);
                textBox2.Text = khTheoSdt.HoVaTen;
                textBox2.ReadOnly = true;
                _laKhachMoi = false;
                return khTheoSdt.ID;
            }

            var nvTheoSdt = _context.NhanVien.AsNoTracking()
                .FirstOrDefault(x => x.DienThoai != null && x.DienThoai.Trim() == sdt);
            if (nvTheoSdt != null)
            {
                MessageBox.Show("Số điện thoại này đang thuộc về nhân viên, không thể tạo khách hàng trùng SĐT.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNhapSDTKH.Focus();
                return 0;
            }

            var khachHangMoi = new KhachHang
            {
                HoVaTen = tenKhMoi,
                DienThoai = sdt,
                DiaChi = null,
                DiemTichLuy = 0
            };
            _context.KhachHang.Add(khachHangMoi);
            _context.SaveChanges();

            _khachHangIdDangChon = khachHangMoi.ID;
            _diemTichLuyKhachDangChon = 0;
            return khachHangMoi.ID;
        }

        private string TaoGhiChuHoaDon(bool daThanhToan)
        {
            return HoaDonSnapshotHelper.TaoGhiChuHoaDon(
                daThanhToan,
                textBox1.Text,
                txtNhanVien.Text,
                textBox2.Text,
                textNhapSDTKH.Text);
        }

        private static bool LaHoaDonDaThanhToan(string? ghiChuHoaDon)
        {
            return HoaDonSnapshotHelper.LaHoaDonDaThanhToan(ghiChuHoaDon);
        }

        private static string LayNoiDungGhiChuNguoiDung(string? ghiChuHoaDon)
        {
            return HoaDonSnapshotHelper.LayNoiDungGhiChuNguoiDung(ghiChuHoaDon);
        }

        private static string TaoGhiChuTheoTrangThai(string? ghiChuHoaDonHienTai, bool daThanhToan)
        {
            return HoaDonSnapshotHelper.TaoGhiChuTheoTrangThai(ghiChuHoaDonHienTai, daThanhToan);
        }

        private int TinhDiemTichLuyTuHoaDonDaThanhToan(int khachHangId)
        {
            var dsHoaDon = _context.HoaDon
                .AsNoTracking()
                .Where(x => x.KhachHangID == khachHangId)
                .Select(x => new
                {
                    x.GhiChuHoaDon,
                    x.SoTienGiamDiem,
                    TongTienHang = x.HoaDonChiTiet.Sum(ct => (long?)ct.SoLuongBan * ct.DonGiaBan) ?? 0
                })
                .ToList();

            long tongDiem = 0;

            foreach (var hd in dsHoaDon)
            {
                if (!HoaDonSnapshotHelper.LaHoaDonDaThanhToan(hd.GhiChuHoaDon))
                {
                    continue;
                }

                var soTienGiam = (long)Math.Clamp(hd.SoTienGiamDiem, 0m, (decimal)long.MaxValue);
                var tongSauGiam = Math.Max(0L, hd.TongTienHang - soTienGiam);

                var diemCongThem = MucTichDiemTheoTien > 0
                    ? tongSauGiam / MucTichDiemTheoTien
                    : 0;

                var diemDaDung = TyLeQuyDoiDiemRaTien > 0
                    ? soTienGiam / TyLeQuyDoiDiemRaTien
                    : 0;

                tongDiem += diemCongThem - diemDaDung;
            }

            return (int)Math.Clamp(tongDiem, 0L, int.MaxValue);
        }

        private void ThanhToanLaiHoaDonDaLuu(int hoaDonId)
        {
            var xacNhan = MessageBox.Show(
                $"Bạn có muốn thanh toán hóa đơn HD{hoaDonId:D6} không?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                using var trans = _context.Database.BeginTransaction();

                var hd = _context.HoaDon
                    .Include(x => x.HoaDonChiTiet)
                    .ThenInclude(ct => ct.SanPham)
                    .FirstOrDefault(x => x.ID == hoaDonId);

                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn cần thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (LaHoaDonDaThanhToan(hd.GhiChuHoaDon))
                {
                    MessageBox.Show("Hóa đơn này đã được thanh toán trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    trans.Rollback();
                    TaiHoaDonGanDay();
                    return;
                }

                var kh = hd.KhachHangID.HasValue
                    ? _context.KhachHang.FirstOrDefault(x => x.ID == hd.KhachHangID.Value)
                    : null;

                var diemHienTai = kh != null
                    ? TinhDiemTichLuyTuHoaDonDaThanhToan(kh.ID)
                    : 0;

                if (kh != null && hd.DiemSuDung > diemHienTai)
                {
                    throw new InvalidOperationException("Điểm tích lũy hiện tại không đủ để thanh toán lại hóa đơn này.");
                }

                if (kh != null && hd.DiemSuDung > 0 && diemHienTai < DiemToiThieuDeSuDung)
                {
                    throw new InvalidOperationException($"Khách hàng cần có tối thiểu {DiemToiThieuDeSuDung} điểm mới được sử dụng điểm.");
                }

                foreach (var ct in hd.HoaDonChiTiet)
                {
                    if (ct.SanPham == null)
                    {
                        throw new InvalidOperationException($"Không tìm thấy sản phẩm ID={ct.SanPhamID}.");
                    }

                    if (ct.SanPham.SoLuong < ct.SoLuongBan)
                    {
                        throw new InvalidOperationException($"Sản phẩm '{ct.SanPham.TenSanPham}' không đủ tồn kho để thanh toán lại.");
                    }
                }

                foreach (var ct in hd.HoaDonChiTiet)
                {
                    var sp = ct.SanPham ?? throw new InvalidOperationException($"Không tìm thấy sản phẩm ID={ct.SanPhamID}.");
                    sp.SoLuong -= ct.SoLuongBan;
                }

                if (kh != null)
                {
                    kh.DiemTichLuy = diemHienTai;
                }

                hd.GhiChuHoaDon = TaoGhiChuTheoTrangThai(hd.GhiChuHoaDon, daThanhToan: true);

                _context.SaveChanges();

                if (kh != null)
                {
                    kh.DiemTichLuy = TinhDiemTichLuyTuHoaDonDaThanhToan(kh.ID);
                    _context.SaveChanges();
                }

                trans.Commit();

                MessageBox.Show("Thanh toán hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _hoaDonChuaThanhToanDangChonId = null;
                _hoaDonDangNapDeThanhToanLaiId = null;
                AppSession.HoaDonDangLap = new HoaDonDraftSession();
                NapDuLieuHoaDonDangLap();
                TaiHoaDonGanDay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thanh toán hóa đơn đã lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiHoaDonGanDay()
        {
            var culture = CultureInfo.GetCultureInfo("vi-VN");

            var dsRaw = _context.HoaDon
                .AsNoTracking()
                .Include(x => x.KhachHang)
                .Include(x => x.NhanVien)
                .OrderByDescending(x => x.ID)
                .Take(50)
                .Select(x => new
                {
                    x.ID,
                    x.NgayLap,
                    x.GhiChuHoaDon,
                    x.SoTienGiamDiem,
                    TenKhachHangDb = x.KhachHang != null ? x.KhachHang.HoVaTen : null,
                    TenNhanVienDb = x.NhanVien != null ? x.NhanVien.HoVaTen : null,
                    TongTienSo = x.HoaDonChiTiet.Sum(ct => (long?)ct.SoLuongBan * ct.DonGiaBan) ?? 0
                })
                .ToList();

            var ds = dsRaw
                .Select(x =>
                {
                    var snapshot = HoaDonSnapshotHelper.LaySnapshot(x.GhiChuHoaDon);

                    var tenKhach = !string.IsNullOrWhiteSpace(snapshot?.KhachHangTen)
                        ? snapshot.KhachHangTen
                        : (!string.IsNullOrWhiteSpace(x.TenKhachHangDb) ? x.TenKhachHangDb : "Khách hàng vãng lai");

                    var tenNv = !string.IsNullOrWhiteSpace(snapshot?.NhanVienTen)
                        ? snapshot.NhanVienTen
                        : (!string.IsNullOrWhiteSpace(x.TenNhanVienDb) ? x.TenNhanVienDb : "-");

                    var trangThai = HoaDonSnapshotHelper.LaHoaDonDaThanhToan(x.GhiChuHoaDon)
                        ? TrangThaiDaThanhToan
                        : TrangThaiChuaThanhToan;

                    var soTienGiam = (long)Math.Clamp(x.SoTienGiamDiem, 0m, (decimal)long.MaxValue);
                    var tongSauGiam = Math.Max(0L, x.TongTienSo - soTienGiam);

                    return new HoaDonGanDayVm
                    {
                        ID = x.ID,
                        TenKhachHang = tenKhach,
                        NguoiLap = tenNv,
                        NgayLap = x.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                        TongTien = tongSauGiam.ToString("N0", culture) + " đ",
                        TrangThai = trangThai
                    };
                })
                .ToList();

            _hoaDonBs.DataSource = ds;
            _hoaDonChuaThanhToanDangChonId = null;
            if (!CoSanPhamDangChon())
            {
                _hoaDonDangNapDeThanhToanLaiId = null;
            }

            CapNhatKhoaDanhSachHoaDonTheoSanPhamDangChon();
            CapNhatTrangThaiNutThanhToan();
        }

        private void dgvHoaDonGanDay_SelectionChanged(object? sender, EventArgs e)
        {
            if (CoSanPhamDangChon())
            {
                _hoaDonChuaThanhToanDangChonId = null;
                CapNhatTrangThaiNutThanhToan();
                return;
            }

            if (dgvHoaDonGanDay.CurrentRow?.DataBoundItem is not HoaDonGanDayVm hd)
            {
                _hoaDonChuaThanhToanDangChonId = null;
                CapNhatTrangThaiNutThanhToan();
                return;
            }

            _hoaDonChuaThanhToanDangChonId = hd.TrangThai == TrangThaiChuaThanhToan
                ? hd.ID
                : null;

            CapNhatTrangThaiNutThanhToan();
        }

        private void dgvHoaDonGanDay_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (CoSanPhamDangChon())
            {
                MessageBox.Show("Đang có sản phẩm trong khung 'Sản phẩm đã chọn mua'. Vui lòng dọn khung này trước khi thao tác danh sách hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex < 0) return;
            if (dgvHoaDonGanDay.Columns[e.ColumnIndex].Name != "Xem") return;

            if (_hoaDonBs[e.RowIndex] is not HoaDonGanDayVm hd) return;

            using var frm = new frmChiTiet_HoaDon(hd.ID);
            frm.ShowDialog(this);
        }

        private void CapNhatTrangThaiNutThanhToan()
        {
            if (_hoaDonDangNapDeThanhToanLaiId.HasValue)
            {
                btnThanhToan.Text = $"Xác nhận thanh toán HD{_hoaDonDangNapDeThanhToanLaiId.Value:D6}";
                return;
            }

            if (_hoaDonChuaThanhToanDangChonId.HasValue && !CoSanPhamDangChon())
            {
                btnThanhToan.Text = $"Nạp & thanh toán HD{_hoaDonChuaThanhToanDangChonId.Value:D6}";
                return;
            }

            btnThanhToan.Text = "Thanh toán";
        }

        private void CapNhatTrangThaiNutThemKh()
        {
            var sdt = ChuanHoaDienThoai(textNhapSDTKH.Text);
            btnThemKh.Enabled = _laKhachMoi && !string.IsNullOrWhiteSpace(sdt);
        }

        private bool CoSanPhamDangChon()
        {
            return (_sanPhamBs.DataSource as List<SanPhamHoaDonVm>)?.Count > 0;
        }

        private void CapNhatKhoaDanhSachHoaDonTheoSanPhamDangChon()
        {
            var coSanPham = CoSanPhamDangChon();
            dgvHoaDonGanDay.Enabled = !coSanPham;

            if (coSanPham)
            {
                dgvHoaDonGanDay.ClearSelection();
                _hoaDonChuaThanhToanDangChonId = null;
            }
        }

        private void NapHoaDonChuaThanhToanLenKhungSanPham(int hoaDonId)
        {
            var hd = _context.HoaDon
                .AsNoTracking()
                .Include(x => x.KhachHang)
                .Include(x => x.HoaDonChiTiet)
                    .ThenInclude(ct => ct.SanPham)
                .FirstOrDefault(x => x.ID == hoaDonId);

            if (hd == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn cần nạp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LaHoaDonDaThanhToan(hd.GhiChuHoaDon))
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán, không thể nạp để thanh toán lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiHoaDonGanDay();
                return;
            }

            var ds = hd.HoaDonChiTiet
                .OrderBy(x => x.ID)
                .Select(x => new SanPhamHoaDonVm
                {
                    ID = x.SanPhamID ?? 0,
                    TenSanPham = !string.IsNullOrWhiteSpace(x.TenSanPhamSnapshot)
                        ? x.TenSanPhamSnapshot
                        : (x.SanPham?.TenSanPham ?? "Sản phẩm đã xóa"),
                    DonGia = x.DonGiaBan,
                    SoLuong = x.SoLuongBan
                })
                .ToList();

            _sanPhamBs.DataSource = ds;
            _giamGia = (long)Math.Clamp(hd.SoTienGiamDiem, 0m, (decimal)long.MaxValue);
            _hoaDonDangNapDeThanhToanLaiId = hoaDonId;

            var snapshot = HoaDonSnapshotHelper.LaySnapshot(hd.GhiChuHoaDon);

            _khachHangIdDangChon = hd.KhachHangID;
            _laKhachMoi = false;
            _diemTichLuyKhachDangChon = hd.KhachHangID.HasValue
                ? TinhDiemTichLuyTuHoaDonDaThanhToan(hd.KhachHangID.Value)
                : 0;
            textNhapSDTKH.Text = !string.IsNullOrWhiteSpace(snapshot?.KhachHangSoDienThoai)
                ? snapshot.KhachHangSoDienThoai
                : (hd.KhachHang?.DienThoai ?? string.Empty);
            textBox2.ReadOnly = true;
            textBox2.Text = !string.IsNullOrWhiteSpace(snapshot?.KhachHangTen)
                ? snapshot.KhachHangTen
                : (hd.KhachHang?.HoVaTen ?? "Khách hàng vãng lai");
            textBox1.Text = LayNoiDungGhiChuNguoiDung(hd.GhiChuHoaDon);
            textMaHĐ.Text = $"HD{hd.ID:D6}";
            _chkSuDungDiem.Checked = _giamGia > 0;

            CapNhatHienThiNhapGiamGiaTheoDiem();
            CapNhatTongTien();
            CapNhatKhoaDanhSachHoaDonTheoSanPhamDangChon();
            CapNhatTrangThaiNutThanhToan();
            CapNhatTrangThaiNutThemKh();

            MessageBox.Show($"Đã nạp sản phẩm của hóa đơn HD{hoaDonId:D6}. Nhấn 'Xác nhận thanh toán' để hoàn tất.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CapNhatTongTien()
        {
            var ds = (_sanPhamBs.DataSource as List<SanPhamHoaDonVm>) ?? new List<SanPhamHoaDonVm>();
            var tamTinh = ds.Sum(x => x.ThanhTien);
            _giamGia = TinhTienGiamTheoLuaChonDiem(tamTinh);

            var tong = tamTinh - _giamGia;
            lblTamTinhValue.Text = tamTinh.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            lblTongValue.Text = tong.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            CapNhatThongTinDiemVaTienGiam();
        }

        private bool CoTheNhapGiamGiaTheoDiem()
        {
            var sdt = ChuanHoaDienThoai(textNhapSDTKH.Text);
            return !_laKhachMoi
                && !string.IsNullOrWhiteSpace(sdt)
                && _khachHangIdDangChon.HasValue
                && _diemTichLuyKhachDangChon >= DiemToiThieuDeSuDung;
        }

        private long TinhTienGiamTheoLuaChonDiem(long tamTinh)
        {
            if (!CoTheNhapGiamGiaTheoDiem() || !_chkSuDungDiem.Checked || TyLeQuyDoiDiemRaTien <= 0)
            {
                return 0;
            }

            return TinhTienGiamToiDaTheoDiem(tamTinh, _diemTichLuyKhachDangChon);
        }

        private static long TinhTienGiamToiDaTheoDiem(long tamTinh, int diemHienCo)
        {
            if (tamTinh <= 0 || diemHienCo <= 0 || TyLeQuyDoiDiemRaTien <= 0)
            {
                return 0;
            }

            var toiDaTheoDiem = (long)diemHienCo * TyLeQuyDoiDiemRaTien;
            var tran50PhanTram = tamTinh / 2;
            var tienDuocGiam = Math.Min(toiDaTheoDiem, tran50PhanTram);

            // Quy về bội số quy đổi để đảm bảo không sinh lẻ điểm.
            return (tienDuocGiam / TyLeQuyDoiDiemRaTien) * TyLeQuyDoiDiemRaTien;
        }

        private void CapNhatHienThiNhapGiamGiaTheoDiem()
        {
            var hien = CoTheNhapGiamGiaTheoDiem();
            _lblTienGiamTheoDiem.Visible = hien;
            _chkSuDungDiem.Visible = hien;
            _lblThongTinDiem.Visible = hien;

            if (!hien)
            {
                _chkSuDungDiem.Checked = false;
            }

            var ds = (_sanPhamBs.DataSource as List<SanPhamHoaDonVm>) ?? new List<SanPhamHoaDonVm>();
            var tamTinh = ds.Sum(x => x.ThanhTien);
            _giamGia = TinhTienGiamTheoLuaChonDiem(tamTinh);

            CapNhatThongTinDiemVaTienGiam();
            ApplyResponsiveLayout();
        }

        private void CapNhatThongTinDiemVaTienGiam()
        {
            if (!CoTheNhapGiamGiaTheoDiem())
            {
                _lblThongTinDiem.Text = string.Empty;
                return;
            }

            var ds = (_sanPhamBs.DataSource as List<SanPhamHoaDonVm>) ?? new List<SanPhamHoaDonVm>();
            var tamTinh = ds.Sum(x => x.ThanhTien);
            var toiDa = (long)_diemTichLuyKhachDangChon * TyLeQuyDoiDiemRaTien;
            var giamToiDaTheo50 = tamTinh / 2;
            var giamToiDaThucTe = TinhTienGiamToiDaTheoDiem(tamTinh, _diemTichLuyKhachDangChon);
            var diemSeDung = TyLeQuyDoiDiemRaTien > 0
                ? (int)Math.Clamp(giamToiDaThucTe / TyLeQuyDoiDiemRaTien, 0, int.MaxValue)
                : 0;
            var toiDaText = toiDa.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
            var giam50Text = giamToiDaTheo50.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
            var giamThucTeText = giamToiDaThucTe.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
            var trangThai = _chkSuDungDiem.Checked ? "Đang chọn dùng toàn bộ điểm" : "Đang tích lũy tiếp (chưa dùng điểm)";

            _lblThongTinDiem.Text = $"Điểm hiện có: {_diemTichLuyKhachDangChon} | Theo điểm: {toiDaText} VNĐ | Trần 50%: {giam50Text} VNĐ | Sẽ giảm: {giamThucTeText} VNĐ ({diemSeDung} điểm) | {trangThai}";
        }

        // ...giữ nguyên phần giao diện responsive/theme...
        private void ApplyTheme()
        {
            BackColor = Color.FromArgb(243, 246, 251);

            foreach (var panel in new[] { panel1, panel2, panel3, panel4, panelSanPhamChon })
            {
                panel.BackColor = Color.White;
            }

            btnThanhToan.BackColor = Color.FromArgb(37, 99, 235);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.FlatAppearance.BorderSize = 0;

            btnLuu.BackColor = Color.FromArgb(245, 158, 11);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatAppearance.BorderSize = 0;

            btnHuy.BackColor = Color.White;
            btnHuy.ForeColor = Color.FromArgb(51, 65, 85);
            btnHuy.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);

            btnThemSP.FlatAppearance.BorderColor = Color.FromArgb(147, 197, 253);
            btnThemSP.ForeColor = Color.FromArgb(37, 99, 235);
        }

        private void ApplyResponsiveLayout()
        {
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0) return;

            const int pad = 14;
            const int gap = 12;

            var contentWidth = ClientSize.Width - (pad * 2);
            var leftWidth = Math.Max(560, (int)(contentWidth * 0.54));
            var rightWidth = Math.Max(440, contentWidth - leftWidth - gap);

            if (leftWidth + rightWidth + gap > contentWidth)
            {
                leftWidth = Math.Max(500, contentWidth - rightWidth - gap);
            }

            var topHeight = Math.Max(240, (int)(ClientSize.Height * 0.38));
            var actionHeight = 68;
            var summaryHeight = 172;

            panel1.SetBounds(pad, pad, leftWidth, topHeight);

            var leftBottomY = panel1.Bottom + gap;
            var leftBottomHeight = Math.Max(200, ClientSize.Height - leftBottomY - pad);
            panel2.SetBounds(pad, leftBottomY, leftWidth, leftBottomHeight);

            var rightX = panel1.Right + gap;
            var rightTopHeight = Math.Max(220, ClientSize.Height - pad - summaryHeight - actionHeight - gap * 2 - pad);
            panelSanPhamChon.SetBounds(rightX, pad, rightWidth, rightTopHeight);
            panel3.SetBounds(rightX, panelSanPhamChon.Bottom + gap, rightWidth, summaryHeight);
            panel4.SetBounds(rightX, panel3.Bottom + gap, rightWidth, actionHeight);

            const int inPad = 16;
            var half = Math.Max(230, (panel1.ClientSize.Width - inPad * 3) / 3);
            var rightInputWidth = panel1.ClientSize.Width - inPad * 2 - half;

            label3.Location = new Point(inPad, 10);
            textMaHĐ.SetBounds(inPad, 38, half, 31);

            label1.Location = new Point(inPad + half + inPad, 10);
            textNhapSDTKH.SetBounds(inPad + half + inPad, 38, rightInputWidth, 31);

            label5.Location = new Point(inPad, 83);
            txtNhanVien.SetBounds(inPad, 111, half, 31);

            label6.Location = new Point(inPad + half + inPad, 83);
            var btnThemKhWidth = 170;
            var btnGap = 8;
            var textKhWidth = Math.Max(160, rightInputWidth - btnThemKhWidth - btnGap);
            textBox2.SetBounds(inPad + half + inPad, 111, textKhWidth, 31);
            btnThemKh.SetBounds(textBox2.Right + btnGap, 110, btnThemKhWidth, 34);

            label7.Location = new Point(inPad, 159);
            textBox1.SetBounds(inPad, 187, panel1.ClientSize.Width - inPad * 2, panel1.ClientSize.Height - 187 - inPad);

            // panel2 nội dung
            lblListTitle.Location = new Point(16, 12);
            dgvHoaDonGanDay.SetBounds(16, 46, panel2.ClientSize.Width - 32, panel2.ClientSize.Height - 58);

            // panel phải nội dung
            lblSanPhamChon.Location = new Point(14, 12);
            btnThemSP.SetBounds(panelSanPhamChon.ClientSize.Width - 14 - 146, 9, 146, 35);
            dataGridView2.SetBounds(14, 50, panelSanPhamChon.ClientSize.Width - 28, panelSanPhamChon.ClientSize.Height - 64);

            lblTamTinhLabel.Location = new Point(14, 12);
            lblTamTinhValue.Location = new Point(panel3.ClientSize.Width - lblTamTinhValue.Width - 14, 10);

            var coNhapGiamGia = _chkSuDungDiem.Visible;
            if (coNhapGiamGia)
            {
                _lblTienGiamTheoDiem.Location = new Point(14, 44);
                var chkX = Math.Max(14, panel3.ClientSize.Width - 320);
                _chkSuDungDiem.Location = new Point(chkX, 45);
                _lblThongTinDiem.MaximumSize = new Size(panel3.ClientSize.Width - 28, 0);
                _lblThongTinDiem.Location = new Point(14, 76);

                var tongY = _lblThongTinDiem.Bottom + 8;
                lblTongLabel.Location = new Point(14, tongY);
                lblTongValue.Location = new Point(panel3.ClientSize.Width - lblTongValue.Width - 14, tongY - 3);
            }
            else
            {
                _lblThongTinDiem.MaximumSize = Size.Empty;
                lblTongLabel.Location = new Point(14, 72);
                lblTongValue.Location = new Point(panel3.ClientSize.Width - lblTongValue.Width - 14, 69);
            }

            var btnY = 14;
            var actionBtnGap = 8;
            var btnW1 = 110;
            var btnW2 = Math.Max(180, (panel4.ClientSize.Width - btnW1 - actionBtnGap * 3) / 3);
            var btnW3 = panel4.ClientSize.Width - btnW1 - btnW2 - actionBtnGap * 4;

            btnHuy.SetBounds(14, btnY, btnW1, 38);
            btnLuu.SetBounds(btnHuy.Right + actionBtnGap, btnY, btnW2, 38);
            btnThanhToan.SetBounds(btnLuu.Right + actionBtnGap, btnY, btnW3, 38);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_laKhachMoi)
            {
                MessageBox.Show("Nút 'Thêm Khách Hàng' chỉ dùng khi là khách hàng mới (chưa có trong dữ liệu).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sdt = ChuanHoaDienThoai(textNhapSDTKH.Text);
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNhapSDTKH.Focus();
                return;
            }

            using var frm = new frmKhachHang(AppSession.VaiTro);
            frm.ShowDialog(this);

            TraCuuKhachHangTheoSoDienThoai(false);

            if (_laKhachMoi)
            {
                MessageBox.Show("Bạn chưa thêm khách hàng có SĐT này. Có thể tiếp tục nhập tên khách mới trực tiếp tại hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
