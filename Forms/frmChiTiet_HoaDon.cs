using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LTQL_QLBHDongHo.Data;
using Microsoft.EntityFrameworkCore;

namespace LTQL_QLBHDongHo.Forms
{
    public partial class frmChiTiet_HoaDon : Form
    {
        private const string TrangThaiDaThanhToan = "Đã thanh toán";
        private const string TrangThaiChuaThanhToan = "Chưa thanh toán";
        private const string ThuongHieu = "DUY WATCHES (Đồng Hồ DUY)";

        private static readonly Color MauNenChinh = Color.White;
        private static readonly Color MauChuChinh = Color.FromArgb(40, 48, 64);
        private static readonly Color MauNhan = Color.FromArgb(44, 105, 214);
        private static readonly Color MauVienNhe = Color.FromArgb(223, 228, 236);
        private static readonly Color MauNenBadge = Color.FromArgb(239, 246, 255);
        private static readonly Color MauHeaderBang = Color.FromArgb(246, 249, 252);

        private readonly int? hoaDonId;
        private readonly QLBHDbContext context = new QLBHDbContext();
        private bool laHoaDonDaThanhToan;
        private readonly Label lblGiamGiaLabel = new Label();
        private readonly Label lblGiamGiaValue = new Label();

        public frmChiTiet_HoaDon(int? id = null)
        {
            InitializeComponent();
            hoaDonId = id;
            KhoiTaoDongGiamGia();

            Load += ChiTiet_HoaDon_Load;
            btnDong.Click += (_, _) => Close();
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            printPreviewDialog1.Document = printDocument1;
        }

