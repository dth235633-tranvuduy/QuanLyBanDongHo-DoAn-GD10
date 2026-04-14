namespace LTQL_QLBHDongHo.Forms
{
    partial class frmDoiMatKhau
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
            pnlContainer = new Panel();
            pnlCard = new Panel();
            lblFooter = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            chkShowPassword = new CheckBox();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtNewPassword = new TextBox();
            lblNewPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblCurrentPassword = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlBrand = new Panel();
            lblBrandDesc = new Label();
            lblBrandSubtitle = new Label();
            lblBrandTitle = new Label();
            pnlContainer.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlBrand.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(243, 246, 251);
            pnlContainer.Controls.Add(pnlCard);
            pnlContainer.Controls.Add(pnlBrand);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(980, 600);
            pnlContainer.TabIndex = 0;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(lblFooter);
            pnlCard.Controls.Add(btnSave);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Controls.Add(chkShowPassword);
            pnlCard.Controls.Add(txtConfirmPassword);
            pnlCard.Controls.Add(lblConfirmPassword);
            pnlCard.Controls.Add(txtNewPassword);
            pnlCard.Controls.Add(lblNewPassword);
            pnlCard.Controls.Add(txtCurrentPassword);
            pnlCard.Controls.Add(lblCurrentPassword);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Location = new Point(420, 52);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(520, 495);
            pnlCard.TabIndex = 1;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Font = new Font("Segoe UI", 8.5F);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.Location = new Point(88, 448);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(343, 23);
            lblFooter.TabIndex = 11;
            lblFooter.Text = "Bảo mật tài khoản • LTQL_QLBHDongHo (.NET 8)";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(25, 135, 84);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(266, 381);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(188, 44);
            btnSave.TabIndex = 10;
            btnSave.Text = "LƯU THAY ĐỔI";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(64, 381);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(188, 44);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "HỦY";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(73, 80, 87);
            chkShowPassword.Location = new Point(64, 337);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(167, 29);
            chkShowPassword.TabIndex = 8;
            chkShowPassword.Text = "Hiển thị mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 10.5F);
            txtConfirmPassword.Location = new Point(64, 296);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu mới";
            txtConfirmPassword.Size = new Size(390, 35);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(33, 37, 41);
            lblConfirmPassword.Location = new Point(64, 266);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(190, 25);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Xác nhận mật khẩu mới";
            // 
            // txtNewPassword
            // 
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 10.5F);
            txtNewPassword.Location = new Point(64, 217);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PlaceholderText = "Nhập mật khẩu mới";
            txtNewPassword.Size = new Size(390, 35);
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(33, 37, 41);
            lblNewPassword.Location = new Point(64, 187);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(131, 25);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "Mật khẩu mới";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPassword.Font = new Font("Segoe UI", 10.5F);
            txtCurrentPassword.Location = new Point(64, 139);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PlaceholderText = "Nhập mật khẩu hiện tại";
            txtCurrentPassword.Size = new Size(390, 35);
            txtCurrentPassword.TabIndex = 3;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCurrentPassword.ForeColor = Color.FromArgb(33, 37, 41);
            lblCurrentPassword.Location = new Point(64, 109);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(150, 25);
            lblCurrentPassword.TabIndex = 2;
            lblCurrentPassword.Text = "Mật khẩu hiện tại";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblSubtitle.Location = new Point(64, 66);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(283, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Cập nhật mật khẩu để bảo vệ tài khoản";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(56, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(231, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đổi mật khẩu";
            // 
            // pnlBrand
            // 
            pnlBrand.BackColor = Color.FromArgb(59, 130, 246);
            pnlBrand.Controls.Add(lblBrandDesc);
            pnlBrand.Controls.Add(lblBrandSubtitle);
            pnlBrand.Controls.Add(lblBrandTitle);
            pnlBrand.Location = new Point(40, 52);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(350, 495);
            pnlBrand.TabIndex = 0;
            // 
            // lblBrandDesc
            // 
            lblBrandDesc.Font = new Font("Segoe UI", 9.5F);
            lblBrandDesc.ForeColor = Color.FromArgb(230, 240, 255);
            lblBrandDesc.Location = new Point(30, 209);
            lblBrandDesc.Name = "lblBrandDesc";
            lblBrandDesc.Size = new Size(288, 177);
            lblBrandDesc.TabIndex = 2;
            lblBrandDesc.Text = "• Mật khẩu mạnh giúp bảo vệ dữ liệu\r\n• Tăng an toàn khi sử dụng hệ thống\r\n• Đảm bảo tính riêng tư cho nhân viên";
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.Font = new Font("Segoe UI", 11F);
            lblBrandSubtitle.ForeColor = Color.FromArgb(219, 234, 254);
            lblBrandSubtitle.Location = new Point(30, 108);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(290, 89);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Thiết lập bảo mật tài khoản\r\nnhanh chóng và trực quan";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.White;
            lblBrandTitle.Location = new Point(24, 40);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(240, 57);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "BẢO MẬT TK";
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 251);
            ClientSize = new Size(980, 600);
            Controls.Add(pnlContainer);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            pnlContainer.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlBrand;
        private Label lblBrandTitle;
        private Label lblBrandSubtitle;
        private Label lblBrandDesc;
        private Panel pnlCard;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private CheckBox chkShowPassword;
        private Button btnCancel;
        private Button btnSave;
        private Label lblFooter;
    }
}