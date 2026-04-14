namespace LTQL_QLBHDongHo.Forms
{
    partial class frmBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.GroupBox grpProducts;
        private System.Windows.Forms.GroupBox grpCart;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Label lblTamTinhValue;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblGiamGiaValue;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblTongValue;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlSummary;

        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtKhachHangPhone;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMain;

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
            pnlTop = new Panel();
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblKhachHang = new Label();
            cboKhachHang = new ComboBox();
            lblSoDienThoai = new Label();
            txtKhachHangPhone = new TextBox();
            pnlMain = new Panel();
            tlpMain = new TableLayoutPanel();
            grpProducts = new GroupBox();
            btnAdd = new Button();
            nudQuantity = new NumericUpDown();
            lblSoLuong = new Label();
            dgvProducts = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            textBox5 = new TextBox();
            lblThuongHieu = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            lblDoChiuNuoc = new Label();
            lblLoaiDongHo = new Label();
            lblKichThuocMat = new Label();
            textBox1 = new TextBox();
            lblLoaiDay = new Label();
            picHinhAnh = new PictureBox();
            grpCart = new GroupBox();
            btnCheckout = new Button();
            pnlSummary = new Panel();
            lblTongValue = new Label();
            lblTong = new Label();
            lblGiamGiaValue = new Label();
            lblGiamGia = new Label();
            lblTamTinhValue = new Label();
            lblTamTinh = new Label();
            btnRemove = new Button();
            dgvCart = new DataGridView();
            pnlBottom = new Panel();
            lblNhanVien = new Label();
            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            tlpMain.SuspendLayout();
            grpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            grpCart.SuspendLayout();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(lblKhachHang);
            pnlTop.Controls.Add(cboKhachHang);
            pnlTop.Controls.Add(lblSoDienThoai);
            pnlTop.Controls.Add(txtKhachHangPhone);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(16, 12, 16, 12);
            pnlTop.Size = new Size(1924, 104);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(20, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(163, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁN HÀNG";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F);
            lblSearch.Location = new Point(20, 62);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(84, 25);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(108, 58);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên sản phẩm...";
            txtSearch.Size = new Size(330, 31);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(13, 110, 253);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(446, 57);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(86, 33);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Font = new Font("Segoe UI", 9F);
            lblKhachHang.Location = new Point(1025, 61);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(104, 25);
            lblKhachHang.TabIndex = 4;
            lblKhachHang.Text = "Khách hàng";
            // 
            // cboKhachHang
            // 
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(1144, 57);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(290, 33);
            cboKhachHang.TabIndex = 5;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 9F);
            lblSoDienThoai.Location = new Point(571, 62);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(117, 25);
            lblSoDienThoai.TabIndex = 6;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtKhachHangPhone
            // 
            txtKhachHangPhone.Location = new Point(695, 58);
            txtKhachHangPhone.Name = "txtKhachHangPhone";
            txtKhachHangPhone.PlaceholderText = "Nhập số điện thoại khách hàng";
            txtKhachHangPhone.Size = new Size(312, 31);
            txtKhachHangPhone.TabIndex = 7;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(245, 247, 250);
            pnlMain.Controls.Add(tlpMain);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 104);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16, 10, 16, 10);
            pnlMain.Size = new Size(1924, 618);
            pnlMain.TabIndex = 1;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 3;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            tlpMain.Controls.Add(grpProducts, 0, 0);
            tlpMain.Controls.Add(groupBox1, 1, 0);
            tlpMain.Controls.Add(grpCart, 2, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(16, 10);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1892, 598);
            tlpMain.TabIndex = 0;
            // 
            // grpProducts
            // 
            grpProducts.Controls.Add(btnAdd);
            grpProducts.Controls.Add(nudQuantity);
            grpProducts.Controls.Add(lblSoLuong);
            grpProducts.Controls.Add(dgvProducts);
            grpProducts.Dock = DockStyle.Fill;
            grpProducts.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpProducts.Location = new Point(3, 3);
            grpProducts.Name = "grpProducts";
            grpProducts.Padding = new Padding(14, 10, 14, 14);
            grpProducts.Size = new Size(1015, 592);
            grpProducts.TabIndex = 0;
            grpProducts.TabStop = false;
            grpProducts.Text = "Danh sách sản phẩm";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(25, 135, 84);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(881, 551);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(131, 35);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm vào giỏ";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // nudQuantity
            // 
            nudQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nudQuantity.Location = new Point(753, 552);
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(120, 34);
            nudQuantity.TabIndex = 2;
            nudQuantity.TextAlign = HorizontalAlignment.Center;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            lblSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 9F);
            lblSoLuong.Location = new Point(658, 558);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(89, 25);
            lblSoLuong.TabIndex = 1;
            lblSoLuong.Text = "Số lượng:";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeight = 36;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSanPham, DonGia });
            dgvProducts.Location = new Point(17, 40);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.RowTemplate.Height = 32;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(995, 500);
            dgvProducts.TabIndex = 0;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "ID";
            MaSP.HeaderText = "Mã sản phẩm";
            MaSP.MinimumWidth = 8;
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.MinimumWidth = 8;
            TenSanPham.Name = "TenSanPham";
            TenSanPham.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 8;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(lblThuongHieu);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(lblDoChiuNuoc);
            groupBox1.Controls.Add(lblLoaiDongHo);
            groupBox1.Controls.Add(lblKichThuocMat);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lblLoaiDay);
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox1.Location = new Point(1024, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(429, 592);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(164, 280);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(243, 34);
            textBox5.TabIndex = 31;
            // 
            // lblThuongHieu
            // 
            lblThuongHieu.Anchor = AnchorStyles.Left;
            lblThuongHieu.AutoSize = true;
            lblThuongHieu.Font = new Font("Segoe UI", 9F);
            lblThuongHieu.Location = new Point(23, 291);
            lblThuongHieu.Name = "lblThuongHieu";
            lblThuongHieu.Size = new Size(112, 25);
            lblThuongHieu.TabIndex = 30;
            lblThuongHieu.Text = "Thương hiệu\r\n";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(164, 532);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(243, 34);
            textBox4.TabIndex = 29;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(164, 405);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(243, 34);
            textBox3.TabIndex = 28;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(164, 341);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(243, 34);
            textBox2.TabIndex = 27;
            // 
            // lblDoChiuNuoc
            // 
            lblDoChiuNuoc.Anchor = AnchorStyles.Left;
            lblDoChiuNuoc.AutoSize = true;
            lblDoChiuNuoc.Font = new Font("Segoe UI", 9F);
            lblDoChiuNuoc.Location = new Point(22, 536);
            lblDoChiuNuoc.Name = "lblDoChiuNuoc";
            lblDoChiuNuoc.Size = new Size(118, 25);
            lblDoChiuNuoc.TabIndex = 26;
            lblDoChiuNuoc.Text = "Độ chịu nước";
            // 
            // lblLoaiDongHo
            // 
            lblLoaiDongHo.Anchor = AnchorStyles.Left;
            lblLoaiDongHo.AutoSize = true;
            lblLoaiDongHo.Font = new Font("Segoe UI", 9F);
            lblLoaiDongHo.Location = new Point(22, 474);
            lblLoaiDongHo.Name = "lblLoaiDongHo";
            lblLoaiDongHo.Size = new Size(118, 25);
            lblLoaiDongHo.TabIndex = 25;
            lblLoaiDongHo.Text = "Loại đồng hồ";
            // 
            // lblKichThuocMat
            // 
            lblKichThuocMat.Anchor = AnchorStyles.Left;
            lblKichThuocMat.AutoSize = true;
            lblKichThuocMat.Font = new Font("Segoe UI", 9F);
            lblKichThuocMat.Location = new Point(22, 410);
            lblKichThuocMat.Name = "lblKichThuocMat";
            lblKichThuocMat.Size = new Size(79, 25);
            lblKichThuocMat.TabIndex = 24;
            lblKichThuocMat.Text = "Size mặt";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(164, 469);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(243, 34);
            textBox1.TabIndex = 23;
            // 
            // lblLoaiDay
            // 
            lblLoaiDay.Anchor = AnchorStyles.Left;
            lblLoaiDay.AutoSize = true;
            lblLoaiDay.Font = new Font("Segoe UI", 9F);
            lblLoaiDay.Location = new Point(23, 347);
            lblLoaiDay.Name = "lblLoaiDay";
            lblLoaiDay.Size = new Size(78, 25);
            lblLoaiDay.TabIndex = 22;
            lblLoaiDay.Text = "Loại dây";
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.White;
            picHinhAnh.Location = new Point(22, 36);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(385, 226);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 21;
            picHinhAnh.TabStop = false;
            picHinhAnh.Click += picHinhAnh_Click;
            // 
            // grpCart
            // 
            grpCart.Controls.Add(btnCheckout);
            grpCart.Controls.Add(pnlSummary);
            grpCart.Controls.Add(btnRemove);
            grpCart.Controls.Add(dgvCart);
            grpCart.Dock = DockStyle.Fill;
            grpCart.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpCart.Location = new Point(1459, 3);
            grpCart.Name = "grpCart";
            grpCart.Padding = new Padding(14, 10, 14, 14);
            grpCart.Size = new Size(430, 592);
            grpCart.TabIndex = 2;
            grpCart.TabStop = false;
            grpCart.Text = "Danh sách sản phẩm đã chọn";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(220, 53, 69);
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(17, 547);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(396, 37);
            btnCheckout.TabIndex = 3;
            btnCheckout.Text = "Thanh toán";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(249, 250, 252);
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(lblTongValue);
            pnlSummary.Controls.Add(lblTong);
            pnlSummary.Controls.Add(lblGiamGiaValue);
            pnlSummary.Controls.Add(lblGiamGia);
            pnlSummary.Controls.Add(lblTamTinhValue);
            pnlSummary.Controls.Add(lblTamTinh);
            pnlSummary.Location = new Point(17, 404);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(396, 132);
            pnlSummary.TabIndex = 2;
            // 
            // lblTongValue
            // 
            lblTongValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongValue.ForeColor = Color.FromArgb(220, 53, 69);
            lblTongValue.Location = new Point(247, 93);
            lblTongValue.Name = "lblTongValue";
            lblTongValue.Size = new Size(137, 28);
            lblTongValue.TabIndex = 5;
            lblTongValue.Text = "0 đ";
            lblTongValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTong
            // 
            lblTong.AutoSize = true;
            lblTong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTong.Location = new Point(14, 93);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(60, 28);
            lblTong.TabIndex = 4;
            lblTong.Text = "Tổng";
            // 
            // lblGiamGiaValue
            // 
            lblGiamGiaValue.Location = new Point(247, 52);
            lblGiamGiaValue.Name = "lblGiamGiaValue";
            lblGiamGiaValue.Size = new Size(137, 28);
            lblGiamGiaValue.TabIndex = 3;
            lblGiamGiaValue.Text = "0 đ";
            lblGiamGiaValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGiamGia
            // 
            lblGiamGia.AutoSize = true;
            lblGiamGia.Font = new Font("Segoe UI", 9F);
            lblGiamGia.Location = new Point(14, 52);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(82, 25);
            lblGiamGia.TabIndex = 2;
            lblGiamGia.Text = "Giảm giá";
            // 
            // lblTamTinhValue
            // 
            lblTamTinhValue.Location = new Point(247, 14);
            lblTamTinhValue.Name = "lblTamTinhValue";
            lblTamTinhValue.Size = new Size(137, 28);
            lblTamTinhValue.TabIndex = 1;
            lblTamTinhValue.Text = "0 đ";
            lblTamTinhValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTamTinh
            // 
            lblTamTinh.AutoSize = true;
            lblTamTinh.Font = new Font("Segoe UI", 9F);
            lblTamTinh.Location = new Point(14, 14);
            lblTamTinh.Name = "lblTamTinh";
            lblTamTinh.Size = new Size(81, 25);
            lblTamTinh.TabIndex = 0;
            lblTamTinh.Text = "Tạm tính";
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(108, 117, 125);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(17, 361);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(396, 35);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "Xóa sản phẩm đã chọn khỏi giỏ";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersHeight = 36;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCart.Location = new Point(17, 37);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 62;
            dgvCart.RowTemplate.Height = 32;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(396, 316);
            dgvCart.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(lblNhanVien);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 722);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(16, 8, 16, 8);
            pnlBottom.Size = new Size(1924, 42);
            pnlBottom.TabIndex = 2;
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNhanVien.ForeColor = Color.FromArgb(70, 70, 70);
            lblNhanVien.Location = new Point(20, 8);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(102, 25);
            lblNhanVien.TabIndex = 0;
            lblNhanVien.Text = "NV bán: ---";
            // 
            // frmBanHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1924, 764);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBanHang";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bán hàng";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlMain.ResumeLayout(false);
            tlpMain.ResumeLayout(false);
            grpProducts.ResumeLayout(false);
            grpProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            grpCart.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private PictureBox picHinhAnh;
        private TextBox textBox1;
        private Label lblLoaiDay;
        private Label lblKichThuocMat;
        private Label lblLoaiDongHo;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label lblDoChiuNuoc;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn DonGia;
        private TextBox textBox5;
        private Label lblThuongHieu;
    }
}