        private void ChiTiet_HoaDon_Load(object? sender, EventArgs e)
        {
            if (!hoaDonId.HasValue)
            {
                MessageBox.Show("Không xác định được hóa đơn cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            var hd = context.HoaDon
                .Include(h => h.HoaDonChiTiet)
                    .ThenInclude(ct => ct.SanPham)
                .Include(h => h.NhanVien)
                .Include(h => h.KhachHang)
                .AsNoTracking()
                .FirstOrDefault(h => h.ID == hoaDonId.Value);

            if (hd == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            var snapshot = HoaDonSnapshotHelper.LaySnapshot(hd.GhiChuHoaDon);
            laHoaDonDaThanhToan = HoaDonSnapshotHelper.LaHoaDonDaThanhToan(hd.GhiChuHoaDon);
            var trangThai = laHoaDonDaThanhToan
                ? TrangThaiDaThanhToan
                : TrangThaiChuaThanhToan;

            ApplyPremiumVisualTheme();

            // Header
            lblMaHD.Text = $"HD{hd.ID:D6}";
            lblThoiGian.Text = hd.NgayLap.ToString("HH:mm - dd/MM/yyyy");
            lblNhanVien.Text = !string.IsNullOrWhiteSpace(snapshot?.NhanVienTen)
                ? snapshot.NhanVienTen
                : (hd.NhanVien?.HoVaTen ?? "-");
            lblKhachHang.Text = !string.IsNullOrWhiteSpace(snapshot?.KhachHangTen)
                ? snapshot.KhachHangTen
                : (hd.KhachHang?.HoVaTen ?? "Khách lẻ");
            lblSDT.Text = !string.IsNullOrWhiteSpace(snapshot?.KhachHangSoDienThoai)
                ? snapshot.KhachHangSoDienThoai
                : (hd.KhachHang?.DienThoai ?? "-");
            lblTrangThaiLabel.Text = trangThai;
            lblFormSubtitle.Text = $"{ThuongHieu} | Chi tiết hóa đơn";
            ApplyTrangThaiBadge(trangThai);
            CapNhatTrangThaiInHoaDon();

            // Details
            var rows = hd.HoaDonChiTiet
                .OrderBy(ct => ct.ID)
                .Select(ct => new
                {
                    Ten = !string.IsNullOrWhiteSpace(ct.TenSanPhamSnapshot)
                        ? ct.TenSanPhamSnapshot
                        : (ct.SanPham?.TenSanPham ?? "Sản phẩm đã xóa"),
                    SL = ct.SoLuongBan,
                    ThanhTien = (long)ct.SoLuongBan * ct.DonGiaBan
                })
                .ToList();

            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.DataSource = rows;
            ConfigureBangSanPham();

            // Totals
            var tong = rows.Sum(r => r.ThanhTien);
            var giamGia = (long)Math.Clamp(hd.SoTienGiamDiem, 0m, (decimal)long.MaxValue);
            var tongSauGiam = Math.Max(0L, tong - giamGia);

            lblTamTinhValue.Text = tong.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
            lblTongValue.Text = tongSauGiam.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
            CapNhatDongGiamGia(giamGia);

            // Notes
            var ghiChuNguoiDung = HoaDonSnapshotHelper.LayNoiDungGhiChuNguoiDung(hd.GhiChuHoaDon);
            txtGhiChu.Text = string.IsNullOrWhiteSpace(ghiChuNguoiDung)
                ? "Không có ghi chú hóa đơn."
                : ghiChuNguoiDung;
        }

        private void CapNhatTrangThaiInHoaDon()
        {
            if (btnIn == null) return;

            btnIn.Enabled = laHoaDonDaThanhToan;
            if (laHoaDonDaThanhToan)
            {
                btnIn.BackColor = MauNhan;
                btnIn.ForeColor = Color.White;
                btnIn.Text = "In hóa đơn";
                return;
            }

            btnIn.BackColor = Color.FromArgb(225, 231, 239);
            btnIn.ForeColor = Color.FromArgb(115, 125, 142);
            btnIn.Text = "Chỉ in khi đã thanh toán";
        }

        private void KhoiTaoDongGiamGia()
        {
            lblGiamGiaLabel.AutoSize = true;
            lblGiamGiaLabel.Font = new Font("Segoe UI", 9F);
            lblGiamGiaLabel.ForeColor = Color.FromArgb(73, 80, 87);
            lblGiamGiaLabel.Text = "Giảm giá theo điểm";
            lblGiamGiaLabel.Visible = false;

            lblGiamGiaValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGiamGiaValue.ForeColor = Color.FromArgb(220, 53, 69);
            lblGiamGiaValue.TextAlign = ContentAlignment.MiddleRight;
            lblGiamGiaValue.Visible = false;

            panelTotals.Controls.Add(lblGiamGiaLabel);
            panelTotals.Controls.Add(lblGiamGiaValue);
        }

        private void CapNhatDongGiamGia(long giamGia)
        {
            if (giamGia <= 0)
            {
                lblGiamGiaLabel.Visible = false;
                lblGiamGiaValue.Visible = false;

                lblTongLabel.Location = new Point(16, 88);
                lblTongValue.Location = new Point(261, 82);
                return;
            }

            lblGiamGiaLabel.Visible = true;
            lblGiamGiaValue.Visible = true;

            lblGiamGiaLabel.Location = new Point(16, 53);
            lblGiamGiaValue.SetBounds(261, 49, 225, 25);
            lblGiamGiaValue.Text = "-" + giamGia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";

            lblTongLabel.Location = new Point(16, 99);
            lblTongValue.Location = new Point(261, 93);
        }

        private void ApplyPremiumVisualTheme()
        {
            BackColor = MauNenChinh;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            lblFormSubtitle.ForeColor = MauNhan;
            lblFormSubtitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular);

            lblMaHD.ForeColor = MauChuChinh;
            lblThoiGian.ForeColor = MauChuChinh;
            lblNhanVien.ForeColor = MauChuChinh;
            lblKhachHang.ForeColor = MauChuChinh;
            lblSDT.ForeColor = MauChuChinh;

            lblTongValue.ForeColor = MauChuChinh;
            lblTongValue.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTamTinhValue.ForeColor = Color.FromArgb(88, 96, 110);

            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            txtGhiChu.BackColor = Color.White;
            txtGhiChu.ForeColor = MauChuChinh;
            txtGhiChu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtGhiChu.Height = Math.Min(txtGhiChu.Height, 76);

            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.FlatAppearance.BorderColor = MauVienNhe;
            btnDong.FlatAppearance.BorderSize = 1;
            btnDong.BackColor = Color.White;
            btnDong.ForeColor = MauChuChinh;
            btnDong.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Regular);
            btnDong.Height = Math.Max(btnDong.Height, 38);

            if (btnIn != null)
            {
                btnIn.FlatStyle = FlatStyle.Flat;
                btnIn.FlatAppearance.BorderSize = 0;
                btnIn.BackColor = MauNhan;
                btnIn.ForeColor = Color.White;
                btnIn.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Regular);
                btnIn.Height = Math.Max(btnIn.Height, 38);
                btnIn.Text = "In hóa đơn";
                btnIn.Image = TaoBieuTuongMayIn(Color.White);
                btnIn.ImageAlign = ContentAlignment.MiddleLeft;
                btnIn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }

        private static Bitmap TaoBieuTuongMayIn(Color color)
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(color, 1.4F);
            using var brush = new SolidBrush(color);

            g.DrawRectangle(pen, 3, 2, 10, 4);  // khay giay tren
            g.DrawRectangle(pen, 2, 6, 12, 6);  // than may in
            g.DrawRectangle(pen, 4, 10, 8, 4);  // giay ra
            g.DrawLine(pen, 5, 11, 11, 11);
            g.FillEllipse(brush, 11, 7, 2, 2);

            return bmp;
        }

