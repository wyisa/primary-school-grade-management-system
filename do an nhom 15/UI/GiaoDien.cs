using System.Drawing.Drawing2D;

namespace do_an_nhom_15.UI
{
    // Bộ định nghĩa giao diện dùng chung cho toàn ứng dụng: tông màu xanh lá nhẹ nhàng,
    // phù hợp chủ đề giáo dục. Các form gọi các hàm trong lớp này (sau InitializeComponent())
    // để tự động style control mà không cần chỉnh tay từng cái trong Designer.
    public static class GiaoDien
    {
        // ============ BẢNG MÀU ============
        public static readonly Color MauNen = ColorTranslator.FromHtml("#F2F9F4");        // nền form
        public static readonly Color MauTrang = Color.White;                              // nền thẻ/card
        public static readonly Color MauXanhChinh = ColorTranslator.FromHtml("#4C9A72");   // xanh lá chính
        public static readonly Color MauXanhChinhHover = ColorTranslator.FromHtml("#3D7D5C");
        public static readonly Color MauXanhDam = ColorTranslator.FromHtml("#25473A");     // xanh đậm (sidebar, tiêu đề)
        public static readonly Color MauXanhDamHover = ColorTranslator.FromHtml("#1B362C");
        public static readonly Color MauXanhNhat = ColorTranslator.FromHtml("#E3F3EA");    // nền nhấn nhẹ / hover phụ
        public static readonly Color MauChuChinh = ColorTranslator.FromHtml("#22322A");    // chữ chính (đen ánh xanh)
        public static readonly Color MauChuPhu = ColorTranslator.FromHtml("#66786E");      // chữ phụ / mô tả
        public static readonly Color MauVien = ColorTranslator.FromHtml("#D6E6DC");        // viền nhạt
        public static readonly Color MauDo = ColorTranslator.FromHtml("#DD5C52");          // cảnh báo / đăng xuất
        public static readonly Color MauDoHover = ColorTranslator.FromHtml("#C24B42");
        public static readonly Color MauXamNhat = ColorTranslator.FromHtml("#EAF2ED");     // nền nút phụ
        public static readonly Color MauSocXen = ColorTranslator.FromHtml("#F5FBF7");      // dòng xen kẽ trong bảng
        public static readonly Color MauDongHover = ColorTranslator.FromHtml("#DCEEE3");   // hover từng dòng trong bảng

        // ---- Màu nhấn phụ để đa sắc hóa các thẻ/khối thông tin (vẫn hài hòa với tông xanh chính) ----
        public static readonly Color MauXanhDuong = ColorTranslator.FromHtml("#3B82C4");
        public static readonly Color MauXanhDuongHover = ColorTranslator.FromHtml("#2F69A3");
        public static readonly Color MauXanhDuongNhat = ColorTranslator.FromHtml("#E6F1FA");

        public static readonly Color MauCam = ColorTranslator.FromHtml("#E38B47");
        public static readonly Color MauCamHover = ColorTranslator.FromHtml("#C7743A");
        public static readonly Color MauCamNhat = ColorTranslator.FromHtml("#FCEEE0");

        public static readonly Color MauTim = ColorTranslator.FromHtml("#8B6FC9");
        public static readonly Color MauTimHover = ColorTranslator.FromHtml("#7259A8");
        public static readonly Color MauTimNhat = ColorTranslator.FromHtml("#EFE9FA");

        public static readonly Color MauHong = ColorTranslator.FromHtml("#D9679A");
        public static readonly Color MauHongHover = ColorTranslator.FromHtml("#BC5382");
        public static readonly Color MauHongNhat = ColorTranslator.FromHtml("#FBE7EF");

        // ============ FONT ============
        public static readonly Font FontChu = new Font("Segoe UI", 9.5F);
        public static readonly Font FontChuDam = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontTieuDeLon = new Font("Segoe UI", 17F, FontStyle.Bold);
        public static readonly Font FontTieuDeVua = new Font("Segoe UI", 12.5F, FontStyle.Bold);
        public static readonly Font FontTieuDeNho = new Font("Segoe UI", 10.5F, FontStyle.Bold);

        // ============ ÁP TỰ ĐỘNG CHO CẢ FORM (không cần style tay từng control) ============
        // Duyệt đệ quy toàn bộ control trên form và tự chọn kiểu style phù hợp theo loại control.
        // Dùng cho các form nhỏ/đơn giản để đồng bộ giao diện nhanh, an toàn (không đổi vị trí/kích thước).
        public static void ApDungTuDong(Form form)
        {
            ApDungNenForm(form);
            ApDungTuDongChoControl(form.Controls);
        }

