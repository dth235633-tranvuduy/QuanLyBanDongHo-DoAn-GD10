namespace LTQL_QLBHDongHo.Forms
{
    partial class frmThuongHieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Controls
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDesc;

        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutInfo;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;

        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;

        private System.Windows.Forms.Panel panelListTop;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;

        private System.Windows.Forms.DataGridView dgvThuongHieu;
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
            groupInfo = new GroupBox();
            tableLayoutInfo = new TableLayoutPanel();
            lblTen = new Label();
            txtTen = new TextBox();
            panelActions = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            panelListTop = new Panel();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            lblListTitle = new Label();
            dgvThuongHieu = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTen = new DataGridViewTextBoxColumn();
            panelHeader.SuspendLayout();
            groupInfo.SuspendLayout();
            tableLayoutInfo.SuspendLayout();
            panelActions.SuspendLayout();
            flowButtons.SuspendLayout();
            panelListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuongHieu).BeginInit();
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
            panelHeader.Size = new Size(1080, 88);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderDesc
            // 
            lblHeaderDesc.AutoSize = true;
            lblHeaderDesc.Font = new Font("Segoe UI", 9F);
            lblHeaderDesc.ForeColor = Color.WhiteSmoke;
            lblHeaderDesc.Location = new Point(24, 49);
            lblHeaderDesc.Name = "lblHeaderDesc";
            lblHeaderDesc.Size = new Size(355, 25);
            lblHeaderDesc.TabIndex = 1;
            lblHeaderDesc.Text = "Quản lý thương hiệu sản phẩm đồng bộ dữ liệu";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(22, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(271, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "QUẢN LÝ THƯƠNG HIỆU";
            // 
            // groupInfo
            // 
            groupInfo.Controls.Add(tableLayoutInfo);
            groupInfo.Dock = DockStyle.Top;
            groupInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupInfo.Location = new Point(0, 88);
            groupInfo.Name = "groupInfo";
            groupInfo.Padding = new Padding(16, 12, 16, 12);
            groupInfo.Size = new Size(1080, 135);
            groupInfo.TabIndex = 1;
            groupInfo.TabStop = false;
            groupInfo.Text = "Thông tin thương hiệu";
            // 
            // tableLayoutInfo
            // 
            tableLayoutInfo.ColumnCount = 2;
            tableLayoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutInfo.Controls.Add(lblTen, 0, 0);
            tableLayoutInfo.Controls.Add(txtTen, 1, 0);
            tableLayoutInfo.Dock = DockStyle.Fill;
            tableLayoutInfo.Location = new Point(16, 36);
            tableLayoutInfo.Name = "tableLayoutInfo";
            tableLayoutInfo.RowCount = 1;
            tableLayoutInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutInfo.Size = new Size(1048, 87);
            tableLayoutInfo.TabIndex = 0;
            // 
            // lblTen
            // 
            lblTen.Anchor = AnchorStyles.Left;
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI", 9F);
            lblTen.Location = new Point(3, 11);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(161, 25);
            lblTen.TabIndex = 0;
            lblTen.Text = "Tên thương hiệu (*)";
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTen.BorderStyle = BorderStyle.FixedSingle;
            txtTen.Font = new Font("Segoe UI", 9F);
            txtTen.Location = new Point(173, 8);
            txtTen.Name = "txtTen";
            txtTen.PlaceholderText = "Nhập tên thương hiệu (ví dụ: Seiko, Casio...)";
            txtTen.Size = new Size(872, 31);
            txtTen.TabIndex = 1;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(248, 250, 252);
            panelActions.Controls.Add(flowButtons);
            panelActions.Dock = DockStyle.Top;
            panelActions.Location = new Point(0, 223);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(16, 10, 16, 10);
            panelActions.Size = new Size(1080, 72);
            panelActions.TabIndex = 2;
            // 
            // flowButtons
            // 
            flowButtons.Controls.Add(btnThem);
            flowButtons.Controls.Add(btnSua);
            flowButtons.Controls.Add(btnXoa);
            flowButtons.Controls.Add(btnLuu);
            flowButtons.Controls.Add(btnHuy);
            flowButtons.Dock = DockStyle.Left;
            flowButtons.Location = new Point(16, 10);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(560, 52);
            flowButtons.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Location = new Point(3, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 44);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Location = new Point(119, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 44);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Location = new Point(225, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 44);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(32, 99, 155);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(331, 3);
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
            btnHuy.Location = new Point(437, 3);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 44);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // panelListTop
            // 
            panelListTop.Controls.Add(txtTimKiem);
            panelListTop.Controls.Add(btnTim);
            panelListTop.Controls.Add(lblListTitle);
            panelListTop.Dock = DockStyle.Top;
            panelListTop.Location = new Point(0, 295);
            panelListTop.Name = "panelListTop";
            panelListTop.Padding = new Padding(16, 10, 16, 10);
            panelListTop.Size = new Size(1080, 62);
            panelListTop.TabIndex = 3;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Location = new Point(700, 14);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thương hiệu...";
            txtTimKiem.Size = new Size(252, 31);
            txtTimKiem.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTim.BackColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Location = new Point(958, 13);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(106, 33);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm kiếm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblListTitle.Location = new Point(16, 16);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(271, 28);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Danh sách thương hiệu hiện có";
            // 
            // dgvThuongHieu
            // 
            dgvThuongHieu.AllowUserToAddRows = false;
            dgvThuongHieu.AllowUserToDeleteRows = false;
            dgvThuongHieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThuongHieu.BackgroundColor = Color.White;
            dgvThuongHieu.BorderStyle = BorderStyle.None;
            dgvThuongHieu.ColumnHeadersHeight = 38;
            dgvThuongHieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvThuongHieu.Columns.AddRange(new DataGridViewColumn[] { colId, colTen });
            dgvThuongHieu.Dock = DockStyle.Fill;
            dgvThuongHieu.Location = new Point(0, 357);
            dgvThuongHieu.Name = "dgvThuongHieu";
            dgvThuongHieu.ReadOnly = true;
            dgvThuongHieu.RowHeadersVisible = false;
            dgvThuongHieu.RowHeadersWidth = 62;
            dgvThuongHieu.RowTemplate.Height = 34;
            dgvThuongHieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuongHieu.Size = new Size(1080, 303);
            dgvThuongHieu.TabIndex = 4;
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
            // colTen
            // 
            colTen.DataPropertyName = "TenHangSanXuat";
            colTen.FillWeight = 82F;
            colTen.HeaderText = "TÊN THƯƠNG HIỆU";
            colTen.MinimumWidth = 8;
            colTen.Name = "colTen";
            colTen.ReadOnly = true;
            // 
            // frmThuongHieu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1080, 660);
            Controls.Add(dgvThuongHieu);
            Controls.Add(panelListTop);
            Controls.Add(panelActions);
            Controls.Add(groupInfo);
            Controls.Add(panelHeader);
            MinimumSize = new Size(980, 620);
            Name = "frmThuongHieu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thương hiệu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupInfo.ResumeLayout(false);
            tableLayoutInfo.ResumeLayout(false);
            tableLayoutInfo.PerformLayout();
            panelActions.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            panelListTop.ResumeLayout(false);
            panelListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuongHieu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTen;
    }
}