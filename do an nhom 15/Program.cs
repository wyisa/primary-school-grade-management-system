using do_an_nhom_15.Data;

namespace do_an_nhom_15
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cấu hình giấy phép QuestPDF (bản Community - miễn phí cho đồ án/sử dụng cá nhân)
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            // Khởi tạo database khi mở ứng dụng
            DatabaseHelper.InitializeDatabase();

            // Mở Form đăng nhập đầu tiên
            Application.Run(new FrmLogin());
        }
    }
}