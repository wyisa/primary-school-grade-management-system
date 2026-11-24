
---

##  Danh Sách Form Chức Năng (13 Form)

| # | Form | Chức năng chính |
|---|---|---|
| 1 | `FrmDangNhap` | Đăng nhập, phân quyền |
| 2 | `FrmMain` | Menu chính |
| 3 | `FrmQuanLyTaiKhoan` | Quản lý tài khoản |
| 4 | `FrmQuanLyHocSinh` | Quản lý học sinh, nhập Excel |
| 5 | `FrmQuanLyLop` | Quản lý lớp học |
| 6 | `FrmQuanLyMonHoc` | Quản lý môn học |
| 7 | `FrmQuanLyGiaoVien` | Quản lý giáo viên |
| 8 | `FrmQuanLyDiem` | Nhập điểm, xuất Excel, in học bạ PDF |
| 9 | `FrmDanhGiaPhamChat` | Đánh giá phẩm chất  năng lực |
| 10 | `FrmThongKe` | Thống kê nâng cao, in báo cáo |
| 11 | `FrmPhanCong` | Phân công giảng dạy |
| 12 | `FrmDoiMatKhau` | Đổi mật khẩu |
| 13 | `FrmGioiThieu` | Giới thiệu phần mềm |

---

##  Cơ Sở Dữ Liệu

| Bảng | Mô tả |
|---|---|
| `TaiKhoan` | Tài khoản, phân quyền |
| `HocSinh` | Thông tin học sinh |
| `Lop` | Lớp học |
| `MonHoc` | Môn học |
| `GiaoVien` | Giáo viên |
| `DiemDinhKy` | Điểm định kỳ |
| `DanhGiaPhamChatNangLuc` | Đánh giá phẩm chất, năng lực |
| `PhanCong` | Phân công giảng dạy |

---

##  Tài Khoản Demo

| Vai trò | Username | Password |
|---|---|---|
| Quản trị viên | `admin` | `admin123` |
| Giáo viên | `giaovien1` | `123456` |
| Học vụ | `hocvu1` | `123456` |

>  Tài khoản demo, không dùng cho môi trường thật.

---

## 🎬 Video Demo & Tài Liệu

- 🎥 Video demo: [YouTube](https://youtu.be/...)
- 📘 Báo cáo đồ án: [docs/BaoCao.pdf](docs/BaoCao.pdf)
- 📊 Slide: [docs/Slide.pdf](docs/Slide.pdf)

---

## 🐛 Hạn Chế & Hướng Phát Triển

**Hạn chế hiện tại**
- Chưa hỗ trợ đa người dùng đồng thời
- Chưa có bản web/mobile
- Chưa tự động sao lưu CSDL

**Hướng phát triển**
- [ ] Chuyển sang client-server (API + WinForms)
- [ ] Bổ sung web app (ASP.NET Core)
- [ ] Tự động backup CSDL
- [ ] Tùy chỉnh mẫu báo cáo
- [ ] Biểu đồ thống kê trực quan

---

## 🗺️ Roadmap

### ✅ v1.0 — Đã hoàn thành
- [x] 13 form chức năng
- [x] Kiến trúc 3 lớp
- [x] Nhập/xuất Excel
- [x] In học bạ PDF
- [x] Thống kê nâng cao

### 🚧 v1.1 — Đang phát triển
- [ ] Biểu đồ thống kê trực quan
- [ ] Sao lưu CSDL tự động
- [ ] Tùy chỉnh mẫu báo cáo

### 💡 v2.0 — Dự kiến
- [ ] Bản web (ASP.NET Core)
- [ ] API RESTful
- [ ] Ứng dụng mobile

---

## 🔒 Bảo Mật

- Mật khẩu mã hóa trước khi lưu CSDL
- Connection string không commit — dùng `appsettings.example.json`
- Phân quyền: Admin / Giáo viên / Học vụ

---

## 🙏 Lời Cảm Ơn

- Giảng viên hướng dẫn: **[Tên GV]**
- Khoa **[CNTT]** — Trường **[UNETI]**
- Cộng đồng Stack Overflow, GitHub

---

## 📬 Liên Hệ

| Thành viên | Vai trò | GitHub |
|---|---|---|
| **Quyền** | Nhóm trưởng | [luuthequyen](https://github.com/luuthequyen144-ship-it)  |
| **Minh** | OOD & Testing | [@wyisa](https://github.com/wyisa) |
| **Hoàng** | OOA & Demo | _username_ |

---

<p align="center"><i>Đồ án được thực hiện với 💚 bởi nhóm 3 thành viên.</i></p>
