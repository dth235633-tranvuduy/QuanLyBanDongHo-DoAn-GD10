USE [master]
GO
/****** Object:  Database [QLBH_DongHo]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE DATABASE [QLBH_DongHo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBH_DongHo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLBH_DongHo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLBH_DongHo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLBH_DongHo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLBH_DongHo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBH_DongHo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBH_DongHo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBH_DongHo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBH_DongHo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLBH_DongHo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBH_DongHo] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [QLBH_DongHo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET RECOVERY FULL 
GO
ALTER DATABASE [QLBH_DongHo] SET  MULTI_USER 
GO
ALTER DATABASE [QLBH_DongHo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBH_DongHo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBH_DongHo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBH_DongHo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLBH_DongHo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLBH_DongHo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLBH_DongHo', N'ON'
GO
ALTER DATABASE [QLBH_DongHo] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLBH_DongHo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLBH_DongHo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienID] [int] NULL,
	[KhachHangID] [int] NULL,
	[NgayLap] [datetime2](7) NOT NULL,
	[GhiChuHoaDon] [nvarchar](max) NULL,
	[DiemSuDung] [int] NOT NULL,
	[SoTienGiamDiem] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonChiTiet]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonChiTiet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoaDonID] [int] NOT NULL,
	[SanPhamID] [int] NULL,
	[SoLuongBan] [int] NOT NULL,
	[DonGiaBan] [int] NOT NULL,
	[TenSanPhamSnapshot] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_HoaDonChiTiet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](max) NOT NULL,
	[DienThoai] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[DiemTichLuy] [int] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiDongHo]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDongHo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LoaiDongHo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](max) NOT NULL,
	[TenDangNhap] [nvarchar](max) NOT NULL,
	[MatKhau] [nvarchar](max) NOT NULL,
	[PhanQuyenID] [int] NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[DienThoai] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhatKyHoatDong]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhatKyHoatDong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](100) NOT NULL,
	[TenNhanVien] [nvarchar](150) NOT NULL,
	[VaiTro] [nvarchar](100) NOT NULL,
	[HanhDong] [nvarchar](120) NOT NULL,
	[ChiTiet] [nvarchar](1000) NOT NULL,
	[ThoiGian] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](200) NOT NULL,
	[DonGia] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[HinhAnh] [nvarchar](500) NULL,
	[MoTa] [nvarchar](1000) NULL,
	[ThuongHieuID] [int] NOT NULL,
	[LoaiDongHoID] [int] NULL,
	[KieuDang] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongSoKyThuat]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongSoKyThuat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SanPhamID] [int] NOT NULL,
	[DoChiuNuoc] [nvarchar](200) NOT NULL,
	[KichThuocMat] [nvarchar](200) NOT NULL,
	[LoaiDay] [nvarchar](200) NOT NULL,
	[LoaiDongHoID] [int] NULL,
	[LoaiKinh] [nvarchar](200) NOT NULL,
	[TenThuongHieu] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ThongSoKyThuat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 04/14/2026 1:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenThuongHieu] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HangSanXuat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260321151707_UpdateData9bang', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260322064254_SuanoidungDatabase', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260322110226_capnhatBangsanpham', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260322121220_themDiaChiKhanhHang', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260323125157_themDiaChiNV', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260403022309_CapNhatDuLieu', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260403023339_CapNhatDuLieu2', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260403025308_DoiTenHangSanXuatThanhThuongHieu', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260403025525_DoiTenHangSanXuatThanhThuongHieu1', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260403030210_ThayDoiTenDoiThuongHSX', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260408173721_AddKieuDangToSanPham', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260409121452_HoaDonSnapshot_SetNull_DeleteBehavior', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260409180757_TenMigrationMoi', N'9.0.12')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20260410020036_AddDiemTichLuyAndHoaDonPointField', N'9.0.12')
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (1, 4, 1, CAST(N'2026-04-01T08:30:00.0000000' AS DateTime2), N'Đã thanh toán tiền mặt ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIFRodSBOZ1x1MDBFMm4iLCJLaGFjaEhhbmdUZW4iOiJOZ3V5XHUxRUM1biBWXHUwMTAzbiBBIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIwODY3Nzk3NzAzIn0=', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (2, 4, 2, CAST(N'2026-04-02T09:15:00.0000000' AS DateTime2), N'Khách hẹn giao buổi chiều ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIFRodSBOZ1x1MDBFMm4iLCJLaGFjaEhhbmdUZW4iOiJUclx1MUVBN24gVGhcdTFFQ0IgQiIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiMDg2Nzc5NzcwNCJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (3, 2, 3, CAST(N'2026-04-03T14:00:00.0000000' AS DateTime2), N'Đã chuyển khoản ngân hàng ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIE1pbmggVFx1MDBFMm0iLCJLaGFjaEhhbmdUZW4iOiJMXHUwMEVBIFZcdTAxMDNuIEMiLCJLaGFjaEhhbmdTb0RpZW5UaG9haSI6IjA4Njc3OTc3MDYifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (4, 5, 4, CAST(N'2026-04-04T10:45:00.0000000' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IlBoXHUxRUExbSBIb1x1MDBFMGkgTmFtIiwiS2hhY2hIYW5nVGVuIjoiUGhcdTFFQTFtIE1pbmggRCIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiMDg2Nzc5NzcxMiJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (5, 1, 5, CAST(N'2026-04-05T16:20:00.0000000' AS DateTime2), N'Đơn hàng quà tặng đặc biệt ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJIb1x1MDBFMG5nIFRoXHUxRUNCIEUiLCJLaGFjaEhhbmdTb0RpZW5UaG9haSI6IjA4Njc3OTc3MDgifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (31, 1, NULL, CAST(N'2026-04-10T08:05:56.4678579' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJEdXkiLCJLaGFjaEhhbmdTb0RpZW5UaG9haSI6IjA4Njc3OTc3MTMifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (32, 1, 16, CAST(N'2026-04-10T08:18:45.7397016' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJLaFx1MDBFMWNoIGhcdTAwRTBuZyB2XHUwMEUzbmcgbGFpIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (33, 1, NULL, CAST(N'2026-04-10T09:03:08.2645376' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiOTk5OTk5OTk5OSJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (34, 1, 27, CAST(N'2026-04-10T09:07:06.8615696' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (35, 1, 4, CAST(N'2026-04-10T09:18:15.1676922' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJQaFx1MUVBMW0gTWluaCBEIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIwODY3Nzk3NzEyIn0=', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (36, 1, 5, CAST(N'2026-04-10T10:34:19.4244240' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJIb1x1MDBFMG5nIFRoXHUxRUNCIEUiLCJLaGFjaEhhbmdTb0RpZW5UaG9haSI6IjA4Njc3OTc3MDgifQ==', 30, CAST(3000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (37, 1, 2, CAST(N'2026-04-10T10:43:08.4612501' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJUclx1MUVBN24gVGhcdTFFQ0IgQiIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiMDg2Nzc5NzcwNCJ9', 250, CAST(2500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (38, 1, 27, CAST(N'2026-04-10T10:47:17.2663831' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 250, CAST(2500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (39, 1, 16, CAST(N'2026-04-10T20:03:07.1257527' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJLaFx1MDBFMWNoIGhcdTAwRTBuZyB2XHUwMEUzbmcgbGFpIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (40, 1, 16, CAST(N'2026-04-10T20:03:32.6682224' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJLaFx1MDBFMWNoIGhcdTAwRTBuZyB2XHUwMEUzbmcgbGFpIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (41, 1, 27, CAST(N'2026-04-10T21:47:14.5119082' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (42, 4, 27, CAST(N'2026-04-10T21:54:12.3511612' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIFRodSBOZ1x1MDBFMm4iLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (43, 4, 27, CAST(N'2026-04-10T21:55:31.0350801' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIFRodSBOZ1x1MDBFMm4iLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 829, CAST(8290000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (44, 4, 27, CAST(N'2026-04-10T21:56:45.6455072' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIFRodSBOZ1x1MDBFMm4iLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (45, 1, 16, CAST(N'2026-04-12T16:24:16.9229380' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJLaFx1MDBFMWNoIGhcdTAwRTBuZyB2XHUwMEUzbmcgbGFpIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (46, 1, 27, CAST(N'2026-04-12T16:27:29.3076102' AS DateTime2), N'Chưa thanh toán | anh đông lx ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (47, 1, 27, CAST(N'2026-04-12T16:28:40.6828186' AS DateTime2), N'Đã thanh toán | anh đông lx ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (48, 1, 27, CAST(N'2026-04-12T16:36:58.1550300' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJcdTAxMTFcdTAwRjRuZyIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiODg4ODg4ODg4OCJ9', 346, CAST(3460000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (49, 1, 16, CAST(N'2026-04-12T18:47:55.2548769' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJLaFx1MDBFMWNoIGhcdTAwRTBuZyB2XHUwMEUzbmcgbGFpIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (50, 1, 16, CAST(N'2026-04-12T19:41:42.3827933' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IkxcdTAwRUEgVHJcdTFFQTduIFF1XHUxRUQxYyBEdXkiLCJLaGFjaEhhbmdUZW4iOiJLaFx1MDBFMWNoIGhcdTAwRTBuZyB2XHUwMEUzbmcgbGFpIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (51, 4, 28, CAST(N'2026-04-12T19:57:34.5926363' AS DateTime2), N'Đã thanh toán | Anh Duy cần thơ ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIFRodSBOZ1x1MDBFMm4iLCJLaGFjaEhhbmdUZW4iOiJEdXkiLCJLaGFjaEhhbmdTb0RpZW5UaG9haSI6IjAwMDAwMDAwMDAifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (52, 4, 16, CAST(N'2026-04-12T19:57:54.0800255' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6Ik5ndXlcdTFFQzVuIFRodSBOZ1x1MDBFMm4iLCJLaGFjaEhhbmdUZW4iOiJLaFx1MDBFMWNoIGhcdTAwRTBuZyB2XHUwMEUzbmcgbGFpIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (53, 1, 9, CAST(N'2026-04-13T22:59:40.5557027' AS DateTime2), N'Đã thanh toán | thị l long xuyen ||META:eyJOaGFuVmllblRlbiI6IlRyXHUxRUE3biBWXHUwMTY5IER1eSIsIktoYWNoSGFuZ1RlbiI6Ik5nXHUwMEY0IFRoXHUxRUNCIEkiLCJLaGFjaEhhbmdTb0RpZW5UaG9haSI6IjA4Njc3OTc3MTQifQ==', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (54, 1, 2, CAST(N'2026-04-13T23:00:07.6388046' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IlRyXHUxRUE3biBWXHUwMTY5IER1eSIsIktoYWNoSGFuZ1RlbiI6IlRyXHUxRUE3biBUaFx1MUVDQiBCIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIwODY3Nzk3NzA0In0=', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (55, 1, 29, CAST(N'2026-04-14T11:35:02.5339875' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IlRyXHUxRUE3biBWXHUwMTY5IER1eSIsIktoYWNoSGFuZ1RlbiI6IkR1eSIsIktoYWNoSGFuZ1NvRGllblRob2FpIjoiMDg2Nzc5NzcxMyJ9', 0, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([ID], [NhanVienID], [KhachHangID], [NgayLap], [GhiChuHoaDon], [DiemSuDung], [SoTienGiamDiem]) VALUES (56, 1, 30, CAST(N'2026-04-14T11:35:50.9690896' AS DateTime2), N'Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IlRyXHUxRUE3biBWXHUwMTY5IER1eSIsIktoYWNoSGFuZ1RlbiI6Ilx1MDExMFx1MUVDQm5oIiwiS2hhY2hIYW5nU29EaWVuVGhvYWkiOiIwODY3Nzk3NzE1In0=', 0, CAST(0.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonChiTiet] ON 
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (1, 1, NULL, 1, 3500000, N'Casio G-Shock GA-100')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (2, 1, NULL, 1, 4500000, N'Casio Edifice')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (3, 2, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (4, 3, 4, 1, 20000000, N'Apple Watch Ultra')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (5, 3, 7, 1, 18000000, N'Garmin Fenix 7')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (6, 3, 14, 1, 11500000, N'Garmin Venu 3S')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (7, 4, 11, 2, 17000000, N'Tissot PRX 35mm')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (8, 5, 15, 1, 320000000, N'Rolex Datejust 31')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (44, 31, NULL, 1, 3500000, N'Casio G-Shock GA-100')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (45, 31, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (46, 32, 4, 1, 20000000, N'Apple Watch Ultra')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (47, 32, 6, 1, 8000000, N'Citizen Eco-Drive')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (48, 33, 2, 2, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (49, 34, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (50, 35, 3, 1, 6000000, N'Seiko 5 Sport')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (51, 36, 3, 1, 6000000, N'Seiko 5 Sport')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (52, 37, 12, 1, 9500000, N'Citizen L Sunrise')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (53, 38, 14, 1, 11500000, N'Garmin Venu 3S')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (54, 39, 3, 1, 6000000, N'Seiko 5 Sport')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (55, 40, 7, 1, 18000000, N'Garmin Fenix 7')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (56, 41, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (57, 42, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (58, 42, 15, 1, 320000000, N'Rolex Datejust 31')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (59, 43, 8, 1, 45000000, N'Longines Master')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (60, 44, 8, 1, 45000000, N'Longines Master')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (61, 45, 3, 1, 6000000, N'Seiko 5 Sport')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (62, 46, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (63, 47, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (64, 47, 5, 1, 15000000, N'Tissot Le Locle')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (65, 48, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (66, 48, 14, 1, 11500000, N'Garmin Venu 3S')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (67, 49, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (68, 50, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (69, 51, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (70, 52, 2, 1, 250000000, N'Rolex Submariner')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (71, 53, 11, 1, 17000000, N'Tissot PRX 35mm')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (72, 54, 11, 1, 17000000, N'Tissot PRX 35mm')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (73, 55, 6, 1, 8000000, N'Citizen Eco-Drive')
GO
INSERT [dbo].[HoaDonChiTiet] ([ID], [HoaDonID], [SanPhamID], [SoLuongBan], [DonGiaBan], [TenSanPhamSnapshot]) VALUES (74, 56, 6, 3, 8000000, N'Citizen Eco-Drive')
GO
SET IDENTITY_INSERT [dbo].[HoaDonChiTiet] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (1, N'Nguyễn Văn A', N'0867797703', N'Hà Nội', 8)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (2, N'Trần Thị B', N'0867797704', N'TP.HCM', 24)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (3, N'Lê Văn C', N'0867797706', N'Đà Nẵng', 49)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (4, N'Phạm Minh D', N'0867797712', N'Cần Thơ', 40)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (5, N'Hoàng Thị E', N'0867797708', N'Hải Phòng', 23)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (6, N'Vũ Văn F', N'0867797709', N'Bình Dương', 0)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (7, N'Đỗ Thị G', N'0867797710', N'Đồng Nai', 0)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (8, N'Bùi Văn H', N'0867797711', N'An Giang', 0)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (9, N'Ngô Thị I', N'0867797714', N'Huế', 17)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (10, N'Lý Văn K', N'0867797705', N'Nha Trang', 0)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (16, N'Khách hàng vãng lai', NULL, NULL, 808)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (27, N'đông', N'0888888888', N'Long xuyên', 258)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (28, N'Duy', N'0111111111', N'Long xuyên', 250)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (29, N'Duy', N'0867797713', N'Long Xuyên', 8)
GO
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [DiemTichLuy]) VALUES (30, N'Định', N'0867797715', N'An Giang', 24)
GO
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiDongHo] ON 
GO
INSERT [dbo].[LoaiDongHo] ([ID], [TenLoai]) VALUES (1, N'Đồng hồ Cơ')
GO
INSERT [dbo].[LoaiDongHo] ([ID], [TenLoai]) VALUES (2, N'Đồng hồ Pin')
GO
INSERT [dbo].[LoaiDongHo] ([ID], [TenLoai]) VALUES (3, N'Đồng hồ Thông minh')
GO
INSERT [dbo].[LoaiDongHo] ([ID], [TenLoai]) VALUES (4, N'Đồng hồ Thể thao')
GO
INSERT [dbo].[LoaiDongHo] ([ID], [TenLoai]) VALUES (5, N'Đồng hồ Lặn')
GO
SET IDENTITY_INSERT [dbo].[LoaiDongHo] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 
GO
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [TenDangNhap], [MatKhau], [PhanQuyenID], [DiaChi], [DienThoai]) VALUES (1, N'Trần Vũ Duy', N'admin', N'123456', 1, N'Long Xuyên, An Giang', N'0911111111')
GO
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [TenDangNhap], [MatKhau], [PhanQuyenID], [DiaChi], [DienThoai]) VALUES (2, N'Trần Quản Lý 1', N'nvql1', N'123', 3, N'Châu Thành, An Giang', N'0933333333')
GO
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [TenDangNhap], [MatKhau], [PhanQuyenID], [DiaChi], [DienThoai]) VALUES (3, N'Trần Quản Lý 2', N'nvql2', N'123', 3, N'Thoại Sơn, An Giang', N'0944444444')
GO
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [TenDangNhap], [MatKhau], [PhanQuyenID], [DiaChi], [DienThoai]) VALUES (4, N'Trần Nhân Viên 1', N'nv1', N'123', 2, N'Mỹ Xuyên, Long Xuyên', N'0922222222')
GO
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [TenDangNhap], [MatKhau], [PhanQuyenID], [DiaChi], [DienThoai]) VALUES (5, N'Trần Nhân Viên 2', N'nv2', N'123', 2, N'Chợ Mới, An Giang', N'0955555555')
GO
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [TenDangNhap], [MatKhau], [PhanQuyenID], [DiaChi], [DienThoai]) VALUES (6, N'Đặng Thị Tuyết', N'nv3', N'123', 2, N'Núi Sập, An Giang', N'0966666666')
GO
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[NhatKyHoatDong] ON 
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (1, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-12T18:44:13.1573237' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (2, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-12T18:47:35.4927631' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (3, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THANH TOÁN HÓA ĐƠN', N'Thanh toán thành công HD000049 | Khách: Khách hàng vãng lai | Tổng tiền: 250,000,000 VNĐ.', CAST(N'2026-04-12T18:47:55.6198455' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (4, N'admin', N'admin', N'Khách', N'ĐĂNG NHẬP THẤT BẠI', N'Đăng nhập thất bại với tài khoản ''admin''.', CAST(N'2026-04-12T19:41:12.4544366' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (5, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-12T19:41:19.1684876' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (6, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482647).', CAST(N'2026-04-12T19:41:42.7430924' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (7, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482647).', CAST(N'2026-04-12T19:41:42.7564162' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (8, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482647).', CAST(N'2026-04-12T19:41:42.9285585' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (9, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=2). SoLuong: ''7'' -> ''6''.', CAST(N'2026-04-12T19:41:42.9333795' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (10, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482647).', CAST(N'2026-04-12T19:41:42.9383128' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (11, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=2). SoLuong: ''7'' -> ''6''.', CAST(N'2026-04-12T19:41:42.9410188' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (12, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=16). DiemTichLuy: ''308'' -> ''558''.', CAST(N'2026-04-12T19:41:42.9664839' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (13, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=16). DiemTichLuy: ''308'' -> ''558''.', CAST(N'2026-04-12T19:41:42.9717511' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (14, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THANH TOÁN HÓA ĐƠN', N'Thanh toán thành công HD000050 | Khách: Khách hàng vãng lai | Tổng tiền: 250,000,000 VNĐ.', CAST(N'2026-04-12T19:41:42.9917919' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (15, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'XÓA LOAIDONGHO', N'Xóa LoaiDongHo (ID=11).', CAST(N'2026-04-12T19:42:05.3641806' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (16, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'XÓA LOAIDONGHO', N'Xóa LoaiDongHo (ID=11).', CAST(N'2026-04-12T19:42:05.3689087' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (17, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM LOAIDONGHO', N'Thêm mới LoaiDongHo (ID=-2147482647).', CAST(N'2026-04-12T19:42:21.3982730' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (18, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM LOAIDONGHO', N'Thêm mới LoaiDongHo (ID=-2147482647).', CAST(N'2026-04-12T19:42:21.4015164' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (19, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-12T19:50:12.3754106' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (20, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM THUONGHIEU', N'Thêm mới ThuongHieu (ID=-2147482647).', CAST(N'2026-04-12T19:50:47.1601375' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (21, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM THUONGHIEU', N'Thêm mới ThuongHieu (ID=-2147482647).', CAST(N'2026-04-12T19:50:47.1667769' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (22, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-12T19:53:10.4600905' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (23, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'THÊM THUONGHIEU', N'Thêm mới ThuongHieu (ID=-2147482647).', CAST(N'2026-04-12T19:53:50.9133706' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (24, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'XÓA LOAIDONGHO', N'Xóa LoaiDongHo (ID=12).', CAST(N'2026-04-12T19:54:15.4766116' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (25, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'XÓA THUONGHIEU', N'Xóa ThuongHieu (ID=11).', CAST(N'2026-04-12T19:54:30.8139840' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (26, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG XUẤT', N'Tài khoản ''admin'' đăng xuất hệ thống.', CAST(N'2026-04-12T19:55:42.0458808' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (27, N'nv1', N'nv1', N'Khách', N'ĐĂNG NHẬP THẤT BẠI', N'Đăng nhập thất bại với tài khoản ''nv1''.', CAST(N'2026-04-12T19:55:59.9437232' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (28, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'ĐĂNG NHẬP', N'Tài khoản ''nv1'' đăng nhập hệ thống.', CAST(N'2026-04-12T19:56:06.2777583' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (29, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'THÊM KHACHHANG', N'Thêm mới KhachHang (ID=-2147482647).', CAST(N'2026-04-12T19:57:34.5619058' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (30, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482647).', CAST(N'2026-04-12T19:57:34.6723239' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (31, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482647).', CAST(N'2026-04-12T19:57:34.7658501' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (32, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'SỬA SANPHAM', N'Sửa SanPham (ID=2). SoLuong: ''6'' -> ''5''.', CAST(N'2026-04-12T19:57:34.7680059' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (33, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=28). DiemTichLuy: ''0'' -> ''250''.', CAST(N'2026-04-12T19:57:34.7763077' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (34, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482646).', CAST(N'2026-04-12T19:57:54.0893728' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (35, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482646).', CAST(N'2026-04-12T19:57:54.0987692' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (36, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'SỬA SANPHAM', N'Sửa SanPham (ID=2). SoLuong: ''5'' -> ''4''.', CAST(N'2026-04-12T19:57:54.1029669' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (37, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=16). DiemTichLuy: ''558'' -> ''808''.', CAST(N'2026-04-12T19:57:54.1101297' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (38, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=28). DiaChi: ''null'' -> ''Long xuyên''.', CAST(N'2026-04-12T19:59:14.9519632' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (39, N'nvql', N'Trần Hoàng Bách', N'Nhân viên quản lý', N'ĐĂNG NHẬP', N'Tài khoản ''nvql'' đăng nhập hệ thống.', CAST(N'2026-04-12T20:02:42.4712693' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (40, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'ĐĂNG NHẬP', N'Tài khoản ''nv1'' đăng nhập hệ thống.', CAST(N'2026-04-12T20:05:27.4197990' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (41, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'ĐĂNG XUẤT', N'Tài khoản ''nv1'' đăng xuất hệ thống.', CAST(N'2026-04-12T20:05:49.2072947' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (42, N'admin', N'admin', N'Khách', N'ĐĂNG NHẬP THẤT BẠI', N'Đăng nhập thất bại với tài khoản ''admin''.', CAST(N'2026-04-12T20:06:16.4423846' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (43, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-12T20:06:22.0963452' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (44, N'admin', N'admin', N'Khách', N'ĐĂNG NHẬP THẤT BẠI', N'Đăng nhập thất bại với tài khoản ''admin''.', CAST(N'2026-04-13T12:47:27.8003434' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (45, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-13T12:47:34.5465788' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (46, N'admin', N'admin', N'Khách', N'ĐĂNG NHẬP THẤT BẠI', N'Đăng nhập thất bại với tài khoản ''admin''.', CAST(N'2026-04-13T12:50:28.3605334' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (47, N'nv1', N'Nguyễn Thu Ngân', N'Nhân viên bán hàng', N'ĐĂNG NHẬP', N'Tài khoản ''nv1'' đăng nhập hệ thống.', CAST(N'2026-04-13T12:50:40.5076054' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (48, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-13T13:07:50.0480658' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (49, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-13T13:36:15.4313378' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (50, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-13T13:49:12.5095800' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (51, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-13T14:47:22.3400525' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (52, N'admin', N'Lê Trần Quốc Duy', N'Quản trị viên', N'SỬA NHANVIEN', N'Sửa NhanVien (ID=1). HoVaTen: ''Lê Trần Quốc Duy'' -> ''Trần Vũ Duy''.', CAST(N'2026-04-13T14:49:45.5249808' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (53, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA NHANVIEN', N'Sửa NhanVien (ID=2). HoVaTen: ''Nguyễn Minh Tâm'' -> ''Trần Quản Lý''.', CAST(N'2026-04-13T14:50:18.5632766' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (54, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA NHANVIEN', N'Sửa NhanVien (ID=3). HoVaTen: ''Trần Hoàng Bách'' -> ''Trần Quản Lý 2''; TenDangNhap: ''nvql'' -> ''nvql2''.', CAST(N'2026-04-13T14:50:59.2627394' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (55, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA NHANVIEN', N'Sửa NhanVien (ID=2). HoVaTen: ''Trần Quản Lý'' -> ''Trần Quản Lý 1''.', CAST(N'2026-04-13T14:51:13.1546960' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (56, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA NHANVIEN', N'Sửa NhanVien (ID=4). HoVaTen: ''Nguyễn Thu Ngân'' -> ''Trần Nhân Viên 1''.', CAST(N'2026-04-13T14:51:39.7184787' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (57, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA NHANVIEN', N'Sửa NhanVien (ID=5). HoVaTen: ''Phạm Hoài Nam'' -> ''Trần Nhân Viên 2''.', CAST(N'2026-04-13T14:52:02.7424112' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (58, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-13T22:59:05.4285386' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (59, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482647).', CAST(N'2026-04-13T22:59:40.7083004' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (60, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482647).', CAST(N'2026-04-13T22:59:40.7980400' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (61, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=11). SoLuong: ''12'' -> ''11''.', CAST(N'2026-04-13T22:59:40.8000471' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (62, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=9). DiemTichLuy: ''0'' -> ''17''.', CAST(N'2026-04-13T22:59:40.8065109' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (63, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482646).', CAST(N'2026-04-13T23:00:07.6488477' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (64, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482646).', CAST(N'2026-04-13T23:00:07.6644626' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (65, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=11). SoLuong: ''11'' -> ''10''.', CAST(N'2026-04-13T23:00:07.6678081' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (66, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=2). DiemTichLuy: ''7'' -> ''24''.', CAST(N'2026-04-13T23:00:07.6814401' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (67, N'admin', N'admin', N'Khách', N'ĐĂNG NHẬP THẤT BẠI', N'Đăng nhập thất bại với tài khoản ''admin''.', CAST(N'2026-04-13T23:37:24.1147279' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (68, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-13T23:37:49.6155829' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (69, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-14T11:34:04.9600535' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (70, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM KHACHHANG', N'Thêm mới KhachHang (ID=-2147482647).', CAST(N'2026-04-14T11:35:02.4469062' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (71, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482647).', CAST(N'2026-04-14T11:35:02.7217955' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (72, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482647).', CAST(N'2026-04-14T11:35:02.9334941' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (73, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM KHACHHANG', N'Thêm mới KhachHang (ID=-2147482646).', CAST(N'2026-04-14T11:35:50.9390726' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (74, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADON', N'Thêm mới HoaDon (ID=-2147482646).', CAST(N'2026-04-14T11:35:50.9836933' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (75, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'THÊM HOADONCHITIET', N'Thêm mới HoaDonChiTiet (ID=-2147482646).', CAST(N'2026-04-14T11:35:51.0527721' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (76, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=6). SoLuong: ''24'' -> ''21''.', CAST(N'2026-04-14T11:35:51.0609728' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (77, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=30). DiemTichLuy: ''0'' -> ''24''.', CAST(N'2026-04-14T11:35:51.1128336' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (78, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA HOADON', N'Sửa HoaDon (ID=55). GhiChuHoaDon: ''Chưa thanh toán ||META:eyJOaGFuVmllblRlbiI6IlRyXHUxRUE3biBWXHUwMTY5IER1eSIsIktoY...'' -> ''Đã thanh toán ||META:eyJOaGFuVmllblRlbiI6IlRyXHUxRUE3biBWXHUwMTY5IER1eSIsIktoYWN...''.', CAST(N'2026-04-14T11:36:31.4775388' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (79, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=6). SoLuong: ''21'' -> ''20''.', CAST(N'2026-04-14T11:36:31.4883468' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (80, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=29). DiemTichLuy: ''0'' -> ''8''.', CAST(N'2026-04-14T11:36:31.5269023' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (81, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=2). SoLuong: ''4'' -> ''6''.', CAST(N'2026-04-14T11:36:54.1825280' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (82, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=29). DiaChi: ''null'' -> ''Long Xuyên''.', CAST(N'2026-04-14T11:37:18.3639439' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (83, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=30). DiaChi: ''null'' -> ''An Giang''.', CAST(N'2026-04-14T11:37:37.7809204' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (84, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG XUẤT', N'Tài khoản ''admin'' đăng xuất hệ thống.', CAST(N'2026-04-14T11:38:51.1247707' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (85, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-14T12:28:13.7836238' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (86, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=4). HinhAnh: ''applewatch.jpg'' -> ''af9e76b8-d675-461c-b80c-d0476af7d925.jpg''.', CAST(N'2026-04-14T12:28:46.8904125' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (87, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-14T12:30:45.3988834' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (88, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=2). HinhAnh: ''7e4e5199-0f2f-43bf-9b83-e3bf1aabb8d2.jpg'' -> ''8daf3d7a-58a6-47e6-b78a-568339b7360c.jpg''.', CAST(N'2026-04-14T12:31:25.0603801' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (89, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA SANPHAM', N'Sửa SanPham (ID=2). HinhAnh: ''8daf3d7a-58a6-47e6-b78a-568339b7360c.jpg'' -> ''56857715-0e69-4924-895a-c7f310ed1dd8.jpg''.', CAST(N'2026-04-14T12:31:38.8395817' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (90, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-14T12:35:57.1344381' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (91, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-14T13:00:25.8696874' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (92, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=27). DienThoai: ''8888888888'' -> ''0888888888''.', CAST(N'2026-04-14T13:01:17.5411168' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (93, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'SỬA KHACHHANG', N'Sửa KhachHang (ID=28). DienThoai: ''0000000000'' -> ''0111111111''.', CAST(N'2026-04-14T13:01:34.4163687' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (94, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG NHẬP', N'Tài khoản ''admin'' đăng nhập hệ thống.', CAST(N'2026-04-14T13:27:47.2798168' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (95, N'admin', N'Trần Vũ Duy', N'Quản trị viên', N'ĐĂNG XUẤT', N'Tài khoản ''admin'' đăng xuất hệ thống.', CAST(N'2026-04-14T13:29:55.1460019' AS DateTime2))
GO
INSERT [dbo].[NhatKyHoatDong] ([ID], [TenDangNhap], [TenNhanVien], [VaiTro], [HanhDong], [ChiTiet], [ThoiGian]) VALUES (96, N'nv1', N'Trần Nhân Viên 1', N'Nhân viên bán hàng', N'ĐĂNG NHẬP', N'Tài khoản ''nv1'' đăng nhập hệ thống.', CAST(N'2026-04-14T13:30:03.2252511' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[NhatKyHoatDong] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 
GO
INSERT [dbo].[PhanQuyen] ([ID], [TenQuyen]) VALUES (1, N'Quản trị viên')
GO
INSERT [dbo].[PhanQuyen] ([ID], [TenQuyen]) VALUES (2, N'Nhân viên bán hàng')
GO
INSERT [dbo].[PhanQuyen] ([ID], [TenQuyen]) VALUES (3, N'Nhân viên quản lý')
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (2, N'Rolex Submariner', 250000000, 6, N'56857715-0e69-4924-895a-c7f310ed1dd8.jpg', NULL, 2, NULL, N'Nam')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (3, N'Seiko 6  Sport', 60000000, 16, N'3ee4fe7c-2caf-4624-9c3e-77d470f7983a.jpg', NULL, 3, NULL, N'Nam')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (4, N'Apple Watch Ultra', 20000000, 14, N'af9e76b8-d675-461c-b80c-d0476af7d925.jpg', NULL, 6, NULL, N'Unisex')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (5, N'Tissot Le Locle', 15000000, 9, N'df82d434-449d-4cce-b772-03a312865f37.jpg', NULL, 5, NULL, N'Nam')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (6, N'Citizen Eco-Drive', 8000000, 20, N'583a2021-1637-455e-9dfe-4fe5c7e61787.jpg', NULL, 4, NULL, N'Nam')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (7, N'Garmin Fenix 7', 18000000, 11, N'cc3e9166-96d4-4308-8b19-f95f33e7297c.jpg', NULL, 7, NULL, N'Unisex')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (8, N'Longines Master', 45000000, 6, N'cd54bc1c-3694-4b21-b123-e6ba79657195.jpg', NULL, 9, NULL, N'Nam')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (9, N'Omega Speedmaster', 120000000, 15, N'1be97d48-667c-4614-ad28-4d4dd4095809.jpg', NULL, 10, NULL, N'Nam')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (11, N'Tissot PRX 35mm', 17000000, 10, N'75805fd8-4d2f-42c2-af5e-f0dc32b7613e.jpg', NULL, 5, NULL, N'Nữ')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (12, N'Citizen L Sunrise', 9500000, 15, N'8c477e89-73f0-4dba-a6fd-ed2589d5e88a.jpg', NULL, 4, NULL, N'Nữ')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (13, N'Seiko Presage Cocktail', 13500000, 11, N'c1692b73-b9d9-4291-8e6c-ede67330ca02.jpg', NULL, 3, NULL, N'Nam')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (14, N'Garmin Venu 3S', 11500000, 16, N'811886b7-5f99-4b93-9826-637b8db760f9.jpg', NULL, 7, NULL, N'Nữ')
GO
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [DonGia], [SoLuong], [HinhAnh], [MoTa], [ThuongHieuID], [LoaiDongHoID], [KieuDang]) VALUES (15, N'Rolex Datejust 31', 320000000, 3, N'63714f87-ad44-4821-b039-9d0f245fdec5.jpg', NULL, 2, NULL, N'Nữ')
GO
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[ThongSoKyThuat] ON 
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (2, 2, N'300m', N'40mm', N'Thép', 5, N'Sapphire', N'Rolex')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (3, 3, N'100m', N'42mm', N'Vải', 1, N'Hardlex', N'Seiko')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (4, 4, N'100m', N'49mm', N'Cao su', 3, N'Sapphire', N'Apple')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (5, 5, N'30m', N'39mm', N'Da bò', 1, N'Sapphire', N'Tissot')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (6, 6, N'50m', N'41mm', N'Thép', 2, N'Khoáng', N'Citizen')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (7, 7, N'100m', N'47mm', N'Silicone', 3, N'Sapphire', N'Garmin')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (8, 8, N'30m', N'40mm', N'Da cá sấu', 1, N'Sapphire', N'Longines')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (9, 9, N'50m', N'42mm', N'Thép', 4, N'Hesalite', N'Omega')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (11, 11, N'50m', N'35mm', N'Thép', 2, N'Sapphire', N'Tissot')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (12, 12, N'50m', N'30mm', N'Thép', 2, N'Sapphire', N'Citizen')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (13, 13, N'50m', N'40.5mm', N'Da', 1, N'Hardlex', N'Seiko')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (14, 14, N'50m', N'41mm', N'Silicone', 3, N'Gorilla Glass', N'Garmin')
GO
INSERT [dbo].[ThongSoKyThuat] ([ID], [SanPhamID], [DoChiuNuoc], [KichThuocMat], [LoaiDay], [LoaiDongHoID], [LoaiKinh], [TenThuongHieu]) VALUES (15, 15, N'100m', N'31mm', N'Vàng/Thép', 1, N'Sapphire', N'Rolex')
GO
SET IDENTITY_INSERT [dbo].[ThongSoKyThuat] OFF
GO
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (2, N'Rolex')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (3, N'Seiko')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (4, N'Citizen')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (5, N'Tissot')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (6, N'Apple')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (7, N'Garmin')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (8, N'Hublot')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (9, N'Longines')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (10, N'Omega')
GO
INSERT [dbo].[ThuongHieu] ([ID], [TenThuongHieu]) VALUES (12, N'Duy')
GO
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
GO
/****** Object:  Index [IX_HoaDon_KhachHangID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDon_KhachHangID] ON [dbo].[HoaDon]
(
	[KhachHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDon_NhanVienID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDon_NhanVienID] ON [dbo].[HoaDon]
(
	[NhanVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonChiTiet_HoaDonID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonChiTiet_HoaDonID] ON [dbo].[HoaDonChiTiet]
(
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonChiTiet_SanPhamID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonChiTiet_SanPhamID] ON [dbo].[HoaDonChiTiet]
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NhanVien_PhanQuyenID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_NhanVien_PhanQuyenID] ON [dbo].[NhanVien]
(
	[PhanQuyenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SanPham_LoaiDongHoID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_SanPham_LoaiDongHoID] ON [dbo].[SanPham]
(
	[LoaiDongHoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SanPham_ThuongHieuID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_SanPham_ThuongHieuID] ON [dbo].[SanPham]
(
	[ThuongHieuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ThongSoKyThuat_LoaiDongHoID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_ThongSoKyThuat_LoaiDongHoID] ON [dbo].[ThongSoKyThuat]
(
	[LoaiDongHoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ThongSoKyThuat_SanPhamID]    Script Date: 04/14/2026 1:59:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_ThongSoKyThuat_SanPhamID] ON [dbo].[ThongSoKyThuat]
(
	[SanPhamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [DiemSuDung]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0.0)) FOR [SoTienGiamDiem]
GO
ALTER TABLE [dbo].[HoaDonChiTiet] ADD  DEFAULT (N'') FOR [TenSanPhamSnapshot]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((0)) FOR [DiemTichLuy]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (N'') FOR [DiaChi]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (N'') FOR [DienThoai]
GO
ALTER TABLE [dbo].[NhatKyHoatDong] ADD  DEFAULT (N'') FOR [TenDangNhap]
GO
ALTER TABLE [dbo].[NhatKyHoatDong] ADD  DEFAULT (N'') FOR [TenNhanVien]
GO
ALTER TABLE [dbo].[NhatKyHoatDong] ADD  DEFAULT (N'') FOR [VaiTro]
GO
ALTER TABLE [dbo].[NhatKyHoatDong] ADD  DEFAULT (N'') FOR [HanhDong]
GO
ALTER TABLE [dbo].[NhatKyHoatDong] ADD  DEFAULT (N'') FOR [ChiTiet]
GO
ALTER TABLE [dbo].[NhatKyHoatDong] ADD  DEFAULT (sysutcdatetime()) FOR [ThoiGian]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT (N'') FOR [KieuDang]
GO
ALTER TABLE [dbo].[ThongSoKyThuat] ADD  DEFAULT (N'') FOR [DoChiuNuoc]
GO
ALTER TABLE [dbo].[ThongSoKyThuat] ADD  DEFAULT (N'') FOR [KichThuocMat]
GO
ALTER TABLE [dbo].[ThongSoKyThuat] ADD  DEFAULT (N'') FOR [LoaiDay]
GO
ALTER TABLE [dbo].[ThongSoKyThuat] ADD  DEFAULT (N'') FOR [LoaiKinh]
GO
ALTER TABLE [dbo].[ThongSoKyThuat] ADD  DEFAULT (N'') FOR [TenThuongHieu]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang_KhachHangID] FOREIGN KEY([KhachHangID])
REFERENCES [dbo].[KhachHang] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang_KhachHangID]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien_NhanVienID] FOREIGN KEY([NhanVienID])
REFERENCES [dbo].[NhanVien] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien_NhanVienID]
GO
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_HoaDon_HoaDonID] FOREIGN KEY([HoaDonID])
REFERENCES [dbo].[HoaDon] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_HoaDon_HoaDonID]
GO
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_SanPham_SanPhamID] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_SanPham_SanPhamID]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhanQuyen_PhanQuyenID] FOREIGN KEY([PhanQuyenID])
REFERENCES [dbo].[PhanQuyen] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhanQuyen_PhanQuyenID]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiDongHo_LoaiDongHoID] FOREIGN KEY([LoaiDongHoID])
REFERENCES [dbo].[LoaiDongHo] ([ID])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiDongHo_LoaiDongHoID]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ThuongHieu_ThuongHieuID] FOREIGN KEY([ThuongHieuID])
REFERENCES [dbo].[ThuongHieu] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ThuongHieu_ThuongHieuID]
GO
ALTER TABLE [dbo].[ThongSoKyThuat]  WITH CHECK ADD  CONSTRAINT [FK_ThongSoKyThuat_LoaiDongHo_LoaiDongHoID] FOREIGN KEY([LoaiDongHoID])
REFERENCES [dbo].[LoaiDongHo] ([ID])
GO
ALTER TABLE [dbo].[ThongSoKyThuat] CHECK CONSTRAINT [FK_ThongSoKyThuat_LoaiDongHo_LoaiDongHoID]
GO
ALTER TABLE [dbo].[ThongSoKyThuat]  WITH CHECK ADD  CONSTRAINT [FK_ThongSoKyThuat_SanPham_SanPhamID] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongSoKyThuat] CHECK CONSTRAINT [FK_ThongSoKyThuat_SanPham_SanPhamID]
GO
USE [master]
GO
ALTER DATABASE [QLBH_DongHo] SET  READ_WRITE 
GO
