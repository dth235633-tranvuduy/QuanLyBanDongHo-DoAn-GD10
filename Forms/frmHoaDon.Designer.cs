namespace LTQL_QLBHDongHo.Forms
{
    partial class frmHoaDon
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
            panel1 = new Panel();
            btnThemKh = new Button();
            textBox1 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            textBox2 = new TextBox();
            txtNhanVien = new TextBox();
            label5 = new Label();
            textMaHĐ = new TextBox();
            label3 = new Label();
            textNhapSDTKH = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            lblListTitle = new Label();
            dgvHoaDonGanDay = new DataGridView();
            colMaHD = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            NGLAP = new DataGridViewTextBoxColumn();
            colThoiGian = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            TT = new DataGridViewTextBoxColumn();
            Xem = new DataGridViewButtonColumn();
            panelSanPhamChon = new Panel();
            btnThemSP = new Button();
            lblSanPhamChon = new Label();
            dataGridView2 = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            lblTongValue = new Label();
            lblTamTinhValue = new Label();
            lblTongLabel = new Label();
            lblTamTinhLabel = new Label();
            panel4 = new Panel();
            btnHuy = new Button();
            btnLuu = new Button();
            btnThanhToan = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonGanDay).BeginInit();
            panelSanPhamChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnThemKh);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(txtNhanVien);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textMaHĐ);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textNhapSDTKH);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(865, 265);
            panel1.TabIndex = 0;
            // 
            // btnThemKh
            // 
            btnThemKh.Location = new Point(665, 110);
            btnThemKh.Name = "btnThemKh";
            btnThemKh.Size = new Size(180, 34);
            btnThemKh.TabIndex = 10;
            btnThemKh.Text = "Thêm Khách Hàng";
            btnThemKh.UseVisualStyleBackColor = true;
            btnThemKh.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Location = new Point(18, 187);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập ghi chú hóa đơn (nếu có)...";
            textBox1.Size = new Size(827, 60);
            textBox1.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(18, 159);
            label7.Name = "label7";
            label7.Size = new Size(152, 25);
            label7.TabIndex = 8;
            label7.Text = "Ghi chú hóa đơn";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(309, 83);
            label6.Name = "label6";
            label6.Size = new Size(113, 25);
            label6.TabIndex = 6;
            label6.Text = "Khách hàng";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(248, 250, 252);
            textBox2.Location = new Point(309, 111);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(332, 31);
            textBox2.TabIndex = 7;
            // 
            // txtNhanVien
            // 
            txtNhanVien.BackColor = Color.FromArgb(248, 250, 252);
            txtNhanVien.Location = new Point(18, 111);
            txtNhanVien.Name = "txtNhanVien";
            txtNhanVien.ReadOnly = true;
            txtNhanVien.Size = new Size(271, 31);
            txtNhanVien.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(18, 83);
            label5.Name = "label5";
            label5.Size = new Size(99, 25);
            label5.TabIndex = 4;
            label5.Text = "Nhân viên";
            // 
            // textMaHĐ
            // 
            textMaHĐ.BackColor = Color.FromArgb(248, 250, 252);
            textMaHĐ.Location = new Point(18, 38);
            textMaHĐ.Name = "textMaHĐ";
            textMaHĐ.ReadOnly = true;
            textMaHĐ.Size = new Size(271, 31);
            textMaHĐ.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(18, 10);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 0;
            label3.Text = "Mã hóa đơn";
            // 
            // textNhapSDTKH
            // 
            textNhapSDTKH.Location = new Point(309, 38);
            textNhapSDTKH.Name = "textNhapSDTKH";
            textNhapSDTKH.PlaceholderText = "Nhập số điện thoại khách hàng";
            textNhapSDTKH.Size = new Size(536, 31);
            textNhapSDTKH.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(309, 10);
            label1.Name = "label1";
            label1.Size = new Size(231, 25);
            label1.TabIndex = 2;
            label1.Text = "Tìm khách hàng theo SĐT";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblListTitle);
            panel2.Controls.Add(dgvHoaDonGanDay);
            panel2.Location = new Point(14, 292);
            panel2.Name = "panel2";
            panel2.Size = new Size(865, 382);
            panel2.TabIndex = 1;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblListTitle.Location = new Point(16, 12);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(277, 28);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Danh sách hóa đơn gần đây";
            // 
            // dgvHoaDonGanDay
            // 
            dgvHoaDonGanDay.AllowUserToAddRows = false;
            dgvHoaDonGanDay.AllowUserToDeleteRows = false;
            dgvHoaDonGanDay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDonGanDay.BackgroundColor = Color.White;
            dgvHoaDonGanDay.BorderStyle = BorderStyle.None;
            dgvHoaDonGanDay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDonGanDay.Columns.AddRange(new DataGridViewColumn[] { colMaHD, colTenKH, NGLAP, colThoiGian, colTongTien, TT, Xem });
            dgvHoaDonGanDay.Location = new Point(16, 46);
            dgvHoaDonGanDay.Name = "dgvHoaDonGanDay";
            dgvHoaDonGanDay.ReadOnly = true;
            dgvHoaDonGanDay.RowHeadersVisible = false;
            dgvHoaDonGanDay.RowHeadersWidth = 62;
            dgvHoaDonGanDay.RowTemplate.Height = 34;
            dgvHoaDonGanDay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDonGanDay.Size = new Size(831, 319);
            dgvHoaDonGanDay.TabIndex = 1;
            // 
            // colMaHD
            // 
            colMaHD.DataPropertyName = "ID";
            colMaHD.FillWeight = 12F;
            colMaHD.HeaderText = "Mã HĐ";
            colMaHD.MinimumWidth = 8;
            colMaHD.Name = "colMaHD";
            colMaHD.ReadOnly = true;
            // 
            // colTenKH
            // 
            colTenKH.DataPropertyName = "TenKhachHang";
            colTenKH.FillWeight = 23F;
            colTenKH.HeaderText = "Khách hàng";
            colTenKH.MinimumWidth = 8;
            colTenKH.Name = "colTenKH";
            colTenKH.ReadOnly = true;
            // 
            // NGLAP
            // 
            NGLAP.DataPropertyName = "NguoiLap";
            NGLAP.FillWeight = 20F;
            NGLAP.HeaderText = "Người lập";
            NGLAP.MinimumWidth = 8;
            NGLAP.Name = "NGLAP";
            NGLAP.ReadOnly = true;
            // 
            // colThoiGian
            // 
            colThoiGian.DataPropertyName = "NgayLap";
            colThoiGian.FillWeight = 18F;
            colThoiGian.HeaderText = "Ngày lập";
            colThoiGian.MinimumWidth = 8;
            colThoiGian.Name = "colThoiGian";
            colThoiGian.ReadOnly = true;
            // 
            // colTongTien
            // 
            colTongTien.DataPropertyName = "TongTien";
            colTongTien.FillWeight = 16F;
            colTongTien.HeaderText = "Tổng tiền";
            colTongTien.MinimumWidth = 8;
            colTongTien.Name = "colTongTien";
            colTongTien.ReadOnly = true;
            // 
            // TT
            // 
            TT.DataPropertyName = "TrangThai";
            TT.FillWeight = 14F;
            TT.HeaderText = "Trạng thái";
            TT.MinimumWidth = 8;
            TT.Name = "TT";
            TT.ReadOnly = true;
            // 
            // Xem
            // 
            Xem.FillWeight = 12F;
            Xem.HeaderText = "Chi tiết";
            Xem.MinimumWidth = 8;
            Xem.Name = "Xem";
            Xem.ReadOnly = true;
            Xem.Text = "Xem";
            Xem.UseColumnTextForButtonValue = true;
            // 
            // panelSanPhamChon
            // 
            panelSanPhamChon.BackColor = Color.White;
            panelSanPhamChon.BorderStyle = BorderStyle.FixedSingle;
            panelSanPhamChon.Controls.Add(btnThemSP);
            panelSanPhamChon.Controls.Add(lblSanPhamChon);
            panelSanPhamChon.Controls.Add(dataGridView2);
            panelSanPhamChon.Location = new Point(892, 14);
            panelSanPhamChon.Name = "panelSanPhamChon";
            panelSanPhamChon.Size = new Size(702, 470);
            panelSanPhamChon.TabIndex = 2;
            // 
            // btnThemSP
            // 
            btnThemSP.BackColor = Color.White;
            btnThemSP.FlatStyle = FlatStyle.Flat;
            btnThemSP.ForeColor = Color.FromArgb(37, 99, 235);
            btnThemSP.Location = new Point(543, 9);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(146, 35);
            btnThemSP.TabIndex = 2;
            btnThemSP.Text = "+ Thêm SP";
            btnThemSP.UseVisualStyleBackColor = false;
            // 
            // lblSanPhamChon
            // 
            lblSanPhamChon.AutoSize = true;
            lblSanPhamChon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSanPhamChon.Location = new Point(14, 12);
            lblSanPhamChon.Name = "lblSanPhamChon";
            lblSanPhamChon.Size = new Size(234, 28);
            lblSanPhamChon.TabIndex = 0;
            lblSanPhamChon.Text = "Sản phẩm đã chọn mua";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colDonGia, colSoLuong, colThanhTien });
            dataGridView2.Location = new Point(14, 50);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 34;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(675, 404);
            dataGridView2.TabIndex = 1;
            // 
            // colMaSP
            // 
            colMaSP.DataPropertyName = "ID";
            colMaSP.FillWeight = 14F;
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 8;
            colMaSP.Name = "colMaSP";
            // 
            // colTenSP
            // 
            colTenSP.DataPropertyName = "TenSanPham";
            colTenSP.FillWeight = 38F;
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.MinimumWidth = 8;
            colTenSP.Name = "colTenSP";
            // 
            // colDonGia
            // 
            colDonGia.DataPropertyName = "DonGia";
            colDonGia.FillWeight = 16F;
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 8;
            colDonGia.Name = "colDonGia";
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.FillWeight = 12F;
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 8;
            colSoLuong.Name = "colSoLuong";
            // 
            // colThanhTien
            // 
            colThanhTien.DataPropertyName = "ThanhTien";
            colThanhTien.FillWeight = 20F;
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 8;
            colThanhTien.Name = "colThanhTien";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblTongValue);
            panel3.Controls.Add(lblTamTinhValue);
            panel3.Controls.Add(lblTongLabel);
            panel3.Controls.Add(lblTamTinhLabel);
            panel3.Location = new Point(892, 495);
            panel3.Name = "panel3";
            panel3.Size = new Size(702, 101);
            panel3.TabIndex = 3;
            // 
            // lblTongValue
            // 
            lblTongValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongValue.ForeColor = Color.FromArgb(220, 38, 38);
            lblTongValue.Location = new Point(504, 56);
            lblTongValue.Name = "lblTongValue";
            lblTongValue.Size = new Size(185, 32);
            lblTongValue.TabIndex = 3;
            lblTongValue.Text = "0 VNĐ";
            lblTongValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTamTinhValue
            // 
            lblTamTinhValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTamTinhValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblTamTinhValue.Location = new Point(504, 16);
            lblTamTinhValue.Name = "lblTamTinhValue";
            lblTamTinhValue.Size = new Size(185, 28);
            lblTamTinhValue.TabIndex = 1;
            lblTamTinhValue.Text = "0 VNĐ";
            lblTamTinhValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTongLabel
            // 
            lblTongLabel.AutoSize = true;
            lblTongLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongLabel.Location = new Point(14, 56);
            lblTongLabel.Name = "lblTongLabel";
            lblTongLabel.Size = new Size(209, 28);
            lblTongLabel.TabIndex = 2;
            lblTongLabel.Text = "TỔNG THANH TOÁN";
            // 
            // lblTamTinhLabel
            // 
            lblTamTinhLabel.AutoSize = true;
            lblTamTinhLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTamTinhLabel.Location = new Point(14, 18);
            lblTamTinhLabel.Name = "lblTamTinhLabel";
            lblTamTinhLabel.Size = new Size(142, 25);
            lblTamTinhLabel.TabIndex = 0;
            lblTamTinhLabel.Text = "Cộng tiền hàng";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(btnHuy);
            panel4.Controls.Add(btnLuu);
            panel4.Controls.Add(btnThanhToan);
            panel4.Location = new Point(892, 606);
            panel4.Name = "panel4";
            panel4.Size = new Size(702, 68);
            panel4.TabIndex = 4;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.ForeColor = Color.FromArgb(51, 65, 85);
            btnHuy.Location = new Point(14, 14);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(130, 38);
            btnHuy.TabIndex = 0;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(245, 158, 11);
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(150, 14);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(228, 38);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu (chưa thanh toán)";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.FromArgb(37, 99, 235);
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(384, 14);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(305, 38);
            btnThanhToan.TabIndex = 2;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // frmHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1608, 686);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panelSanPhamChon);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lập hóa đơn";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonGanDay).EndInit();
            panelSanPhamChon.ResumeLayout(false);
            panelSanPhamChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textNhapSDTKH;
        private Label label1;
        private Panel panel2;
        private DataGridView dgvHoaDonGanDay;
        private Label lblListTitle;
        private Panel panelSanPhamChon;
        private Label lblSanPhamChon;
        private DataGridView dataGridView2;
        private Panel panel3;
        private Label lblTamTinhLabel;
        private Label lblTongLabel;
        private Label lblTamTinhValue;
        private Label lblTongValue;
        private Panel panel4;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnThanhToan;
        private Button btnThemSP;
        private TextBox textMaHĐ;
        private Label label3;
        private Label label5;
        private TextBox txtNhanVien;
        private Label label6;
        private TextBox textBox2;
        private Label label7;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn colMaHD;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn NGLAP;
        private DataGridViewTextBoxColumn colThoiGian;
        private DataGridViewTextBoxColumn colTongTien;
        private DataGridViewTextBoxColumn TT;
        private DataGridViewButtonColumn Xem;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colThanhTien;
        private Button btnThemKh;
    }
}