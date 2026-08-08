namespace do_an_nhom_15
{
    partial class FrmChangePassword
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
            lblTieuDe = new Label();
            lblMatKhauCu = new Label();
            lblMatKhauMoi = new Label();
            lblNhapLaiMatKhau = new Label();
            btnDoiMatKhau = new Button();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtNhapLaiMatKhau = new TextBox();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(313, 39);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(90, 15);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐỔI MẬT KHẨU";
            // 
            // lblMatKhauCu
            // 
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.Location = new Point(100, 93);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new Size(99, 15);
            lblMatKhauCu.TabIndex = 1;
            lblMatKhauCu.Text = "Mật khẩu hiện tại";
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Location = new Point(100, 141);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(81, 15);
            lblMatKhauMoi.TabIndex = 2;
            lblMatKhauMoi.Text = "Mật khẩu mới";
            // 
            // lblNhapLaiMatKhau
            // 
            lblNhapLaiMatKhau.AutoSize = true;
            lblNhapLaiMatKhau.Location = new Point(100, 190);
            lblNhapLaiMatKhau.Name = "lblNhapLaiMatKhau";
            lblNhapLaiMatKhau.Size = new Size(128, 15);
            lblNhapLaiMatKhau.TabIndex = 3;
            lblNhapLaiMatKhau.Text = "Nhập lại mật khẩu mới";
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Location = new Point(208, 247);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(104, 23);
            btnDoiMatKhau.TabIndex = 4;
            btnDoiMatKhau.Text = "Lưu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(288, 93);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(100, 23);
            txtMatKhauCu.TabIndex = 6;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(288, 138);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(100, 23);
            txtMatKhauMoi.TabIndex = 7;
            // 
            // txtNhapLaiMatKhau
            // 
            txtNhapLaiMatKhau.Location = new Point(288, 190);
            txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            txtNhapLaiMatKhau.Size = new Size(100, 23);
            txtNhapLaiMatKhau.TabIndex = 8;
            // 
            // FrmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 314);
            Controls.Add(txtNhapLaiMatKhau);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(lblNhapLaiMatKhau);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(lblMatKhauCu);
            Controls.Add(lblTieuDe);
            Name = "FrmChangePassword";
            Text = "ĐỔI MẬT KHẨU";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblNhapLaiMatKhau;
        private Button btnDoiMatKhau;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtNhapLaiMatKhau;
    }
}