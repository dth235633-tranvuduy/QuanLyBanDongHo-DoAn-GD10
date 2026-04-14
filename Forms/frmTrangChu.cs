using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmTrangChu : Form
    {
        private sealed class HoaDonThanhToanHomNayVm
        {
            public int ID { get; set; }
            public string MaHoaDon { get; set; } = string.Empty;
            public string GioLap { get; set; } = string.Empty;
            public string KhachHang { get; set; } = string.Empty;
            public string NhanVien { get; set; } = string.Empty;
            public string TongTien { get; set; } = string.Empty;
        }

        private const string TrangThaiDaThanhToan = "Đã thanh toán";
        private const int DashboardRefreshIntervalMs = 5000;
        private readonly BindingSource _hoaDonThanhToanHomNayBs = new();
        private readonly System.Windows.Forms.Timer _dashboardRefreshTimer = new();
        private Form? currentFormChild;
        private bool _dangLamMoiDashboard;
        private object lblOverviewDate;

        public frmTrangChu()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            MinimumSize = new System.Drawing.Size(1280, 720);

            Load += FrmTrangChu_Load;
            Resize += FrmTrangChu_Resize;
            FormClosed += FrmTrangChu_FormClosed;

            // quick-access
            btnTaoHoaDon.Click += BtnTaoHoaDon_Click;
            btnQuanLyKho.Click += BtnQuanLyKho_Click;
            btnKhachHang.Click += BtnKhachHang_Click;

            // dashboard invoices
            CauHinhBangHoaDonThanhToanHomNay();
            dgvPaidInvoicesToday.CellDoubleClick += DgvPaidInvoicesToday_CellDoubleClick;

            // menu còn thiếu event ở Designer
            mnuSanPham.Click += mnuSanPham_Click;
            bánHàngToolStripMenuItem.Click += banHangToolStripMenuItem_Click;
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;
            mnuDangXuat.Click += mnuDangXuat_Click;

            mnuHuongDanSuDung.Click += mnuHuongDanSuDung_Click;
            nhậtKýHoạtĐộngToolStripMenuItem.Click += NhatKyHoatDongToolStripMenuItem_Click;

            _dashboardRefreshTimer.Interval = DashboardRefreshIntervalMs;
            _dashboardRefreshTimer.Tick += DashboardRefreshTimer_Tick;
        }

        private void FrmTrangChu_Load(object? sender, EventArgs e)
        {
            var gioVn = LayGioVietNamHienTai();
            lblAppName.Text = "DUY WATCHES";
            Text = $"Trang chủ - {AppSession.TenDangNhap}";
            lblHeaderSubtitle.Text = $"Xin chào {AppSession.TenDangNhap} - {LayTenVaiTroHienThi()}";
            lblOverviewTitle.Text = $"Tổng quan hệ thống - {gioVn:dd/MM/yyyy}";
            pnlDashboard.AutoScroll = true;

            TaiDuLieuTongQuan();
            KiemSoatMenuTheoQuyen();
            HienDashboard();
            ApplyResponsiveLayout();

            _dashboardRefreshTimer.Start();
        }

        private static DateTime LayGioVietNamHienTai()
        {
            var tzId = OperatingSystem.IsWindows() ? "SE Asia Standard Time" : "Asia/Ho_Chi_Minh";
            var vnTz = TimeZoneInfo.FindSystemTimeZoneById(tzId);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnTz);
        }

        private void FrmTrangChu_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _dashboardRefreshTimer.Stop();
            _dashboardRefreshTimer.Dispose();
        }

        private void FrmTrangChu_Resize(object? sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (IsDisposed) return;

            // Header/menu lớn hơn để cân đối màn hình lớn
            pnlHeader.Height = 108;
            lblAppName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblAppName.Location = new System.Drawing.Point(24, 10);
            lblHeaderSubtitle.Location = new System.Drawing.Point(28, 70);

            menuStrip.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            menuStrip.Padding = new Padding(8, 4, 8, 4);

            var headerPadding = 24;
            var appBrandWidth = Math.Max(lblAppName.Right, lblHeaderSubtitle.Right) + 24;
            var menuWidth = Math.Clamp(pnlHeader.ClientSize.Width - appBrandWidth - headerPadding, 500, 860);

            menuStrip.Dock = DockStyle.None;
            menuStrip.AutoSize = false;
            menuStrip.Size = new System.Drawing.Size(menuWidth, 54);
            menuStrip.Location = new System.Drawing.Point(
                Math.Max(appBrandWidth, pnlHeader.ClientSize.Width - menuWidth - headerPadding),
                24);

            var dashboardPadding = 30;
            var contentWidth = Math.Max(560, pnlDashboard.ClientSize.Width - dashboardPadding * 2);

            flpSummary.Left = dashboardPadding;
            flpSummary.Width = contentWidth;

            const int cardGap = 12;
            var cardWidth = Math.Max(180, (contentWidth - cardGap * 3) / 4);
            cardDoanhThu.Width = cardWidth;
            cardDonHang.Width = cardWidth;
            cardSanPham.Width = cardWidth;
            cardKhachHang.Width = cardWidth;

            lblQuickAccess.Left = dashboardPadding;
            lblQuickAccess.Top = flpSummary.Bottom + 24;

            flpQuickAccess.Left = dashboardPadding;
            flpQuickAccess.Top = lblQuickAccess.Bottom + 10;
            flpQuickAccess.Width = contentWidth;

            var quickButtonWidth = Math.Max(180, (contentWidth - cardGap * 2) / 3);
            btnTaoHoaDon.Width = quickButtonWidth;
            btnQuanLyKho.Width = quickButtonWidth;
            btnKhachHang.Width = quickButtonWidth;

            var paidTop = flpQuickAccess.Bottom + 22;
            pnlPaidInvoices.Left = dashboardPadding;
            pnlPaidInvoices.Top = paidTop;
            pnlPaidInvoices.Width = contentWidth;
            pnlPaidInvoices.Height = Math.Max(220, pnlDashboard.ClientSize.Height - paidTop - 24);
        }

        private void CauHinhBangHoaDonThanhToanHomNay()
        {
            dgvPaidInvoicesToday.AutoGenerateColumns = false;
            dgvPaidInvoicesToday.ReadOnly = true;
            dgvPaidInvoicesToday.MultiSelect = false;
            dgvPaidInvoicesToday.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaidInvoicesToday.Columns.Clear();

            dgvPaidInvoicesToday.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaHoaDonHomNay",
                HeaderText = "Mã HĐ",
                DataPropertyName = nameof(HoaDonThanhToanHomNayVm.MaHoaDon),
                FillWeight = 18
            });

            dgvPaidInvoicesToday.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGioLapHomNay",
                HeaderText = "Giờ lập",
                DataPropertyName = nameof(HoaDonThanhToanHomNayVm.GioLap),
                FillWeight = 16
            });

            dgvPaidInvoicesToday.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colKhachHangHomNay",
                HeaderText = "Khách hàng",
                DataPropertyName = nameof(HoaDonThanhToanHomNayVm.KhachHang),
                FillWeight = 24
            });

            dgvPaidInvoicesToday.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNhanVienHomNay",
                HeaderText = "Nhân viên",
                DataPropertyName = nameof(HoaDonThanhToanHomNayVm.NhanVien),
                FillWeight = 22
            });

            dgvPaidInvoicesToday.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTongTienHomNay",
                HeaderText = "Tổng tiền",
                DataPropertyName = nameof(HoaDonThanhToanHomNayVm.TongTien),
                FillWeight = 20,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvPaidInvoicesToday.DataSource = _hoaDonThanhToanHomNayBs;
        }

        private void KiemSoatMenuTheoQuyen()
        {
            var laAdmin = AppSession.VaiTro == VaiTroNguoiDung.Admin;
            var laQuanLy = AppSession.VaiTro == VaiTroNguoiDung.QuanLyCuaHang;
            var laBanHang = AppSession.VaiTro == VaiTroNguoiDung.NhanVienBanHang;

            mnuNhanVien.Enabled = laAdmin;
            nhậtKýHoạtĐộngToolStripMenuItem.Enabled = laAdmin;
            nhậtKýHoạtĐộngToolStripMenuItem.Visible = laAdmin;

            // Nhân viên bán hàng chỉ truy cập: Hóa đơn, Bán hàng, Khách hàng, Thương hiệu, Loại đồng hồ.
            if (laBanHang)
            {
                thôngTiềnBánToolStripMenuItem.Enabled = false;
            }

            if (laQuanLy)
            {
                btnQuanLyKho.Enabled = true;
            }
        }

        private static string LayTenVaiTroHienThi()
        {
            return AppSession.VaiTro switch
            {
                VaiTroNguoiDung.Admin => "Admin",
                VaiTroNguoiDung.QuanLyCuaHang => "Nhân viên quản lý cửa hàng",
                VaiTroNguoiDung.NhanVienBanHang => "Nhân viên bán hàng",
                _ => "Nhân viên"
            };
        }

        private void TaiDuLieuTongQuan()
        {
            if (_dangLamMoiDashboard) return;

            _dangLamMoiDashboard = true;
            try
            {
                using var context = new QLBHDbContext();

                var tuNgay = LayGioVietNamHienTai().Date;
                var denNgay = tuNgay.AddDays(1);

                var tongQuanHoaDonThanhToanHomNay = TaiDanhSachHoaDonThanhToanHomNay(context, tuNgay, denNgay);

                var sanPhamSapHet = context.SanPham
                    .AsNoTracking()
                    .Count(sp => sp.SoLuong <= 5);

                var hoaDonKhachHang = context.HoaDon
                    .AsNoTracking()
                    .Where(hd => hd.KhachHangID.HasValue)
                    .Select(hd => new
                    {
                        hd.KhachHangID,
                        hd.NgayLap,
                        hd.GhiChuHoaDon
                    })
                    .ToList()
                    .Where(hd => HoaDonSnapshotHelper.LaHoaDonDaThanhToan(hd.GhiChuHoaDon))
                    .ToList();

                var khachMoiHomNay = hoaDonKhachHang
                    .GroupBy(hd => hd.KhachHangID!.Value)
                    .Select(g => g.Min(x => x.NgayLap))
                    .Count(firstDate => firstDate >= tuNgay && firstDate < denNgay);

                lblCard1Value.Text = tongQuanHoaDonThanhToanHomNay.DoanhThu.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + "đ";
                lblCard2Value.Text = tongQuanHoaDonThanhToanHomNay.SoDonHang.ToString();
                lblCard3Value.Text = sanPhamSapHet.ToString();
                lblCard4Value.Text = khachMoiHomNay.ToString();
            }
            catch
            {
                lblCard1Value.Text = "0đ";
                lblCard2Value.Text = "0";
                lblCard3Value.Text = "0";
                lblCard4Value.Text = "0";
                lblPaidInvoicesTitle.Text = "Hóa đơn đã thanh toán hôm nay (0)";
                _hoaDonThanhToanHomNayBs.DataSource = new System.Collections.Generic.List<HoaDonThanhToanHomNayVm>();
            }
            finally
            {
                _dangLamMoiDashboard = false;
            }
        }

        private void DashboardRefreshTimer_Tick(object? sender, EventArgs e)
        {
            if (!pnlDashboard.Visible) return;
            TaiDuLieuTongQuan();
        }

        private (int SoDonHang, long DoanhThu) TaiDanhSachHoaDonThanhToanHomNay(QLBHDbContext context, DateTime tuNgay, DateTime denNgay)
        {
            var culture = CultureInfo.GetCultureInfo("vi-VN");

            var dsRaw = context.HoaDon
                .AsNoTracking()
                .Include(x => x.KhachHang)
                .Include(x => x.NhanVien)
                .Where(x => x.NgayLap >= tuNgay && x.NgayLap < denNgay)
                .OrderByDescending(x => x.NgayLap)
                .Select(x => new
                {
                    x.ID,
                    x.NgayLap,
                    x.GhiChuHoaDon,
                    TenKhachHangDb = x.KhachHang != null ? x.KhachHang.HoVaTen : null,
                    TenNhanVienDb = x.NhanVien != null ? x.NhanVien.HoVaTen : null,
                    TongTienSo = x.HoaDonChiTiet.Sum(ct => (long?)ct.SoLuongBan * ct.DonGiaBan) ?? 0
                })
                .ToList();

            var dsHoaDonDaThanhToan = dsRaw
                .Where(x => HoaDonSnapshotHelper.LaHoaDonDaThanhToan(x.GhiChuHoaDon))
                .ToList();

            var ds = dsHoaDonDaThanhToan
                .Select(x =>
                {
                    var snapshot = HoaDonSnapshotHelper.LaySnapshot(x.GhiChuHoaDon);

                    return new HoaDonThanhToanHomNayVm
                    {
                        ID = x.ID,
                        MaHoaDon = $"HD{x.ID:D6}",
                        GioLap = x.NgayLap.ToString("HH:mm"),
                        KhachHang = !string.IsNullOrWhiteSpace(snapshot?.KhachHangTen)
                            ? snapshot.KhachHangTen
                            : (!string.IsNullOrWhiteSpace(x.TenKhachHangDb) ? x.TenKhachHangDb : "Khách hàng vãng lai"),
                        NhanVien = !string.IsNullOrWhiteSpace(snapshot?.NhanVienTen)
                            ? snapshot.NhanVienTen
                            : (!string.IsNullOrWhiteSpace(x.TenNhanVienDb) ? x.TenNhanVienDb : "-"),
                        TongTien = x.TongTienSo.ToString("N0", culture) + " đ"
                    };
                })
                .ToList();

            _hoaDonThanhToanHomNayBs.DataSource = ds;
            lblPaidInvoicesTitle.Text = $"Hóa đơn đã thanh toán hôm nay ({ds.Count})";

            return (ds.Count, dsHoaDonDaThanhToan.Sum(x => x.TongTienSo));
        }

        private void DgvPaidInvoicesToday_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (_hoaDonThanhToanHomNayBs[e.RowIndex] is not HoaDonThanhToanHomNayVm hd) return;

            using var frm = new frmChiTiet_HoaDon(hd.ID);
            frm.ShowDialog(this);

            TaiDuLieuTongQuan();
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
                currentFormChild.Dispose();
            }

            currentFormChild = childForm;
            pnlDashboard.Visible = false;
            pnlDashboard.SendToBack();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.WindowState = FormWindowState.Normal;

            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void HienDashboard()
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
                currentFormChild.Dispose();
                currentFormChild = null;
            }

            pnlDashboard.Visible = true;
            pnlDashboard.BringToFront();
            TaiDuLieuTongQuan();
            ApplyResponsiveLayout();
        }

        private void BtnQuanLyKho_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham(AppSession.VaiTro));
        }

        private void BtnTaoHoaDon_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmBanHang());
        }

        private void BtnKhachHang_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang(AppSession.VaiTro));
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void mnuThuongHieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThuongHieu(AppSession.VaiTro));
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (!AppSession.LaAdmin)
            {
                MessageBox.Show("Bạn không có quyền truy cập quản lý nhân viên.",
                    "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenChildForm(new frmNhanVien(AppSession.LaAdmin));
        }

        private void mnuHeThong_Click(object sender, EventArgs e)
        {
            HienDashboard();
        }

        private void mnuLoaiDongHo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLoaiDongHo(AppSession.VaiTro));
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang(AppSession.VaiTro));
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDon());
        }

        private void mnuSanPham_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham(AppSession.VaiTro));
        }

        private void banHangToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmBanHang());
        }

        private void mnuDoiMatKhau_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmDoiMatKhau());
        }

        private void mnuDangXuat_Click(object? sender, EventArgs e)
        {
            var xacNhan = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes) return;

            ActivityLogger.GhiNhatKy("ĐĂNG XUẤT", $"Tài khoản '{AppSession.TenDangNhap}' đăng xuất hệ thống.");

            AppSession.TenDangNhap = string.Empty;
            AppSession.LaAdmin = false;
            AppSession.VaiTro = VaiTroNguoiDung.KhongXacDinh;
            Application.Restart();
        }



        private void mnuThongKeDoanhThu_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeTienBan());
        }

        private void mnuHuongDanSuDung_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Sử dụng menu Quản lý hoặc các nút Truy cập nhanh để mở chức năng tương ứng.",
                "Hướng dẫn sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuThongTinPhanMem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("DUY WATCHES - Quản lý bán hàng đồng hồ", "Thông tin phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuStrip_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thôngTiềnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeTienBan());
        }

        private void NhatKyHoatDongToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (AppSession.VaiTro != VaiTroNguoiDung.Admin)
            {
                MessageBox.Show("Bạn không có quyền xem nhật ký hoạt động.",
                    "Từ chối quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenChildForm(new frmNhatKyHoatDong());
        }
    }
}
