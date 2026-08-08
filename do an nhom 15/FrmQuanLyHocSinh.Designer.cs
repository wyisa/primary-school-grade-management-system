namespace do_an_nhom_15
{
    partial class FrmQuanLyHocSinh : Form
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
            lblLopPhuTrach = new Label();
            lblTieuDe = new Label();
            lblIconTieuDe = new Label();
            pnlThongKe = new Panel();
            pnlTheNu = new Panel();
            lblIconNu = new Label();
            lblSoNu = new Label();
            lblNhanNu = new Label();
            pnlTheNam = new Panel();
            lblIconNam = new Label();
            lblSoNam = new Label();
            lblNhanNam = new Label();
            pnlTheTong = new Panel();
            lblIconTong = new Label();
            lblSoTong = new Label();
            lblNhanTong = new Label();
            pnlToolbar = new Panel();
            btnTaoTaiKhoanPhuHuynh = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThemMoi = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            pnlBangCard = new Panel();
            dgvHocSinh = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlThongKe.SuspendLayout();
            pnlTheNu.SuspendLayout();
            pnlTheNam.SuspendLayout();
            pnlTheTong.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlBangCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocSinh).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblLopPhuTrach);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblIconTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1040, 110);
            pnlHeader.TabIndex = 0;
            // 
            // lblIconTieuDe
            // 
            lblIconTieuDe.AutoSize = false;
            lblIconTieuDe.Font = new Font("Segoe UI Emoji", 26F);
            lblIconTieuDe.ForeColor = Color.White;
            lblIconTieuDe.Location = new Point(34, 22);
            lblIconTieuDe.Name = "lblIconTieuDe";
            lblIconTieuDe.Size = new Size(65, 65);
            lblIconTieuDe.TabIndex = 0;
            lblIconTieuDe.Text = "🎓";
            lblIconTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(108, 22);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(115, 15);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "QUẢN LÝ HỌC SINH";
            // 
            // lblLopPhuTrach
            // 
            lblLopPhuTrach.AutoSize = true;
            lblLopPhuTrach.Location = new Point(110, 60);
            lblLopPhuTrach.Name = "lblLopPhuTrach";
            lblLopPhuTrach.Size = new Size(140, 15);
            lblLopPhuTrach.TabIndex = 2;
            lblLopPhuTrach.Text = "🏫 Lớp 1A  •  0 học sinh";
            // 
            // pnlThongKe
            // 
            pnlThongKe.Controls.Add(pnlTheNu);
            pnlThongKe.Controls.Add(pnlTheNam);
            pnlThongKe.Controls.Add(pnlTheTong);
            pnlThongKe.Dock = DockStyle.Top;
            pnlThongKe.Location = new Point(0, 110);
            pnlThongKe.Name = "pnlThongKe";
            pnlThongKe.Size = new Size(1040, 104);
            pnlThongKe.TabIndex = 1;
            // 
            // pnlTheTong
            // 
            pnlTheTong.Controls.Add(lblIconTong);
            pnlTheTong.Controls.Add(lblSoTong);
            pnlTheTong.Controls.Add(lblNhanTong);
            pnlTheTong.Location = new Point(34, 12);
            pnlTheTong.Name = "pnlTheTong";
            pnlTheTong.Size = new Size(310, 82);
            pnlTheTong.TabIndex = 0;
            // 
            // lblIconTong
            // 
            lblIconTong.AutoSize = false;
            lblIconTong.Font = new Font("Segoe UI Emoji", 22F);
            lblIconTong.Location = new Point(18, 14);
            lblIconTong.Name = "lblIconTong";
            lblIconTong.Size = new Size(56, 54);
            lblIconTong.TabIndex = 0;
            lblIconTong.Text = "👥";
            lblIconTong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSoTong
            // 
            lblSoTong.AutoSize = true;
            lblSoTong.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSoTong.Location = new Point(86, 12);
            lblSoTong.Name = "lblSoTong";
            lblSoTong.Size = new Size(20, 32);
            lblSoTong.TabIndex = 1;
            lblSoTong.Text = "0";
            // 
            // lblNhanTong
            // 
            lblNhanTong.AutoSize = true;
            lblNhanTong.Location = new Point(88, 48);
            lblNhanTong.Name = "lblNhanTong";
            lblNhanTong.Size = new Size(110, 15);
            lblNhanTong.TabIndex = 2;
            lblNhanTong.Text = "Tổng số học sinh";
            // 
            // pnlTheNam
            // 
            pnlTheNam.Controls.Add(lblIconNam);
            pnlTheNam.Controls.Add(lblSoNam);
            pnlTheNam.Controls.Add(lblNhanNam);
            pnlTheNam.Location = new Point(360, 12);
            pnlTheNam.Name = "pnlTheNam";
            pnlTheNam.Size = new Size(310, 82);
            pnlTheNam.TabIndex = 1;
            // 
            // lblIconNam
            // 
            lblIconNam.AutoSize = false;
            lblIconNam.Font = new Font("Segoe UI Emoji", 22F);
            lblIconNam.Location = new Point(18, 14);
            lblIconNam.Name = "lblIconNam";
            lblIconNam.Size = new Size(56, 54);
            lblIconNam.TabIndex = 0;
            lblIconNam.Text = "👦";
            lblIconNam.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSoNam
            // 
            lblSoNam.AutoSize = true;
            lblSoNam.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSoNam.Location = new Point(86, 12);
            lblSoNam.Name = "lblSoNam";
            lblSoNam.Size = new Size(20, 32);
            lblSoNam.TabIndex = 1;
            lblSoNam.Text = "0";
            // 
            // lblNhanNam
            // 
            lblNhanNam.AutoSize = true;
            lblNhanNam.Location = new Point(88, 48);
            lblNhanNam.Name = "lblNhanNam";
            lblNhanNam.Size = new Size(100, 15);
            lblNhanNam.TabIndex = 2;
            lblNhanNam.Text = "Học sinh Nam";
            // 
            // pnlTheNu
            // 
            pnlTheNu.Controls.Add(lblIconNu);
            pnlTheNu.Controls.Add(lblSoNu);
            pnlTheNu.Controls.Add(lblNhanNu);
            pnlTheNu.Location = new Point(686, 12);
            pnlTheNu.Name = "pnlTheNu";
            pnlTheNu.Size = new Size(310, 82);
            pnlTheNu.TabIndex = 2;
            // 
            // lblIconNu
            // 
            lblIconNu.AutoSize = false;
            lblIconNu.Font = new Font("Segoe UI Emoji", 22F);
            lblIconNu.Location = new Point(18, 14);
            lblIconNu.Name = "lblIconNu";
            lblIconNu.Size = new Size(56, 54);
            lblIconNu.TabIndex = 0;
            lblIconNu.Text = "👧";
            lblIconNu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSoNu
            // 
            lblSoNu.AutoSize = true;
            lblSoNu.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSoNu.Location = new Point(86, 12);
            lblSoNu.Name = "lblSoNu";
            lblSoNu.Size = new Size(20, 32);
            lblSoNu.TabIndex = 1;
            lblSoNu.Text = "0";
            // 
            // lblNhanNu
            // 
            lblNhanNu.AutoSize = true;
            lblNhanNu.Location = new Point(88, 48);
            lblNhanNu.Name = "lblNhanNu";
            lblNhanNu.Size = new Size(90, 15);
            lblNhanNu.TabIndex = 2;
            lblNhanNu.Text = "Học sinh Nữ";
            // 
            // pnlToolbar
            // 
            pnlToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlToolbar.Controls.Add(btnTaoTaiKhoanPhuHuynh);
            pnlToolbar.Controls.Add(btnXoa);
            pnlToolbar.Controls.Add(btnSua);
            pnlToolbar.Controls.Add(btnThemMoi);
            pnlToolbar.Controls.Add(txtTimKiem);
            pnlToolbar.Controls.Add(lblTimKiem);
            pnlToolbar.Location = new Point(34, 226);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(972, 66);
            pnlToolbar.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(16, 24);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(70, 15);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "🔍 Tìm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(90, 19);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(200, 30);
            txtTimKiem.TabIndex = 1;
            // 
            // btnThemMoi
            // 
            btnThemMoi.Location = new Point(310, 16);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(120, 36);
            btnThemMoi.TabIndex = 2;
            btnThemMoi.Text = "➕ Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(440, 16);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 36);
            btnSua.TabIndex = 3;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(550, 16);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 36);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnTaoTaiKhoanPhuHuynh
            // 
            btnTaoTaiKhoanPhuHuynh.Location = new Point(660, 16);
            btnTaoTaiKhoanPhuHuynh.Name = "btnTaoTaiKhoanPhuHuynh";
            btnTaoTaiKhoanPhuHuynh.Size = new Size(226, 36);
            btnTaoTaiKhoanPhuHuynh.TabIndex = 5;
            btnTaoTaiKhoanPhuHuynh.Text = "👪 Tạo tài khoản phụ huynh";
            btnTaoTaiKhoanPhuHuynh.UseVisualStyleBackColor = true;
            // 
            // pnlBangCard
            // 
            pnlBangCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBangCard.Controls.Add(dgvHocSinh);
            pnlBangCard.Location = new Point(34, 306);
            pnlBangCard.Name = "pnlBangCard";
            pnlBangCard.Padding = new Padding(12);
            pnlBangCard.Size = new Size(972, 358);
            pnlBangCard.TabIndex = 3;
            // 
            // dgvHocSinh
            // 
            dgvHocSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHocSinh.Dock = DockStyle.Fill;
            dgvHocSinh.Location = new Point(12, 12);
            dgvHocSinh.Name = "dgvHocSinh";
            dgvHocSinh.ReadOnly = true;
            dgvHocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocSinh.MultiSelect = false;
            dgvHocSinh.Size = new Size(948, 334);
            dgvHocSinh.TabIndex = 0;
            // 
            // FrmQuanLyHocSinh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 700);
            Controls.Add(pnlBangCard);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlThongKe);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(940, 620);
            Name = "FrmQuanLyHocSinh";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý học sinh";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlThongKe.ResumeLayout(false);
            pnlTheNu.ResumeLayout(false);
            pnlTheNu.PerformLayout();
            pnlTheNam.ResumeLayout(false);
            pnlTheNam.PerformLayout();
            pnlTheTong.ResumeLayout(false);
            pnlTheTong.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlBangCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHocSinh).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblIconTieuDe;
        private Label lblTieuDe;
        private Label lblLopPhuTrach;
        private Panel pnlThongKe;
        private Panel pnlTheTong;
        private Label lblIconTong;
        private Label lblSoTong;
        private Label lblNhanTong;
        private Panel pnlTheNam;
        private Label lblIconNam;
        private Label lblSoNam;
        private Label lblNhanNam;
        private Panel pnlTheNu;
        private Label lblIconNu;
        private Label lblSoNu;
        private Label lblNhanNu;
        private Panel pnlToolbar;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnThemMoi;
        private Button btnSua;
        private Button btnXoa;
        private Button btnTaoTaiKhoanPhuHuynh;
        private Panel pnlBangCard;
        private DataGridView dgvHocSinh;
    }
}