        private void ApplyTrangThaiBadge(string trangThai)
        {
            lblTrangThaiLabel.BackColor = MauNenBadge;
            lblTrangThaiLabel.ForeColor = MauNhan;
            lblTrangThaiLabel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Regular);
            lblTrangThaiLabel.Padding = new Padding(10, 4, 10, 4);
            lblTrangThaiLabel.AutoSize = true;
            lblTrangThaiLabel.Text = trangThai;
        }

        private void ConfigureBangSanPham()
        {
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = MauHeaderBang;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = MauChuChinh;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvChiTiet.ColumnHeadersHeight = 38;

            dgvChiTiet.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvChiTiet.DefaultCellStyle.ForeColor = MauChuChinh;
            dgvChiTiet.DefaultCellStyle.BackColor = Color.White;
            dgvChiTiet.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 255);
            dgvChiTiet.DefaultCellStyle.SelectionForeColor = MauChuChinh;
            dgvChiTiet.DefaultCellStyle.Padding = new Padding(0, 4, 0, 4);
            dgvChiTiet.RowTemplate.Height = 36;
            dgvChiTiet.GridColor = MauVienNhe;

            if (dgvChiTiet.Columns.Contains("cStt"))
            {
                dgvChiTiet.Columns["cStt"].Visible = false;
            }

