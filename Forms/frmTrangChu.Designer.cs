namespace LTQL_QLBHDongHo.Forms
{
    partial class frmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOverviewTitle;
        private System.Windows.Forms.FlowLayoutPanel flpSummary;
        private System.Windows.Forms.Panel cardDoanhThu;
        private System.Windows.Forms.Label lblCard1Value;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Panel cardDonHang;
        private System.Windows.Forms.Label lblCard2Value;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Panel cardSanPham;
        private System.Windows.Forms.Label lblCard3Value;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Panel cardKhachHang;
        private System.Windows.Forms.Label lblCard4Value;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Label lblQuickAccess;
        private System.Windows.Forms.FlowLayoutPanel flpQuickAccess;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Button btnQuanLyKho;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Panel pnlPaidInvoices;
        private System.Windows.Forms.Label lblPaidInvoicesTitle;
        private System.Windows.Forms.DataGridView dgvPaidInvoicesToday;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblOverviewTitle = new Label();
            flpSummary = new FlowLayoutPanel();
            cardDoanhThu = new Panel();
            lblCard1Value = new Label();
            lblCard1Title = new Label();
            cardDonHang = new Panel();
            lblCard2Value = new Label();
            lblCard2Title = new Label();
            cardSanPham = new Panel();
            lblCard3Value = new Label();
            lblCard3Title = new Label();
            cardKhachHang = new Panel();
            lblCard4Value = new Label();
            lblCard4Title = new Label();
            lblQuickAccess = new Label();
            flpQuickAccess = new FlowLayoutPanel();
            btnTaoHoaDon = new Button();
            btnQuanLyKho = new Button();
            btnKhachHang = new Button();
            lblAppName = new Label();
            lblHeaderSubtitle = new Label();
            mnuHuongDanSuDung = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuBaoCaoThongKe = new ToolStripMenuItem();
            mnuHoaDon = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            mnuSanPham = new ToolStripMenuItem();
            mnuThuongHieu = new ToolStripMenuItem();
            mnuLoaiDongHo = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            bánHàngToolStripMenuItem = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuHeThong = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            thôngTiềnBánToolStripMenuItem = new ToolStripMenuItem();
            nhậtKýHoạtĐộngToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new Panel();
            panelBody = new Panel();
            pnlDashboard = new Panel();
            pnlPaidInvoices = new Panel();
            dgvPaidInvoicesToday = new DataGridView();
            lblPaidInvoicesTitle = new Label();
            pnlHeader = new Panel();
            flpSummary.SuspendLayout();
            cardDoanhThu.SuspendLayout();
            cardDonHang.SuspendLayout();
            cardSanPham.SuspendLayout();
            cardKhachHang.SuspendLayout();
            flpQuickAccess.SuspendLayout();
            menuStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            panelBody.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlPaidInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaidInvoicesToday).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblOverviewTitle
            // 
            lblOverviewTitle.AutoSize = true;
            lblOverviewTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblOverviewTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblOverviewTitle.Location = new Point(30, 24);
            lblOverviewTitle.Name = "lblOverviewTitle";
            lblOverviewTitle.Size = new Size(365, 48);
            lblOverviewTitle.TabIndex = 0;
            lblOverviewTitle.Text = "Tổng quan hệ thống";
            // 
            // flpSummary
            // 
            flpSummary.Controls.Add(cardDoanhThu);
            flpSummary.Controls.Add(cardDonHang);
            flpSummary.Controls.Add(cardSanPham);
            flpSummary.Controls.Add(cardKhachHang);
            flpSummary.Location = new Point(30, 120);
            flpSummary.Name = "flpSummary";
            flpSummary.Size = new Size(1020, 132);
            flpSummary.TabIndex = 2;
            flpSummary.WrapContents = false;
            // 
            // cardDoanhThu
            // 
            cardDoanhThu.BackColor = Color.White;
            cardDoanhThu.BorderStyle = BorderStyle.FixedSingle;
            cardDoanhThu.Controls.Add(lblCard1Value);
            cardDoanhThu.Controls.Add(lblCard1Title);
            cardDoanhThu.Location = new Point(0, 0);
            cardDoanhThu.Margin = new Padding(0, 0, 12, 0);
            cardDoanhThu.Name = "cardDoanhThu";
            cardDoanhThu.Padding = new Padding(16, 14, 16, 14);
            cardDoanhThu.Size = new Size(246, 128);
            cardDoanhThu.TabIndex = 0;
            // 
            // lblCard1Value
            // 
            lblCard1Value.AutoSize = true;
            lblCard1Value.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCard1Value.ForeColor = Color.FromArgb(37, 99, 235);
            lblCard1Value.Location = new Point(14, 54);
            lblCard1Value.Name = "lblCard1Value";
            lblCard1Value.Size = new Size(220, 45);
            lblCard1Value.TabIndex = 1;
            lblCard1Value.Text = "578.000.000đ";
            // 
            // lblCard1Title
            // 
            lblCard1Title.AutoSize = true;
            lblCard1Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard1Title.ForeColor = Color.FromArgb(108, 117, 125);
            lblCard1Title.Location = new Point(14, 16);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(215, 25);
            lblCard1Title.TabIndex = 0;
            lblCard1Title.Text = "DOANH THU HÔM NAY";
            // 
            // cardDonHang
            // 
            cardDonHang.BackColor = Color.White;
            cardDonHang.BorderStyle = BorderStyle.FixedSingle;
            cardDonHang.Controls.Add(lblCard2Value);
            cardDonHang.Controls.Add(lblCard2Title);
            cardDonHang.Location = new Point(258, 0);
            cardDonHang.Margin = new Padding(0, 0, 12, 0);
            cardDonHang.Name = "cardDonHang";
            cardDonHang.Padding = new Padding(16, 14, 16, 14);
            cardDonHang.Size = new Size(246, 128);
            cardDonHang.TabIndex = 1;
            // 
            // lblCard2Value
            // 
            lblCard2Value.AutoSize = true;
            lblCard2Value.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCard2Value.ForeColor = Color.FromArgb(5, 150, 105);
            lblCard2Value.Location = new Point(14, 54);
            lblCard2Value.Name = "lblCard2Value";
            lblCard2Value.Size = new Size(56, 45);
            lblCard2Value.TabIndex = 1;
            lblCard2Value.Text = "24";
            // 
            // lblCard2Title
            // 
            lblCard2Title.AutoSize = true;
            lblCard2Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard2Title.ForeColor = Color.FromArgb(108, 117, 125);
            lblCard2Title.Location = new Point(14, 16);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(154, 25);
            lblCard2Title.TabIndex = 0;
            lblCard2Title.Text = "ĐƠN HÀNG MỚI";
            // 
            // cardSanPham
            // 
            cardSanPham.BackColor = Color.White;
            cardSanPham.BorderStyle = BorderStyle.FixedSingle;
            cardSanPham.Controls.Add(lblCard3Value);
            cardSanPham.Controls.Add(lblCard3Title);
            cardSanPham.Location = new Point(516, 0);
            cardSanPham.Margin = new Padding(0, 0, 12, 0);
            cardSanPham.Name = "cardSanPham";
            cardSanPham.Padding = new Padding(16, 14, 16, 14);
            cardSanPham.Size = new Size(246, 128);
            cardSanPham.TabIndex = 2;
            // 
            // lblCard3Value
            // 
            lblCard3Value.AutoSize = true;
            lblCard3Value.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCard3Value.ForeColor = Color.FromArgb(217, 119, 6);
            lblCard3Value.Location = new Point(14, 54);
            lblCard3Value.Name = "lblCard3Value";
            lblCard3Value.Size = new Size(38, 45);
            lblCard3Value.TabIndex = 1;
            lblCard3Value.Text = "5";
            // 
            // lblCard3Title
            // 
            lblCard3Title.AutoSize = true;
            lblCard3Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard3Title.ForeColor = Color.FromArgb(108, 117, 125);
            lblCard3Title.Location = new Point(14, 16);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(188, 25);
            lblCard3Title.TabIndex = 0;
            lblCard3Title.Text = "SẢN PHẨM SẮP HẾT";
            // 
            // cardKhachHang
            // 
            cardKhachHang.BackColor = Color.White;
            cardKhachHang.BorderStyle = BorderStyle.FixedSingle;
            cardKhachHang.Controls.Add(lblCard4Value);
            cardKhachHang.Controls.Add(lblCard4Title);
            cardKhachHang.Location = new Point(774, 0);
            cardKhachHang.Margin = new Padding(0);
            cardKhachHang.Name = "cardKhachHang";
            cardKhachHang.Padding = new Padding(16, 14, 16, 14);
            cardKhachHang.Size = new Size(246, 128);
            cardKhachHang.TabIndex = 3;
            // 
            // lblCard4Value
            // 
            lblCard4Value.AutoSize = true;
            lblCard4Value.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCard4Value.ForeColor = Color.FromArgb(124, 58, 237);
            lblCard4Value.Location = new Point(14, 54);
            lblCard4Value.Name = "lblCard4Value";
            lblCard4Value.Size = new Size(56, 45);
            lblCard4Value.TabIndex = 1;
            lblCard4Value.Text = "12";
            // 
            // lblCard4Title
            // 
            lblCard4Title.AutoSize = true;
            lblCard4Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard4Title.ForeColor = Color.FromArgb(108, 117, 125);
            lblCard4Title.Location = new Point(14, 16);
            lblCard4Title.Name = "lblCard4Title";
            lblCard4Title.Size = new Size(177, 25);
            lblCard4Title.TabIndex = 0;
            lblCard4Title.Text = "KHÁCH HÀNG MỚI";
            // 
            // lblQuickAccess
            // 
            lblQuickAccess.AutoSize = true;
            lblQuickAccess.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblQuickAccess.ForeColor = Color.FromArgb(33, 37, 41);
            lblQuickAccess.Location = new Point(30, 288);
            lblQuickAccess.Name = "lblQuickAccess";
            lblQuickAccess.Size = new Size(202, 36);
            lblQuickAccess.TabIndex = 3;
            lblQuickAccess.Text = "Truy cập nhanh";
            // 
            // flpQuickAccess
            // 
            flpQuickAccess.Controls.Add(btnTaoHoaDon);
            flpQuickAccess.Controls.Add(btnQuanLyKho);
            flpQuickAccess.Controls.Add(btnKhachHang);
            flpQuickAccess.Location = new Point(45, 341);
            flpQuickAccess.Name = "flpQuickAccess";
            flpQuickAccess.Size = new Size(1004, 123);
            flpQuickAccess.TabIndex = 4;
            flpQuickAccess.WrapContents = false;
            // 
            // btnTaoHoaDon
            // 
            btnTaoHoaDon.BackColor = Color.FromArgb(59, 130, 246);
            btnTaoHoaDon.FlatAppearance.BorderSize = 0;
            btnTaoHoaDon.FlatStyle = FlatStyle.Flat;
            btnTaoHoaDon.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTaoHoaDon.ForeColor = Color.White;
            btnTaoHoaDon.Location = new Point(0, 0);
            btnTaoHoaDon.Margin = new Padding(0, 0, 12, 0);
            btnTaoHoaDon.Name = "btnTaoHoaDon";
            btnTaoHoaDon.Size = new Size(325, 120);
            btnTaoHoaDon.TabIndex = 0;
            btnTaoHoaDon.Text = "Tạo đơn hàng mới";
            btnTaoHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnQuanLyKho
            // 
            btnQuanLyKho.BackColor = Color.FromArgb(59, 130, 246);
            btnQuanLyKho.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);
            btnQuanLyKho.FlatStyle = FlatStyle.Flat;
            btnQuanLyKho.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuanLyKho.ForeColor = Color.White;
            btnQuanLyKho.Location = new Point(337, 0);
            btnQuanLyKho.Margin = new Padding(0, 0, 12, 0);
            btnQuanLyKho.Name = "btnQuanLyKho";
            btnQuanLyKho.Size = new Size(325, 120);
            btnQuanLyKho.TabIndex = 1;
            btnQuanLyKho.Text = "Quản lý sản phẩm ";
            btnQuanLyKho.UseVisualStyleBackColor = false;
            // 
            // btnKhachHang
            // 
            btnKhachHang.BackColor = Color.FromArgb(59, 130, 246);
            btnKhachHang.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Location = new Point(674, 0);
            btnKhachHang.Margin = new Padding(0, 0, 12, 0);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(325, 120);
            btnKhachHang.TabIndex = 2;
            btnKhachHang.Text = "Khách hàng";
            btnKhachHang.UseVisualStyleBackColor = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(24, 11);
            lblAppName.Margin = new Padding(2, 0, 2, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(252, 54);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "SEVEN TIME";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(219, 234, 254);
            lblHeaderSubtitle.Location = new Point(28, 62);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(325, 25);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Quản lý bán hàng đồng hồ thông minh";
            // 
            // mnuHuongDanSuDung
            // 
            mnuHuongDanSuDung.Name = "mnuHuongDanSuDung";
            mnuHuongDanSuDung.ShortcutKeys = Keys.Control | Keys.F1;
            mnuHuongDanSuDung.Size = new Size(446, 40);
            mnuHuongDanSuDung.Text = "&Hướng dẫn sử dụng";
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuHuongDanSuDung });
            mnuTroGiup.ForeColor = Color.White;
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(126, 42);
            mnuTroGiup.Text = "Trợ giúp";
            // 
            // mnuBaoCaoThongKe
            // 
            mnuBaoCaoThongKe.ForeColor = Color.White;
            mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            mnuBaoCaoThongKe.Size = new Size(16, 42);
            // 
            // mnuHoaDon
            // 
            mnuHoaDon.Name = "mnuHoaDon";
            mnuHoaDon.Size = new Size(268, 40);
            mnuHoaDon.Text = "&Hóa đơn";
            mnuHoaDon.Click += mnuHoaDon_Click;
            // 
            // mnuNhanVien
            // 
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Size = new Size(268, 40);
            mnuNhanVien.Text = "&Nhân viên";
            mnuNhanVien.Click += mnuNhanVien_Click;
            // 
            // mnuSanPham
            // 
            mnuSanPham.Name = "mnuSanPham";
            mnuSanPham.Size = new Size(268, 40);
            mnuSanPham.Text = "&Sản phẩm";
            // 
            // mnuThuongHieu
            // 
            mnuThuongHieu.Name = "mnuThuongHieu";
            mnuThuongHieu.Size = new Size(268, 40);
            mnuThuongHieu.Text = "&Thương hiệu";
            mnuThuongHieu.Click += mnuThuongHieu_Click;
            // 
            // mnuLoaiDongHo
            // 
            mnuLoaiDongHo.Name = "mnuLoaiDongHo";
            mnuLoaiDongHo.Size = new Size(268, 40);
            mnuLoaiDongHo.Text = "&Loại đồng hồ";
            mnuLoaiDongHo.Click += mnuLoaiDongHo_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuLoaiDongHo, mnuThuongHieu, mnuSanPham, mnuKhachHang, mnuNhanVien, mnuHoaDon, bánHàngToolStripMenuItem });
            mnuQuanLy.ForeColor = Color.White;
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(118, 42);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(268, 40);
            mnuKhachHang.Text = "&Khách hàng";
            mnuKhachHang.Click += mnuKhachHang_Click;
            // 
            // bánHàngToolStripMenuItem
            // 
            bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            bánHàngToolStripMenuItem.Size = new Size(268, 40);
            bánHàngToolStripMenuItem.Text = "&Bán hàng";
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(271, 40);
            mnuDoiMatKhau.Text = "Đổi &mật khẩu";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(271, 40);
            mnuDangXuat.Text = "Đăng &xuất";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuDoiMatKhau });
            mnuHeThong.ForeColor = Color.White;
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(136, 42);
            mnuHeThong.Text = "Hệ thống";
            mnuHeThong.Click += mnuHeThong_Click;
            // 
            // menuStrip
            // 
            menuStrip.AutoSize = false;
            menuStrip.BackColor = Color.FromArgb(59, 130, 246);
            menuStrip.Dock = DockStyle.None;
            menuStrip.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuBaoCaoThongKe, thốngKêToolStripMenuItem, mnuTroGiup });
            menuStrip.Location = new Point(458, 20);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(620, 46);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
            menuStrip.ItemClicked += menuStrip_ItemClicked_1;
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTiềnBánToolStripMenuItem, nhậtKýHoạtĐộngToolStripMenuItem });
            thốngKêToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Size = new Size(139, 42);
            thốngKêToolStripMenuItem.Text = "Thống Kê";
            // 
            // thôngTiềnBánToolStripMenuItem
            // 
            thôngTiềnBánToolStripMenuItem.Name = "thôngTiềnBánToolStripMenuItem";
            thôngTiềnBánToolStripMenuItem.Size = new Size(340, 40);
            thôngTiềnBánToolStripMenuItem.Text = "Thông Tiền Bán";
            thôngTiềnBánToolStripMenuItem.Click += thôngTiềnBánToolStripMenuItem_Click;
            // 
            // nhậtKýHoạtĐộngToolStripMenuItem
            // 
            nhậtKýHoạtĐộngToolStripMenuItem.Name = "nhậtKýHoạtĐộngToolStripMenuItem";
            nhậtKýHoạtĐộngToolStripMenuItem.Size = new Size(340, 40);
            nhậtKýHoạtĐộngToolStripMenuItem.Text = "Nhật Ký Hoạt Động";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelBody);
            groupBox1.Controls.Add(pnlHeader);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1103, 642);
            groupBox1.TabIndex = 0;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.FromArgb(243, 246, 251);
            panelBody.Controls.Add(pnlDashboard);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 96);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1103, 546);
            panelBody.TabIndex = 1;
            // 
            // pnlDashboard
            // 
            pnlDashboard.Controls.Add(pnlPaidInvoices);
            pnlDashboard.Controls.Add(lblOverviewTitle);
            pnlDashboard.Controls.Add(flpSummary);
            pnlDashboard.Controls.Add(lblQuickAccess);
            pnlDashboard.Controls.Add(flpQuickAccess);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1103, 546);
            pnlDashboard.TabIndex = 0;
            // 
            // pnlPaidInvoices
            // 
            pnlPaidInvoices.BackColor = Color.White;
            pnlPaidInvoices.BorderStyle = BorderStyle.FixedSingle;
            pnlPaidInvoices.Controls.Add(dgvPaidInvoicesToday);
            pnlPaidInvoices.Controls.Add(lblPaidInvoicesTitle);
            pnlPaidInvoices.Location = new Point(30, 486);
            pnlPaidInvoices.Name = "pnlPaidInvoices";
            pnlPaidInvoices.Size = new Size(1020, 250);
            pnlPaidInvoices.TabIndex = 5;
            // 
            // dgvPaidInvoicesToday
            // 
            dgvPaidInvoicesToday.AllowUserToAddRows = false;
            dgvPaidInvoicesToday.AllowUserToDeleteRows = false;
            dgvPaidInvoicesToday.AllowUserToResizeRows = false;
            dgvPaidInvoicesToday.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPaidInvoicesToday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaidInvoicesToday.BackgroundColor = Color.White;
            dgvPaidInvoicesToday.BorderStyle = BorderStyle.None;
            dgvPaidInvoicesToday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaidInvoicesToday.Location = new Point(16, 54);
            dgvPaidInvoicesToday.MultiSelect = false;
            dgvPaidInvoicesToday.Name = "dgvPaidInvoicesToday";
            dgvPaidInvoicesToday.ReadOnly = true;
            dgvPaidInvoicesToday.RowHeadersVisible = false;
            dgvPaidInvoicesToday.RowHeadersWidth = 62;
            dgvPaidInvoicesToday.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaidInvoicesToday.Size = new Size(986, 178);
            dgvPaidInvoicesToday.TabIndex = 1;
            // 
            // lblPaidInvoicesTitle
            // 
            lblPaidInvoicesTitle.AutoSize = true;
            lblPaidInvoicesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPaidInvoicesTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblPaidInvoicesTitle.Location = new Point(16, 12);
            lblPaidInvoicesTitle.Name = "lblPaidInvoicesTitle";
            lblPaidInvoicesTitle.Size = new Size(384, 32);
            lblPaidInvoicesTitle.TabIndex = 0;
            lblPaidInvoicesTitle.Text = "Hóa đơn đã thanh toán hôm nay";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(59, 130, 246);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Controls.Add(menuStrip);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1103, 96);
            pnlHeader.TabIndex = 0;
            // 
            // frmTrangChu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1103, 642);
            Controls.Add(groupBox1);
            MainMenuStrip = menuStrip;
            Margin = new Padding(2);
            Name = "frmTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            flpSummary.ResumeLayout(false);
            cardDoanhThu.ResumeLayout(false);
            cardDoanhThu.PerformLayout();
            cardDonHang.ResumeLayout(false);
            cardDonHang.PerformLayout();
            cardSanPham.ResumeLayout(false);
            cardSanPham.PerformLayout();
            cardKhachHang.ResumeLayout(false);
            cardKhachHang.PerformLayout();
            flpQuickAccess.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            groupBox1.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            pnlPaidInvoices.ResumeLayout(false);
            pnlPaidInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaidInvoicesToday).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblAppName;
        private Label lblHeaderSubtitle;
        private ToolStripStatusLabel lblLienKet;
        private ToolStripStatusLabel lblTrangThai;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem mnuHuongDanSuDung;
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuBaoCaoThongKe;
        private ToolStripMenuItem mnuHoaDon;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuSanPham;
        private ToolStripMenuItem mnuThuongHieu;
        private ToolStripMenuItem mnuLoaiDongHo;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuHeThong;
        private MenuStrip menuStrip;
        private Panel groupBox1;
        private Panel pnlHeader;
        private Panel panelBody;
        private Panel pnlDashboard;
        private ToolStripMenuItem bánHàngToolStripMenuItem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private ToolStripMenuItem thôngTiềnBánToolStripMenuItem;
        private ToolStripMenuItem nhậtKýHoạtĐộngToolStripMenuItem;
    }
}