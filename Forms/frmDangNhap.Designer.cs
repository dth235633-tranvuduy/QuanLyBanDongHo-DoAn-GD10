namespace LTQL_QLBHDongHo.Forms
{
    partial class frmDangNhap
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
            btnLogin = new Button();
            chkRemember = new CheckBox();
            txtPass = new TextBox();
            lblPass = new Label();
            txtUser = new TextBox();
            lblUser = new Label();
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
            pnlContainer.Size = new Size(960, 560);
            pnlContainer.TabIndex = 0;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(lblFooter);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(chkRemember);
            pnlCard.Controls.Add(txtPass);
            pnlCard.Controls.Add(lblPass);
            pnlCard.Controls.Add(txtUser);
            pnlCard.Controls.Add(lblUser);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Location = new Point(410, 60);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(500, 440);
            pnlCard.TabIndex = 1;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Font = new Font("Segoe UI", 8.5F);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.Location = new Point(109, 384);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(279, 23);
            lblFooter.TabIndex = 8;
            lblFooter.Text = "LTQL_QLBHDongHo • Phiên bản .NET 8";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(59, 130, 246);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(56, 322);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(386, 46);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Font = new Font("Segoe UI", 9F);
            chkRemember.ForeColor = Color.FromArgb(73, 80, 87);
            chkRemember.Location = new Point(56, 279);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(160, 29);
            chkRemember.TabIndex = 6;
            chkRemember.Text = "Hiển thị mật khẩu";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 10.5F);
            txtPass.Location = new Point(56, 237);
            txtPass.Name = "txtPass";
            txtPass.PlaceholderText = "Nhập mật khẩu";
            txtPass.Size = new Size(386, 35);
            txtPass.TabIndex = 5;
            txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(33, 37, 41);
            lblPass.Location = new Point(56, 207);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(93, 25);
            lblPass.TabIndex = 4;
            lblPass.Text = "Mật khẩu";
            // 
            // txtUser
            // 
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 10.5F);
            txtUser.Location = new Point(56, 157);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Nhập tên đăng nhập";
            txtUser.Size = new Size(386, 35);
            txtUser.TabIndex = 3;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUser.ForeColor = Color.FromArgb(33, 37, 41);
            lblUser.Location = new Point(56, 127);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(139, 25);
            lblUser.TabIndex = 2;
            lblUser.Text = "Tên đăng nhập";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblSubtitle.Location = new Point(56, 74);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(341, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Vui lòng nhập thông tin để truy cập hệ thống";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(48, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(299, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng nhập hệ thống";
            // 
            // pnlBrand
            // 
            pnlBrand.BackColor = Color.FromArgb(59, 130, 246);
            pnlBrand.Controls.Add(lblBrandDesc);
            pnlBrand.Controls.Add(lblBrandSubtitle);
            pnlBrand.Controls.Add(lblBrandTitle);
            pnlBrand.Location = new Point(48, 60);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(340, 440);
            pnlBrand.TabIndex = 0;
            // 
            // lblBrandDesc
            // 
            lblBrandDesc.Font = new Font("Segoe UI", 9.5F);
            lblBrandDesc.ForeColor = Color.FromArgb(230, 240, 255);
            lblBrandDesc.Location = new Point(28, 208);
            lblBrandDesc.Name = "lblBrandDesc";
            lblBrandDesc.Size = new Size(284, 148);
            lblBrandDesc.TabIndex = 2;
            lblBrandDesc.Text = "• Quản lý sản phẩm đồng hồ\r\n• Theo dõi hóa đơn và khách hàng\r\n• Đồng bộ dữ liệu bán hàng nhanh chóng";
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.Font = new Font("Segoe UI", 11F);
            lblBrandSubtitle.ForeColor = Color.FromArgb(219, 234, 254);
            lblBrandSubtitle.Location = new Point(28, 110);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(290, 86);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Giải pháp quản lý bán hàng đồng hồ\r\nhiện đại và trực quan";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.White;
            lblBrandTitle.Location = new Point(22, 42);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(212, 57);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "SEVEN TIME";
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 251);
            ClientSize = new Size(960, 560);
            Controls.Add(pnlContainer);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
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
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.Button btnLogin;
        private Label lblFooter;
    }
}