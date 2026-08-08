using System.Data;
using ClosedXML.Excel;
using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    // Bảng tổng hợp điểm cả lớp: mỗi hàng là 1 học sinh, mỗi cột là 1 môn học,
    // ứng với đúng 1 năm học - học kỳ - thời điểm đánh giá đang chọn ở FrmQuanLyDiem.
    public partial class FrmBangTongHopLop : Form
    {
        private readonly string _tenLop;
        private readonly string _namHoc;
        private readonly string _hocKy;
        private readonly string _thoiDiem;
        private readonly List<HocSinh> _danhSachHocSinh;
        private readonly List<MonHoc> _danhSachMon;
        private readonly DiemService _diemService;

        public FrmBangTongHopLop(
            string tenLop,
            string namHoc,
            string hocKy,
            string thoiDiem,
            List<HocSinh> danhSachHocSinh,
            List<MonHoc> danhSachMon,
            DiemService diemService)
        {
            InitializeComponent();

            _tenLop = tenLop;
            _namHoc = namHoc;
            _hocKy = hocKy;
            _thoiDiem = thoiDiem;
            _danhSachHocSinh = danhSachHocSinh.OrderBy(h => h.MaHocSinh).ToList();
            _danhSachMon = danhSachMon;
            _diemService = diemService;

            GiaoDien.ApDungTuDong(this);
            GiaoDien.LamDepBang(dgvTongHop);

            lblBoLoc.Text = $"Lớp {_tenLop}  ·  Năm học {_namHoc}  ·  {_hocKy}  ·  {_thoiDiem}";

            btnXuatExcel.Click += btnXuatExcel_Click;

            NapBangTongHop();
        }

        // Với mỗi học sinh, lấy điểm/ kết quả của từng môn tại đúng mốc đánh giá đang xem.
        // Ưu tiên hiển thị điểm số (Điểm KTĐK); nếu môn đó không chấm điểm số thì hiển thị Kết quả môn học (Đạt/Chưa đạt...).
        private string LayGiaTriO(string maHocSinh, string maMon)
        {
            Diem? banGhi = _diemService.LayMotBanGhi(maHocSinh, maMon, _namHoc, _hocKy, _thoiDiem);

            if (banGhi == null)
            {
                return "-";
            }

            if (banGhi.DiemKiemTraDinhKy.HasValue)
            {
                return banGhi.DiemKiemTraDinhKy.Value.ToString("0.0");
            }

            return string.IsNullOrWhiteSpace(banGhi.KetQuaMonHoc) ? "-" : banGhi.KetQuaMonHoc;
        }

        private DataTable XayDungBangDuLieu()
        {
            DataTable bang = new DataTable();

            bang.Columns.Add("Mã HS");
            bang.Columns.Add("Họ và tên");

            foreach (MonHoc mon in _danhSachMon)
            {
                bang.Columns.Add(mon.TenMon);
            }

            foreach (HocSinh hocSinh in _danhSachHocSinh)
            {
                DataRow dong = bang.NewRow();

                dong["Mã HS"] = hocSinh.MaHocSinh;
                dong["Họ và tên"] = hocSinh.HoTen;

                foreach (MonHoc mon in _danhSachMon)
                {
                    dong[mon.TenMon] = LayGiaTriO(hocSinh.MaHocSinh, mon.MaMon);
                }

                bang.Rows.Add(dong);
            }

            return bang;
        }

        private void NapBangTongHop()
        {
            dgvTongHop.AutoGenerateColumns = true;
            dgvTongHop.DataSource = XayDungBangDuLieu();

            foreach (DataGridViewColumn cot in dgvTongHop.Columns)
            {
                cot.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (cot.Index >= 2)
                {
                    cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"BangTongHop_{_tenLop}_{_namHoc}_{_hocKy}_{DateTime.Now:ddMMyyyy}.xlsx"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            DataTable bangDuLieu = XayDungBangDuLieu();

            using XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet sheet = workbook.Worksheets.Add("Tổng hợp");

            for (int i = 0; i < bangDuLieu.Columns.Count; i++)
            {
                sheet.Cell(1, i + 1).Value = bangDuLieu.Columns[i].ColumnName;
            }

            IXLRange hangTieuDe = sheet.Range(1, 1, 1, bangDuLieu.Columns.Count);
            hangTieuDe.Style.Font.Bold = true;
            hangTieuDe.Style.Fill.BackgroundColor = XLColor.LightGray;

            for (int dong = 0; dong < bangDuLieu.Rows.Count; dong++)
            {
                for (int cot = 0; cot < bangDuLieu.Columns.Count; cot++)
                {
                    sheet.Cell(dong + 2, cot + 1).Value = bangDuLieu.Rows[dong][cot]?.ToString() ?? string.Empty;
                }
            }

            sheet.Columns().AdjustToContents();
            sheet.SheetView.FreezeRows(1);

            try
            {
                workbook.SaveAs(saveDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể lưu file Excel: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            MessageBox.Show(
                "Đã xuất bảng tổng hợp ra Excel thành công.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
