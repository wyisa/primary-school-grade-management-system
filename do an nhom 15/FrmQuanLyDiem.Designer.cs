namespace do_an_nhom_15
{
    partial class FrmQuanLyDiem
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
            pnlNoiDung = new Panel();
            pnlBoLoc = new Panel();
            lblTieuDeBoLoc = new Label();
            lblChonHocSinh = new Label();
            cboHocSinh = new ComboBox();
            lblChonMon = new Label();
            cboMonHoc = new ComboBox();
            lblNamHoc = new Label();
            cboNamHoc = new ComboBox();
            lblThoiDiem = new Label();
            cboThoiDiemDanhGia = new ComboBox();
            lblHocKy = new Label();
            txtHocKy = new TextBox();
            pnlNhapDiem = new Panel();
            lblTieuDeNhapDiem = new Label();
            lblDiemKtdk = new Label();
            txtDiemKtdk = new TextBox();
            lblKetQuaMonHoc = new Label();
            cboKetQuaMonHoc = new ComboBox();
            lblNhanXet = new Label();
            txtNhanXet = new TextBox();
            btnLuuDiem = new Button();
            btnLamMoi = new Button();
            pnlHanhDong = new Panel();
            lblTieuDeHanhDong = new Label();
            btnInBangDiem = new Button();
            btnXuatExcel = new Button();
            btnNhapExcel = new Button();
            btnInHocBaPdf = new Button();
            btnBangTongHopLop = new Button();
            chkXemTatCaLichSu = new CheckBox();
            pnlBangCard = new Panel();
            lblTieuDeBang = new Label();
            dgvDiem = new DataGridView();
            pnlPhamChat = new Panel();
            lblPhamChatNangLuc = new Label();
            lblPhamChat = new Label();
            cboPhamChat = new ComboBox();
            lblNangLuc = new Label();
            cboNangLuc = new ComboBox();
            lblHocKyPhamChat = new Label();
            cboHocKyPhamChat = new ComboBox();
            lblNhanXetPhamChat = new Label();
            txtNhanXetPhamChat = new TextBox();
            btnLuuPhamChat = new Button();
            pnlHeader.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            pnlBoLoc.SuspendLayout();
            pnlNhapDiem.SuspendLayout();
            pnlHanhDong.SuspendLayout();
            pnlBangCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            pnlPhamChat.SuspendLayout();
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
            pnlHeader.Size = new Size(1100, 92);
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
            lblIconTieuDe.Text = "📊";
            lblIconTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(104, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(150, 32);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "QUẢN LÝ ĐIỂM";
            // 
            // lblLopPhuTrach
            // 
            lblLopPhuTrach.AutoSize = true;
            lblLopPhuTrach.Location = new Point(104, 52);
            lblLopPhuTrach.Name = "lblLopPhuTrach";
            lblLopPhuTrach.Size = new Size(150, 15);
            lblLopPhuTrach.TabIndex = 2;
            lblLopPhuTrach.Text = "LỚP PHỤ TRÁCH: Lớp 1A";
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.AutoScroll = true;
            pnlNoiDung.Controls.Add(pnlBoLoc);
            pnlNoiDung.Controls.Add(pnlNhapDiem);
            pnlNoiDung.Controls.Add(pnlHanhDong);
            pnlNoiDung.Controls.Add(pnlBangCard);
            pnlNoiDung.Controls.Add(pnlPhamChat);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(0, 92);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Size = new Size(1100, 608);
            pnlNoiDung.TabIndex = 1;
            // 
            // pnlBoLoc
            // 
            pnlBoLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBoLoc.Controls.Add(lblTieuDeBoLoc);
            pnlBoLoc.Controls.Add(lblChonHocSinh);
            pnlBoLoc.Controls.Add(cboHocSinh);
            pnlBoLoc.Controls.Add(lblChonMon);
            pnlBoLoc.Controls.Add(cboMonHoc);
            pnlBoLoc.Controls.Add(lblNamHoc);
            pnlBoLoc.Controls.Add(cboNamHoc);
            pnlBoLoc.Controls.Add(lblThoiDiem);
            pnlBoLoc.Controls.Add(cboThoiDiemDanhGia);
            pnlBoLoc.Controls.Add(lblHocKy);
            pnlBoLoc.Controls.Add(txtHocKy);
            pnlBoLoc.Location = new Point(34, 20);
            pnlBoLoc.Name = "pnlBoLoc";
            pnlBoLoc.Size = new Size(1012, 168);
            pnlBoLoc.TabIndex = 0;
            // 
            // lblTieuDeBoLoc
            // 
            lblTieuDeBoLoc.AutoSize = true;
            lblTieuDeBoLoc.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeBoLoc.Location = new Point(20, 12);
            lblTieuDeBoLoc.Name = "lblTieuDeBoLoc";
            lblTieuDeBoLoc.Size = new Size(150, 19);
            lblTieuDeBoLoc.TabIndex = 0;
            lblTieuDeBoLoc.Text = "🔎 THÔNG TIN ĐÁNH GIÁ";
            // 
            // lblChonHocSinh
            // 
            lblChonHocSinh.AutoSize = true;
            lblChonHocSinh.Location = new Point(20, 48);
            lblChonHocSinh.Name = "lblChonHocSinh";
            lblChonHocSinh.Size = new Size(65, 15);
            lblChonHocSinh.TabIndex = 1;
            lblChonHocSinh.Text = "Học sinh";
            // 
            // cboHocSinh
            // 
            cboHocSinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHocSinh.FormattingEnabled = true;
            cboHocSinh.Location = new Point(20, 66);
            cboHocSinh.Name = "cboHocSinh";
            cboHocSinh.Size = new Size(460, 28);
            cboHocSinh.TabIndex = 2;
            // 
            // lblChonMon
            // 
            lblChonMon.AutoSize = true;
            lblChonMon.Location = new Point(500, 48);
            lblChonMon.Name = "lblChonMon";
            lblChonMon.Size = new Size(60, 15);
            lblChonMon.TabIndex = 3;
            lblChonMon.Text = "Môn học";
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(500, 66);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(220, 28);
            cboMonHoc.TabIndex = 4;
            // 
            // lblNamHoc
            // 
            lblNamHoc.AutoSize = true;
            lblNamHoc.Location = new Point(740, 48);
            lblNamHoc.Name = "lblNamHoc";
            lblNamHoc.Size = new Size(58, 15);
            lblNamHoc.TabIndex = 5;
            lblNamHoc.Text = "Năm học";
            // 
            // cboNamHoc
            // 
            cboNamHoc.FormattingEnabled = true;
            cboNamHoc.Location = new Point(740, 66);
            cboNamHoc.Name = "cboNamHoc";
            cboNamHoc.Size = new Size(230, 28);
            cboNamHoc.TabIndex = 6;
            // 
            // lblThoiDiem
            // 
            lblThoiDiem.AutoSize = true;
            lblThoiDiem.Location = new Point(20, 106);
            lblThoiDiem.Name = "lblThoiDiem";
            lblThoiDiem.Size = new Size(100, 15);
            lblThoiDiem.TabIndex = 7;
            lblThoiDiem.Text = "Thời điểm đánh giá";
            // 
            // cboThoiDiemDanhGia
            // 
            cboThoiDiemDanhGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThoiDiemDanhGia.FormattingEnabled = true;
            cboThoiDiemDanhGia.Location = new Point(20, 124);
            cboThoiDiemDanhGia.Name = "cboThoiDiemDanhGia";
            cboThoiDiemDanhGia.Size = new Size(300, 28);
            cboThoiDiemDanhGia.TabIndex = 8;
            // 
            // lblHocKy
            // 
            lblHocKy.AutoSize = true;
            lblHocKy.Location = new Point(340, 106);
            lblHocKy.Name = "lblHocKy";
            lblHocKy.Size = new Size(53, 15);
            lblHocKy.TabIndex = 9;
            lblHocKy.Text = "Học kỳ";
            // 
            // txtHocKy
            // 
            txtHocKy.Enabled = false;
            txtHocKy.Location = new Point(340, 124);
            txtHocKy.Name = "txtHocKy";
            txtHocKy.Size = new Size(150, 28);
            txtHocKy.TabIndex = 10;
            // 
            // pnlNhapDiem
            // 
            pnlNhapDiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlNhapDiem.Controls.Add(lblTieuDeNhapDiem);
            pnlNhapDiem.Controls.Add(lblDiemKtdk);
            pnlNhapDiem.Controls.Add(txtDiemKtdk);
            pnlNhapDiem.Controls.Add(lblKetQuaMonHoc);
            pnlNhapDiem.Controls.Add(cboKetQuaMonHoc);
            pnlNhapDiem.Controls.Add(lblNhanXet);
            pnlNhapDiem.Controls.Add(txtNhanXet);
            pnlNhapDiem.Controls.Add(btnLuuDiem);
            pnlNhapDiem.Controls.Add(btnLamMoi);
            pnlNhapDiem.Location = new Point(34, 204);
            pnlNhapDiem.Name = "pnlNhapDiem";
            pnlNhapDiem.Size = new Size(1012, 232);
            pnlNhapDiem.TabIndex = 1;
            // 
            // lblTieuDeNhapDiem
            // 
            lblTieuDeNhapDiem.AutoSize = true;
            lblTieuDeNhapDiem.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeNhapDiem.Location = new Point(20, 12);
            lblTieuDeNhapDiem.Name = "lblTieuDeNhapDiem";
            lblTieuDeNhapDiem.Size = new Size(150, 19);
            lblTieuDeNhapDiem.TabIndex = 0;
            lblTieuDeNhapDiem.Text = "📝 NHẬP / CẬP NHẬT ĐIỂM";
            // 
            // lblDiemKtdk
            // 
            lblDiemKtdk.AutoSize = true;
            lblDiemKtdk.Location = new Point(20, 48);
            lblDiemKtdk.Name = "lblDiemKtdk";
            lblDiemKtdk.Size = new Size(120, 15);
            lblDiemKtdk.TabIndex = 1;
            lblDiemKtdk.Text = "Điểm kiểm tra định kỳ";
            // 
            // txtDiemKtdk
            // 
            txtDiemKtdk.Location = new Point(20, 66);
            txtDiemKtdk.Name = "txtDiemKtdk";
            txtDiemKtdk.Size = new Size(150, 28);
            txtDiemKtdk.TabIndex = 2;
            // 
            // lblKetQuaMonHoc
            // 
            lblKetQuaMonHoc.AutoSize = true;
            lblKetQuaMonHoc.Location = new Point(200, 48);
            lblKetQuaMonHoc.Name = "lblKetQuaMonHoc";
            lblKetQuaMonHoc.Size = new Size(110, 15);
            lblKetQuaMonHoc.TabIndex = 3;
            lblKetQuaMonHoc.Text = "Kết quả môn học";
            // 
            // cboKetQuaMonHoc
            // 
            cboKetQuaMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQuaMonHoc.FormattingEnabled = true;
            cboKetQuaMonHoc.Location = new Point(200, 66);
            cboKetQuaMonHoc.Name = "cboKetQuaMonHoc";
            cboKetQuaMonHoc.Size = new Size(220, 28);
            cboKetQuaMonHoc.TabIndex = 4;
            // 
            // lblNhanXet
            // 
            lblNhanXet.AutoSize = true;
            lblNhanXet.Location = new Point(20, 106);
            lblNhanXet.Name = "lblNhanXet";
            lblNhanXet.Size = new Size(120, 15);
            lblNhanXet.TabIndex = 5;
            lblNhanXet.Text = "Nhận xét của giáo viên";
            // 
            // txtNhanXet
            // 
            txtNhanXet.Location = new Point(20, 124);
            txtNhanXet.Multiline = true;
            txtNhanXet.Name = "txtNhanXet";
            txtNhanXet.Size = new Size(972, 50);
            txtNhanXet.TabIndex = 6;
            // 
            // btnLuuDiem
            // 
            btnLuuDiem.Location = new Point(20, 186);
            btnLuuDiem.Name = "btnLuuDiem";
            btnLuuDiem.Size = new Size(150, 34);
            btnLuuDiem.TabIndex = 7;
            btnLuuDiem.Text = "💾 Lưu điểm";
            btnLuuDiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(180, 186);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 34);
            btnLamMoi.TabIndex = 8;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // pnlHanhDong
            // 
            pnlHanhDong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHanhDong.Controls.Add(lblTieuDeHanhDong);
            pnlHanhDong.Controls.Add(btnInBangDiem);
            pnlHanhDong.Controls.Add(btnXuatExcel);
            pnlHanhDong.Controls.Add(btnNhapExcel);
            pnlHanhDong.Controls.Add(btnInHocBaPdf);
            pnlHanhDong.Controls.Add(btnBangTongHopLop);
            pnlHanhDong.Controls.Add(chkXemTatCaLichSu);
            pnlHanhDong.Location = new Point(34, 452);
            pnlHanhDong.Name = "pnlHanhDong";
            pnlHanhDong.Size = new Size(1012, 140);
            pnlHanhDong.TabIndex = 2;
            // 
            // lblTieuDeHanhDong
            // 
            lblTieuDeHanhDong.AutoSize = true;
            lblTieuDeHanhDong.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeHanhDong.Location = new Point(20, 12);
            lblTieuDeHanhDong.Name = "lblTieuDeHanhDong";
            lblTieuDeHanhDong.Size = new Size(150, 19);
            lblTieuDeHanhDong.TabIndex = 0;
            lblTieuDeHanhDong.Text = "⚙️ THAO TÁC & XUẤT DỮ LIỆU";
            // 
            // btnInBangDiem
            // 
            btnInBangDiem.Location = new Point(20, 48);
            btnInBangDiem.Name = "btnInBangDiem";
            btnInBangDiem.Size = new Size(150, 34);
            btnInBangDiem.TabIndex = 1;
            btnInBangDiem.Text = "🖨️ In bảng điểm";
            btnInBangDiem.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(180, 48);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(170, 34);
            btnXuatExcel.TabIndex = 2;
            btnXuatExcel.Text = "📊 Xuất Excel cả lớp";
            btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnNhapExcel
            // 
            btnNhapExcel.Location = new Point(360, 48);
            btnNhapExcel.Name = "btnNhapExcel";
            btnNhapExcel.Size = new Size(180, 34);
            btnNhapExcel.TabIndex = 3;
            btnNhapExcel.Text = "📥 Nhập Excel hàng loạt";
            btnNhapExcel.UseVisualStyleBackColor = true;
            // 
            // btnInHocBaPdf
            // 
            btnInHocBaPdf.Location = new Point(550, 48);
            btnInHocBaPdf.Name = "btnInHocBaPdf";
            btnInHocBaPdf.Size = new Size(170, 34);
            btnInHocBaPdf.TabIndex = 4;
            btnInHocBaPdf.Text = "📄 In học bạ (PDF)";
            btnInHocBaPdf.UseVisualStyleBackColor = true;
            // 
            // btnBangTongHopLop
            // 
            btnBangTongHopLop.Location = new Point(460, 90);
            btnBangTongHopLop.Name = "btnBangTongHopLop";
            btnBangTongHopLop.Size = new Size(320, 34);
            btnBangTongHopLop.TabIndex = 6;
            btnBangTongHopLop.Text = "📋 Xem bảng tổng hợp điểm cả lớp";
            btnBangTongHopLop.UseVisualStyleBackColor = true;
            // 
            // chkXemTatCaLichSu
            // 
            chkXemTatCaLichSu.Location = new Point(20, 96);
            chkXemTatCaLichSu.Name = "chkXemTatCaLichSu";
            chkXemTatCaLichSu.Size = new Size(420, 24);
            chkXemTatCaLichSu.TabIndex = 5;
            chkXemTatCaLichSu.Text = "Xem toàn bộ lịch sử (bỏ lọc theo năm học/học kỳ)";
            chkXemTatCaLichSu.UseVisualStyleBackColor = true;
            // 
            // pnlBangCard
            // 
            pnlBangCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBangCard.Controls.Add(lblTieuDeBang);
            pnlBangCard.Controls.Add(dgvDiem);
            pnlBangCard.Location = new Point(34, 608);
            pnlBangCard.Name = "pnlBangCard";
            pnlBangCard.Size = new Size(1012, 260);
            pnlBangCard.TabIndex = 3;
            // 
            // lblTieuDeBang
            // 
            lblTieuDeBang.AutoSize = true;
            lblTieuDeBang.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeBang.Location = new Point(20, 12);
            lblTieuDeBang.Name = "lblTieuDeBang";
            lblTieuDeBang.Size = new Size(120, 19);
            lblTieuDeBang.TabIndex = 0;
            lblTieuDeBang.Text = "📚 LỊCH SỬ ĐIỂM";
            // 
            // dgvDiem
            // 
            dgvDiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Location = new Point(20, 44);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.ReadOnly = true;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.MultiSelect = false;
            dgvDiem.Size = new Size(972, 200);
            dgvDiem.TabIndex = 1;
            // 
            // pnlPhamChat
            // 
            pnlPhamChat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPhamChat.Controls.Add(lblPhamChatNangLuc);
            pnlPhamChat.Controls.Add(lblPhamChat);
            pnlPhamChat.Controls.Add(cboPhamChat);
            pnlPhamChat.Controls.Add(lblNangLuc);
            pnlPhamChat.Controls.Add(cboNangLuc);
            pnlPhamChat.Controls.Add(lblHocKyPhamChat);
            pnlPhamChat.Controls.Add(cboHocKyPhamChat);
            pnlPhamChat.Controls.Add(lblNhanXetPhamChat);
            pnlPhamChat.Controls.Add(txtNhanXetPhamChat);
            pnlPhamChat.Controls.Add(btnLuuPhamChat);
            pnlPhamChat.Location = new Point(34, 884);
            pnlPhamChat.Name = "pnlPhamChat";
            pnlPhamChat.Size = new Size(1012, 250);
            pnlPhamChat.TabIndex = 4;
            // 
            // lblPhamChatNangLuc
            // 
            lblPhamChatNangLuc.AutoSize = true;
            lblPhamChatNangLuc.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPhamChatNangLuc.Location = new Point(20, 12);
            lblPhamChatNangLuc.Name = "lblPhamChatNangLuc";
            lblPhamChatNangLuc.Size = new Size(280, 19);
            lblPhamChatNangLuc.TabIndex = 0;
            lblPhamChatNangLuc.Text = "🌟 ĐÁNH GIÁ PHẨM CHẤT & NĂNG LỰC (theo học kỳ)";
            // 
            // lblPhamChat
            // 
            lblPhamChat.AutoSize = true;
            lblPhamChat.Location = new Point(20, 48);
            lblPhamChat.Name = "lblPhamChat";
            lblPhamChat.Size = new Size(58, 15);
            lblPhamChat.TabIndex = 1;
            lblPhamChat.Text = "Phẩm chất";
            // 
            // cboPhamChat
            // 
            cboPhamChat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhamChat.FormattingEnabled = true;
            cboPhamChat.Location = new Point(20, 66);
            cboPhamChat.Name = "cboPhamChat";
            cboPhamChat.Size = new Size(200, 28);
            cboPhamChat.TabIndex = 2;
            // 
            // lblNangLuc
            // 
            lblNangLuc.AutoSize = true;
            lblNangLuc.Location = new Point(240, 48);
            lblNangLuc.Name = "lblNangLuc";
            lblNangLuc.Size = new Size(52, 15);
            lblNangLuc.TabIndex = 3;
            lblNangLuc.Text = "Năng lực";
            // 
            // cboNangLuc
            // 
            cboNangLuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNangLuc.FormattingEnabled = true;
            cboNangLuc.Location = new Point(240, 66);
            cboNangLuc.Name = "cboNangLuc";
            cboNangLuc.Size = new Size(200, 28);
            cboNangLuc.TabIndex = 4;
            // 
            // lblHocKyPhamChat
            // 
            lblHocKyPhamChat.AutoSize = true;
            lblHocKyPhamChat.Location = new Point(460, 48);
            lblHocKyPhamChat.Name = "lblHocKyPhamChat";
            lblHocKyPhamChat.Size = new Size(53, 15);
            lblHocKyPhamChat.TabIndex = 5;
            lblHocKyPhamChat.Text = "Học kỳ";
            // 
            // cboHocKyPhamChat
            // 
            cboHocKyPhamChat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHocKyPhamChat.FormattingEnabled = true;
            cboHocKyPhamChat.Location = new Point(460, 66);
            cboHocKyPhamChat.Name = "cboHocKyPhamChat";
            cboHocKyPhamChat.Size = new Size(160, 28);
            cboHocKyPhamChat.TabIndex = 6;
            // 
            // lblNhanXetPhamChat
            // 
            lblNhanXetPhamChat.AutoSize = true;
            lblNhanXetPhamChat.Location = new Point(20, 106);
            lblNhanXetPhamChat.Name = "lblNhanXetPhamChat";
            lblNhanXetPhamChat.Size = new Size(87, 15);
            lblNhanXetPhamChat.TabIndex = 7;
            lblNhanXetPhamChat.Text = "Nhận xét thêm";
            // 
            // txtNhanXetPhamChat
            // 
            txtNhanXetPhamChat.Location = new Point(20, 124);
            txtNhanXetPhamChat.Multiline = true;
            txtNhanXetPhamChat.Name = "txtNhanXetPhamChat";
            txtNhanXetPhamChat.Size = new Size(700, 60);
            txtNhanXetPhamChat.TabIndex = 8;
            // 
            // btnLuuPhamChat
            // 
            btnLuuPhamChat.Location = new Point(20, 196);
            btnLuuPhamChat.Name = "btnLuuPhamChat";
            btnLuuPhamChat.Size = new Size(240, 34);
            btnLuuPhamChat.TabIndex = 9;
            btnLuuPhamChat.Text = "💾 Lưu phẩm chất && năng lực";
            btnLuuPhamChat.UseVisualStyleBackColor = true;
            // 
            // FrmQuanLyDiem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(pnlNoiDung);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(1000, 650);
            Name = "FrmQuanLyDiem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "QUẢN LÝ ĐIỂM";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            pnlBoLoc.ResumeLayout(false);
            pnlBoLoc.PerformLayout();
            pnlNhapDiem.ResumeLayout(false);
            pnlNhapDiem.PerformLayout();
            pnlHanhDong.ResumeLayout(false);
            pnlHanhDong.PerformLayout();
            pnlBangCard.ResumeLayout(false);
            pnlBangCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            pnlPhamChat.ResumeLayout(false);
            pnlPhamChat.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblIconTieuDe;
        private Label lblTieuDe;
        private Label lblLopPhuTrach;
        private Panel pnlNoiDung;
        private Panel pnlBoLoc;
        private Label lblTieuDeBoLoc;
        private Label lblChonHocSinh;
        private ComboBox cboHocSinh;
        private Label lblChonMon;
        private ComboBox cboMonHoc;
        private Label lblNamHoc;
        private ComboBox cboNamHoc;
        private Label lblThoiDiem;
        private ComboBox cboThoiDiemDanhGia;
        private Label lblHocKy;
        private TextBox txtHocKy;
        private Panel pnlNhapDiem;
        private Label lblTieuDeNhapDiem;
        private Label lblDiemKtdk;
        private TextBox txtDiemKtdk;
        private Label lblKetQuaMonHoc;
        private ComboBox cboKetQuaMonHoc;
        private Label lblNhanXet;
        private TextBox txtNhanXet;
        private Button btnLuuDiem;
        private Button btnLamMoi;
        private Panel pnlHanhDong;
        private Label lblTieuDeHanhDong;
        private Button btnInBangDiem;
        private Button btnXuatExcel;
        private Button btnNhapExcel;
        private Button btnInHocBaPdf;
        private Button btnBangTongHopLop;
        private CheckBox chkXemTatCaLichSu;
        private Panel pnlBangCard;
        private Label lblTieuDeBang;
        private DataGridView dgvDiem;
        private Panel pnlPhamChat;
        private Label lblPhamChatNangLuc;
        private Label lblPhamChat;
        private ComboBox cboPhamChat;
        private Label lblNangLuc;
        private ComboBox cboNangLuc;
        private Label lblHocKyPhamChat;
        private ComboBox cboHocKyPhamChat;
        private Label lblNhanXetPhamChat;
        private TextBox txtNhanXetPhamChat;
        private Button btnLuuPhamChat;
    }
}
