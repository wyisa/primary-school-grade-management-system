using do_an_nhom_15.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace do_an_nhom_15.Reports
{
    // Xuất "Học bạ" (bảng tổng hợp kết quả đánh giá) dạng PDF cho 1 hoặc nhiều học sinh.
    // Mỗi học sinh chiếm 1 trang: thông tin cá nhân + bảng kết quả môn học + bảng phẩm chất/năng lực.
    public static class HocBaPdfExporter
    {
        public class HocSinhHocBa
        {
            public required HocSinh HocSinh { get; init; }
            public required List<Diem> DanhSachDiem { get; init; }
            public required List<DanhGiaPhamChatNangLuc> DanhSachDanhGia { get; init; }
        }

        private static readonly string MauXanhChinh = "#4C9A72";
        private static readonly string MauVienNhat = "#D6E6DC";
        private static readonly string MauSocXen = "#F5FBF7";

        public static void XuatFile(
            string duongDanFile,
            string tenLop,
            List<HocSinhHocBa> danhSachHocSinh,
            Func<string, string> layTenMon)
        {
            Document.Create(container =>
            {
                foreach (HocSinhHocBa hs in danhSachHocSinh)
                {
                    container.Page(page => VeTrangHocBa(page, tenLop, hs, layTenMon));
                }
            })
            .GeneratePdf(duongDanFile);
        }

        private static void VeTrangHocBa(
            PageDescriptor page,
            string tenLop,
            HocSinhHocBa hs,
            Func<string, string> layTenMon)
        {
            page.Size(PageSizes.A4);
            page.Margin(36);
            page.DefaultTextStyle(x => x.FontSize(10));

            page.Header().Column(cot =>
            {
                cot.Item().AlignCenter().Text("HỌC BẠ").FontSize(18).Bold().FontColor(MauXanhChinh);
                cot.Item().AlignCenter().Text("Bảng tổng hợp kết quả đánh giá học sinh tiểu học").FontSize(11);
                cot.Item().PaddingTop(8).LineHorizontal(1).LineColor(MauVienNhat);
            });

            page.Content().PaddingTop(10).Column(cot =>
            {
                cot.Item().Text(t =>
                {
                    t.Span("Họ và tên: ").SemiBold();
                    t.Span(hs.HocSinh.HoTen);
                });

                cot.Item().PaddingTop(3).Row(row =>
                {
                    row.RelativeItem().Text(t =>
                    {
                        t.Span("Mã học sinh: ").SemiBold();
                        t.Span(hs.HocSinh.MaHocSinh);
                    });

                    row.RelativeItem().Text(t =>
                    {
                        t.Span("Ngày sinh: ").SemiBold();
                        t.Span(hs.HocSinh.NgaySinh.ToString("dd/MM/yyyy"));
                    });

                    row.RelativeItem().Text(t =>
                    {
                        t.Span("Giới tính: ").SemiBold();
                        t.Span(hs.HocSinh.GioiTinh);
                    });
                });

                cot.Item().PaddingTop(3).Text(t =>
                {
                    t.Span("Lớp: ").SemiBold();
                    t.Span(tenLop);
                });

                cot.Item().PaddingTop(16).Text("I. Kết quả các môn học").Bold().FontSize(12).FontColor(MauXanhChinh);

                cot.Item().PaddingTop(4).Element(c => VeBangMonHoc(c, hs.DanhSachDiem, layTenMon));

                cot.Item().PaddingTop(18).Text("II. Đánh giá phẩm chất & năng lực").Bold().FontSize(12).FontColor(MauXanhChinh);

                cot.Item().PaddingTop(4).Element(c => VeBangPhamChat(c, hs.DanhSachDanhGia));
            });

            page.Footer().PaddingTop(12).Row(row =>
            {
                row.RelativeItem().Text($"Ngày in: {DateTime.Now:dd/MM/yyyy}").FontSize(9).Italic();

                row.RelativeItem().AlignRight().Text(t =>
                {
                    t.Span("Trang ").FontSize(9);
                    t.CurrentPageNumber().FontSize(9);
                    t.Span(" / ").FontSize(9);
                    t.TotalPages().FontSize(9);
                });
            });
        }

        private static void VeBangMonHoc(IContainer container, List<Diem> danhSachDiem, Func<string, string> layTenMon)
        {
            container.Table(bang =>
            {
                bang.ColumnsDefinition(cols =>
                {
                    cols.RelativeColumn(2.1f);
                    cols.RelativeColumn(1.3f);
                    cols.RelativeColumn(1.1f);
                    cols.RelativeColumn(1.6f);
                    cols.RelativeColumn(0.9f);
                    cols.RelativeColumn(1.6f);
                    cols.RelativeColumn(2.4f);
                });

                bang.Header(header =>
                {
                    header.Cell().Element(TieuDeO).Text("Môn học");
                    header.Cell().Element(TieuDeO).Text("Năm học");
                    header.Cell().Element(TieuDeO).Text("Học kỳ");
                    header.Cell().Element(TieuDeO).Text("Thời điểm");
                    header.Cell().Element(TieuDeO).Text("Điểm");
                    header.Cell().Element(TieuDeO).Text("Kết quả");
                    header.Cell().Element(TieuDeO).Text("Nhận xét");
                });

                List<Diem> danhSachSapXep = danhSachDiem
                    .OrderBy(x => x.NamHoc)
                    .ThenBy(x => x.HocKy)
                    .ThenBy(x => layTenMon(x.MaMon))
                    .ToList();

                bool dongLe = false;

                foreach (Diem d in danhSachSapXep)
                {
                    IContainer O(IContainer c) => DongO(c, dongLe);
                    dongLe = !dongLe;

                    bang.Cell().Element(O).Text(layTenMon(d.MaMon));
                    bang.Cell().Element(O).Text(d.NamHoc);
                    bang.Cell().Element(O).Text(d.HocKy);
                    bang.Cell().Element(O).Text(d.ThoiDiemDanhGia);
                    bang.Cell().Element(O).Text(d.DiemKiemTraDinhKy.HasValue ? d.DiemKiemTraDinhKy.Value.ToString("0.0") : "-");
                    bang.Cell().Element(O).Text(string.IsNullOrWhiteSpace(d.KetQuaMonHoc) ? "-" : d.KetQuaMonHoc);
                    bang.Cell().Element(O).Text(d.NhanXet ?? string.Empty);
                }

                if (danhSachSapXep.Count == 0)
                {
                    bang.Cell().ColumnSpan(7).Element(c => DongO(c, false)).Text("Chưa có kết quả môn học.").Italic();
                }
            });
        }

        private static void VeBangPhamChat(IContainer container, List<DanhGiaPhamChatNangLuc> danhSachDanhGia)
        {
            container.Table(bang =>
            {
                bang.ColumnsDefinition(cols =>
                {
                    cols.RelativeColumn(1.6f);
                    cols.RelativeColumn(1.3f);
                    cols.RelativeColumn(1.6f);
                    cols.RelativeColumn(1.6f);
                    cols.RelativeColumn(3f);
                });

                bang.Header(header =>
                {
                    header.Cell().Element(TieuDeO).Text("Năm học");
                    header.Cell().Element(TieuDeO).Text("Học kỳ");
                    header.Cell().Element(TieuDeO).Text("Phẩm chất");
                    header.Cell().Element(TieuDeO).Text("Năng lực");
                    header.Cell().Element(TieuDeO).Text("Nhận xét");
                });

                List<DanhGiaPhamChatNangLuc> danhSachSapXep = danhSachDanhGia
                    .OrderBy(x => x.NamHoc)
                    .ThenBy(x => x.HocKy)
                    .ToList();

                bool dongLe = false;

                foreach (DanhGiaPhamChatNangLuc dg in danhSachSapXep)
                {
                    IContainer O(IContainer c) => DongO(c, dongLe);
                    dongLe = !dongLe;

                    bang.Cell().Element(O).Text(dg.NamHoc);
                    bang.Cell().Element(O).Text(dg.HocKy);
                    bang.Cell().Element(O).Text(dg.PhamChat);
                    bang.Cell().Element(O).Text(dg.NangLuc);
                    bang.Cell().Element(O).Text(dg.NhanXet ?? string.Empty);
                }

                if (danhSachSapXep.Count == 0)
                {
                    bang.Cell().ColumnSpan(5).Element(c => DongO(c, false)).Text("Chưa có đánh giá phẩm chất & năng lực.").Italic();
                }
            });
        }

        private static IContainer TieuDeO(IContainer container)
        {
            return container
                .Background(MauXanhChinh)
                .Padding(5)
                .DefaultTextStyle(x => x.SemiBold().FontColor(Colors.White).FontSize(9.5f));
        }

        private static IContainer DongO(IContainer container, bool dongLe)
        {
            return container
                .Background(dongLe ? MauSocXen : Colors.White)
                .BorderBottom(0.5f)
                .BorderColor(MauVienNhat)
                .Padding(5)
                .DefaultTextStyle(x => x.FontSize(9.5f));
        }
    }
}