            if (dgvChiTiet.Columns.Contains("cTen"))
            {
                dgvChiTiet.Columns["cTen"].HeaderText = "Tên sản phẩm";
                dgvChiTiet.Columns["cTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvChiTiet.Columns["cTen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvChiTiet.Columns.Contains("cSl"))
            {
                dgvChiTiet.Columns["cSl"].HeaderText = "Số lượng";
                dgvChiTiet.Columns["cSl"].Width = 110;
                dgvChiTiet.Columns["cSl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns["cSl"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvChiTiet.Columns.Contains("cThanhTien"))
            {
                dgvChiTiet.Columns["cThanhTien"].HeaderText = "Thành tiền";
                dgvChiTiet.Columns["cThanhTien"].Width = 170;
                dgvChiTiet.Columns["cThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns["cThanhTien"].DefaultCellStyle.Format = "N0";
                dgvChiTiet.Columns["cThanhTien"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void BtnIn_Click(object? sender, EventArgs e)
        {
            if (!laHoaDonDaThanhToan)
            {
                MessageBox.Show("Hóa đơn chưa thanh toán nên không thể in. Vui lòng thanh toán trước khi in hóa đơn.", "Không thể in hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                printPreviewDialog1.Width = 1000;
                printPreviewDialog1.Height = 700;
                printPreviewDialog1.StartPosition = FormStartPosition.CenterParent;
                printPreviewDialog1.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở xem trước khi in.\nChi tiết: {ex.Message}", "Lỗi in hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument1_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (!laHoaDonDaThanhToan)
            {
                e.HasMorePages = false;
                return;
            }

            var g = e.Graphics;
            var margin = e.MarginBounds;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using var fontBrand = new Font("Segoe UI Semibold", 14, FontStyle.Bold);
            using var fontTitle = new Font("Segoe UI", 11, FontStyle.Bold);
            using var fontHeader = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            using var fontNormal = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            using var fontSmall = new Font("Segoe UI", 9, FontStyle.Regular);
            using var penBorder = new Pen(Color.FromArgb(188, 197, 212), 1);
            using var penLine = new Pen(Color.FromArgb(223, 228, 236), 1);
            using var brushText = new SolidBrush(Color.FromArgb(40, 48, 64));
            using var brushSubText = new SolidBrush(Color.FromArgb(88, 96, 110));
            using var brushHeaderBg = new SolidBrush(Color.FromArgb(246, 249, 252));
            using var brushBadgeBg = new SolidBrush(Color.FromArgb(239, 246, 255));
            using var brushAccent = new SolidBrush(Color.FromArgb(44, 105, 214));

            float y = margin.Top;
            float left = margin.Left;
            float right = margin.Right;
            float width = margin.Width;
            var rightFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
            var leftFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };

            string moneyText = lblTongValue.Text;
            string tamTinhText = lblTamTinhValue.Text;
            string giamGiaText = lblGiamGiaValue.Visible ? lblGiamGiaValue.Text : string.Empty;
            var nowText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Header thuong hieu
            var logoRect = new RectangleF(left, y, 52, 52);
            VeLogoThuongHieu(g, logoRect, brushAccent);
            g.DrawString("DUY WATCHES", fontBrand, brushText, left + 64, y + 3);
            g.DrawString("Đồng Hồ DUY", fontNormal, brushSubText, left + 64, y + 28);
            g.DrawString("Địa chỉ: 123 Nguyễn Huệ, Q.1, TP.HCM", fontSmall, brushSubText, left + 64, y + 45);
            g.DrawString("Hotline: 0901 234 567", fontSmall, brushSubText, right - 220, y + 45);

            g.DrawString("HÓA ĐƠN BÁN HÀNG", fontTitle, brushText, right - 190, y + 5);
            g.DrawString($"Mã hóa đơn: {lblMaHD.Text}", fontNormal, brushText, right - 190, y + 26);

            y += 66;
            g.DrawLine(penLine, left, y, right, y);
            y += 14;

            // Khoi thong tin hoa don + khach hang
            var infoHeight = 92F;
            var gap = 12F;
            var colWidth = (width - gap) / 2;
            var infoHoaDonRect = new RectangleF(left, y, colWidth, infoHeight);
            var infoKhachRect = new RectangleF(left + colWidth + gap, y, colWidth, infoHeight);

            g.DrawRectangle(penBorder, Rectangle.Round(infoHoaDonRect));
            g.DrawRectangle(penBorder, Rectangle.Round(infoKhachRect));

            g.DrawString("Thông tin hóa đơn", fontHeader, brushText, infoHoaDonRect.Left + 10, infoHoaDonRect.Top + 8);
            g.DrawString($"Mã hóa đơn: {lblMaHD.Text}", fontNormal, brushText, infoHoaDonRect.Left + 10, infoHoaDonRect.Top + 34);
            g.DrawString($"Thời gian: {lblThoiGian.Text}", fontNormal, brushText, infoHoaDonRect.Left + 10, infoHoaDonRect.Top + 56);

            g.DrawString("Thông tin khách hàng", fontHeader, brushText, infoKhachRect.Left + 10, infoKhachRect.Top + 8);
            g.DrawString($"Nhân viên: {lblNhanVien.Text}", fontNormal, brushText, infoKhachRect.Left + 10, infoKhachRect.Top + 34);
            g.DrawString($"Khách hàng: {lblKhachHang.Text}", fontNormal, brushText, infoKhachRect.Left + 10, infoKhachRect.Top + 56);
            g.DrawString($"SĐT: {lblSDT.Text}", fontNormal, brushText, infoKhachRect.Left + 10, infoKhachRect.Top + 76);

            // Badge trang thai
            var badgeRect = new RectangleF(right - 160, y + infoHeight + 8, 160, 24);
            g.FillRectangle(brushBadgeBg, badgeRect);
            g.DrawRectangle(penLine, Rectangle.Round(badgeRect));
            g.DrawString($"Trạng thái: {lblTrangThaiLabel.Text}", fontSmall, brushAccent, badgeRect, rightFormat);

            y += infoHeight + 42;

            // Bang san pham
            var tableTop = y;
            var rowHeight = 30F;
            var colTen = left + 10;
            var colSoLuongRight = left + width - 150;
            var colThanhTienRight = right - 12;

            var headerRect = new RectangleF(left, tableTop, width, rowHeight);
            g.FillRectangle(brushHeaderBg, headerRect);
            g.DrawRectangle(penBorder, Rectangle.Round(headerRect));
            g.DrawString("Tên sản phẩm", fontHeader, brushText, colTen, tableTop + 7);
            g.DrawString("Số lượng", fontHeader, brushText, new RectangleF(colSoLuongRight - 80, tableTop, 80, rowHeight), rightFormat);
            g.DrawString("Thành tiền", fontHeader, brushText, new RectangleF(colThanhTienRight - 130, tableTop, 130, rowHeight), rightFormat);

            y += rowHeight;

            var rows = LayDongChiTietIn();
            foreach (var row in rows)
            {
                var rowRect = new RectangleF(left, y, width, rowHeight);
                g.DrawRectangle(penLine, Rectangle.Round(rowRect));
                g.DrawString(row.Ten, fontNormal, brushText, new RectangleF(colTen, y + 6, colSoLuongRight - colTen - 16, rowHeight));
                g.DrawString(row.SoLuong, fontNormal, brushText, new RectangleF(colSoLuongRight - 80, y, 80, rowHeight), rightFormat);
                g.DrawString(row.ThanhTien, fontNormal, brushText, new RectangleF(colThanhTienRight - 130, y, 130, rowHeight), rightFormat);
                y += rowHeight;
            }

            y += 14;

            // Footer tong hop
            var coGiamGia = lblGiamGiaValue.Visible && !string.IsNullOrWhiteSpace(giamGiaText);
            var footerHeight = coGiamGia ? 144F : 118F;
            var footerRect = new RectangleF(left, y, width, footerHeight);
            g.DrawRectangle(penBorder, Rectangle.Round(footerRect));
            g.DrawString("Tiền sản phẩm", fontSmall, brushSubText, footerRect.Left + 12, footerRect.Top + 12);
            g.DrawString(tamTinhText, fontSmall, brushText, footerRect.Left + 130, footerRect.Top + 12);

            var tongY = footerRect.Top + 34;
            if (coGiamGia)
            {
                g.DrawString("Trừ giảm giá", fontSmall, brushSubText, footerRect.Left + 12, footerRect.Top + 34);
                g.DrawString(giamGiaText, fontSmall, brushText, footerRect.Left + 130, footerRect.Top + 34);
                tongY = footerRect.Top + 56;
            }

            g.DrawString("TỔNG CỘNG", fontSmall, brushSubText, footerRect.Left + 12, tongY);
            g.DrawString(moneyText, new Font("Segoe UI Semibold", 13, FontStyle.Bold), brushText, footerRect.Left + 12, tongY + 20);

            var note = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? "Không có ghi chú." : txtGhiChu.Text.Trim();
            var noteY = coGiamGia ? footerRect.Top + 96 : footerRect.Top + 70;
            var printDateY = coGiamGia ? footerRect.Top + 118 : footerRect.Top + 92;
            g.DrawString($"Ghi chú: {note}", fontSmall, brushSubText, new RectangleF(footerRect.Left + 12, noteY, width - 24, 22));
            g.DrawString($"Ngày in: {nowText}", fontSmall, brushSubText, new RectangleF(footerRect.Left + 12, printDateY, width - 24, 20), leftFormat);
            g.DrawString("Cảm ơn quý khách đã tin tưởng DUY WATCHES.", fontSmall, brushSubText, new RectangleF(footerRect.Left + 12, printDateY, width - 24, 20), rightFormat);

            e.HasMorePages = false;
        }

        private static void VeLogoThuongHieu(Graphics g, RectangleF rect, Brush accentBrush)
        {
            using var penOuter = new Pen(Color.FromArgb(44, 105, 214), 2);
            using var penInner = new Pen(Color.FromArgb(150, 170, 200), 1);
            using var fontMono = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            using var brushText = new SolidBrush(Color.FromArgb(40, 48, 64));

            g.DrawEllipse(penOuter, rect);
            var inner = new RectangleF(rect.X + 4, rect.Y + 4, rect.Width - 8, rect.Height - 8);
            g.DrawEllipse(penInner, inner);

            var centerX = rect.X + rect.Width / 2;
            var centerY = rect.Y + rect.Height / 2;
            g.FillEllipse(accentBrush, centerX - 1.5F, centerY - 10, 3, 3);
            g.FillEllipse(accentBrush, centerX + 7, centerY - 1.5F, 3, 3);
            g.FillEllipse(accentBrush, centerX - 1.5F, centerY + 7, 3, 3);
            g.FillEllipse(accentBrush, centerX - 10, centerY - 1.5F, 3, 3);

            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("DW", fontMono, brushText, rect, sf);
        }

        private List<DongChiTietIn> LayDongChiTietIn()
        {
            var result = new List<DongChiTietIn>();

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.IsNewRow) continue;

                var ten = Convert.ToString(row.Cells["cTen"].Value) ?? string.Empty;
                var sl = Convert.ToString(row.Cells["cSl"].Value) ?? "0";

                var rawThanhTien = row.Cells["cThanhTien"].Value;
                long thanhTienValue = 0;
                if (rawThanhTien != null)
                {
                    _ = long.TryParse(rawThanhTien.ToString(), out thanhTienValue);
                }

                result.Add(new DongChiTietIn
                {
                    Ten = ten,
                    SoLuong = sl,
                    ThanhTien = thanhTienValue.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ"
                });
            }

            return result;
        }

        private sealed class DongChiTietIn
        {
            public string Ten { get; init; } = string.Empty;
            public string SoLuong { get; init; } = "0";
            public string ThanhTien { get; init; } = "0 đ";
        }

        private void lblMaHD_Click(object sender, EventArgs e)
        {
        }

        private void panelTotals_Paint(object sender, PaintEventArgs e)
        {
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            context.Dispose();
            base.OnFormClosed(e);
        }
    }
}
