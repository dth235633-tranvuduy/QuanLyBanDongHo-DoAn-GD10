namespace LTQL_QLBHDongHo.Forms
{
    partial class frmLoaiDongHo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Controls
        private Panel panelHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderDesc;

        private GroupBox groupThongTin;
        private TableLayoutPanel tableLayoutThongTin;
        private Label lblMaLoai;
        private TextBox txtMaLoai;
        private Label lblTenLoai;
        private TextBox txtTenLoai;

        private Panel panelActions;
        private FlowLayoutPanel flowButtons;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnLamMoi;

        private Panel panelListTop;
        private Label lblDanhSach;
        private TextBox txtTimKiem;
        private Button btnTimKiem;

        private DataGridView dgvLoaiDongHo;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTenLoai;
        private DataGridViewTextBoxColumn colSoLuongSanPham;
        #endregion

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
            groupThongTin = new GroupBox();
            tableLayoutThongTin = new TableLayoutPanel();
            lblMaLoai = new Label();
            txtMaLoai = new TextBox();
            lblTenLoai = new Label();
            txtTenLoai = new TextBox();
            panelActions = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            btnLamMoi = new Button();
            panelListTop = new Panel();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            lblDanhSach = new Label();
            dgvLoaiDongHo = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTenLoai = new DataGridViewTextBoxColumn();
            colSoLuongSanPham = new DataGridViewTextBoxColumn();
            panelHeader.SuspendLayout();
            groupThongTin.SuspendLayout();
            tableLayoutThongTin.SuspendLayout();
            panelActions.SuspendLayout();
            flowButtons.SuspendLayout();
            panelListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiDongHo).BeginInit();
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
            panelHeader.Size = new Size(1100, 88);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderDesc
            // 
            lblHeaderDesc.AutoSize = true;
            lblHeaderDesc.Font = new Font("Segoe UI", 9F);
            lblHeaderDesc.ForeColor = Color.WhiteSmoke;
            lblHeaderDesc.Location = new Point(24, 49);
            lblHeaderDesc.Name = "lblHeaderDesc";
            lblHeaderDesc.Size = new Size(372, 25);
            lblHeaderDesc.TabIndex = 1;
            lblHeaderDesc.Text = "Quản lý loại đồng hồ nhất quán với dữ liệu sản phẩm";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(22, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(275, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "QUẢN LÝ LOẠI ĐỒNG HỒ";
            // 
            // groupThongTin
            // 
            groupThongTin.Controls.Add(tableLayoutThongTin);
            groupThongTin.Dock = DockStyle.Top;
            groupThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupThongTin.Location = new Point(0, 88);
            groupThongTin.Name = "groupThongTin";
            groupThongTin.Padding = new Padding(16, 12, 16, 12);
            groupThongTin.Size = new Size(1100, 160);
            groupThongTin.TabIndex = 1;
            groupThongTin.TabStop = false;
            groupThongTin.Text = "Thông tin loại đồng hồ";
            // 
            // tableLayoutThongTin
            // 
            tableLayoutThongTin.ColumnCount = 2;
            tableLayoutThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutThongTin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutThongTin.Controls.Add(lblMaLoai, 0, 0);
            tableLayoutThongTin.Controls.Add(txtMaLoai, 1, 0);
            tableLayoutThongTin.Controls.Add(lblTenLoai, 0, 1);
            tableLayoutThongTin.Controls.Add(txtTenLoai, 1, 1);
            tableLayoutThongTin.Dock = DockStyle.Fill;
            tableLayoutThongTin.Location = new Point(16, 36);
            tableLayoutThongTin.Name = "tableLayoutThongTin";
            tableLayoutThongTin.RowCount = 2;
            tableLayoutThongTin.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutThongTin.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutThongTin.Size = new Size(1068, 112);
            tableLayoutThongTin.TabIndex = 0;
            // 
            // lblMaLoai
            // 
            lblMaLoai.Anchor = AnchorStyles.Left;
            lblMaLoai.AutoSize = true;
            lblMaLoai.Font = new Font("Segoe UI", 9F);
            lblMaLoai.Location = new Point(3, 11);
            lblMaLoai.Name = "lblMaLoai";
            lblMaLoai.Size = new Size(157, 25);
            lblMaLoai.TabIndex = 0;
            lblMaLoai.Text = "Mã loại đồng hồ (*)";
            // 
            // txtMaLoai
            // 
            txtMaLoai.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaLoai.BackColor = Color.FromArgb(248, 250, 252);
            txtMaLoai.BorderStyle = BorderStyle.FixedSingle;
            txtMaLoai.Font = new Font("Segoe UI", 9F);
            txtMaLoai.Location = new Point(173, 8);
            txtMaLoai.Name = "txtMaLoai";
            txtMaLoai.PlaceholderText = "Mã loại tự sinh hoặc nhập theo quy định";
            txtMaLoai.Size = new Size(892, 31);
            txtMaLoai.TabIndex = 1;
            // 
            // lblTenLoai
            // 
            lblTenLoai.Anchor = AnchorStyles.Left;
            lblTenLoai.AutoSize = true;
            lblTenLoai.Font = new Font("Segoe UI", 9F);
            lblTenLoai.Location = new Point(3, 59);
            lblTenLoai.Name = "lblTenLoai";
            lblTenLoai.Size = new Size(96, 25);
            lblTenLoai.TabIndex = 2;
            lblTenLoai.Text = "Tên loại (*)";
            // 
            // txtTenLoai
            // 
            txtTenLoai.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenLoai.BorderStyle = BorderStyle.FixedSingle;
            txtTenLoai.Font = new Font("Segoe UI", 9F);
            txtTenLoai.Location = new Point(173, 56);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.PlaceholderText = "Ví dụ: Đồng hồ cơ, Đồng hồ pin, Smartwatch";
            txtTenLoai.Size = new Size(892, 31);
            txtTenLoai.TabIndex = 3;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(248, 250, 252);
            panelActions.Controls.Add(flowButtons);
            panelActions.Dock = DockStyle.Top;
            panelActions.Location = new Point(0, 248);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(16, 10, 16, 10);
            panelActions.Size = new Size(1100, 72);
            panelActions.TabIndex = 2;
            // 
            // flowButtons
            // 
            flowButtons.Controls.Add(btnThem);
            flowButtons.Controls.Add(btnSua);
            flowButtons.Controls.Add(btnXoa);
            flowButtons.Controls.Add(btnLuu);
            flowButtons.Controls.Add(btnHuy);
            flowButtons.Controls.Add(btnLamMoi);
            flowButtons.Dock = DockStyle.Left;
            flowButtons.Location = new Point(16, 10);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(666, 52);
            flowButtons.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Location = new Point(3, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(104, 44);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Location = new Point(113, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(104, 44);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Location = new Point(223, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(104, 44);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(32, 99, 155);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(333, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(104, 44);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Location = new Point(443, 3);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(104, 44);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Location = new Point(553, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(104, 44);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // panelListTop
            // 
            panelListTop.Controls.Add(btnTimKiem);
            panelListTop.Controls.Add(txtTimKiem);
            panelListTop.Controls.Add(lblDanhSach);
            panelListTop.Dock = DockStyle.Top;
            panelListTop.Location = new Point(0, 320);
            panelListTop.Name = "panelListTop";
            panelListTop.Padding = new Padding(16, 10, 16, 10);
            panelListTop.Size = new Size(1100, 62);
            panelListTop.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Location = new Point(976, 13);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 33);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Location = new Point(718, 14);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên loại đồng hồ...";
            txtTimKiem.Size = new Size(252, 31);
            txtTimKiem.TabIndex = 1;
            // 
            // lblDanhSach
            // 
            lblDanhSach.AutoSize = true;
            lblDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDanhSach.Location = new Point(16, 16);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Size = new Size(296, 28);
            lblDanhSach.TabIndex = 0;
            lblDanhSach.Text = "Danh sách loại đồng hồ hiện có";
            // 
            // dgvLoaiDongHo
            // 
            dgvLoaiDongHo.AllowUserToAddRows = false;
            dgvLoaiDongHo.AllowUserToDeleteRows = false;
            dgvLoaiDongHo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiDongHo.BackgroundColor = Color.White;
            dgvLoaiDongHo.BorderStyle = BorderStyle.None;
            dgvLoaiDongHo.ColumnHeadersHeight = 38;
            dgvLoaiDongHo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLoaiDongHo.Columns.AddRange(new DataGridViewColumn[] { colId, colTenLoai, colSoLuongSanPham });
            dgvLoaiDongHo.Dock = DockStyle.Fill;
            dgvLoaiDongHo.Location = new Point(0, 382);
            dgvLoaiDongHo.Name = "dgvLoaiDongHo";
            dgvLoaiDongHo.ReadOnly = true;
            dgvLoaiDongHo.RowHeadersVisible = false;
            dgvLoaiDongHo.RowHeadersWidth = 62;
            dgvLoaiDongHo.RowTemplate.Height = 34;
            dgvLoaiDongHo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiDongHo.Size = new Size(1100, 318);
            dgvLoaiDongHo.TabIndex = 4;
            // 
            // colId
            // 
            colId.DataPropertyName = "ID";
            colId.FillWeight = 18F;
            colId.HeaderText = "ID";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTenLoai
            // 
            colTenLoai.DataPropertyName = "TenLoai";
            colTenLoai.FillWeight = 55F;
            colTenLoai.HeaderText = "TÊN LOẠI ĐỒNG HỒ";
            colTenLoai.MinimumWidth = 8;
            colTenLoai.Name = "colTenLoai";
            colTenLoai.ReadOnly = true;
            // 
            // colSoLuongSanPham
            // 
            colSoLuongSanPham.DataPropertyName = "SoLuongSanPham";
            colSoLuongSanPham.FillWeight = 27F;
            colSoLuongSanPham.HeaderText = "SỐ LƯỢNG SẢN PHẨM";
            colSoLuongSanPham.MinimumWidth = 8;
            colSoLuongSanPham.Name = "colSoLuongSanPham";
            colSoLuongSanPham.ReadOnly = true;
            // 
            // frmLoaiDongHo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 700);
            Controls.Add(dgvLoaiDongHo);
            Controls.Add(panelListTop);
            Controls.Add(panelActions);
            Controls.Add(groupThongTin);
            Controls.Add(panelHeader);
            MinimumSize = new Size(980, 620);
            Name = "frmLoaiDongHo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý loại đồng hồ";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupThongTin.ResumeLayout(false);
            tableLayoutThongTin.ResumeLayout(false);
            tableLayoutThongTin.PerformLayout();
            panelActions.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            panelListTop.ResumeLayout(false);
            panelListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiDongHo).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}