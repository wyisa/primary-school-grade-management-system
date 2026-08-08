namespace do_an_nhom_15
{
    partial class FrmThemHocSinh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtMaHocSinh = new TextBox();
            txtHoTen = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cboGioiTinh = new ComboBox();
            lblLop = new Label();
            btnLuu = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 49);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã học sinh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 87);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(114, 129);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Ngày sinh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(114, 168);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 3;
            label4.Text = "Giới Tính";
            // 
            // txtMaHocSinh
            // 
            txtMaHocSinh.Location = new Point(232, 49);
            txtMaHocSinh.Name = "txtMaHocSinh";
            txtMaHocSinh.Size = new Size(100, 23);
            txtMaHocSinh.TabIndex = 4;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(230, 91);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 23);
            txtHoTen.TabIndex = 5;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(230, 129);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(200, 23);
            dtpNgaySinh.TabIndex = 6;
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(232, 168);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(121, 23);
            cboGioiTinh.TabIndex = 7;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(114, 210);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(300, 15);
            lblLop.TabIndex = 8;
            lblLop.Text = "Lớp:";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(232, 250);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 30);
            btnLuu.TabIndex = 9;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // FrmThemHocSinh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 320);
            Controls.Add(btnLuu);
            Controls.Add(lblLop);
            Controls.Add(cboGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaHocSinh);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmThemHocSinh";
            Text = "THÊM HỌC SINH";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtMaHocSinh;
        private TextBox txtHoTen;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboGioiTinh;
        private Label lblLop;
        private Button btnLuu;
    }
}