namespace do_an_nhom_15
{
    partial class FrmBangTongHopLop
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
            lblTieuDe = new Label();
            lblBoLoc = new Label();
            btnXuatExcel = new Button();
            dgvTongHop = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTongHop).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(24, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(260, 21);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "BẢNG TỔNG HỢP ĐIỂM CẢ LỚP";
            // 
            // lblBoLoc
            // 
            lblBoLoc.AutoSize = true;
            lblBoLoc.Location = new Point(24, 54);
            lblBoLoc.Name = "lblBoLoc";
            lblBoLoc.Size = new Size(300, 15);
            lblBoLoc.TabIndex = 1;
            lblBoLoc.Text = "Năm học ... - Học kỳ ... - Thời điểm đánh giá ...";
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(870, 44);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(150, 30);
            btnXuatExcel.TabIndex = 2;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // dgvTongHop
            // 
            dgvTongHop.AllowUserToAddRows = false;
            dgvTongHop.AllowUserToDeleteRows = false;
            dgvTongHop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTongHop.Location = new Point(24, 90);
            dgvTongHop.Name = "dgvTongHop";
            dgvTongHop.ReadOnly = true;
            dgvTongHop.AllowUserToOrderColumns = false;
            dgvTongHop.Size = new Size(996, 470);
            dgvTongHop.TabIndex = 3;
            // 
            // FrmBangTongHopLop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 584);
            Controls.Add(dgvTongHop);
            Controls.Add(btnXuatExcel);
            Controls.Add(lblBoLoc);
            Controls.Add(lblTieuDe);
            MinimumSize = new Size(760, 420);
            Name = "FrmBangTongHopLop";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bảng tổng hợp điểm cả lớp";
            ((System.ComponentModel.ISupportInitialize)dgvTongHop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblBoLoc;
        private Button btnXuatExcel;
        private DataGridView dgvTongHop;
    }
}
