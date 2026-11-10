<div align="center">

# Quản lý ⌚ DUY WATCHES

### Hệ thống quản lý bán đồng hồ

Ứng dụng desktop hỗ trợ cửa hàng quản lý sản phẩm, khách hàng, nhân viên,
hóa đơn và hoạt động kinh doanh trên một nền tảng tập trung.

<p>
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8">
  <img src="https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white" alt="C Sharp">
  <img src="https://img.shields.io/badge/WinForms-0078D4?style=for-the-badge&logo=windows&logoColor=white" alt="Windows Forms">
</p>
<p>
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server">
  <img src="https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="Entity Framework Core">
  <img src="https://img.shields.io/badge/LINQ-68217A?style=for-the-badge&logo=.net&logoColor=white" alt="LINQ">
  <img src="https://img.shields.io/badge/ClosedXML-217346?style=for-the-badge&logo=microsoftexcel&logoColor=white" alt="ClosedXML">
</p>

</div>

---

## 📌 Giới thiệu

**DUY WATCHES** là đồ án xây dựng hệ thống quản lý bán đồng hồ dành cho cửa
hàng bán lẻ. Phần mềm số hóa quy trình từ quản lý danh mục và tồn kho đến
bán hàng, xuất hóa đơn, thống kê doanh thu và theo dõi nhật ký hoạt động.

### Mục tiêu

- Tập trung dữ liệu sản phẩm, thương hiệu, khách hàng và nhân viên.
- Đơn giản hóa thao tác bán hàng và quản lý hóa đơn.
- Hỗ trợ phân quyền theo vai trò người dùng.
- Bảo toàn thông tin lịch sử giao dịch bằng dữ liệu snapshot trên hóa đơn.
- Cung cấp nhật ký hoạt động để dễ dàng kiểm tra và truy vết.

## ✨ Tính năng chính

### 🔐 Đăng nhập và phân quyền

- Đăng nhập bằng tài khoản nhân viên.
- Phân quyền theo vai trò: **Admin**, **Quản lý cửa hàng** và **Nhân viên bán hàng**.
- Hiển thị chức năng phù hợp với quyền của người dùng.

### 🛒 Bán hàng và hóa đơn

- Tạo hóa đơn, thêm sản phẩm vào giỏ hàng và tính tổng tiền.
- Quản lý trạng thái thanh toán.
- Lưu snapshot thông tin khách hàng, nhân viên và sản phẩm tại thời điểm bán.
- Tích hợp điểm tích lũy khách hàng.

### 📦 Quản lý danh mục

- Sản phẩm và thông số kỹ thuật đồng hồ.
- Thương hiệu và loại đồng hồ.
- Khách hàng và nhân viên.
- Kiểm tra dữ liệu đầu vào trước khi lưu.

### 📊 Thống kê và nhật ký

- Dashboard tổng quan doanh thu, đơn hàng và khách hàng.
- Thống kê tiền bán theo thời gian.
- Cảnh báo sản phẩm sắp hết hàng.
- Ghi nhận các thao tác thêm, sửa, xóa, đăng nhập và thanh toán.

### ⚙️ Tự động hóa cơ sở dữ liệu

- Tự động chạy `Database.Migrate()` khi khởi động ứng dụng.
- Tự động backfill snapshot cho các hóa đơn cũ.
- Entity Framework Core Code First với thư mục migration đi kèm dự án.

## 🧰 Công nghệ sử dụng

| Nhóm            | Công nghệ                 |
| --------------- | ------------------------- |
| Ngôn ngữ        | C#                        |
| Nền tảng        | .NET 8 (`net8.0-windows`) |
| Giao diện       | Windows Forms             |
| Cơ sở dữ liệu   | Microsoft SQL Server      |
| ORM             | Entity Framework Core 9   |
| Truy vấn        | LINQ                      |
| Migration       | EF Core Code First        |
| Xuất/nhập Excel | ClosedXML                 |

## 🏗️ Kiến trúc và cấu trúc dự án

```text
LTQL_QLBHDongHo/
├── Data/             # Entity, DbContext, session và activity logger
├── Forms/            # Các màn hình WinForms của ứng dụng
├── Migrations/       # EF Core migrations
├── Images/           # Tài nguyên hình ảnh
├── Reports/          # Báo cáo
├── App.config        # Cấu hình chuỗi kết nối
├── Program.cs        # Điểm khởi chạy ứng dụng
└── *.csproj          # Cấu hình dự án và package
```

### Các thực thể chính

- **Danh mục:** `SanPham`, `ThuongHieu`, `LoaiDongHo`, `ThongSoKyThuat`
- **Người dùng:** `NhanVien`, `KhachHang`, `PhanQuyen`
- **Giao dịch:** `HoaDon`, `HoaDonChiTiet`
- **Hệ thống:** `NhatKyHoatDong`

## 🚀 Cài đặt và chạy dự án

### Yêu cầu môi trường

- Windows 10/11.
- Visual Studio 2022 có workload **.NET desktop development**.
- .NET 8 SDK.
- SQL Server hoặc SQL Server Express.

### Các bước thực hiện

1. Clone repository và mở solution `LTQL_QLBHDongHo.sln` bằng Visual Studio.
2. Tạo database `QLBH_DongHo` trên SQL Server.
3. Mở `App.config` và cập nhật `Server` trong chuỗi kết nối cho phù hợp với máy.
4. Chọn project `LTQL_QLBHDongHo` làm **Startup Project**.
5. Build và chạy bằng `Ctrl + F5` hoặc `F5`.

Ứng dụng sẽ tự động áp dụng các migration hiện có khi khởi động. Nếu cần
thực hiện thủ công trong **Package Manager Console**, chạy:

```powershell
Update-Database
```

Khi thay đổi model, tạo migration mới bằng:

```powershell
Add-Migration TenMigration
Update-Database
```

## 🗃️ Cấu hình cơ sở dữ liệu

Chuỗi kết nối được cấu hình trong `App.config`:

```xml
<connectionStrings>
  <add name="ChuoiKetNoi"
       connectionString="Server=TEN_MAY_CHU;Database=QLBH_DongHo;Trusted_Connection=True;TrustServerCertificate=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

> Không đưa thông tin đăng nhập hoặc chuỗi kết nối chứa mật khẩu thật lên
> repository.

## 📝 Ghi chú

- Đây là đồ án môn **Lập trình quản lý**.
- Giao diện và nghiệp vụ được xây dựng hướng tới quy trình bán đồng hồ tại
  cửa hàng bán lẻ.
- Dữ liệu lịch sử hóa đơn được ưu tiên giữ ổn định ngay cả khi thông tin gốc
  của sản phẩm, khách hàng hoặc nhân viên thay đổi.

---

<div align="center">

**DUY WATCHES · Watch Store Management System**

</div>
