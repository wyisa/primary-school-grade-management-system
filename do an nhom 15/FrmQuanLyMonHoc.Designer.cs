namespace do_an_nhom_15
{
    partial class FrmQuanLyMonHoc
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
            dgvMonHoc = new DataGridView();
            lblMaMon = new Label();
            lblTenMon = new Label();
            txtMaMon = new TextBox();
            txtTenMon = new TextBox();
            lblHinhThucDanhGia = new Label();
            cboHinhThucDanhGia = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(274, 25);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(117, 15);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ MÔN HỌC";
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonHoc.Location = new Point(202, 52);
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.Size = new Size(391, 150);
            dgvMonHoc.TabIndex = 1;
            // 
            // lblMaMon
            // 
            lblMaMon.AutoSize = true;
            lblMaMon.Location = new Point(194, 246);
            lblMaMon.Name = "lblMaMon";
            lblMaMon.Size = new Size(52, 15);
            lblMaMon.TabIndex = 2;
            lblMaMon.Text = "Mã môn";
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Location = new Point(194, 284);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(76, 15);
            lblTenMon.TabIndex = 3;
            lblTenMon.Text = "Tên môn học";
            // 
            // txtMaMon
            // 
            txtMaMon.Location = new Point(341, 246);
            txtMaMon.Name = "txtMaMon";
            txtMaMon.Size = new Size(100, 23);
            txtMaMon.TabIndex = 4;
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(341, 281);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(100, 23);
            txtTenMon.TabIndex = 5;
            // 
            // lblHinhThucDanhGia
            // 
            lblHinhThucDanhGia.AutoSize = true;
            lblHinhThucDanhGia.Location = new Point(194, 323);
            lblHinhThucDanhGia.Name = "lblHinhThucDanhGia";
            lblHinhThucDanhGia.Size = new Size(109, 15);
            lblHinhThucDanhGia.TabIndex = 6;
            lblHinhThucDanhGia.Text = "Hình thức đánh giá";
            // 
            // cboHinhThucDanhGia
            // 
            cboHinhThucDanhGia.FormattingEnabled = true;
            cboHinhThucDanhGia.Location = new Point(341, 319);
            cboHinhThucDanhGia.Name = "cboHinhThucDanhGia";
            cboHinhThucDanhGia.Size = new Size(121, 23);
            cboHinhThucDanhGia.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(174, 370);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 8;
            btnThem.Text = "THÊM";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(304, 370);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 9;
            btnSua.Text = "SỬA";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(451, 371);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "XÓA";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(599, 368);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(75, 23);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // FrmQuanLyMonHoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 479);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboHinhThucDanhGia);
            Controls.Add(lblHinhThucDanhGia);
            Controls.Add(txtTenMon);
            Controls.Add(txtMaMon);
            Controls.Add(lblTenMon);
            Controls.Add(lblMaMon);
            Controls.Add(dgvMonHoc);
            Controls.Add(lblTieuDe);
            Name = "FrmQuanLyMonHoc";
            Text = "FrmQuanLyMonHoc";
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private DataGridView dgvMonHoc;
        private Label lblMaMon;
        private Label lblTenMon;
        private TextBox txtMaMon;
        private TextBox txtTenMon;
        private Label lblHinhThucDanhGia;
        private ComboBox cboHinhThucDanhGia;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
    }
}