        private static void ApDungTuDongChoControl(Control.ControlCollection danhSachControl)
        {
            foreach (Control control in danhSachControl)
            {
                switch (control)
                {
                    case Button nut:
                        LamDepNut(nut, DoanKieuNut(nut.Text));
                        break;

                    case TextBox oNhap:
                        LamDepTextBox(oNhap);
                        break;

                    case ComboBox oChon:
                        LamDepCombo(oChon);
                        break;

                    case DataGridView bang:
                        LamDepBang(bang);
                        break;

                    case LinkLabel lienKet:
                        LamDepLinkLabel(lienKet);
                        break;

                    case Label nhan:
                        if (nhan.Font.Bold && nhan.Font.Size >= 11F)
                        {
                            LamDepTieuDe(nhan, lon: nhan.Font.Size >= 14F);
                        }
                        else
                        {
                            nhan.ForeColor = MauChuChinh;
                        }
                        break;
                }

                // Đệ quy vào các control con (Panel, GroupBox, TabPage...)
                if (control.HasChildren)
                {
                    ApDungTuDongChoControl(control.Controls);
                }
            }
        }

        // Đoán "vai trò" của nút dựa theo chữ trên nút, để tô màu phù hợp
        private static KieuNut DoanKieuNut(string chuTrenNut)
        {
            string chu = chuTrenNut.ToLowerInvariant();

            if (chu.Contains("xóa") || chu.Contains("hủy") || chu.Contains("đăng xuất"))
            {
                return KieuNut.NguyHiem;
            }

            if (chu.Contains("lưu") || chu.Contains("thêm") || chu.Contains("tạo")
                || chu.Contains("đăng nhập") || chu.Contains("đăng ký") || chu.Contains("xác nhận")
                || chu.Contains("cập nhật") || chu.Contains("gửi"))
            {
                return KieuNut.Chinh;
            }

            return KieuNut.Phu;
        }

        public enum KieuNut { Chinh, Phu, NguyHiem, TrongSuot, XanhDuong, Cam, Tim }

        // Áp nền + font chung cho cả form
        public static void ApDungNenForm(Form f)
        {
            f.BackColor = MauNen;
            f.Font = FontChu;
        }

        // ============ NÚT BẤM ============
        public static void LamDepNut(Button b, KieuNut kieu = KieuNut.Phu, int bankinh = 8)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Cursor = Cursors.Hand;
            b.Font = FontChuDam;
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.UseVisualStyleBackColor = false;

            Color nen, nenHover, chu;

            switch (kieu)
            {
                case KieuNut.Chinh:
                    nen = MauXanhChinh;
                    nenHover = MauXanhChinhHover;
                    chu = Color.White;
                    break;

                case KieuNut.NguyHiem:
                    nen = MauDo;
                    nenHover = MauDoHover;
                    chu = Color.White;
                    break;

                case KieuNut.TrongSuot:
                    nen = MauXanhDam;
                    nenHover = MauXanhDamHover;
                    chu = Color.White;
                    break;

                case KieuNut.XanhDuong:
                    nen = MauXanhDuong;
                    nenHover = MauXanhDuongHover;
                    chu = Color.White;
                    break;

                case KieuNut.Cam:
                    nen = MauCam;
                    nenHover = MauCamHover;
                    chu = Color.White;
                    break;

                case KieuNut.Tim:
                    nen = MauTim;
                    nenHover = MauTimHover;
                    chu = Color.White;
                    break;

                default:
                    nen = MauXamNhat;
                    nenHover = MauXanhNhat;
                    chu = MauXanhDam;
                    break;
            }

            b.BackColor = nen;
            b.ForeColor = chu;

            b.MouseEnter += (s, e) => b.BackColor = nenHover;
            b.MouseLeave += (s, e) => b.BackColor = nen;

            BoGocTron(b, bankinh);
        }

        // ============ Ô NHẬP ============
        public static void LamDepTextBox(TextBox t)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.BackColor = Color.White;
            t.ForeColor = MauChuChinh;
            t.Font = FontChu;

