namespace LTQL_QLBHDongHo.Forms
{
    partial class frmThongSoKyThuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDesc;
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label lblSanPhamID;
        private System.Windows.Forms.TextBox txtSanPhamID;
        private System.Windows.Forms.Label lblLoaiKinh;
        private System.Windows.Forms.ComboBox txtLoaiKinh;
        private System.Windows.Forms.Label lblDoChiuNuoc;
        private System.Windows.Forms.ComboBox txtDoChiuNuoc;
        private System.Windows.Forms.Label lblLoaiDay;
        private System.Windows.Forms.ComboBox txtLoaiDay;
        private System.Windows.Forms.Label lblKichThuocMat;
        private System.Windows.Forms.ComboBox txtKichThuocMat;
        private System.Windows.Forms.Label lblLoaiDongHo;
        private System.Windows.Forms.ComboBox cboLoaiDongHo;
        private System.Windows.Forms.Label lblTenThuongHieu;
        private System.Windows.Forms.TextBox txtTenThuongHieu;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            tableLayoutMain = new TableLayoutPanel();
            lblSanPhamID = new Label();
            txtSanPhamID = new TextBox();
            lblLoaiKinh = new Label();
            txtLoaiKinh = new ComboBox();
            lblDoChiuNuoc = new Label();
            txtDoChiuNuoc = new ComboBox();
            lblLoaiDay = new Label();
            txtLoaiDay = new ComboBox();
            lblKichThuocMat = new Label();
            txtKichThuocMat = new ComboBox();
            lblLoaiDongHo = new Label();
            cboLoaiDongHo = new ComboBox();
            lblTenThuongHieu = new Label();
            txtTenThuongHieu = new TextBox();
            panelActions = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            groupInfo.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            panelActions.SuspendLayout();
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
            panelHeader.Size = new Size(760, 88);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderDesc
            // 
            lblHeaderDesc.AutoSize = true;
            lblHeaderDesc.Font = new Font("Segoe UI", 9F);
            lblHeaderDesc.ForeColor = Color.WhiteSmoke;
            lblHeaderDesc.Location = new Point(24, 49);
            lblHeaderDesc.Name = "lblHeaderDesc";
            lblHeaderDesc.Size = new Size(429, 25);
            lblHeaderDesc.TabIndex = 1;
            lblHeaderDesc.Text = "Cập nhật chi tiết thông số để đồng bộ với sản phẩm";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(22, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(263, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "THÔNG SỐ KỸ THUẬT";
            // 
            // groupInfo
            // 
            groupInfo.Controls.Add(tableLayoutMain);
            groupInfo.Dock = DockStyle.Fill;
            groupInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupInfo.Location = new Point(0, 88);
            groupInfo.Name = "groupInfo";
            groupInfo.Padding = new Padding(16, 12, 16, 12);
            groupInfo.Size = new Size(760, 354);
            groupInfo.TabIndex = 1;
            groupInfo.TabStop = false;
            groupInfo.Text = "Thông tin chi tiết";
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 4;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutMain.Controls.Add(lblSanPhamID, 0, 0);
            tableLayoutMain.Controls.Add(txtSanPhamID, 1, 0);
            tableLayoutMain.Controls.Add(lblLoaiKinh, 0, 1);
            tableLayoutMain.Controls.Add(txtLoaiKinh, 1, 1);
            tableLayoutMain.Controls.Add(lblDoChiuNuoc, 0, 2);
            tableLayoutMain.Controls.Add(txtDoChiuNuoc, 1, 2);
            tableLayoutMain.Controls.Add(lblLoaiDay, 2, 0);
            tableLayoutMain.Controls.Add(txtLoaiDay, 3, 0);
            tableLayoutMain.Controls.Add(lblKichThuocMat, 2, 1);
            tableLayoutMain.Controls.Add(txtKichThuocMat, 3, 1);
            tableLayoutMain.Controls.Add(lblLoaiDongHo, 2, 2);
            tableLayoutMain.Controls.Add(cboLoaiDongHo, 3, 2);
            tableLayoutMain.Controls.Add(lblTenThuongHieu, 0, 3);
            tableLayoutMain.Controls.Add(txtTenThuongHieu, 1, 3);
            tableLayoutMain.Dock = DockStyle.Top;
            tableLayoutMain.Location = new Point(16, 36);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutMain.Size = new Size(728, 249);
            tableLayoutMain.TabIndex = 0;
            // 
            // lblSanPhamID
            // 
            lblSanPhamID.Anchor = AnchorStyles.Left;
            lblSanPhamID.AutoSize = true;
            lblSanPhamID.Font = new Font("Segoe UI", 9F);
            lblSanPhamID.Location = new Point(3, 18);
            lblSanPhamID.Name = "lblSanPhamID";
            lblSanPhamID.Size = new Size(120, 25);
            lblSanPhamID.TabIndex = 0;
            lblSanPhamID.Text = "Mã sản phẩm";
            // 
            // txtSanPhamID
            // 
            txtSanPhamID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSanPhamID.BorderStyle = BorderStyle.FixedSingle;
            txtSanPhamID.Font = new Font("Segoe UI", 9F);
            txtSanPhamID.Location = new Point(163, 15);
            txtSanPhamID.Name = "txtSanPhamID";
            txtSanPhamID.Size = new Size(198, 31);
            txtSanPhamID.TabIndex = 1;
            // 
            // lblLoaiKinh
            // 
            lblLoaiKinh.Anchor = AnchorStyles.Left;
            lblLoaiKinh.AutoSize = true;
            lblLoaiKinh.Font = new Font("Segoe UI", 9F);
            lblLoaiKinh.Location = new Point(3, 80);
            lblLoaiKinh.Name = "lblLoaiKinh";
            lblLoaiKinh.Size = new Size(82, 25);
            lblLoaiKinh.TabIndex = 2;
            lblLoaiKinh.Text = "Loại kính";
            // 
            // txtLoaiKinh
            // 
            txtLoaiKinh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLoaiKinh.Font = new Font("Segoe UI", 9F);
            txtLoaiKinh.FormattingEnabled = true;
            txtLoaiKinh.Items.AddRange(new object[] { "Sapphire", "Mineral", "Hardlex", "Kính cứng" });
            txtLoaiKinh.Location = new Point(163, 76);
            txtLoaiKinh.Name = "txtLoaiKinh";
            txtLoaiKinh.Size = new Size(198, 33);
            txtLoaiKinh.TabIndex = 3;
            // 
            // lblDoChiuNuoc
            // 
            lblDoChiuNuoc.Anchor = AnchorStyles.Left;
            lblDoChiuNuoc.AutoSize = true;
            lblDoChiuNuoc.Font = new Font("Segoe UI", 9F);
            lblDoChiuNuoc.Location = new Point(3, 142);
            lblDoChiuNuoc.Name = "lblDoChiuNuoc";
            lblDoChiuNuoc.Size = new Size(118, 25);
            lblDoChiuNuoc.TabIndex = 4;
            lblDoChiuNuoc.Text = "Độ chịu nước";
            // 
            // txtDoChiuNuoc
            // 
            txtDoChiuNuoc.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDoChiuNuoc.Font = new Font("Segoe UI", 9F);
            txtDoChiuNuoc.FormattingEnabled = true;
            txtDoChiuNuoc.Items.AddRange(new object[] { "3 ATM", "5 ATM", "10 ATM", "20 ATM" });
            txtDoChiuNuoc.Location = new Point(163, 138);
            txtDoChiuNuoc.Name = "txtDoChiuNuoc";
            txtDoChiuNuoc.Size = new Size(198, 33);
            txtDoChiuNuoc.TabIndex = 5;
            // 
            // lblLoaiDay
            // 
            lblLoaiDay.Anchor = AnchorStyles.Left;
            lblLoaiDay.AutoSize = true;
            lblLoaiDay.Font = new Font("Segoe UI", 9F);
            lblLoaiDay.Location = new Point(367, 18);
            lblLoaiDay.Name = "lblLoaiDay";
            lblLoaiDay.Size = new Size(78, 25);
            lblLoaiDay.TabIndex = 6;
            lblLoaiDay.Text = "Loại dây";
            // 
            // txtLoaiDay
            // 
            txtLoaiDay.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLoaiDay.Font = new Font("Segoe UI", 9F);
            txtLoaiDay.FormattingEnabled = true;
            txtLoaiDay.Items.AddRange(new object[] { "Dây da", "Dây kim loại", "Dây cao su", "Dây vải" });
            txtLoaiDay.Location = new Point(527, 14);
            txtLoaiDay.Name = "txtLoaiDay";
            txtLoaiDay.Size = new Size(198, 33);
            txtLoaiDay.TabIndex = 7;
            // 
            // lblKichThuocMat
            // 
            lblKichThuocMat.Anchor = AnchorStyles.Left;
            lblKichThuocMat.AutoSize = true;
            lblKichThuocMat.Font = new Font("Segoe UI", 9F);
            lblKichThuocMat.Location = new Point(367, 80);
            lblKichThuocMat.Name = "lblKichThuocMat";
            lblKichThuocMat.Size = new Size(131, 25);
            lblKichThuocMat.TabIndex = 8;
            lblKichThuocMat.Text = "Kích thước mặt";
            // 
            // txtKichThuocMat
            // 
            txtKichThuocMat.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtKichThuocMat.Font = new Font("Segoe UI", 9F);
            txtKichThuocMat.FormattingEnabled = true;
            txtKichThuocMat.Items.AddRange(new object[] { "34 mm", "36 mm", "38 mm", "40 mm", "42 mm", "44 mm" });
            txtKichThuocMat.Location = new Point(527, 76);
            txtKichThuocMat.Name = "txtKichThuocMat";
            txtKichThuocMat.Size = new Size(198, 33);
            txtKichThuocMat.TabIndex = 9;
            // 
            // lblLoaiDongHo
            // 
            lblLoaiDongHo.Anchor = AnchorStyles.Left;
            lblLoaiDongHo.AutoSize = true;
            lblLoaiDongHo.Font = new Font("Segoe UI", 9F);
            lblLoaiDongHo.Location = new Point(367, 142);
            lblLoaiDongHo.Name = "lblLoaiDongHo";
            lblLoaiDongHo.Size = new Size(118, 25);
            lblLoaiDongHo.TabIndex = 10;
            lblLoaiDongHo.Text = "Loại đồng hồ";
            // 
            // cboLoaiDongHo
            // 
            cboLoaiDongHo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboLoaiDongHo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiDongHo.Font = new Font("Segoe UI", 9F);
            cboLoaiDongHo.FormattingEnabled = true;
            cboLoaiDongHo.Location = new Point(527, 138);
            cboLoaiDongHo.Name = "cboLoaiDongHo";
            cboLoaiDongHo.Size = new Size(198, 33);
            cboLoaiDongHo.TabIndex = 11;
            cboLoaiDongHo.SelectedIndexChanged += cboLoaiDongHo_SelectedIndexChanged;
            // 
            // lblTenThuongHieu
            // 
            lblTenThuongHieu.Anchor = AnchorStyles.Left;
            lblTenThuongHieu.AutoSize = true;
            lblTenThuongHieu.Font = new Font("Segoe UI", 9F);
            lblTenThuongHieu.Location = new Point(3, 205);
            lblTenThuongHieu.Name = "lblTenThuongHieu";
            lblTenThuongHieu.Size = new Size(140, 25);
            lblTenThuongHieu.TabIndex = 12;
            lblTenThuongHieu.Text = "Tên thương hiệu";
            // 
            // txtTenThuongHieu
            // 
            tableLayoutMain.SetColumnSpan(txtTenThuongHieu, 3);
            txtTenThuongHieu.Dock = DockStyle.Fill;
            txtTenThuongHieu.Font = new Font("Segoe UI", 9F);
            txtTenThuongHieu.Location = new Point(163, 189);
            txtTenThuongHieu.Multiline = true;
            txtTenThuongHieu.Name = "txtTenThuongHieu";
            txtTenThuongHieu.Size = new Size(562, 57);
            txtTenThuongHieu.TabIndex = 13;
            txtTenThuongHieu.TextChanged += txtTenThuongHieu_TextChanged;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(248, 250, 252);
            panelActions.Controls.Add(btnCancel);
            panelActions.Controls.Add(btnSave);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 442);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(16, 10, 16, 10);
            panelActions.Size = new Size(760, 68);
            panelActions.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(613, 14);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Đóng";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(32, 99, 155);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(468, 14);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // frmThongSoKyThuat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 510);
            Controls.Add(groupInfo);
            Controls.Add(panelActions);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThongSoKyThuat";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông số kỹ thuật sản phẩm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupInfo.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            tableLayoutMain.PerformLayout();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}