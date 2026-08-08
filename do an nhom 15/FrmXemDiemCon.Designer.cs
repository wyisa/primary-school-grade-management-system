namespace do_an_nhom_15
{
    partial class FrmXemDiemCon
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
            pnlHeader = new Panel();
            btnDangXuat = new Button();
            btnDoiMatKhau = new Button();
            lblHocSinhBanner = new Label();
            lblTieuDe = new Label();
            lblIconTieuDe = new Label();
            pnlThongTin = new Panel();
            lblTieuDeThongTin = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblMaHocSinh = new Label();
            txtMaHocSinh = new TextBox();
            lblLop = new Label();
            txtLop = new TextBox();
            pnlKetQua = new Panel();
            lblTieuDeKetQua = new Label();
            pnlBangDiem = new Panel();
            lblTieuDeBangDiem = new Label();
            dgvDiem = new DataGridView();
            pnlPhamChat = new Panel();
            lblTieuDePhamChat = new Label();
            lblPhamChat = new Label();
            txtPhamChat = new Label();
            lblNangLuc = new Label();
            txtNangLuc = new Label();
            pnlHeader.SuspendLayout();
            pnlThongTin.SuspendLayout();
            pnlBangDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            pnlPhamChat.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnDangXuat);
            pnlHeader.Controls.Add(btnDoiMatKhau);
            pnlHeader.Controls.Add(lblHocSinhBanner);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblIconTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(980, 92);
            pnlHeader.TabIndex = 0;
            // 
            // lblIconTieuDe
            // 
            lblIconTieuDe.AutoSize = false;
            lblIconTieuDe.Font = new Font("Segoe UI Emoji", 24F);
            lblIconTieuDe.ForeColor = Color.White;
            lblIconTieuDe.Location = new Point(34, 16);
            lblIconTieuDe.Name = "lblIconTieuDe";
            lblIconTieuDe.Size = new Size(60, 60);
            lblIconTieuDe.TabIndex = 0;
            lblIconTieuDe.Text = "🎓";
            lblIconTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(104, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(300, 32);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "THÔNG TIN HỌC TẬP CỦA CON";
            // 
            // lblHocSinhBanner
            // 
            lblHocSinhBanner.AutoSize = true;
            lblHocSinhBanner.Location = new Point(104, 54);
            lblHocSinhBanner.Name = "lblHocSinhBanner";
            lblHocSinhBanner.Size = new Size(150, 15);
            lblHocSinhBanner.TabIndex = 2;
            lblHocSinhBanner.Text = "HỌC SINH: —";
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDoiMatKhau.Location = new Point(640, 29);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(150, 34);
            btnDoiMatKhau.TabIndex = 3;
            btnDoiMatKhau.Text = "🔑  Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDangXuat.Location = new Point(800, 29);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(130, 34);
            btnDangXuat.TabIndex = 4;
            btnDangXuat.Text = "🚪  Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // pnlThongTin
            // 
            pnlThongTin.Controls.Add(lblTieuDeThongTin);
            pnlThongTin.Controls.Add(lblHoTen);
            pnlThongTin.Controls.Add(txtHoTen);
            pnlThongTin.Controls.Add(lblMaHocSinh);
            pnlThongTin.Controls.Add(txtMaHocSinh);
            pnlThongTin.Controls.Add(lblLop);
            pnlThongTin.Controls.Add(txtLop);
            pnlThongTin.Location = new Point(30, 110);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.Size = new Size(920, 120);
            pnlThongTin.TabIndex = 1;
            // 
            // lblTieuDeThongTin
            // 
            lblTieuDeThongTin.AutoSize = true;
            lblTieuDeThongTin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeThongTin.Location = new Point(20, 12);
            lblTieuDeThongTin.Name = "lblTieuDeThongTin";
            lblTieuDeThongTin.Size = new Size(150, 19);
            lblTieuDeThongTin.TabIndex = 0;
            lblTieuDeThongTin.Text = "👤 THÔNG TIN HỌC SINH";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 54);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(106, 15);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ và tên học sinh";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(20, 74);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(260, 23);
            txtHoTen.TabIndex = 2;
            // 
            // lblMaHocSinh
            // 
            lblMaHocSinh.AutoSize = true;
            lblMaHocSinh.Location = new Point(300, 54);
            lblMaHocSinh.Name = "lblMaHocSinh";
            lblMaHocSinh.Size = new Size(72, 15);
            lblMaHocSinh.TabIndex = 3;
            lblMaHocSinh.Text = "Mã học sinh";
            // 
            // txtMaHocSinh
            // 
            txtMaHocSinh.Location = new Point(300, 74);
            txtMaHocSinh.Name = "txtMaHocSinh";
            txtMaHocSinh.Size = new Size(160, 23);
            txtMaHocSinh.TabIndex = 4;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(480, 54);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(27, 15);
            lblLop.TabIndex = 5;
            lblLop.Text = "Lớp";
            // 
            // txtLop
            // 
            txtLop.Location = new Point(480, 74);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(140, 23);
            txtLop.TabIndex = 6;
            // 
            // pnlKetQua
            // 
            pnlKetQua.Controls.Add(lblTieuDeKetQua);
            pnlKetQua.Location = new Point(30, 242);
            pnlKetQua.Name = "pnlKetQua";
            pnlKetQua.Size = new Size(920, 170);
            pnlKetQua.TabIndex = 2;
            // 
            // lblTieuDeKetQua
            // 
            lblTieuDeKetQua.AutoSize = true;
            lblTieuDeKetQua.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeKetQua.Location = new Point(20, 12);
            lblTieuDeKetQua.Name = "lblTieuDeKetQua";
            lblTieuDeKetQua.Size = new Size(150, 19);
            lblTieuDeKetQua.TabIndex = 0;
            lblTieuDeKetQua.Text = "📊 KẾT QUẢ HỌC TẬP";
            // 
            // pnlBangDiem
            // 
            pnlBangDiem.Controls.Add(dgvDiem);
            pnlBangDiem.Controls.Add(lblTieuDeBangDiem);
            pnlBangDiem.Location = new Point(30, 428);
            pnlBangDiem.Name = "pnlBangDiem";
            pnlBangDiem.Size = new Size(920, 220);
            pnlBangDiem.TabIndex = 3;
            // 
            // lblTieuDeBangDiem
            // 
            lblTieuDeBangDiem.AutoSize = true;
            lblTieuDeBangDiem.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeBangDiem.Location = new Point(20, 12);
            lblTieuDeBangDiem.Name = "lblTieuDeBangDiem";
            lblTieuDeBangDiem.Size = new Size(150, 19);
            lblTieuDeBangDiem.TabIndex = 0;
            lblTieuDeBangDiem.Text = "📋 BẢNG ĐIỂM CHI TIẾT";
            // 
            // dgvDiem
            // 
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Location = new Point(20, 50);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.Size = new Size(880, 152);
            dgvDiem.TabIndex = 1;
            // 
            // pnlPhamChat
            // 
            pnlPhamChat.Controls.Add(lblTieuDePhamChat);
            pnlPhamChat.Controls.Add(lblPhamChat);
            pnlPhamChat.Controls.Add(txtPhamChat);
            pnlPhamChat.Controls.Add(lblNangLuc);
            pnlPhamChat.Controls.Add(txtNangLuc);
            pnlPhamChat.Location = new Point(30, 664);
            pnlPhamChat.Name = "pnlPhamChat";
            pnlPhamChat.Size = new Size(920, 110);
            pnlPhamChat.TabIndex = 4;
            // 
            // lblTieuDePhamChat
            // 
            lblTieuDePhamChat.AutoSize = true;
            lblTieuDePhamChat.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDePhamChat.Location = new Point(20, 12);
            lblTieuDePhamChat.Name = "lblTieuDePhamChat";
            lblTieuDePhamChat.Size = new Size(150, 19);
            lblTieuDePhamChat.TabIndex = 0;
            lblTieuDePhamChat.Text = "🌟 PHẨM CHẤT & NĂNG LỰC";
            // 
            // lblPhamChat
            // 
            lblPhamChat.AutoSize = true;
            lblPhamChat.Location = new Point(20, 62);
            lblPhamChat.Name = "lblPhamChat";
            lblPhamChat.Size = new Size(64, 15);
            lblPhamChat.TabIndex = 1;
            lblPhamChat.Text = "Phẩm chất";
            // 
            // txtPhamChat
            // 
            txtPhamChat.AutoSize = true;
            txtPhamChat.Location = new Point(150, 56);
            txtPhamChat.Name = "txtPhamChat";
            txtPhamChat.Size = new Size(100, 28);
            txtPhamChat.TabIndex = 2;
            txtPhamChat.Text = "Chưa có đánh giá";
            // 
            // lblNangLuc
            // 
            lblNangLuc.AutoSize = true;
            lblNangLuc.Location = new Point(480, 62);
            lblNangLuc.Name = "lblNangLuc";
            lblNangLuc.Size = new Size(55, 15);
            lblNangLuc.TabIndex = 3;
            lblNangLuc.Text = "Năng lực";
            // 
            // txtNangLuc
            // 
            txtNangLuc.AutoSize = true;
            txtNangLuc.Location = new Point(600, 56);
            txtNangLuc.Name = "txtNangLuc";
            txtNangLuc.Size = new Size(100, 28);
            txtNangLuc.TabIndex = 4;
            txtNangLuc.Text = "Chưa có đánh giá";
            // 
            // FrmXemDiemCon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 800);
            Controls.Add(pnlPhamChat);
            Controls.Add(pnlBangDiem);
            Controls.Add(pnlKetQua);
            Controls.Add(pnlThongTin);
            Controls.Add(pnlHeader);
            Name = "FrmXemDiemCon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin học tập của con";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            pnlBangDiem.ResumeLayout(false);
            pnlBangDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            pnlPhamChat.ResumeLayout(false);
            pnlPhamChat.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblIconTieuDe;
        private Label lblTieuDe;
        private Label lblHocSinhBanner;
        private Button btnDoiMatKhau;
        private Button btnDangXuat;
        private Panel pnlThongTin;
        private Label lblTieuDeThongTin;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblMaHocSinh;
        private TextBox txtMaHocSinh;
        private Label lblLop;
        private TextBox txtLop;
        private Panel pnlKetQua;
        private Label lblTieuDeKetQua;
        private Panel pnlBangDiem;
        private Label lblTieuDeBangDiem;
        private DataGridView dgvDiem;
        private Panel pnlPhamChat;
        private Label lblTieuDePhamChat;
        private Label lblPhamChat;
        private Label txtPhamChat;
        private Label lblNangLuc;
        private Label txtNangLuc;
    }
}
