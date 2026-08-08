namespace do_an_nhom_15
{
    partial class FrmThongKe
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
            pnlBoLoc = new Panel();
            lblTieuDeBoLoc = new Label();
            btnThongKe = new Button();
            cboThoiDiemDanhGia = new ComboBox();
            lblChonMoc = new Label();
            cboMonHoc = new ComboBox();
            lblChonMon = new Label();
            cboNamHoc = new ComboBox();
            lblNamHoc = new Label();
            pnlKetQua = new Panel();
            btnInBaoCao = new Button();
            lblTieuDeKetQua = new Label();
            pnlHeader.SuspendLayout();
            pnlBoLoc.SuspendLayout();
            pnlKetQua.SuspendLayout();
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
            pnlHeader.Size = new Size(980, 92);
            pnlHeader.TabIndex = 0;
            // 
            // lblLopPhuTrach
            // 
            lblLopPhuTrach.AutoSize = true;
            lblLopPhuTrach.BackColor = Color.Transparent;
            lblLopPhuTrach.Location = new Point(104, 54);
            lblLopPhuTrach.Name = "lblLopPhuTrach";
            lblLopPhuTrach.Size = new Size(141, 15);
            lblLopPhuTrach.TabIndex = 2;
            lblLopPhuTrach.Text = "LỚP PHỤ TRÁCH: Lớp 1A";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.BackColor = Color.Transparent;
            lblTieuDe.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.Black;
            lblTieuDe.Location = new Point(104, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(335, 31);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "THỐNG KÊ KẾT QUẢ HỌC TẬP";
            // 
            // lblIconTieuDe
            // 
            lblIconTieuDe.BackColor = Color.Transparent;
            lblIconTieuDe.Font = new Font("Segoe UI Emoji", 24F);
            lblIconTieuDe.ForeColor = Color.Black;
            lblIconTieuDe.Location = new Point(34, 16);
            lblIconTieuDe.Name = "lblIconTieuDe";
            lblIconTieuDe.Size = new Size(60, 60);
            lblIconTieuDe.TabIndex = 0;
            lblIconTieuDe.Text = "📊";
            lblIconTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBoLoc
            // 
            pnlBoLoc.Controls.Add(lblTieuDeBoLoc);
            pnlBoLoc.Controls.Add(btnThongKe);
            pnlBoLoc.Controls.Add(cboThoiDiemDanhGia);
            pnlBoLoc.Controls.Add(lblChonMoc);
            pnlBoLoc.Controls.Add(cboMonHoc);
            pnlBoLoc.Controls.Add(lblChonMon);
            pnlBoLoc.Controls.Add(cboNamHoc);
            pnlBoLoc.Controls.Add(lblNamHoc);
            pnlBoLoc.Location = new Point(30, 110);
            pnlBoLoc.Name = "pnlBoLoc";
            pnlBoLoc.Size = new Size(920, 120);
            pnlBoLoc.TabIndex = 1;
            // 
            // lblTieuDeBoLoc
            // 
            lblTieuDeBoLoc.AutoSize = true;
            lblTieuDeBoLoc.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeBoLoc.Location = new Point(20, 12);
            lblTieuDeBoLoc.Name = "lblTieuDeBoLoc";
            lblTieuDeBoLoc.Size = new Size(159, 19);
            lblTieuDeBoLoc.TabIndex = 0;
            lblTieuDeBoLoc.Text = "🔎 BỘ LỌC THỐNG KÊ";
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(750, 70);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(140, 34);
            btnThongKe.TabIndex = 7;
            btnThongKe.Text = "📊  Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // cboThoiDiemDanhGia
            // 
            cboThoiDiemDanhGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThoiDiemDanhGia.FormattingEnabled = true;
            cboThoiDiemDanhGia.Location = new Point(430, 74);
            cboThoiDiemDanhGia.Name = "cboThoiDiemDanhGia";
            cboThoiDiemDanhGia.Size = new Size(230, 23);
            cboThoiDiemDanhGia.TabIndex = 6;
            // 
            // lblChonMoc
            // 
            lblChonMoc.AutoSize = true;
            lblChonMoc.Location = new Point(430, 54);
            lblChonMoc.Name = "lblChonMoc";
            lblChonMoc.Size = new Size(110, 15);
            lblChonMoc.TabIndex = 5;
            lblChonMoc.Text = "Thời điểm đánh giá";
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(180, 74);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(230, 23);
            cboMonHoc.TabIndex = 4;
            // 
            // lblChonMon
            // 
            lblChonMon.AutoSize = true;
            lblChonMon.Location = new Point(180, 54);
            lblChonMon.Name = "lblChonMon";
            lblChonMon.Size = new Size(55, 15);
            lblChonMon.TabIndex = 3;
            lblChonMon.Text = "Môn học";
            // 
            // cboNamHoc
            // 
            cboNamHoc.FormattingEnabled = true;
            cboNamHoc.Location = new Point(20, 74);
            cboNamHoc.Name = "cboNamHoc";
            cboNamHoc.Size = new Size(140, 23);
            cboNamHoc.TabIndex = 2;
            // 
            // lblNamHoc
            // 
            lblNamHoc.AutoSize = true;
            lblNamHoc.Location = new Point(20, 54);
            lblNamHoc.Name = "lblNamHoc";
            lblNamHoc.Size = new Size(56, 15);
            lblNamHoc.TabIndex = 1;
            lblNamHoc.Text = "Năm học";
            // 
            // pnlKetQua
            // 
            pnlKetQua.Controls.Add(btnInBaoCao);
            pnlKetQua.Controls.Add(lblTieuDeKetQua);
            pnlKetQua.Location = new Point(30, 246);
            pnlKetQua.Name = "pnlKetQua";
            pnlKetQua.Size = new Size(920, 420);
            pnlKetQua.TabIndex = 2;
            // 
            // btnInBaoCao
            // 
            btnInBaoCao.Location = new Point(750, 8);
            btnInBaoCao.Name = "btnInBaoCao";
            btnInBaoCao.Size = new Size(150, 34);
            btnInBaoCao.TabIndex = 1;
            btnInBaoCao.Text = "🖨️  In báo cáo";
            btnInBaoCao.UseVisualStyleBackColor = true;
            // 
            // lblTieuDeKetQua
            // 
            lblTieuDeKetQua.AutoSize = true;
            lblTieuDeKetQua.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeKetQua.Location = new Point(20, 14);
            lblTieuDeKetQua.Name = "lblTieuDeKetQua";
            lblTieuDeKetQua.Size = new Size(167, 19);
            lblTieuDeKetQua.TabIndex = 0;
            lblTieuDeKetQua.Text = "📊 KẾT QUẢ THỐNG KÊ";
            // 
            // FrmThongKe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 706);
            Controls.Add(pnlKetQua);
            Controls.Add(pnlBoLoc);
            Controls.Add(pnlHeader);
            Name = "FrmThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBoLoc.ResumeLayout(false);
            pnlBoLoc.PerformLayout();
            pnlKetQua.ResumeLayout(false);
            pnlKetQua.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblIconTieuDe;
        private Label lblTieuDe;
        private Label lblLopPhuTrach;
        private Panel pnlBoLoc;
        private Label lblTieuDeBoLoc;
        private Label lblNamHoc;
        private ComboBox cboNamHoc;
        private Label lblChonMon;
        private ComboBox cboMonHoc;
        private Label lblChonMoc;
        private ComboBox cboThoiDiemDanhGia;
        private Button btnThongKe;
        private Panel pnlKetQua;
        private Label lblTieuDeKetQua;
        private Button btnInBaoCao;
    }
}
