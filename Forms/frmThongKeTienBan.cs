using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmThongKeTienBan : Form
    {
        private readonly QLBHDbContext _context = new QLBHDbContext();
        private readonly CultureInfo _viVn = CultureInfo.GetCultureInfo("vi-VN");
        private bool _uiBuilt;

        private readonly Panel _panelFilter = new Panel();
        private readonly FlowLayoutPanel _flpFilter = new FlowLayoutPanel();
        private readonly Label _lblNgay = new Label();
        private readonly Label _lblTuNgay = new Label();
        private readonly DateTimePicker _dtpTuNgay = new DateTimePicker();
        private readonly Label _lblDenNgay = new Label();
        private readonly DateTimePicker _dtpDenNgay = new DateTimePicker();
        private readonly Button _btnLoc = new Button();

        private readonly Panel _panelSummary = new Panel();
        private readonly FlowLayoutPanel _flpSummary = new FlowLayoutPanel();
        private readonly Label _lblTongHoaDon = new Label();
        private readonly Label _lblTongSoLuong = new Label();
        private readonly Label _lblTongTien = new Label();

        private readonly DataGridView _dgv = new DataGridView();

        private static bool IsDesignTimeMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public frmThongKeTienBan()
        {
            InitializeComponent();
            EnsureUiBuilt();

            Text = "Thống kê tiền bán";
            BackColor = Color.FromArgb(243, 246, 251);
            MinimumSize = new Size(900, 560);

            Load += frmThongKeTienBan_Load;
            _btnLoc.Click += (_, _) => LoadThongKeTheoNgay();
            _dtpTuNgay.ValueChanged += (_, _) => LoadThongKeTheoNgay();
            _dtpDenNgay.ValueChanged += (_, _) => LoadThongKeTheoNgay();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void EnsureUiBuilt()
        {
            if (_uiBuilt) return;
            BuildUi();

            if (IsDesignTimeMode)
            {
                _lblTongHoaDon.Text = "Hóa đơn đã thanh toán: 0";
                _lblTongSoLuong.Text = "Tổng SL bán: 0";
                _lblTongTien.Text = "Tổng tiền bán: 0 đ";

                if (_dgv.Rows.Count == 0)
                {
                    _dgv.Rows.Add(1, "SP001", "Đồng hồ mẫu", "Casio", "0", "0 đ");
                }
            }

            _uiBuilt = true;
        }

        private void frmThongKeTienBan_Load(object? sender, EventArgs e)
        {
            ApplyResponsiveLayout();
            if (IsDesignTimeMode) return;
            LoadThongKeTheoNgay();
        }

        private void BuildUi()
        {
            _panelFilter.Dock = DockStyle.Top;
            _panelFilter.Height = 64;
            _panelFilter.Padding = new Padding(16, 12, 16, 12);
            _panelFilter.BackColor = Color.White;

            _flpFilter.Dock = DockStyle.Left;
            _flpFilter.AutoSize = true;
            _flpFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _flpFilter.WrapContents = false;
            _flpFilter.FlowDirection = FlowDirection.LeftToRight;
            _flpFilter.Margin = new Padding(0);

            _lblNgay.AutoSize = true;
            _lblNgay.Text = "Khoảng ngày:";
            _lblNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblNgay.Margin = new Padding(0, 8, 8, 0);

            _lblTuNgay.AutoSize = true;
            _lblTuNgay.Text = "Từ";
            _lblTuNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblTuNgay.Margin = new Padding(0, 8, 6, 0);

            _dtpTuNgay.Format = DateTimePickerFormat.Custom;
            _dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            _dtpTuNgay.Size = new Size(140, 31);
            _dtpTuNgay.Margin = new Padding(0, 2, 12, 0);

            _lblDenNgay.AutoSize = true;
            _lblDenNgay.Text = "Đến";
            _lblDenNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblDenNgay.Margin = new Padding(0, 8, 6, 0);

            _dtpDenNgay.Format = DateTimePickerFormat.Custom;
            _dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            _dtpDenNgay.Size = new Size(140, 31);
            _dtpDenNgay.Margin = new Padding(0, 2, 12, 0);

            _btnLoc.Text = "Lọc";
            _btnLoc.BackColor = Color.FromArgb(37, 99, 235);
            _btnLoc.ForeColor = Color.White;
            _btnLoc.FlatStyle = FlatStyle.Flat;
            _btnLoc.FlatAppearance.BorderSize = 0;
            _btnLoc.Size = new Size(92, 34);
            _btnLoc.Margin = new Padding(0, 0, 0, 0);

            _flpFilter.Controls.Add(_lblNgay);
            _flpFilter.Controls.Add(_lblTuNgay);
            _flpFilter.Controls.Add(_dtpTuNgay);
            _flpFilter.Controls.Add(_lblDenNgay);
            _flpFilter.Controls.Add(_dtpDenNgay);
            _flpFilter.Controls.Add(_btnLoc);
            _panelFilter.Controls.Add(_flpFilter);

            _panelSummary.Dock = DockStyle.Top;
            _panelSummary.Height = 48;
            _panelSummary.Padding = new Padding(16, 10, 16, 8);
            _panelSummary.BackColor = Color.FromArgb(243, 246, 251);

            _flpSummary.Dock = DockStyle.Fill;
            _flpSummary.WrapContents = false;
            _flpSummary.FlowDirection = FlowDirection.LeftToRight;
            _flpSummary.AutoScroll = true;
            _flpSummary.Margin = new Padding(0);

            _lblTongHoaDon.AutoSize = true;
            _lblTongSoLuong.AutoSize = true;
            _lblTongTien.AutoSize = true;

            _lblTongHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblTongSoLuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _lblTongTien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            _lblTongHoaDon.ForeColor = Color.FromArgb(30, 64, 175);
            _lblTongSoLuong.ForeColor = Color.FromArgb(5, 150, 105);
            _lblTongTien.ForeColor = Color.FromArgb(220, 53, 69);

            _lblTongHoaDon.Margin = new Padding(0, 2, 24, 0);
            _lblTongSoLuong.Margin = new Padding(0, 2, 24, 0);
            _lblTongTien.Margin = new Padding(0, 2, 0, 0);

            _flpSummary.Controls.Add(_lblTongHoaDon);
            _flpSummary.Controls.Add(_lblTongSoLuong);
            _flpSummary.Controls.Add(_lblTongTien);
            _panelSummary.Controls.Add(_flpSummary);

            _dgv.Dock = DockStyle.Fill;
            _dgv.BackgroundColor = Color.White;
            _dgv.AllowUserToAddRows = false;
            _dgv.AllowUserToDeleteRows = false;
            _dgv.ReadOnly = true;
            _dgv.RowHeadersVisible = false;
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgv.MultiSelect = false;
            _dgv.EnableHeadersVisualStyles = false;
            _dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(219, 234, 254);
            _dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 64, 175);
            _dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            _dgv.Columns.Add("cStt", "STT");
            _dgv.Columns.Add("cMaSp", "Mã SP");
            _dgv.Columns.Add("cTenSp", "Tên sản phẩm");
            _dgv.Columns.Add("cThuongHieu", "Thương hiệu");
            _dgv.Columns.Add("cSoLuong", "SL bán");
            _dgv.Columns.Add("cTongTien", "Tổng tiền bán");

            _dgv.Columns[0].FillWeight = 8;
            _dgv.Columns[1].FillWeight = 14;
            _dgv.Columns[2].FillWeight = 28;
            _dgv.Columns[3].FillWeight = 18;
            _dgv.Columns[4].FillWeight = 12;
            _dgv.Columns[5].FillWeight = 20;

            _dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Controls.Add(_dgv);
            Controls.Add(_panelSummary);
            Controls.Add(_panelFilter);
        }

        private void ApplyResponsiveLayout()
        {
            var small = ClientSize.Width < 980;
            _btnLoc.Width = small ? 78 : 92;
            _dtpTuNgay.Width = small ? 125 : 140;
            _dtpDenNgay.Width = small ? 125 : 140;
        }

        private void LoadThongKeTheoNgay()
        {
            try
            {
                var ngayA = _dtpTuNgay.Value.Date;
                var ngayB = _dtpDenNgay.Value.Date;
                var tuNgay = ngayA <= ngayB ? ngayA : ngayB;
                var denNgay = (ngayA <= ngayB ? ngayB : ngayA).AddDays(1);

                var hoaDonNgay = _context.HoaDon
                    .AsNoTracking()
                    .Where(h => h.NgayLap >= tuNgay && h.NgayLap < denNgay)
                    .Select(h => new
                    {
                        h.ID,
                        h.GhiChuHoaDon,
                        h.SoTienGiamDiem
                    })
                    .ToList();

                var hoaDonDaThanhToan = hoaDonNgay
                    .Where(h => HoaDonSnapshotHelper.LaHoaDonDaThanhToan(h.GhiChuHoaDon))
                    .ToList();

                var hoaDonIds = hoaDonDaThanhToan.Select(h => h.ID).ToList();

                if (hoaDonIds.Count == 0)
                {
                    _dgv.Rows.Clear();
                    _lblTongHoaDon.Text = "Hóa đơn đã thanh toán: 0";
                    _lblTongSoLuong.Text = "Tổng SL bán: 0";
                    _lblTongTien.Text = "Tổng tiền bán: 0 đ";
                    return;
                }

                var chiTietDaThanhToan = _context.HoaDonChiTiet
                    .AsNoTracking()
                    .Where(ct => hoaDonIds.Contains(ct.HoaDonID))
                    .Select(ct => new
                    {
                        ct.HoaDonID,
                        ct.SanPhamID,
                        ct.TenSanPhamSnapshot,
                        ct.SoLuongBan,
                        ct.DonGiaBan
                    })
                    .ToList();

                var productIds = chiTietDaThanhToan
                    .Where(x => x.SanPhamID.HasValue)
                    .Select(x => x.SanPhamID!.Value)
                    .Distinct()
                    .ToList();

                var productInfo =
                    (from sp in _context.SanPham.AsNoTracking()
                     join th in _context.ThuongHieu.AsNoTracking()
                        on sp.ThuongHieuID equals th.ID into thg
                     from th in thg.DefaultIfEmpty()
                     where productIds.Contains(sp.ID)
                     select new
                     {
                         sp.ID,
                         sp.TenSanPham,
                         TenThuongHieu = th != null ? th.TenThuongHieu : "(Không rõ)"
                     })
                    .ToDictionary(x => x.ID, x => x);

                var ds =
                    (from ct in chiTietDaThanhToan
                     group ct by ct.SanPhamID
                    into g
                     let tongSoLuongTheoSanPham = g.Sum(x => x.SoLuongBan)
                     select new
                     {
                         SanPhamID = g.Key,
                         TenSp = g.Key.HasValue && productInfo.ContainsKey(g.Key.Value)
                                     ? productInfo[g.Key.Value].TenSanPham
                            : g.Select(x => x.TenSanPhamSnapshot).FirstOrDefault() ?? "(Sản phẩm đã xóa)",
                         TenThuongHieu = g.Key.HasValue && productInfo.ContainsKey(g.Key.Value)
                                     ? productInfo[g.Key.Value].TenThuongHieu
                            : "(Không rõ)",
                         SoLuong = tongSoLuongTheoSanPham,
                         TongTien = g.Sum(x => (decimal)x.SoLuongBan * x.DonGiaBan)
                     })
                    .OrderByDescending(x => x.SoLuong)
                    .ThenByDescending(x => x.TongTien)
                    .ToList();

                _dgv.Rows.Clear();
                for (var i = 0; i < ds.Count; i++)
                {
                    var r = ds[i];
                    _dgv.Rows.Add(
                        i + 1,
                        r.SanPhamID.HasValue ? $"SP{r.SanPhamID.Value:D3}" : "N/A",
                        r.TenSp,
                        r.TenThuongHieu,
                        r.SoLuong.ToString("N0", _viVn),
                        r.TongTien.ToString("N0", _viVn) + " đ");
                }

                var tongSoLuongBan = ds.Sum(x => x.SoLuong);
                var tongTienTheoHoaDon = chiTietDaThanhToan
                    .GroupBy(x => x.HoaDonID)
                    .ToDictionary(g => g.Key, g => g.Sum(x => (decimal)x.SoLuongBan * x.DonGiaBan));

                var tongTienBan = Math.Max(0m, hoaDonDaThanhToan.Sum(h =>
                {
                    var tongCt = tongTienTheoHoaDon.TryGetValue(h.ID, out var tong) ? tong : 0m;
                    return tongCt - h.SoTienGiamDiem;
                }));

                _lblTongHoaDon.Text = $"Hóa đơn đã thanh toán: {hoaDonDaThanhToan.Count:N0}";
                _lblTongSoLuong.Text = $"Tổng SL bán: {tongSoLuongBan:N0}";
                _lblTongTien.Text = $"Tổng tiền bán: {tongTienBan.ToString("N0", _viVn)} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // frmThongKeTienBan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 655);
            Name = "frmThongKeTienBan";
            ResumeLayout(false);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}
