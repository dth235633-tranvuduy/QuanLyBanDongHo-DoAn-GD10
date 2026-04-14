namespace LTQL_QLBHDongHo.Forms
{
    partial class frmChiTiet_HoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTiet_HoaDon));
            panelHeader = new Panel();
            lblFormTitle = new Label();
            lblFormSubtitle = new Label();
            panelInfo = new Panel();
            lblTrangThaiLabel = new Label();
            lblSDT = new Label();
            lblKhachHang = new Label();
            lblNhanVien = new Label();
            lblThoiGian = new Label();
            lblMaHD = new Label();
            lblTrangThaiTitle = new Label();
            lblSDTTitle = new Label();
            lblKhachHangTitle = new Label();
            lblNhanVienTitle = new Label();
            lblThoiGianTitle = new Label();
            lblMaHDTitle = new Label();
            panelContent = new Panel();
            dgvChiTiet = new DataGridView();
            cStt = new DataGridViewTextBoxColumn();
            cTen = new DataGridViewTextBoxColumn();
            cSl = new DataGridViewTextBoxColumn();
            cThanhTien = new DataGridViewTextBoxColumn();
            lblChiTietTitle = new Label();
            panelBottom = new Panel();
            btnIn = new Button();
            btnDong = new Button();
            panelTotals = new Panel();
            lblTongValue = new Label();
            lblTongLabel = new Label();
            lblTamTinhValue = new Label();
            lblTamTinhLabel = new Label();
            panelNotes = new Panel();
            txtGhiChu = new TextBox();
            lblGhiChuTitle = new Label();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            panelHeader.SuspendLayout();
            panelInfo.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            panelBottom.SuspendLayout();
            panelTotals.SuspendLayout();
            panelNotes.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            panelHeader.Controls.Add(lblFormTitle);
            panelHeader.Controls.Add(lblFormSubtitle);
            panelHeader.Controls.Add(panelInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 16, 20, 16);
            panelHeader.Size = new Size(1051, 222);
            panelHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(22, 12);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(260, 45);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Chi tiết hóa đơn";
            // 
            // lblFormSubtitle
            // 
            lblFormSubtitle.AutoSize = true;
            lblFormSubtitle.Font = new Font("Segoe UI", 9F);
            lblFormSubtitle.ForeColor = Color.FromArgb(219, 234, 254);
            lblFormSubtitle.Location = new Point(24, 57);
            lblFormSubtitle.Name = "lblFormSubtitle";
            lblFormSubtitle.Size = new Size(420, 25);
            lblFormSubtitle.TabIndex = 1;
            lblFormSubtitle.Text = "Xem thông tin hóa đơn và sản phẩm đã thanh toán";
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(lblTrangThaiLabel);
            panelInfo.Controls.Add(lblSDT);
            panelInfo.Controls.Add(lblKhachHang);
            panelInfo.Controls.Add(lblNhanVien);
            panelInfo.Controls.Add(lblThoiGian);
            panelInfo.Controls.Add(lblMaHD);
            panelInfo.Controls.Add(lblTrangThaiTitle);
            panelInfo.Controls.Add(lblSDTTitle);
            panelInfo.Controls.Add(lblKhachHangTitle);
            panelInfo.Controls.Add(lblNhanVienTitle);
            panelInfo.Controls.Add(lblThoiGianTitle);
            panelInfo.Controls.Add(lblMaHDTitle);
            panelInfo.Location = new Point(24, 91);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(1000, 116);
            panelInfo.TabIndex = 2;
            // 
            // lblTrangThaiLabel
            // 
            lblTrangThaiLabel.AutoEllipsis = true;
            lblTrangThaiLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTrangThaiLabel.ForeColor = Color.FromArgb(37, 99, 235);
            lblTrangThaiLabel.Location = new Point(780, 65);
            lblTrangThaiLabel.Name = "lblTrangThaiLabel";
            lblTrangThaiLabel.Size = new Size(189, 28);
            lblTrangThaiLabel.TabIndex = 11;
            lblTrangThaiLabel.Text = "-";
            // 
            // lblSDT
            // 
            lblSDT.AutoEllipsis = true;
            lblSDT.Font = new Font("Segoe UI", 10F);
            lblSDT.ForeColor = Color.FromArgb(33, 37, 41);
            lblSDT.Location = new Point(780, 14);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(189, 28);
            lblSDT.TabIndex = 10;
            lblSDT.Text = "-";
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoEllipsis = true;
            lblKhachHang.Font = new Font("Segoe UI", 10F);
            lblKhachHang.ForeColor = Color.FromArgb(33, 37, 41);
            lblKhachHang.Location = new Point(458, 65);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(185, 28);
            lblKhachHang.TabIndex = 9;
            lblKhachHang.Text = "-";
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoEllipsis = true;
            lblNhanVien.Font = new Font("Segoe UI", 10F);
            lblNhanVien.ForeColor = Color.FromArgb(33, 37, 41);
            lblNhanVien.Location = new Point(458, 14);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(185, 28);
            lblNhanVien.TabIndex = 8;
            lblNhanVien.Text = "-";
            // 
            // lblThoiGian
            // 
            lblThoiGian.AutoEllipsis = true;
            lblThoiGian.Font = new Font("Segoe UI", 10F);
            lblThoiGian.ForeColor = Color.FromArgb(33, 37, 41);
            lblThoiGian.Location = new Point(134, 65);
            lblThoiGian.Name = "lblThoiGian";
            lblThoiGian.Size = new Size(183, 28);
            lblThoiGian.TabIndex = 7;
            lblThoiGian.Text = "--:-- - --/--/----";
            // 
            // lblMaHD
            // 
            lblMaHD.AutoEllipsis = true;
            lblMaHD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaHD.ForeColor = Color.FromArgb(33, 37, 41);
            lblMaHD.Location = new Point(134, 14);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(170, 28);
            lblMaHD.TabIndex = 6;
            lblMaHD.Text = "HD0000";
            lblMaHD.Click += lblMaHD_Click;
            // 
            // lblTrangThaiTitle
            // 
            lblTrangThaiTitle.AutoSize = true;
            lblTrangThaiTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrangThaiTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblTrangThaiTitle.Location = new Point(662, 67);
            lblTrangThaiTitle.Name = "lblTrangThaiTitle";
            lblTrangThaiTitle.Size = new Size(99, 25);
            lblTrangThaiTitle.TabIndex = 5;
            lblTrangThaiTitle.Text = "Trạng thái";
            // 
            // lblSDTTitle
            // 
            lblSDTTitle.AutoSize = true;
            lblSDTTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSDTTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblSDTTitle.Location = new Point(662, 16);
            lblSDTTitle.Name = "lblSDTTitle";
            lblSDTTitle.Size = new Size(46, 25);
            lblSDTTitle.TabIndex = 4;
            lblSDTTitle.Text = "SĐT";
            // 
            // lblKhachHangTitle
            // 
            lblKhachHangTitle.AutoSize = true;
            lblKhachHangTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKhachHangTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblKhachHangTitle.Location = new Point(337, 67);
            lblKhachHangTitle.Name = "lblKhachHangTitle";
            lblKhachHangTitle.Size = new Size(113, 25);
            lblKhachHangTitle.TabIndex = 3;
            lblKhachHangTitle.Text = "Khách hàng";
            // 
            // lblNhanVienTitle
            // 
            lblNhanVienTitle.AutoSize = true;
            lblNhanVienTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNhanVienTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblNhanVienTitle.Location = new Point(337, 16);
            lblNhanVienTitle.Name = "lblNhanVienTitle";
            lblNhanVienTitle.Size = new Size(99, 25);
            lblNhanVienTitle.TabIndex = 2;
            lblNhanVienTitle.Text = "Nhân viên";
            // 
            // lblThoiGianTitle
            // 
            lblThoiGianTitle.AutoSize = true;
            lblThoiGianTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblThoiGianTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblThoiGianTitle.Location = new Point(16, 67);
            lblThoiGianTitle.Name = "lblThoiGianTitle";
            lblThoiGianTitle.Size = new Size(92, 25);
            lblThoiGianTitle.TabIndex = 1;
            lblThoiGianTitle.Text = "Thời gian";
            // 
            // lblMaHDTitle
            // 
            lblMaHDTitle.AutoSize = true;
            lblMaHDTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMaHDTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblMaHDTitle.Location = new Point(16, 16);
            lblMaHDTitle.Name = "lblMaHDTitle";
            lblMaHDTitle.Size = new Size(71, 25);
            lblMaHDTitle.TabIndex = 0;
            lblMaHDTitle.Text = "Mã HĐ";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(243, 246, 251);
            panelContent.Controls.Add(dgvChiTiet);
            panelContent.Controls.Add(lblChiTietTitle);
            panelContent.Dock = DockStyle.Top;
            panelContent.Location = new Point(0, 222);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(24, 14, 24, 12);
            panelContent.Size = new Size(1051, 308);
            panelContent.TabIndex = 1;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvChiTiet.ColumnHeadersHeight = 42;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { cStt, cTen, cSl, cThanhTien });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle4;
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.GridColor = Color.FromArgb(222, 226, 230);
            dgvChiTiet.Location = new Point(24, 50);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowHeadersWidth = 62;
            dgvChiTiet.RowTemplate.Height = 34;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(976, 243);
            dgvChiTiet.TabIndex = 1;
            // 
            // cStt
            // 
            cStt.DataPropertyName = "STT";
            cStt.FillWeight = 10F;
            cStt.HeaderText = "STT";
            cStt.MinimumWidth = 8;
            cStt.Name = "cStt";
            cStt.ReadOnly = true;
            // 
            // cTen
            // 
            cTen.DataPropertyName = "Ten";
            cTen.FillWeight = 46F;
            cTen.HeaderText = "Sản phẩm";
            cTen.MinimumWidth = 8;
            cTen.Name = "cTen";
            cTen.ReadOnly = true;
            // 
            // cSl
            // 
            cSl.DataPropertyName = "SL";
            cSl.FillWeight = 14F;
            cSl.HeaderText = "Số lượng";
            cSl.MinimumWidth = 8;
            cSl.Name = "cSl";
            cSl.ReadOnly = true;
            // 
            // cThanhTien
            // 
            cThanhTien.DataPropertyName = "ThanhTien";
            cThanhTien.FillWeight = 30F;
            cThanhTien.HeaderText = "Thành tiền";
            cThanhTien.MinimumWidth = 8;
            cThanhTien.Name = "cThanhTien";
            cThanhTien.ReadOnly = true;
            // 
            // lblChiTietTitle
            // 
            lblChiTietTitle.AutoSize = true;
            lblChiTietTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChiTietTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblChiTietTitle.Location = new Point(24, 14);
            lblChiTietTitle.Name = "lblChiTietTitle";
            lblChiTietTitle.Size = new Size(225, 30);
            lblChiTietTitle.TabIndex = 0;
            lblChiTietTitle.Text = "Danh sách sản phẩm";
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(243, 246, 251);
            panelBottom.Controls.Add(btnIn);
            panelBottom.Controls.Add(btnDong);
            panelBottom.Controls.Add(panelTotals);
            panelBottom.Controls.Add(panelNotes);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(0, 530);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(24, 0, 24, 20);
            panelBottom.Size = new Size(1051, 202);
            panelBottom.TabIndex = 2;
            // 
            // btnIn
            // 
            btnIn.BackColor = Color.FromArgb(59, 130, 246);
            btnIn.FlatAppearance.BorderSize = 0;
            btnIn.FlatStyle = FlatStyle.Flat;
            btnIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnIn.ForeColor = Color.White;
            btnIn.Location = new Point(846, 153);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(151, 37);
            btnIn.TabIndex = 3;
            btnIn.Text = "In  hóa đơn";
            btnIn.UseVisualStyleBackColor = false;
            btnIn.Click += BtnIn_Click;
            // 
            // btnDong
            // 
            btnDong.BackColor = Color.White;
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(206, 212, 218);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDong.ForeColor = Color.FromArgb(73, 80, 87);
            btnDong.Location = new Point(735, 153);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(104, 37);
            btnDong.TabIndex = 2;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // panelTotals
            // 
            panelTotals.BackColor = Color.White;
            panelTotals.BorderStyle = BorderStyle.FixedSingle;
            panelTotals.Controls.Add(lblTongValue);
            panelTotals.Controls.Add(lblTongLabel);
            panelTotals.Controls.Add(lblTamTinhValue);
            panelTotals.Controls.Add(lblTamTinhLabel);
            panelTotals.Location = new Point(496, 10);
            panelTotals.Name = "panelTotals";
            panelTotals.Size = new Size(504, 136);
            panelTotals.TabIndex = 1;
            // 
            // lblTongValue
            // 
            lblTongValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongValue.ForeColor = Color.FromArgb(220, 53, 69);
            lblTongValue.Location = new Point(261, 82);
            lblTongValue.Name = "lblTongValue";
            lblTongValue.Size = new Size(225, 38);
            lblTongValue.TabIndex = 4;
            lblTongValue.Text = "0 đ";
            lblTongValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTongLabel
            // 
            lblTongLabel.AutoSize = true;
            lblTongLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongLabel.ForeColor = Color.FromArgb(33, 37, 41);
            lblTongLabel.Location = new Point(16, 88);
            lblTongLabel.Name = "lblTongLabel";
            lblTongLabel.Size = new Size(209, 28);
            lblTongLabel.TabIndex = 3;
            lblTongLabel.Text = "TỔNG THANH TOÁN";
            // 
            // lblTamTinhValue
            // 
            lblTamTinhValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTamTinhValue.ForeColor = Color.FromArgb(33, 37, 41);
            lblTamTinhValue.Location = new Point(294, 18);
            lblTamTinhValue.Name = "lblTamTinhValue";
            lblTamTinhValue.Size = new Size(192, 25);
            lblTamTinhValue.TabIndex = 1;
            lblTamTinhValue.Text = "0 đ";
            lblTamTinhValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTamTinhLabel
            // 
            lblTamTinhLabel.AutoSize = true;
            lblTamTinhLabel.Font = new Font("Segoe UI", 9F);
            lblTamTinhLabel.ForeColor = Color.FromArgb(73, 80, 87);
            lblTamTinhLabel.Location = new Point(16, 18);
            lblTamTinhLabel.Name = "lblTamTinhLabel";
            lblTamTinhLabel.Size = new Size(127, 25);
            lblTamTinhLabel.TabIndex = 0;
            lblTamTinhLabel.Text = "Tiền sản phẩm";
            // 
            // panelNotes
            // 
            panelNotes.BackColor = Color.White;
            panelNotes.BorderStyle = BorderStyle.FixedSingle;
            panelNotes.Controls.Add(txtGhiChu);
            panelNotes.Controls.Add(lblGhiChuTitle);
            panelNotes.Location = new Point(24, 10);
            panelNotes.Name = "panelNotes";
            panelNotes.Size = new Size(458, 136);
            panelNotes.TabIndex = 0;
            // 
            // txtGhiChu
            // 
            txtGhiChu.BackColor = Color.White;
            txtGhiChu.BorderStyle = BorderStyle.None;
            txtGhiChu.Font = new Font("Segoe UI", 9F);
            txtGhiChu.ForeColor = Color.FromArgb(73, 80, 87);
            txtGhiChu.Location = new Point(14, 40);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ReadOnly = true;
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(428, 84);
            txtGhiChu.TabIndex = 1;
            txtGhiChu.Text = "Không có ghi chú.";
            // 
            // lblGhiChuTitle
            // 
            lblGhiChuTitle.AutoSize = true;
            lblGhiChuTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGhiChuTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblGhiChuTitle.Location = new Point(12, 10);
            lblGhiChuTitle.Name = "lblGhiChuTitle";
            lblGhiChuTitle.Size = new Size(77, 25);
            lblGhiChuTitle.TabIndex = 0;
            lblGhiChuTitle.Text = "Ghi chú";
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // frmChiTiet_HoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 251);
            ClientSize = new Size(1051, 732);
            Controls.Add(panelBottom);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            MinimumSize = new Size(980, 680);
            Name = "frmChiTiet_HoaDon";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết hóa đơn";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            panelBottom.ResumeLayout(false);
            panelTotals.ResumeLayout(false);
            panelTotals.PerformLayout();
            panelNotes.ResumeLayout(false);
            panelNotes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblFormTitle;
        private Label lblFormSubtitle;
        private Panel panelInfo;
        private Label lblMaHDTitle;
        private Label lblThoiGianTitle;
        private Label lblNhanVienTitle;
        private Label lblKhachHangTitle;
        private Label lblSDTTitle;
        private Label lblTrangThaiTitle;
        private Label lblMaHD;
        private Label lblThoiGian;
        private Label lblNhanVien;
        private Label lblKhachHang;
        private Label lblSDT;
        private Label lblTrangThaiLabel;
        private Panel panelContent;
        private Label lblChiTietTitle;
        private DataGridView dgvChiTiet;
        private DataGridViewTextBoxColumn cStt;
        private DataGridViewTextBoxColumn cTen;
        private DataGridViewTextBoxColumn cSl;
        private DataGridViewTextBoxColumn cThanhTien;
        private Panel panelBottom;
        private Panel panelNotes;
        private Label lblGhiChuTitle;
        private TextBox txtGhiChu;
        private Panel panelTotals;
        private Label lblTamTinhLabel;
        private Label lblTamTinhValue;
        private Label lblTongLabel;
        private Label lblTongValue;
        private Button btnDong;
        private Button btnIn;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}