            // Hiệu ứng nhẹ khi người dùng bấm vào ô để biết đang nhập ở đâu
            t.Enter += (s, e) => t.BackColor = MauXanhNhat;
            t.Leave += (s, e) => t.BackColor = Color.White;
        }

        public static void LamDepCombo(ComboBox c)
        {
            c.FlatStyle = FlatStyle.Flat;
            c.BackColor = Color.White;
            c.ForeColor = MauChuChinh;
            c.Font = FontChu;
        }

        // ============ NHÃN ============
        public static void LamDepTieuDe(Label l, bool lon = false)
        {
            l.ForeColor = MauXanhDam;
            l.Font = lon ? FontTieuDeLon : FontTieuDeVua;
        }

        public static void LamDepNhanPhu(Label l)
        {
            l.ForeColor = MauChuPhu;
        }

        public static void LamDepLinkLabel(LinkLabel l)
        {
            l.LinkColor = MauXanhChinh;
            l.ActiveLinkColor = MauXanhChinhHover;
            l.VisitedLinkColor = MauXanhChinh;
            l.LinkBehavior = LinkBehavior.HoverUnderline;
            l.Font = FontChuDam;
        }

        // ============ BẢNG DỮ LIỆU ============
        public static void LamDepBang(DataGridView g)
        {
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.GridColor = MauVien;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersDefaultCellStyle.BackColor = MauXanhChinh;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = FontChuDam;
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            g.ColumnHeadersHeight = 36;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.RowTemplate.Height = 30;
            g.DefaultCellStyle.SelectionBackColor = MauXanhNhat;
            g.DefaultCellStyle.SelectionForeColor = MauChuChinh;
            g.DefaultCellStyle.Font = FontChu;
            g.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            g.AlternatingRowsDefaultCellStyle.BackColor = MauSocXen;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.RowHeadersVisible = false;
            g.BorderStyle = BorderStyle.FixedSingle;

            // Sáng nhẹ dòng đang rê chuột qua để bảng sống động, dễ dò theo hàng hơn
            g.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    g.Rows[e.RowIndex].DefaultCellStyle.BackColor = MauDongHover;
                }
            };

            g.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    g.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : MauSocXen;
                }
            };
        }

        // ============ NỀN GRADIENT (dùng cho panel thương hiệu, sidebar, banner...) ============
        public static void VeNenGradient(Control c, Color mauTren, Color mauDuoi, float gocDo = 90f)
        {
            c.Paint += (s, e) =>
            {
                if (c.Width <= 0 || c.Height <= 0)
                {
                    return;
                }

                Rectangle vung = new Rectangle(0, 0, c.Width, c.Height);
                using LinearGradientBrush co = new LinearGradientBrush(vung, mauTren, mauDuoi, gocDo);
                e.Graphics.FillRectangle(co, vung);
            };

            c.Resize += (s, e) => c.Invalidate();
            c.Invalidate();
        }

        // ============ NHÃN DẠNG HUY HIỆU (PILL/BADGE) ============
        public static void LamDepNhanBadge(Label l, Color? mauNen = null, Color? mauChu = null, int bankinh = 11)
        {
            l.AutoSize = true;
            l.BackColor = mauNen ?? MauXanhNhat;
            l.ForeColor = mauChu ?? MauXanhDam;
            l.Font = FontChuDam;
            l.Padding = new Padding(14, 5, 14, 5);
            l.TextAlign = ContentAlignment.MiddleCenter;

            BoGocTron(l, bankinh);
        }

        // ============ THẺ (CARD) BO GÓC ============
        public static void LamDepThe(Panel p, int bankinh = 14, bool coVien = true)
        {
            p.BackColor = MauTrang;

            void CapNhatVung()
            {
                if (p.Width <= 0 || p.Height <= 0)
                {
                    return;
                }

                using GraphicsPath duong = TaoDuongBoTron(new Rectangle(0, 0, p.Width, p.Height), bankinh);
                p.Region = new Region(duong);
            }

            p.Resize += (s, e) => CapNhatVung();
            CapNhatVung();

            if (coVien)
            {
                p.Paint += (s, e) =>
                {
                    using GraphicsPath duong = TaoDuongBoTron(new Rectangle(0, 0, p.Width - 1, p.Height - 1), bankinh);
                    using Pen but = new Pen(MauVien, 1);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(but, duong);
                };
            }
        }

        // ============ THANH BÊN (SIDEBAR) ============
        public static void LamDepNutMenu(Button b, bool dangChon = false)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Cursor = Cursors.Hand;
            b.Font = FontChuDam;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(18, 0, 0, 0);
            b.BackColor = dangChon ? MauXanhChinh : MauXanhDam;
            b.ForeColor = Color.White;

            Color nenThuong = dangChon ? MauXanhChinh : MauXanhDam;
            Color nenHover = MauXanhChinhHover;

            b.MouseEnter += (s, e) => b.BackColor = nenHover;
            b.MouseLeave += (s, e) => b.BackColor = nenThuong;
        }

        public static void BoGocTron(Control c, int bankinh)
        {
            void CapNhat()
            {
                if (c.Width <= 0 || c.Height <= 0)
                {
                    return;
                }

                using GraphicsPath duong = TaoDuongBoTron(new Rectangle(0, 0, c.Width, c.Height), bankinh);
                c.Region = new Region(duong);
            }

            c.Resize += (s, e) => CapNhat();
            CapNhat();
        }

        private static GraphicsPath TaoDuongBoTron(Rectangle r, int bankinh)
        {
            GraphicsPath duong = new GraphicsPath();
            int d = bankinh * 2;

            if (d > r.Width) d = r.Width;
            if (d > r.Height) d = r.Height;

            duong.AddArc(r.X, r.Y, d, d, 180, 90);
            duong.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            duong.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            duong.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            duong.CloseFigure();

            return duong;
        }
    }
}
