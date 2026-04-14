🚀 Đồ Án: Hệ Thống Quản Lý Bán Đồng Hồ - DUY WATCHES
📝 Giới thiệu dự án
DUY WATCHES là phần mềm quản lý bán hàng đồng hồ chuyên nghiệp dành cho các cửa hàng bán lẻ. Dự án được xây dựng bằng WinForms trên nền tảng .NET 8, hướng tới việc số hóa quy trình kinh doanh, kiểm soát tồn kho và quản lý nhân sự hiệu quả.

Đây là phiên bản hoàn thiện (Final Version) của đồ án với trọng tâm:

Tự động hóa quy trình bán hàng và thống kê doanh thu thời gian thực.

Đảm bảo tính toàn vẹn dữ liệu (Data Integrity) cho hóa đơn lịch sử.

Theo dõi chặt chẽ hệ thống qua Nhật ký hoạt động (Activity Log).

Tối ưu hóa trải nghiệm người dùng (UI/UX) và tinh gọn logic xử lý (Clean Code).

🛠 Công nghệ & Kiến trúc (Tech Stack)
Ngôn ngữ: C# (.NET 8, net8.0-windows)

UI Framework: Windows Forms (WinForms)

Cơ sở dữ liệu: SQL Server

ORM: Entity Framework Core

Truy vấn dữ liệu: LINQ

Migration: Code-First Migration

Thư viện bổ trợ: ClosedXML (Xử lý và xuất/nhập dữ liệu Excel)

✨ Các tính năng nổi bật
1) 🔐 Quản trị Hệ thống & Phân quyền
Đăng nhập & Phân quyền: Hỗ trợ 3 vai trò (Admin, Quản lý cửa hàng, Nhân viên bán hàng). Menu và chức năng tự động hiển thị theo quyền hạn.

Nhật ký hoạt động (Activity Log - Tính năng mới): Tự động ghi nhận mọi thao tác quan trọng (thêm, sửa, xóa, đăng nhập, thanh toán) của người dùng, giúp Admin dễ dàng truy vết và quản lý rủi ro.

2) 🛒 Nghiệp vụ Bán hàng cốt lõi
Tạo hóa đơn, thêm sản phẩm vào giỏ hàng, tính toán tổng tiền và quản lý trạng thái thanh toán.

Snapshot Hóa đơn: Tự động "chụp" lại thông tin khách hàng, nhân viên và tên sản phẩm tại thời điểm bán, đảm bảo dữ liệu lịch sử không bị thay đổi dù thông tin gốc trong database bị cập nhật.

3) 📊 Dashboard Tổng quan (Real-time)
Trang chủ đóng vai trò là trung tâm kiểm soát, hiển thị ngay lập tức:

Doanh thu trong ngày.

Số lượng đơn hàng & Khách hàng mới.

Cảnh báo sản phẩm sắp hết hàng.

Danh sách hóa đơn vừa giao dịch.

4) 📦 Quản lý Danh mục (CRUD Tối ưu)
Quản lý sản phẩm, thông số kỹ thuật, thương hiệu, loại đồng hồ.

Quản lý thông tin nhân viên, khách hàng.

Logic tại các Form đã được tinh chỉnh, kiểm tra tính hợp lệ của dữ liệu (Validate) khắt khe và loại bỏ hoàn toàn các thao tác dư thừa.

5) ⚙️ Tự động hóa Cơ sở dữ liệu
Cơ chế Backfill: Tự động đồng bộ và sửa chữa dữ liệu hóa đơn cũ khi khởi động.

Tự động gọi Database.Migrate() lúc chạy app, tự động cấu trúc lại CSDL mà không cần chạy lệnh thủ công trên máy mới.

🏗️ Cấu trúc Thực thể (Database Schema)
Hệ thống xoay quanh các nhóm thực thể chính:

Sản phẩm: SanPham, ThuongHieu, LoaiDongHo, ThongSoKyThuat

Con người: NhanVien, KhachHang, PhanQuyen

Giao dịch & Hệ thống: HoaDon, HoaDonChiTiet, NhatKyHoatDong (hoặc log file tương đương).
