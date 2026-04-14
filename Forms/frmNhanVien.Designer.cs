namespace LTQL_QLBHDongHo.Forms
{
    partial class frmNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblSubTitle = new Label();
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            btnTimKiem = new Button();
            btnThoat = new Button();
            flpPrimaryActions = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuyBo = new Button();
            cboQuyenHan = new ComboBox();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtDiaChi = new TextBox();
            label3 = new Label();
            txtDienThoai = new TextBox();
            label2 = new Label();
            txtHoVaTen = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            txtTim = new TextBox();
            ID = new DataGridViewTextBoxColumn();
            HoVaTen = new DataGridViewTextBoxColumn();
            DienThoai = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            QuyenHan = new DataGridViewTextBoxColumn();
            label7 = new Label();
            panelHeader.SuspendLayout();
            groupBox1.SuspendLayout();
            flpPrimaryActions.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            panelHeader.Controls.Add(lblSubTitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1140, 96);
            panelHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubTitle.ForeColor = Color.FromArgb(219, 234, 254);
            lblSubTitle.Location = new Point(32, 55);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(0, 28);
            lblSubTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(325, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý nhân viên";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtTim);
            groupBox1.Controls.Add(flpPrimaryActions);
            groupBox1.Controls.Add(cboQuyenHan);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(txtTenDangNhap);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDienThoai);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtHoVaTen);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(30, 41, 59);
            groupBox1.Location = new Point(16, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1108, 298);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhân viên";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatAppearance.BorderColor = Color.FromArgb(148, 163, 184);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.FromArgb(51, 65, 85);
            btnTimKiem.Location = new Point(603, 3);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 44);
            btnTimKiem.TabIndex = 0;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(239, 68, 68);
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(503, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 44);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // flpPrimaryActions
            // 
            flpPrimaryActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpPrimaryActions.Controls.Add(btnThem);
            flpPrimaryActions.Controls.Add(btnSua);
            flpPrimaryActions.Controls.Add(btnXoa);
            flpPrimaryActions.Controls.Add(btnLuu);
            flpPrimaryActions.Controls.Add(btnHuyBo);
            flpPrimaryActions.Controls.Add(btnThoat);
            flpPrimaryActions.Controls.Add(btnTimKiem);
            flpPrimaryActions.Location = new Point(24, 226);
            flpPrimaryActions.Name = "flpPrimaryActions";
            flpPrimaryActions.Size = new Size(708, 51);
            flpPrimaryActions.TabIndex = 12;
            flpPrimaryActions.WrapContents = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(37, 99, 235);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(3, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 44);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(14, 116, 144);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(103, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 44);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(220, 38, 38);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(203, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 44);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(22, 163, 74);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(303, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 44);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.FromArgb(100, 116, 139);
            btnHuyBo.FlatAppearance.BorderSize = 0;
            btnHuyBo.FlatStyle = FlatStyle.Flat;
            btnHuyBo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyBo.ForeColor = Color.White;
            btnHuyBo.Location = new Point(403, 3);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 44);
            btnHuyBo.TabIndex = 4;
            btnHuyBo.Text = "Hủy";
            btnHuyBo.UseVisualStyleBackColor = false;
            // 
            // cboQuyenHan
            // 
            cboQuyenHan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuyenHan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboQuyenHan.FormattingEnabled = true;
            cboQuyenHan.Items.AddRange(new object[] { "Quản lý", "Nhân viên" });
            cboQuyenHan.Location = new Point(751, 156);
            cboQuyenHan.Name = "cboQuyenHan";
            cboQuyenHan.Size = new Size(341, 36);
            cboQuyenHan.TabIndex = 11;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(751, 99);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(341, 34);
            txtMatKhau.TabIndex = 9;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenDangNhap.Location = new Point(751, 42);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(341, 34);
            txtTenDangNhap.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(71, 85, 105);
            label6.Location = new Point(627, 159);
            label6.Name = "label6";
            label6.Size = new Size(106, 28);
            label6.TabIndex = 10;
            label6.Text = "Quyền hạn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(71, 85, 105);
            label5.Location = new Point(626, 102);
            label5.Name = "label5";
            label5.Size = new Size(94, 28);
            label5.TabIndex = 8;
            label5.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(71, 85, 105);
            label4.Location = new Point(624, 45);
            label4.Name = "label4";
            label4.Size = new Size(108, 28);
            label4.TabIndex = 6;
            label4.Text = "Đăng nhập";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiaChi.Location = new Point(145, 156);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(424, 34);
            txtDiaChi.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(71, 85, 105);
            label3.Location = new Point(24, 159);
            label3.Name = "label3";
            label3.Size = new Size(71, 28);
            label3.TabIndex = 4;
            label3.Text = "Địa chỉ";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDienThoai.Location = new Point(145, 99);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(424, 34);
            txtDienThoai.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(71, 85, 105);
            label2.Location = new Point(24, 102);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 2;
            label2.Text = "Điện thoại";
            // 
            // txtHoVaTen
            // 
            txtHoVaTen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoVaTen.Location = new Point(145, 42);
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.Size = new Size(424, 34);
            txtHoVaTen.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(71, 85, 105);
            label1.Location = new Point(24, 45);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.FromArgb(30, 41, 59);
            groupBox2.Location = new Point(16, 427);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1108, 305);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhân viên";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeight = 42;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTen, DienThoai, DiaChi, QuyenHan });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.FromArgb(226, 232, 240);
            dataGridView.Location = new Point(3, 30);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 62;
            dataGridView.RowTemplate.Height = 36;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1102, 272);
            dataGridView.TabIndex = 0;
            // 
            // txtTim
            // 
            txtTim.Font = new Font("Segoe UI", 10F);
            txtTim.Location = new Point(751, 242);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(341, 34);
            txtTim.TabIndex = 14;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 50F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 8;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // HoVaTen
            // 
            HoVaTen.DataPropertyName = "HoVaTen";
            HoVaTen.HeaderText = "Họ và tên";
            HoVaTen.MinimumWidth = 8;
            HoVaTen.Name = "HoVaTen";
            HoVaTen.ReadOnly = true;
            // 
            // DienThoai
            // 
            DienThoai.DataPropertyName = "DienThoai";
            DienThoai.HeaderText = "Điện thoại";
            DienThoai.MinimumWidth = 8;
            DienThoai.Name = "DienThoai";
            DienThoai.ReadOnly = true;
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.MinimumWidth = 8;
            DiaChi.Name = "DiaChi";
            DiaChi.ReadOnly = true;
            // 
            // QuyenHan
            // 
            QuyenHan.DataPropertyName = "QuyenHan";
            QuyenHan.HeaderText = "Quyền hạn";
            QuyenHan.MinimumWidth = 8;
            QuyenHan.Name = "QuyenHan";
            QuyenHan.ReadOnly = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.FromArgb(71, 85, 105);
            label7.Location = new Point(751, 207);
            label7.Name = "label7";
            label7.Size = new Size(262, 28);
            label7.TabIndex = 15;
            label7.Text = "Nhập thông tin cần tìm kiếm";
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1140, 744);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panelHeader);
            Name = "frmNhanVien";
            Text = "Quản lý nhân viên";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flpPrimaryActions.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblSubTitle;
        private Label lblTitle;
        private GroupBox groupBox1;
        private Button btnTimKiem;
        private Button btnThoat;
        private FlowLayoutPanel flpPrimaryActions;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuyBo;
        private ComboBox cboQuyenHan;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtDiaChi;
        private Label label3;
        private TextBox txtDienThoai;
        private Label label2;
        private TextBox txtHoVaTen;
        private Label label1;
        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private TextBox txtTim;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn HoVaTen;
        private DataGridViewTextBoxColumn DienThoai;
        private DataGridViewTextBoxColumn DiaChi;
        private DataGridViewTextBoxColumn QuyenHan;
        private Label label7;
    }
}