namespace do_an_nhom_15
{
    partial class FrmQuanLyLop
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
            dgvLopHoc = new DataGridView();
            lblMaLop = new Label();
            lblTenLop = new Label();
            txtMaLop = new TextBox();
            txtTenLop = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(354, 24);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(110, 15);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ LỚP HỌC";
            // 
            // dgvLopHoc
            // 
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Location = new Point(185, 42);
            dgvLopHoc.Name = "dgvLopHoc";
            dgvLopHoc.Size = new Size(516, 150);
            dgvLopHoc.TabIndex = 1;
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(191, 224);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Size = new Size(47, 15);
            lblMaLop.TabIndex = 2;
            lblMaLop.Text = "Mã lớp:";
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new Point(193, 269);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Size = new Size(45, 15);
            lblTenLop.TabIndex = 3;
            lblTenLop.Text = "Tên lớp";
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new Point(294, 224);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(100, 23);
            txtMaLop.TabIndex = 4;
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(294, 269);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(100, 23);
            txtTenLop.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(161, 336);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(86, 28);
            btnThem.TabIndex = 6;
            btnThem.Text = "THÊM";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(331, 336);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(78, 28);
            btnSua.TabIndex = 7;
            btnSua.Text = "SỬA";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(492, 336);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(85, 28);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "XÓA";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(642, 336);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(82, 28);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // FrmQuanLyLop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 484);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTenLop);
            Controls.Add(txtMaLop);
            Controls.Add(lblTenLop);
            Controls.Add(lblMaLop);
            Controls.Add(dgvLopHoc);
            Controls.Add(lblTieuDe);
            Name = "FrmQuanLyLop";
            Text = "FrmQuanLyLop";
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private DataGridView dgvLopHoc;
        private Label lblMaLop;
        private Label lblTenLop;
        private TextBox txtMaLop;
        private TextBox txtTenLop;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
    }
}