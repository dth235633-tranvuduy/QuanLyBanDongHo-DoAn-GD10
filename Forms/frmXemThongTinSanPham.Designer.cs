namespace LTQL_QLBHDongHo.Forms
{
    partial class frmXemThongTinSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutRoot;

        private System.Windows.Forms.GroupBox groupThongTinSanPham;
        private System.Windows.Forms.TableLayoutPanel tableThongTinSanPham;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblThuongHieu;
        private System.Windows.Forms.TextBox txtThuongHieu;
        private System.Windows.Forms.Label lblLoaiDongHo;
        private System.Windows.Forms.TextBox txtLoaiDongHo;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;

        private System.Windows.Forms.GroupBox groupThongSoKyThuat;
        private System.Windows.Forms.TableLayoutPanel tableThongSoKyThuat;
        private System.Windows.Forms.Label lblLoaiKinh;
        private System.Windows.Forms.TextBox txtLoaiKinh;
        private System.Windows.Forms.Label lblDoChiuNuoc;
        private System.Windows.Forms.TextBox txtDoChiuNuoc;
        private System.Windows.Forms.Label lblLoaiDay;
        private System.Windows.Forms.TextBox txtLoaiDay;
        private System.Windows.Forms.Label lblKichThuocMat;
        private System.Windows.Forms.TextBox txtKichThuocMat;
        private System.Windows.Forms.Label lblTenThuongHieuTS;
        private System.Windows.Forms.TextBox txtTenThuongHieuTS;

        private System.Windows.Forms.GroupBox groupHinhAnh;
        private System.Windows.Forms.PictureBox picHinhAnh;

        private System.Windows.Forms.GroupBox groupGhiChu;
        private System.Windows.Forms.RichTextBox rtbGhiChu;

        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnDong;

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
            panelHeader = new Panel();
            lblHeaderTitle = new Label();
            panelMain = new Panel();
            tableLayoutRoot = new TableLayoutPanel();
            groupThongTinSanPham = new GroupBox();
            tableThongTinSanPham = new TableLayoutPanel();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblGiaBan = new Label();
            txtGiaBan = new TextBox();
            lblThuongHieu = new Label();
            txtThuongHieu = new TextBox();
            lblLoaiDongHo = new Label();
            txtLoaiDongHo = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            groupThongSoKyThuat = new GroupBox();
            tableThongSoKyThuat = new TableLayoutPanel();
            lblLoaiKinh = new Label();
            txtLoaiKinh = new TextBox();
            lblDoChiuNuoc = new Label();
            txtDoChiuNuoc = new TextBox();
            lblLoaiDay = new Label();
            txtLoaiDay = new TextBox();
            lblKichThuocMat = new Label();
            txtKichThuocMat = new TextBox();
            lblTenThuongHieuTS = new Label();
            txtTenThuongHieuTS = new TextBox();
            groupHinhAnh = new GroupBox();
            picHinhAnh = new PictureBox();
            groupGhiChu = new GroupBox();
            rtbGhiChu = new RichTextBox();
            panelActions = new Panel();
            btnDong = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            tableLayoutRoot.SuspendLayout();
            groupThongTinSanPham.SuspendLayout();
            tableThongTinSanPham.SuspendLayout();
            groupThongSoKyThuat.SuspendLayout();
            tableThongSoKyThuat.SuspendLayout();
            groupHinhAnh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            groupGhiChu.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(32, 99, 155);
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 14, 20, 14);
            panelHeader.Size = new Size(1180, 88);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(22, 17);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(343, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "XEM THÔNG TIN SẢN PHẨM";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(tableLayoutRoot);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 88);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(16, 14, 16, 14);
            panelMain.Size = new Size(1180, 564);
            panelMain.TabIndex = 1;
            // 
            // tableLayoutRoot
            // 
            tableLayoutRoot.ColumnCount = 2;
            tableLayoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            tableLayoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tableLayoutRoot.Controls.Add(groupThongTinSanPham, 0, 0);
            tableLayoutRoot.Controls.Add(groupThongSoKyThuat, 0, 1);
            tableLayoutRoot.Controls.Add(groupHinhAnh, 1, 0);
            tableLayoutRoot.Controls.Add(groupGhiChu, 1, 1);
            tableLayoutRoot.Dock = DockStyle.Fill;
            tableLayoutRoot.Location = new Point(16, 14);
            tableLayoutRoot.Name = "tableLayoutRoot";
            tableLayoutRoot.RowCount = 2;
            tableLayoutRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 56F));
            tableLayoutRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 44F));
            tableLayoutRoot.Size = new Size(1148, 536);
            tableLayoutRoot.TabIndex = 0;
            // 
            // groupThongTinSanPham
            // 
            groupThongTinSanPham.Controls.Add(tableThongTinSanPham);
            groupThongTinSanPham.Dock = DockStyle.Fill;
            groupThongTinSanPham.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupThongTinSanPham.Location = new Point(3, 3);
            groupThongTinSanPham.Name = "groupThongTinSanPham";
            groupThongTinSanPham.Padding = new Padding(14, 10, 14, 10);
            groupThongTinSanPham.Size = new Size(659, 294);
            groupThongTinSanPham.TabIndex = 0;
            groupThongTinSanPham.TabStop = false;
            groupThongTinSanPham.Text = "Thông tin sản phẩm";
            // 
            // tableThongTinSanPham
            // 
            tableThongTinSanPham.ColumnCount = 2;
            tableThongTinSanPham.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            tableThongTinSanPham.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableThongTinSanPham.Controls.Add(lblMaSP, 0, 0);
            tableThongTinSanPham.Controls.Add(txtMaSP, 1, 0);
            tableThongTinSanPham.Controls.Add(lblTenSP, 0, 1);
            tableThongTinSanPham.Controls.Add(txtTenSP, 1, 1);
            tableThongTinSanPham.Controls.Add(lblGiaBan, 0, 2);
            tableThongTinSanPham.Controls.Add(txtGiaBan, 1, 2);
            tableThongTinSanPham.Controls.Add(lblThuongHieu, 0, 3);
            tableThongTinSanPham.Controls.Add(txtThuongHieu, 1, 3);
            tableThongTinSanPham.Controls.Add(lblLoaiDongHo, 0, 4);
            tableThongTinSanPham.Controls.Add(txtLoaiDongHo, 1, 4);
            tableThongTinSanPham.Controls.Add(lblSoLuong, 0, 5);
            tableThongTinSanPham.Controls.Add(txtSoLuong, 1, 5);
            tableThongTinSanPham.Dock = DockStyle.Fill;
            tableThongTinSanPham.Location = new Point(14, 34);
            tableThongTinSanPham.Name = "tableThongTinSanPham";
            tableThongTinSanPham.RowCount = 6;
            tableThongTinSanPham.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableThongTinSanPham.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableThongTinSanPham.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableThongTinSanPham.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableThongTinSanPham.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableThongTinSanPham.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableThongTinSanPham.Size = new Size(631, 250);
            tableThongTinSanPham.TabIndex = 0;
            // 
            // lblMaSP
            // 
            lblMaSP.Anchor = AnchorStyles.Left;
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI", 9F);
            lblMaSP.Location = new Point(3, 7);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(120, 25);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã sản phẩm";
            // 
            // txtMaSP
            // 
            txtMaSP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaSP.BackColor = Color.FromArgb(248, 250, 252);
            txtMaSP.BorderStyle = BorderStyle.FixedSingle;
            txtMaSP.Font = new Font("Segoe UI", 9F);
            txtMaSP.Location = new Point(148, 4);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(480, 31);
            txtMaSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            lblTenSP.Anchor = AnchorStyles.Left;
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI", 9F);
            lblTenSP.Location = new Point(3, 47);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(121, 25);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên sản phẩm";
            // 
            // txtTenSP
            // 
            txtTenSP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenSP.BackColor = Color.FromArgb(248, 250, 252);
            txtTenSP.BorderStyle = BorderStyle.FixedSingle;
            txtTenSP.Font = new Font("Segoe UI", 9F);
            txtTenSP.Location = new Point(148, 44);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.ReadOnly = true;
            txtTenSP.Size = new Size(480, 31);
            txtTenSP.TabIndex = 3;
            // 
            // lblGiaBan
            // 
            lblGiaBan.Anchor = AnchorStyles.Left;
            lblGiaBan.AutoSize = true;
            lblGiaBan.Font = new Font("Segoe UI", 9F);
            lblGiaBan.Location = new Point(3, 87);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(72, 25);
            lblGiaBan.TabIndex = 4;
            lblGiaBan.Text = "Giá bán";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtGiaBan.BackColor = Color.FromArgb(248, 250, 252);
            txtGiaBan.BorderStyle = BorderStyle.FixedSingle;
            txtGiaBan.Font = new Font("Segoe UI", 9F);
            txtGiaBan.Location = new Point(148, 84);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.ReadOnly = true;
            txtGiaBan.Size = new Size(480, 31);
            txtGiaBan.TabIndex = 5;
            // 
            // lblThuongHieu
            // 
            lblThuongHieu.Anchor = AnchorStyles.Left;
            lblThuongHieu.AutoSize = true;
            lblThuongHieu.Font = new Font("Segoe UI", 9F);
            lblThuongHieu.Location = new Point(3, 127);
            lblThuongHieu.Name = "lblThuongHieu";
            lblThuongHieu.Size = new Size(112, 25);
            lblThuongHieu.TabIndex = 6;
            lblThuongHieu.Text = "Thương hiệu";
            // 
            // txtThuongHieu
            // 
            txtThuongHieu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtThuongHieu.BackColor = Color.FromArgb(248, 250, 252);
            txtThuongHieu.BorderStyle = BorderStyle.FixedSingle;
            txtThuongHieu.Font = new Font("Segoe UI", 9F);
            txtThuongHieu.Location = new Point(148, 124);
            txtThuongHieu.Name = "txtThuongHieu";
            txtThuongHieu.ReadOnly = true;
            txtThuongHieu.Size = new Size(480, 31);
            txtThuongHieu.TabIndex = 7;
            // 
            // lblLoaiDongHo
            // 
            lblLoaiDongHo.Anchor = AnchorStyles.Left;
            lblLoaiDongHo.AutoSize = true;
            lblLoaiDongHo.Font = new Font("Segoe UI", 9F);
            lblLoaiDongHo.Location = new Point(3, 167);
            lblLoaiDongHo.Name = "lblLoaiDongHo";
            lblLoaiDongHo.Size = new Size(118, 25);
            lblLoaiDongHo.TabIndex = 8;
            lblLoaiDongHo.Text = "Loại đồng hồ";
            // 
            // txtLoaiDongHo
            // 
            txtLoaiDongHo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLoaiDongHo.BackColor = Color.FromArgb(248, 250, 252);
            txtLoaiDongHo.BorderStyle = BorderStyle.FixedSingle;
            txtLoaiDongHo.Font = new Font("Segoe UI", 9F);
            txtLoaiDongHo.Location = new Point(148, 164);
            txtLoaiDongHo.Name = "txtLoaiDongHo";
            txtLoaiDongHo.ReadOnly = true;
            txtLoaiDongHo.Size = new Size(480, 31);
            txtLoaiDongHo.TabIndex = 9;
            // 
            // lblSoLuong
            // 
            lblSoLuong.Anchor = AnchorStyles.Left;
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 9F);
            lblSoLuong.Location = new Point(3, 212);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(85, 25);
            lblSoLuong.TabIndex = 10;
            lblSoLuong.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSoLuong.BackColor = Color.FromArgb(248, 250, 252);
            txtSoLuong.BorderStyle = BorderStyle.FixedSingle;
            txtSoLuong.Font = new Font("Segoe UI", 9F);
            txtSoLuong.Location = new Point(148, 209);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.ReadOnly = true;
            txtSoLuong.Size = new Size(480, 31);
            txtSoLuong.TabIndex = 11;
            // 
            // groupThongSoKyThuat
            // 
            groupThongSoKyThuat.Controls.Add(tableThongSoKyThuat);
            groupThongSoKyThuat.Dock = DockStyle.Fill;
            groupThongSoKyThuat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupThongSoKyThuat.Location = new Point(3, 303);
            groupThongSoKyThuat.Name = "groupThongSoKyThuat";
            groupThongSoKyThuat.Padding = new Padding(14, 10, 14, 10);
            groupThongSoKyThuat.Size = new Size(659, 230);
            groupThongSoKyThuat.TabIndex = 1;
            groupThongSoKyThuat.TabStop = false;
            groupThongSoKyThuat.Text = "Thông số kỹ thuật";
            // 
            // tableThongSoKyThuat
            // 
            tableThongSoKyThuat.ColumnCount = 2;
            tableThongSoKyThuat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            tableThongSoKyThuat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableThongSoKyThuat.Controls.Add(lblLoaiKinh, 0, 0);
            tableThongSoKyThuat.Controls.Add(txtLoaiKinh, 1, 0);
            tableThongSoKyThuat.Controls.Add(lblDoChiuNuoc, 0, 1);
            tableThongSoKyThuat.Controls.Add(txtDoChiuNuoc, 1, 1);
            tableThongSoKyThuat.Controls.Add(lblLoaiDay, 0, 2);
            tableThongSoKyThuat.Controls.Add(txtLoaiDay, 1, 2);
            tableThongSoKyThuat.Controls.Add(lblKichThuocMat, 0, 3);
            tableThongSoKyThuat.Controls.Add(txtKichThuocMat, 1, 3);
            tableThongSoKyThuat.Controls.Add(lblTenThuongHieuTS, 0, 4);
            tableThongSoKyThuat.Controls.Add(txtTenThuongHieuTS, 1, 4);
            tableThongSoKyThuat.Dock = DockStyle.Fill;
            tableThongSoKyThuat.Location = new Point(14, 34);
            tableThongSoKyThuat.Name = "tableThongSoKyThuat";
            tableThongSoKyThuat.RowCount = 5;
            tableThongSoKyThuat.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableThongSoKyThuat.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableThongSoKyThuat.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableThongSoKyThuat.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableThongSoKyThuat.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableThongSoKyThuat.Size = new Size(631, 186);
            tableThongSoKyThuat.TabIndex = 0;
            // 
            // lblLoaiKinh
            // 
            lblLoaiKinh.Anchor = AnchorStyles.Left;
            lblLoaiKinh.AutoSize = true;
            lblLoaiKinh.Font = new Font("Segoe UI", 9F);
            lblLoaiKinh.Location = new Point(3, 6);
            lblLoaiKinh.Name = "lblLoaiKinh";
            lblLoaiKinh.Size = new Size(82, 25);
            lblLoaiKinh.TabIndex = 0;
            lblLoaiKinh.Text = "Loại kính";
            // 
            // txtLoaiKinh
            // 
            txtLoaiKinh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLoaiKinh.BackColor = Color.FromArgb(248, 250, 252);
            txtLoaiKinh.BorderStyle = BorderStyle.FixedSingle;
            txtLoaiKinh.Font = new Font("Segoe UI", 9F);
            txtLoaiKinh.Location = new Point(148, 3);
            txtLoaiKinh.Name = "txtLoaiKinh";
            txtLoaiKinh.ReadOnly = true;
            txtLoaiKinh.Size = new Size(480, 31);
            txtLoaiKinh.TabIndex = 1;
            // 
            // lblDoChiuNuoc
            // 
            lblDoChiuNuoc.Anchor = AnchorStyles.Left;
            lblDoChiuNuoc.AutoSize = true;
            lblDoChiuNuoc.Font = new Font("Segoe UI", 9F);
            lblDoChiuNuoc.Location = new Point(3, 44);
            lblDoChiuNuoc.Name = "lblDoChiuNuoc";
            lblDoChiuNuoc.Size = new Size(118, 25);
            lblDoChiuNuoc.TabIndex = 2;
            lblDoChiuNuoc.Text = "Độ chịu nước";
            // 
            // txtDoChiuNuoc
            // 
            txtDoChiuNuoc.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDoChiuNuoc.BackColor = Color.FromArgb(248, 250, 252);
            txtDoChiuNuoc.BorderStyle = BorderStyle.FixedSingle;
            txtDoChiuNuoc.Font = new Font("Segoe UI", 9F);
            txtDoChiuNuoc.Location = new Point(148, 41);
            txtDoChiuNuoc.Name = "txtDoChiuNuoc";
            txtDoChiuNuoc.ReadOnly = true;
            txtDoChiuNuoc.Size = new Size(480, 31);
            txtDoChiuNuoc.TabIndex = 3;
            // 
            // lblLoaiDay
            // 
            lblLoaiDay.Anchor = AnchorStyles.Left;
            lblLoaiDay.AutoSize = true;
            lblLoaiDay.Font = new Font("Segoe UI", 9F);
            lblLoaiDay.Location = new Point(3, 82);
            lblLoaiDay.Name = "lblLoaiDay";
            lblLoaiDay.Size = new Size(78, 25);
            lblLoaiDay.TabIndex = 4;
            lblLoaiDay.Text = "Loại dây";
            // 
            // txtLoaiDay
            // 
            txtLoaiDay.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLoaiDay.BackColor = Color.FromArgb(248, 250, 252);
            txtLoaiDay.BorderStyle = BorderStyle.FixedSingle;
            txtLoaiDay.Font = new Font("Segoe UI", 9F);
            txtLoaiDay.Location = new Point(148, 79);
            txtLoaiDay.Name = "txtLoaiDay";
            txtLoaiDay.ReadOnly = true;
            txtLoaiDay.Size = new Size(480, 31);
            txtLoaiDay.TabIndex = 5;
            // 
            // lblKichThuocMat
            // 
            lblKichThuocMat.Anchor = AnchorStyles.Left;
            lblKichThuocMat.AutoSize = true;
            lblKichThuocMat.Font = new Font("Segoe UI", 9F);
            lblKichThuocMat.Location = new Point(3, 120);
            lblKichThuocMat.Name = "lblKichThuocMat";
            lblKichThuocMat.Size = new Size(131, 25);
            lblKichThuocMat.TabIndex = 6;
            lblKichThuocMat.Text = "Kích thước mặt";
            // 
            // txtKichThuocMat
            // 
            txtKichThuocMat.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtKichThuocMat.BackColor = Color.FromArgb(248, 250, 252);
            txtKichThuocMat.BorderStyle = BorderStyle.FixedSingle;
            txtKichThuocMat.Font = new Font("Segoe UI", 9F);
            txtKichThuocMat.Location = new Point(148, 117);
            txtKichThuocMat.Name = "txtKichThuocMat";
            txtKichThuocMat.ReadOnly = true;
            txtKichThuocMat.Size = new Size(480, 31);
            txtKichThuocMat.TabIndex = 7;
            // 
            // lblTenThuongHieuTS
            // 
            lblTenThuongHieuTS.Anchor = AnchorStyles.Left;
            lblTenThuongHieuTS.AutoSize = true;
            lblTenThuongHieuTS.Font = new Font("Segoe UI", 9F);
            lblTenThuongHieuTS.Location = new Point(3, 152);
            lblTenThuongHieuTS.Name = "lblTenThuongHieuTS";
            lblTenThuongHieuTS.Size = new Size(107, 38);
            lblTenThuongHieuTS.TabIndex = 8;
            lblTenThuongHieuTS.Text = "Tên thương hiệu";
            // 
            // txtTenThuongHieuTS
            // 
            txtTenThuongHieuTS.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenThuongHieuTS.BackColor = Color.FromArgb(248, 250, 252);
            txtTenThuongHieuTS.BorderStyle = BorderStyle.FixedSingle;
            txtTenThuongHieuTS.Font = new Font("Segoe UI", 9F);
            txtTenThuongHieuTS.Location = new Point(148, 155);
            txtTenThuongHieuTS.Name = "txtTenThuongHieuTS";
            txtTenThuongHieuTS.ReadOnly = true;
            txtTenThuongHieuTS.Size = new Size(480, 31);
            txtTenThuongHieuTS.TabIndex = 9;
            // 
            // groupHinhAnh
            // 
            groupHinhAnh.Controls.Add(picHinhAnh);
            groupHinhAnh.Dock = DockStyle.Fill;
            groupHinhAnh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupHinhAnh.Location = new Point(668, 3);
            groupHinhAnh.Name = "groupHinhAnh";
            groupHinhAnh.Padding = new Padding(14, 10, 14, 10);
            groupHinhAnh.Size = new Size(477, 294);
            groupHinhAnh.TabIndex = 2;
            groupHinhAnh.TabStop = false;
            groupHinhAnh.Text = "Hình ảnh sản phẩm";
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.FromArgb(248, 250, 252);
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Dock = DockStyle.Fill;
            picHinhAnh.Location = new Point(14, 34);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(449, 250);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 0;
            picHinhAnh.TabStop = false;
            // 
            // groupGhiChu
            // 
            groupGhiChu.Controls.Add(rtbGhiChu);
            groupGhiChu.Dock = DockStyle.Fill;
            groupGhiChu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupGhiChu.Location = new Point(668, 303);
            groupGhiChu.Name = "groupGhiChu";
            groupGhiChu.Padding = new Padding(14, 10, 14, 10);
            groupGhiChu.Size = new Size(477, 230);
            groupGhiChu.TabIndex = 3;
            groupGhiChu.TabStop = false;
            groupGhiChu.Text = "Ghi chú / mô tả thêm";
            // 
            // rtbGhiChu
            // 
            rtbGhiChu.BackColor = Color.FromArgb(248, 250, 252);
            rtbGhiChu.BorderStyle = BorderStyle.FixedSingle;
            rtbGhiChu.Dock = DockStyle.Fill;
            rtbGhiChu.Font = new Font("Segoe UI", 9F);
            rtbGhiChu.Location = new Point(14, 34);
            rtbGhiChu.Name = "rtbGhiChu";
            rtbGhiChu.ReadOnly = true;
            rtbGhiChu.Size = new Size(449, 186);
            rtbGhiChu.TabIndex = 0;
            rtbGhiChu.Text = "";
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(248, 250, 252);
            panelActions.Controls.Add(btnDong);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 652);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(16, 10, 16, 10);
            panelActions.Size = new Size(1180, 68);
            panelActions.TabIndex = 2;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Right;
            btnDong.BackColor = Color.White;
            btnDong.DialogResult = DialogResult.Cancel;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Location = new Point(1034, 14);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(130, 40);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // frmXemThongTinSanPham
            // 
            AcceptButton = btnDong;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnDong;
            ClientSize = new Size(1180, 720);
            Controls.Add(panelMain);
            Controls.Add(panelActions);
            Controls.Add(panelHeader);
            MinimumSize = new Size(1100, 700);
            Name = "frmXemThongTinSanPham";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Xem thông số kỹ thuật sản phẩm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            tableLayoutRoot.ResumeLayout(false);
            groupThongTinSanPham.ResumeLayout(false);
            tableThongTinSanPham.ResumeLayout(false);
            tableThongTinSanPham.PerformLayout();
            groupThongSoKyThuat.ResumeLayout(false);
            tableThongSoKyThuat.ResumeLayout(false);
            tableThongSoKyThuat.PerformLayout();
            groupHinhAnh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            groupGhiChu.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}