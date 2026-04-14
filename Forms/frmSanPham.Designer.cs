namespace LTQL_QLBHDongHo.Forms
{
    partial class frmSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDesc;

        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutInfo;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblThuongHieu;
        private System.Windows.Forms.ComboBox cboThuongHieu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblKieuDang;
        private System.Windows.Forms.ComboBox cboKieuDang;

        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnDoiAnh;

        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnThemSp;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXem;

        private System.Windows.Forms.Panel panelListTop;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

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
            lblHeaderDesc = new Label();
            lblHeaderTitle = new Label();
            groupInfo = new GroupBox();
            panelImage = new Panel();
            btnDoiAnh = new Button();
            btnChonAnh = new Button();
            picHinhAnh = new PictureBox();
            btnNhapThongSoKyThuat = new Button();
            tableLayoutInfo = new TableLayoutPanel();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblGiaBan = new Label();
            txtGiaBan = new TextBox();
            lblThuongHieu = new Label();
            cboThuongHieu = new ComboBox();
            lblSoLuong = new Label();
            numSoLuong = new NumericUpDown();
            lblKieuDang = new Label();
            cboKieuDang = new ComboBox();
            panelActions = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnThemSp = new Button();
            btnSuaSP = new Button();
            btnXoaSP = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            btnXem = new Button();
            panelListTop = new Panel();
            textBox1 = new TextBox();
            btnTimKiem = new Button();
            lblListTitle = new Label();
            dgvDanhSach = new DataGridView();
            cStt = new DataGridViewTextBoxColumn();
            cMaSP = new DataGridViewTextBoxColumn();
            cTen = new DataGridViewTextBoxColumn();
            cThuongHieu = new DataGridViewTextBoxColumn();
            cKd = new DataGridViewTextBoxColumn();
            cGia = new DataGridViewTextBoxColumn();
            cSoLuong = new DataGridViewTextBoxColumn();
            Anh = new DataGridViewImageColumn();
            openFileDialog1 = new OpenFileDialog();
            panelHeader.SuspendLayout();
            groupInfo.SuspendLayout();
            panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            tableLayoutInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            panelActions.SuspendLayout();
            flowButtons.SuspendLayout();
            panelListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(32, 99, 155);
            panelHeader.Controls.Add(lblHeaderDesc);
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 14, 20, 14);
            panelHeader.Size = new Size(1280, 88);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderDesc
            // 
            lblHeaderDesc.AutoSize = true;
            lblHeaderDesc.Font = new Font("Segoe UI", 9F);
            lblHeaderDesc.ForeColor = Color.WhiteSmoke;
            lblHeaderDesc.Location = new Point(24, 49);
            lblHeaderDesc.Name = "lblHeaderDesc";
            lblHeaderDesc.Size = new Size(403, 25);
            lblHeaderDesc.TabIndex = 1;
            lblHeaderDesc.Text = "Quản lý danh mục sản phẩm đồng bộ với dữ liệu";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(22, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(254, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // groupInfo
            // 
            groupInfo.Controls.Add(panelImage);
            groupInfo.Controls.Add(btnNhapThongSoKyThuat);
            groupInfo.Controls.Add(tableLayoutInfo);
            groupInfo.Dock = DockStyle.Top;
            groupInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupInfo.Location = new Point(0, 88);
            groupInfo.Name = "groupInfo";
            groupInfo.Padding = new Padding(16, 12, 16, 12);
            groupInfo.Size = new Size(1280, 353);
            groupInfo.TabIndex = 1;
            groupInfo.TabStop = false;
            groupInfo.Text = "Thông tin sản phẩm";
            // 
            // panelImage
            // 
            panelImage.Controls.Add(btnDoiAnh);
            panelImage.Controls.Add(btnChonAnh);
            panelImage.Controls.Add(picHinhAnh);
            panelImage.Dock = DockStyle.Right;
            panelImage.Location = new Point(826, 36);
            panelImage.Name = "panelImage";
            panelImage.Padding = new Padding(12, 0, 0, 0);
            panelImage.Size = new Size(438, 305);
            panelImage.TabIndex = 1;
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.BackColor = Color.White;
            btnDoiAnh.FlatStyle = FlatStyle.Flat;
            btnDoiAnh.Font = new Font("Segoe UI", 9F);
            btnDoiAnh.Location = new Point(248, 259);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(124, 40);
            btnDoiAnh.TabIndex = 2;
            btnDoiAnh.Text = "Đổi ảnh";
            btnDoiAnh.UseVisualStyleBackColor = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.FromArgb(32, 99, 155);
            btnChonAnh.FlatAppearance.BorderSize = 0;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(84, 259);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(126, 40);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.FromArgb(248, 250, 252);
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Location = new Point(12, 5);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(423, 245);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 0;
            picHinhAnh.TabStop = false;
            // 
            // btnNhapThongSoKyThuat
            // 
            btnNhapThongSoKyThuat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNhapThongSoKyThuat.BackColor = Color.FromArgb(15, 118, 110);
            btnNhapThongSoKyThuat.FlatAppearance.BorderSize = 0;
            btnNhapThongSoKyThuat.FlatStyle = FlatStyle.Flat;
            btnNhapThongSoKyThuat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNhapThongSoKyThuat.ForeColor = Color.White;
            btnNhapThongSoKyThuat.Location = new Point(16, 293);
            btnNhapThongSoKyThuat.Name = "btnNhapThongSoKyThuat";
            btnNhapThongSoKyThuat.Size = new Size(804, 44);
            btnNhapThongSoKyThuat.TabIndex = 1;
            btnNhapThongSoKyThuat.Text = "Nhập thông số kỹ thuật";
            btnNhapThongSoKyThuat.UseVisualStyleBackColor = false;
            // 
            // tableLayoutInfo
            // 
            tableLayoutInfo.Anchor = AnchorStyles.None;
            tableLayoutInfo.ColumnCount = 4;
            tableLayoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tableLayoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            tableLayoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutInfo.Controls.Add(lblMaSP, 0, 0);
            tableLayoutInfo.Controls.Add(txtMaSP, 1, 0);
            tableLayoutInfo.Controls.Add(lblTenSP, 0, 1);
            tableLayoutInfo.Controls.Add(txtTenSP, 1, 1);
            tableLayoutInfo.Controls.Add(lblGiaBan, 0, 2);
            tableLayoutInfo.Controls.Add(txtGiaBan, 1, 2);
            tableLayoutInfo.Controls.Add(lblThuongHieu, 0, 3);
            tableLayoutInfo.Controls.Add(cboThuongHieu, 1, 3);
            tableLayoutInfo.Controls.Add(lblSoLuong, 0, 4);
            tableLayoutInfo.Controls.Add(numSoLuong, 1, 4);
            tableLayoutInfo.Controls.Add(lblKieuDang, 2, 4);
            tableLayoutInfo.Controls.Add(cboKieuDang, 3, 4);
            tableLayoutInfo.Location = new Point(16, 36);
            tableLayoutInfo.Name = "tableLayoutInfo";
            tableLayoutInfo.RowCount = 5;
            tableLayoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutInfo.Size = new Size(807, 250);
            tableLayoutInfo.TabIndex = 0;
            // 
            // lblMaSP
            // 
            lblMaSP.Anchor = AnchorStyles.Left;
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI", 9F);
            lblMaSP.Location = new Point(3, 8);
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
            tableLayoutInfo.SetColumnSpan(txtMaSP, 3);
            txtMaSP.Font = new Font("Segoe UI", 9F);
            txtMaSP.Location = new Point(163, 5);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(641, 31);
            txtMaSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            lblTenSP.Anchor = AnchorStyles.Left;
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI", 9F);
            lblTenSP.Location = new Point(3, 52);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(121, 25);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên sản phẩm";
            // 
            // txtTenSP
            // 
            txtTenSP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenSP.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutInfo.SetColumnSpan(txtTenSP, 3);
            txtTenSP.Font = new Font("Segoe UI", 9F);
            txtTenSP.Location = new Point(163, 49);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(641, 31);
            txtTenSP.TabIndex = 3;
            // 
            // lblGiaBan
            // 
            lblGiaBan.Anchor = AnchorStyles.Left;
            lblGiaBan.AutoSize = true;
            lblGiaBan.Font = new Font("Segoe UI", 9F);
            lblGiaBan.Location = new Point(3, 98);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(72, 25);
            lblGiaBan.TabIndex = 4;
            lblGiaBan.Text = "Giá bán";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtGiaBan.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutInfo.SetColumnSpan(txtGiaBan, 3);
            txtGiaBan.Font = new Font("Segoe UI", 9F);
            txtGiaBan.Location = new Point(163, 95);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(641, 31);
            txtGiaBan.TabIndex = 5;
            // 
            // lblThuongHieu
            // 
            lblThuongHieu.Anchor = AnchorStyles.Left;
            lblThuongHieu.AutoSize = true;
            lblThuongHieu.Font = new Font("Segoe UI", 9F);
            lblThuongHieu.Location = new Point(3, 144);
            lblThuongHieu.Name = "lblThuongHieu";
            lblThuongHieu.Size = new Size(112, 25);
            lblThuongHieu.TabIndex = 6;
            lblThuongHieu.Text = "Thương hiệu";
            // 
            // cboThuongHieu
            // 
            cboThuongHieu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutInfo.SetColumnSpan(cboThuongHieu, 3);
            cboThuongHieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThuongHieu.Font = new Font("Segoe UI", 9F);
            cboThuongHieu.FormattingEnabled = true;
            cboThuongHieu.Location = new Point(163, 140);
            cboThuongHieu.Name = "cboThuongHieu";
            cboThuongHieu.Size = new Size(641, 33);
            cboThuongHieu.TabIndex = 7;
            // 
            // lblSoLuong
            // 
            lblSoLuong.Anchor = AnchorStyles.Left;
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 9F);
            lblSoLuong.Location = new Point(3, 202);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(85, 25);
            lblSoLuong.TabIndex = 8;
            lblSoLuong.Text = "Số lượng";
            // 
            // numSoLuong
            // 
            numSoLuong.Anchor = AnchorStyles.Left;
            numSoLuong.Font = new Font("Segoe UI", 9F);
            numSoLuong.Location = new Point(163, 199);
            numSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(234, 31);
            numSoLuong.TabIndex = 9;
            // 
            // lblKieuDang
            // 
            lblKieuDang.Anchor = AnchorStyles.Left;
            lblKieuDang.AutoSize = true;
            lblKieuDang.Font = new Font("Segoe UI", 9F);
            lblKieuDang.Location = new Point(403, 202);
            lblKieuDang.Name = "lblKieuDang";
            lblKieuDang.Size = new Size(91, 25);
            lblKieuDang.TabIndex = 10;
            lblKieuDang.Text = "Kiểu dáng";
            // 
            // cboKieuDang
            // 
            cboKieuDang.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboKieuDang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKieuDang.Font = new Font("Segoe UI", 9F);
            cboKieuDang.FormattingEnabled = true;
            cboKieuDang.Location = new Point(543, 198);
            cboKieuDang.Name = "cboKieuDang";
            cboKieuDang.Size = new Size(261, 33);
            cboKieuDang.TabIndex = 11;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(248, 250, 252);
            panelActions.Controls.Add(flowButtons);
            panelActions.Dock = DockStyle.Top;
            panelActions.Location = new Point(0, 441);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(16, 10, 16, 10);
            panelActions.Size = new Size(1280, 72);
            panelActions.TabIndex = 2;
            // 
            // flowButtons
            // 
            flowButtons.Controls.Add(btnThemSp);
            flowButtons.Controls.Add(btnSuaSP);
            flowButtons.Controls.Add(btnXoaSP);
            flowButtons.Controls.Add(btnLuu);
            flowButtons.Controls.Add(btnHuy);
            flowButtons.Controls.Add(btnXem);
            flowButtons.Dock = DockStyle.Left;
            flowButtons.Location = new Point(16, 10);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(658, 52);
            flowButtons.TabIndex = 0;
            // 
            // btnThemSp
            // 
            btnThemSp.BackColor = Color.White;
            btnThemSp.FlatStyle = FlatStyle.Flat;
            btnThemSp.Location = new Point(3, 3);
            btnThemSp.Name = "btnThemSp";
            btnThemSp.Size = new Size(120, 44);
            btnThemSp.TabIndex = 0;
            btnThemSp.Text = "Thêm mới";
            btnThemSp.UseVisualStyleBackColor = false;
            btnThemSp.Click += btnThemSp_Click;
            // 
            // btnSuaSP
            // 
            btnSuaSP.BackColor = Color.White;
            btnSuaSP.FlatStyle = FlatStyle.Flat;
            btnSuaSP.Location = new Point(129, 3);
            btnSuaSP.Name = "btnSuaSP";
            btnSuaSP.Size = new Size(100, 44);
            btnSuaSP.TabIndex = 1;
            btnSuaSP.Text = "Sửa";
            btnSuaSP.UseVisualStyleBackColor = false;
            btnSuaSP.Click += btnSuaSP_Click;
            // 
            // btnXoaSP
            // 
            btnXoaSP.BackColor = Color.White;
            btnXoaSP.FlatStyle = FlatStyle.Flat;
            btnXoaSP.Location = new Point(235, 3);
            btnXoaSP.Name = "btnXoaSP";
            btnXoaSP.Size = new Size(100, 44);
            btnXoaSP.TabIndex = 2;
            btnXoaSP.Text = "Xóa";
            btnXoaSP.UseVisualStyleBackColor = false;
            btnXoaSP.Click += btnXoaSP_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(32, 99, 155);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(341, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 44);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Location = new Point(447, 3);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 44);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.White;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Location = new Point(553, 3);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(100, 44);
            btnXem.TabIndex = 5;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = false;
            // 
            // panelListTop
            // 
            panelListTop.Controls.Add(textBox1);
            panelListTop.Controls.Add(btnTimKiem);
            panelListTop.Controls.Add(lblListTitle);
            panelListTop.Dock = DockStyle.Top;
            panelListTop.Location = new Point(0, 513);
            panelListTop.Name = "panelListTop";
            panelListTop.Padding = new Padding(16, 10, 16, 10);
            panelListTop.Size = new Size(1280, 62);
            panelListTop.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(860, 14);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập từ khóa tìm kiếm...";
            textBox1.Size = new Size(292, 31);
            textBox1.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Location = new Point(1158, 13);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(106, 33);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblListTitle.Location = new Point(16, 16);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(282, 28);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Danh sách sản phẩm hiện có";
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.BackgroundColor = Color.White;
            dgvDanhSach.BorderStyle = BorderStyle.None;
            dgvDanhSach.ColumnHeadersHeight = 38;
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDanhSach.Columns.AddRange(new DataGridViewColumn[] { cStt, cMaSP, cTen, cThuongHieu, cKd, cGia, cSoLuong, Anh });
            dgvDanhSach.Dock = DockStyle.Fill;
            dgvDanhSach.Location = new Point(0, 575);
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.RowHeadersVisible = false;
            dgvDanhSach.RowHeadersWidth = 62;
            dgvDanhSach.RowTemplate.Height = 34;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.Size = new Size(1280, 245);
            dgvDanhSach.TabIndex = 4;
            // 
            // cStt
            // 
            cStt.FillWeight = 8F;
            cStt.HeaderText = "STT";
            cStt.MinimumWidth = 8;
            cStt.Name = "cStt";
            cStt.ReadOnly = true;
            // 
            // cMaSP
            // 
            cMaSP.DataPropertyName = "MaSP";
            cMaSP.FillWeight = 14F;
            cMaSP.HeaderText = "MÃ SP";
            cMaSP.MinimumWidth = 8;
            cMaSP.Name = "cMaSP";
            cMaSP.ReadOnly = true;
            // 
            // cTen
            // 
            cTen.DataPropertyName = "TenSanPham";
            cTen.FillWeight = 34F;
            cTen.HeaderText = "TÊN ĐỒNG HỒ";
            cTen.MinimumWidth = 8;
            cTen.Name = "cTen";
            cTen.ReadOnly = true;
            // 
            // cThuongHieu
            // 
            cThuongHieu.DataPropertyName = "ThuongHieu";
            cThuongHieu.FillWeight = 22F;
            cThuongHieu.HeaderText = "THƯƠNG HIỆU";
            cThuongHieu.MinimumWidth = 8;
            cThuongHieu.Name = "cThuongHieu";
            cThuongHieu.ReadOnly = true;
            // 
            // cKd
            // 
            cKd.FillWeight = 13F;
            cKd.HeaderText = "KIỂU DÁNG";
            cKd.MinimumWidth = 8;
            cKd.Name = "cKd";
            cKd.ReadOnly = true;
            // 
            // cGia
            // 
            cGia.DataPropertyName = "DonGia";
            cGia.FillWeight = 14F;
            cGia.HeaderText = "GIÁ BÁN";
            cGia.MinimumWidth = 8;
            cGia.Name = "cGia";
            cGia.ReadOnly = true;
            // 
            // cSoLuong
            // 
            cSoLuong.DataPropertyName = "SoLuong";
            cSoLuong.FillWeight = 10F;
            cSoLuong.HeaderText = "SỐ LƯỢNG";
            cSoLuong.MinimumWidth = 8;
            cSoLuong.Name = "cSoLuong";
            cSoLuong.ReadOnly = true;
            // 
            // Anh
            // 
            Anh.FillWeight = 12F;
            Anh.HeaderText = "ẢNH";
            Anh.MinimumWidth = 8;
            Anh.Name = "Anh";
            Anh.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 820);
            Controls.Add(dgvDanhSach);
            Controls.Add(panelListTop);
            Controls.Add(panelActions);
            Controls.Add(groupInfo);
            Controls.Add(panelHeader);
            MinimumSize = new Size(1180, 760);
            Name = "frmSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupInfo.ResumeLayout(false);
            panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            tableLayoutInfo.ResumeLayout(false);
            tableLayoutInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            panelActions.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            panelListTop.ResumeLayout(false);
            panelListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNhapThongSoKyThuat;
        private DataGridViewTextBoxColumn cStt;
        private DataGridViewTextBoxColumn cMaSP;
        private DataGridViewTextBoxColumn cTen;
        private DataGridViewTextBoxColumn cThuongHieu;
        private DataGridViewTextBoxColumn cKd;
        private DataGridViewTextBoxColumn cGia;
        private DataGridViewTextBoxColumn cSoLuong;
        private DataGridViewImageColumn Anh;
    }
}