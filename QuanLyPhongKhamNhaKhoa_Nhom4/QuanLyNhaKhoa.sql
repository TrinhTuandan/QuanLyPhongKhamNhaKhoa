USE [master]
GO
/****** Object:  Database [QuanLyNhaKhoa]    Script Date: 19/10/2023 00:37:18 ******/
CREATE DATABASE [QuanLyNhaKhoa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhaKhoa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyNhaKhoa.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyNhaKhoa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyNhaKhoa_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyNhaKhoa] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhaKhoa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhaKhoa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhaKhoa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyNhaKhoa] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyNhaKhoa', N'ON'
GO
USE [QuanLyNhaKhoa]
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[MaBenhNhan] [varchar](10) NOT NULL,
	[MaThe] [varchar](10) NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](4) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](12) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBenhNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTPhieuDichVu]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTPhieuDichVu](
	[SoPhieuDV] [varchar](10) NOT NULL,
	[MaDV] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SoPhieuDV] ASC,
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDV] [varchar](10) NOT NULL,
	[TenDV] [nvarchar](100) NULL,
	[DonGia] [int] NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[MaLoai] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiDichVu]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiDichVu](
	[MaLoai] [varchar](10) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ManHinh]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ManHinh](
	[MaManHinh] [varchar](20) NOT NULL,
	[TenManHinh] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNhanVien] [varchar](10) NOT NULL,
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](50) NULL,
	[TrangThai] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NguoiDungNhomNguoiDung]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDungNhomNguoiDung](
	[TenDangNhap] [varchar](50) NOT NULL,
	[MaNhom] [varchar](20) NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC,
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Phai] [nvarchar](4) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](12) NULL,
	[NgayVaoLam] [date] NULL,
	[LuongCoBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhomNguoiDung]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhomNguoiDung](
	[MaNhom] [varchar](20) NOT NULL,
	[TenNhom] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaNhom] [varchar](20) NOT NULL,
	[MaManHinh] [varchar](20) NOT NULL,
	[CoQuyen] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC,
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuDichVu]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuDichVu](
	[SoPhieuDV] [varchar](10) NOT NULL,
	[MaBenhNhan] [varchar](10) NOT NULL,
	[MaPhong] [varchar](10) NOT NULL,
	[SoPhieu] [varchar](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[TinhTrang] [nvarchar](20) NULL,
	[TongTien] [int] NULL,
	[ThanhToan] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[SoPhieuDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuKetQua]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuKetQua](
	[SoPhieuKQ] [varchar](10) NOT NULL,
	[TenDV] [nvarchar](100) NULL,
	[SoPhieuDV] [varchar](10) NOT NULL,
	[HinhAnh] [text] NULL,
	[KetLuan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SoPhieuKQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuKhamBenh]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuKhamBenh](
	[SoPhieu] [varchar](10) NOT NULL,
	[ChuanDoan] [nvarchar](225) NULL,
	[KetLuan] [nvarchar](225) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SoPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongKham]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongKham](
	[MaPhong] [varchar](10) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TiepDonBenhNhan]    Script Date: 19/10/2023 00:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiepDonBenhNhan](
	[SoPhieu] [varchar](10) NOT NULL,
	[NgayKham] [date] NOT NULL,
	[LoaiKham] [nvarchar](50) NULL,
	[LyDoKham] [nvarchar](50) NULL,
	[TieuDuong] [nvarchar](20) NULL,
	[BenhTimMach] [nvarchar](20) NULL,
	[HuyetAp] [nvarchar](20) NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[MaBenhNhan] [varchar](10) NOT NULL,
	[MaPhong] [varchar](10) NOT NULL,
	[NhanVienTiepDon] [varchar](10) NOT NULL,
	[BacSi] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[SoPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN001', N'', N'Viên Vịnh Nghi', N'Nữ', CAST(N'1991-03-02' AS Date), N'61/11, Đường Liên Khu 5 - 6, Phường Bình Hưng Hoà B, Quận Bình Tân', N'0365882156', N'nghitv@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN002', N'', N'Ngô Mạnh Đạt', N'Nam', CAST(N'1988-06-11' AS Date), N'12 Đường số 66, Phường 10, Quận 6', N'0326510015', N'datmocsung@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN003', N'', N'Khưu Thục Trinh', N'Nữ', CAST(N'1990-03-10' AS Date), N'75, Long Thuận, Phường Trường Thạnh, Quận 9', N'0935125572', N'trinh123@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN004', N'', N'Trương Mẫn', N'Nữ', CAST(N'1993-05-23' AS Date), N'112 Đường Nguyễn Đình Chiểu, Phường 4, Quận Phú Nhuận', N'0123452568', N'manman@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN005', N'', N'Trương Quốc Vinh', N'Nam', CAST(N'1991-04-28' AS Date), N'79, Đường Giải Phóng, Phường 4, Quận Tân Bình', N'0932561004', N'quocvinh@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN006', N'', N'Lưu Đức Hoa', N'Nam', CAST(N'1989-12-06' AS Date), N'281/2, Phường 13, Quận Bình Thạnh', N'0123005699', N'luuhoa11@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN007', N'', N'Lý Liên Kiệt', N'Nam', CAST(N'1994-12-17' AS Date), N'79, Đường Trung Chánh, Phường Trung Mỹ Tây, Quận 12', N'0935122452', N'lykiet102@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN008', N'', N'Phạm Băng Băng', N'Nữ', CAST(N'1995-01-10' AS Date), N'111 Đường Nguyễn Văn Đậu, Phường 11, Quận Bình Thạnh', N'0389802451', N'bangcute@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN009', N'', N'Triệu Hựu Đình', N'Nam', CAST(N'1992-08-03' AS Date), N'76 Đường Phan Xích Long, Phường 7, Quận Phú Nhuận', N'0914563652', N'dinh3sinh@gmail.com')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [MaThe], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email]) VALUES (N'BN010', N'', N'Triệu Lệ Dĩnh', N'Nữ', CAST(N'1993-12-26' AS Date), N'Đường 16, Phường Tân Phú, Quận 7', N'0989651246', N'bedinhdethuong@gmail.com')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV001', N'Chụp xquang quanh chóp Digital Xray', 40000, N'1 Răng', N'L001')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV002', N'Chụp x quang răng toàn cảnh Panorama', 40000, N'1 Lần', N'L001')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV003', N'Chụp X-ray Occlusal', 45000, N'1 Lần', N'L001')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV004', N'Răng Inox.', 500000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV005', N'Răng sứ kim loại', 1000000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV006', N'Răng sứ hợp kim Titan', 2500000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV007', N'Răng sứ Crom Cobalt 3.5', 3500000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV008', N'Răng sứ toàn sứ Zirconia', 5000000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV009', N'Răng sứ Cercon', 5500000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV010', N'Răng sứ Lava Plus', 7000000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV011', N'Venneer sứ', 6000000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV012', N'Nail Venneer sứ siêu mỏng', 12000000, N'1 Răng', N'L002')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV013', N'Scan Digital', 500000, N'1 Lần', N'L001')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV014', N'Implant Dio – Hàn Quốc', 9500000, N'1 Trụ', N'L003')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV015', N'Implant California – Mỹ', 11700000, N'1 Trụ', N'L003')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV016', N'Implant C1 – Đức', 15200000, N'1 Trụ', N'L003')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV017', N'Implant Straumann – Thụy Sĩ', 21000000, N'1 Trụ', N'L003')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV018', N'Niềng răng trong suốt Invisalign', 90000, N'2 Hàm', N'L004')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV019', N'Mắc cài Sino Trung Quốc', 18000000, N'2 Hàm', N'L004')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV020', N'Mắc cài thép buộc chun', 27000000, N'2 Hàm', N'L004')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV021', N'Mắc cài tự khóa thông minh', 32000000, N'2 Hàm', N'L004')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV022', N'Mắc cài Pitts', 35000000, N'2 Hàm', N'L004')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV023', N'Mắc cài sứ thẩm mỹ', 42000000, N'2 Hàm', N'L004')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV024', N'Mắc cài sứ thẩm mỹ thông minh', 50000000, N'2 Hàm', N'L004')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV025', N'Tẩy trắng răng tại nhà 2 ống thuốc (Máng tẩy trắng răng)', 700000, N'1 Lần', N'L005')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV026', N'Tẩy trắng răng tại phòng khám', 1000000, N'1 Lần', N'L005')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV027', N'Tẩy trắng răng kết hợp tại nhà 2 ống thuốc & tại phòng khám', 1500000, N'1 Lần', N'L005')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV028', N'Răng khôn mọc dễ', 500000, N'1 Răng', N'L006')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV029', N'Răng khôn mọc khó loại 1', 1000000, N'1 Răng', N'L006')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV030', N'Răng khôn mọc khó loại 2', 2000000, N'1 Răng', N'L006')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV031', N'Răng khôn mọc khó loại 3', 3500000, N'1 Răng', N'L006')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV032', N'Trám răng sữa', 70000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV033', N'Trám răng mòn cổ', 250000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV034', N'Trám răng sâu (không lấy tủy) composite', 300000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV035', N'Trám răng sâu (không lấy tủy) GIC', 150000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV036', N'Trám kẽ răng', 300000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV037', N'Đắp mặt răng', 400000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV038', N'Chữa tủy răng cửa', 500000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV039', N'Chữa tủy răng tiền cối', 700000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV040', N'Chữa tủy răng cối lớn', 1000000, N'1 Răng', N'L007')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV041', N'Điều trị nha chu mức 1', 1000000, N'1 Lần', N'L008')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV042', N'Điều trị nha chu mức 2', 2500000, N'1 Lần', N'L008')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV043', N'Điều trị nha chu mức 3', 5000000, N'1 Lần', N'L008')
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [DonViTinh], [MaLoai]) VALUES (N'DV044', N'Điều trị nha chu mức 4', 10000000, N'1 Lần', N'L008')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L001', N'Chụp X-Quang')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L002', N'Bọc Răng Sứ')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L003', N'Cấy Ghép Implant')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L004', N'Niềng Răng Thẩm Mỹ')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L005', N'Tẩy Trắng Răng')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L006', N'Nhổ Răng Khôn')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L007', N'Xử Lý Răng Sâu')
INSERT [dbo].[LoaiDichVu] ([MaLoai], [TenLoai]) VALUES (N'L008', N'Điều Trị Nha Chu')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'ribbBacSi', N'Màn hình nghiệp vụ bác sĩ')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'ribbCaNhan', N'Màn hình cá nhân')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'ribbLeTan', N'Màn hình lễ tân')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'ribbQuanLy', N'Màn hình quản lý')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'ribbThongKe', N'Màn hình thống kê')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'ribbThuNgan', N'Màn hình nghiệp vụ thu ngân')
INSERT [dbo].[NguoiDung] ([MaNhanVien], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (N'NV003', N'don123', N'32441859', N'Hoạt động')
INSERT [dbo].[NguoiDung] ([MaNhanVien], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (N'NV002', N'duong', N'32441859', N'Hoạt động')
INSERT [dbo].[NguoiDung] ([MaNhanVien], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (N'NV005', N'giahan', N'32441859', N'Hoạt động')
INSERT [dbo].[NguoiDung] ([MaNhanVien], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (N'NV001', N'ngo10', N'32441859', N'Hoạt động')
INSERT [dbo].[NguoiDung] ([MaNhanVien], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (N'NV006', N'nhu01', N'32441859', N'Hoạt động')
INSERT [dbo].[NguoiDung] ([MaNhanVien], [TenDangNhap], [MatKhau], [TrangThai]) VALUES (N'NV004', N'phat1', N'32441859', N'Hoạt động')
INSERT [dbo].[NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhom], [GhiChu]) VALUES (N'don123', N'BS', N'chung tử đơn')
INSERT [dbo].[NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhom], [GhiChu]) VALUES (N'duong', N'LeTan', N'hehe')
INSERT [dbo].[NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhom], [GhiChu]) VALUES (N'giahan', N'BS', N'hân hân')
INSERT [dbo].[NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhom], [GhiChu]) VALUES (N'ngo10', N'admin', N'không có ghi chú')
INSERT [dbo].[NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhom], [GhiChu]) VALUES (N'nhu01', N'BS', N'như nè')
INSERT [dbo].[NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhom], [GhiChu]) VALUES (N'phat1', N'BS', N'anh phát')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV001', N'Ngô Văn Mười', N'Nam', CAST(N'1999-09-08' AS Date), N'123 Nguyễn Hữu Tiến, Tây Thạnh, Tân Phú, Tp.Hcm', N'0392419643', CAST(N'2010-05-30' AS Date), 200000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV002', N'Nguyễn Thị Thùy Dương', N'Nữ', CAST(N'2001-05-23' AS Date), N'11/50 Nguyễn Hữu Tiến, Tây Thạnh, Tân Phú, Tp.Hcm', N'0351248625', CAST(N'2020-06-02' AS Date), 110000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV003', N'Chung Tử Đơn', N'Nam', CAST(N'1990-03-21' AS Date), N'11 Bàu Bàng, Phường 13, Tân Bình, Tp.HCM', N'0935224412', CAST(N'2015-05-12' AS Date), 200000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV004', N'Châu Nhuận Phát ', N'Nam', CAST(N'1991-12-15' AS Date), N'64 Đường số 17, Linh Trung, Thủ Đức', N'0392419643', CAST(N'2010-05-30' AS Date), 200000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV005', N'Lý Gia Hân', N'Nữ', CAST(N'1995-10-01' AS Date), N'4 đường D11, P.Tây Thạnh ,Q.Tân Phú, Tp.Hcm', N'0924032217', CAST(N'2018-12-21' AS Date), 150000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV006', N'Huỳnh Thúy Như', N'Nữ', CAST(N'1993-02-16' AS Date), N'37 Trần Quý Cáp, Phường 11, Q.Bình Thạnh, Tp.Hcm', N'0935124588', CAST(N'2019-11-04' AS Date), 120000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV007', N'Trần Mỹ Loan', N'Nữ', CAST(N'1996-07-29' AS Date), N'30 Kha Vạn Cân, Hiệp Bình Chánh, Thủ Đức', N'0322548963', CAST(N'2019-11-04' AS Date), 120000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV008', N'Bùi Hoàng Khánh Ngọc', N'Nữ', CAST(N'1999-05-30' AS Date), N' 60 Giang Văn Minh, An Phú, Q.2, Tp.Hcm', N'0935010234', CAST(N'2019-11-04' AS Date), 120000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV009', N'Trương Trung Hiếu', N'Nam', CAST(N'1990-02-28' AS Date), N'224 Hoàng Hoa Thám, Phường 13, Q.Tân Bình, Tp.Hcm', N'0396542214', CAST(N'2019-11-04' AS Date), 120000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV010', N'Bùi Hồng Ngọc', N'Nữ', CAST(N'1997-01-14' AS Date), N'130 Hoàng Văn Thụ, Phường 9, Q.Phú Nhuận, Tp.Hcm', N'0987362214', CAST(N'2019-11-04' AS Date), 120000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV011', N'Võ Trường Giang', N'Nam', CAST(N'1996-03-23' AS Date), N'25 Cao Thắng, Phường 11, Q.3, Tp.Hcm', N'0365210025', CAST(N'2019-11-04' AS Date), 120000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [Phai], [NgaySinh], [DiaChi], [SDT], [NgayVaoLam], [LuongCoBan]) VALUES (N'NV012', N'Trương Thế Vinh', N'Nam', CAST(N'1995-11-20' AS Date), N'135 Điện Biên Phủ, P.Đa Kao, Q.1, Tp.Hcm', N'0123547824', CAST(N'2019-11-04' AS Date), 120000)
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'admin', N'Quản lý', N'admin nnè')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'BS', N'Bác sĩ', N'Bác sĩ nè')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'LeTan', N'Lễ Tân', N'hihi')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'ThuNgan', N'Thu Ngân', N'dành cho thu ngân')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'admin', N'ribbBacSi', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'admin', N'ribbCaNhan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'admin', N'ribbLeTan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'admin', N'ribbQuanLy', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'admin', N'ribbThongKe', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'admin', N'ribbThuNgan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'BS', N'ribbBacSi', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'BS', N'ribbCaNhan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'BS', N'ribbLeTan', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'BS', N'ribbQuanLy', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'BS', N'ribbThongKe', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'BS', N'ribbThuNgan', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'LeTan', N'ribbBacSi', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'LeTan', N'ribbCaNhan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'LeTan', N'ribbLeTan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'LeTan', N'ribbQuanLy', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'LeTan', N'ribbThongKe', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'LeTan', N'ribbThuNgan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'ThuNgan', N'ribbBacSi', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'ThuNgan', N'ribbCaNhan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'ThuNgan', N'ribbLeTan', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'ThuNgan', N'ribbQuanLy', 0)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'ThuNgan', N'ribbThongKe', 1)
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaManHinh], [CoQuyen]) VALUES (N'ThuNgan', N'ribbThuNgan', 1)
INSERT [dbo].[PhongKham] ([MaPhong], [TenPhong]) VALUES (N'PDV003', N'Phòng Dịch Vụ 1')
INSERT [dbo].[PhongKham] ([MaPhong], [TenPhong]) VALUES (N'PDV004', N'Phòng Dịch Vụ 2')
INSERT [dbo].[PhongKham] ([MaPhong], [TenPhong]) VALUES (N'PK001', N'Phòng Khám 1')
INSERT [dbo].[PhongKham] ([MaPhong], [TenPhong]) VALUES (N'PK002', N'Phòng Khám 2')
INSERT [dbo].[TiepDonBenhNhan] ([SoPhieu], [NgayKham], [LoaiKham], [LyDoKham], [TieuDuong], [BenhTimMach], [HuyetAp], [TinhTrang], [MaBenhNhan], [MaPhong], [NhanVienTiepDon], [BacSi]) VALUES (N'PH01-001', CAST(N'2021-06-16' AS Date), N'Khám miễn phí', N'Khám miệng-đau nhức răng hàm', N'Không', N'Không', N'Trung bình', N'Đã khám', N'BN003', N'PK001', N'NV001', N'NV006')
INSERT [dbo].[TiepDonBenhNhan] ([SoPhieu], [NgayKham], [LoaiKham], [LyDoKham], [TieuDuong], [BenhTimMach], [HuyetAp], [TinhTrang], [MaBenhNhan], [MaPhong], [NhanVienTiepDon], [BacSi]) VALUES (N'PH01-002', CAST(N'2021-06-17' AS Date), N'Khám miễn phí', N'Khám miệng-chảy máu chân răng', N'Không', N'Không', N'Trung bình', N'Chờ khám', N'BN001', N'PK001', N'NV001', N'NV005')
INSERT [dbo].[TiepDonBenhNhan] ([SoPhieu], [NgayKham], [LoaiKham], [LyDoKham], [TieuDuong], [BenhTimMach], [HuyetAp], [TinhTrang], [MaBenhNhan], [MaPhong], [NhanVienTiepDon], [BacSi]) VALUES (N'PH01-003', CAST(N'2021-07-01' AS Date), N'Khám miễn phí', N'Khám miệng-đau nhức răng hàm', N'Không', N'Không', N'Trung bình', N'Chờ khám', N'BN002', N'PK001', N'NV001', N'NV006')
ALTER TABLE [dbo].[CTPhieuDichVu]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuDV_DV] FOREIGN KEY([MaDV])
REFERENCES [dbo].[DichVu] ([MaDV])
GO
ALTER TABLE [dbo].[CTPhieuDichVu] CHECK CONSTRAINT [FK_CTPhieuDV_DV]
GO
ALTER TABLE [dbo].[CTPhieuDichVu]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuDV_PDV] FOREIGN KEY([SoPhieuDV])
REFERENCES [dbo].[PhieuDichVu] ([SoPhieuDV])
GO
ALTER TABLE [dbo].[CTPhieuDichVu] CHECK CONSTRAINT [FK_CTPhieuDV_PDV]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [FK_DichVu_LoaiDichVu] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiDichVu] ([MaLoai])
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [FK_DichVu_LoaiDichVu]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_NhanVien]
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_Nhom] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[NguoiDung] ([TenDangNhap])
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_NguoiDung_Nhom]
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NhomNguoiDung_Nhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[NguoiDungNhomNguoiDung] CHECK CONSTRAINT [FK_NhomNguoiDung_Nhom]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_ManHinh] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[ManHinh] ([MaManHinh])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_ManHinh]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_NhomNguoiDung] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_NhomNguoiDung]
GO
ALTER TABLE [dbo].[PhieuDichVu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDV_BenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[PhieuDichVu] CHECK CONSTRAINT [FK_PhieuDV_BenhNhan]
GO
ALTER TABLE [dbo].[PhieuDichVu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDV_PhieuKham] FOREIGN KEY([SoPhieu])
REFERENCES [dbo].[PhieuKhamBenh] ([SoPhieu])
GO
ALTER TABLE [dbo].[PhieuDichVu] CHECK CONSTRAINT [FK_PhieuDV_PhieuKham]
GO
ALTER TABLE [dbo].[PhieuDichVu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDV_Phong] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongKham] ([MaPhong])
GO
ALTER TABLE [dbo].[PhieuDichVu] CHECK CONSTRAINT [FK_PhieuDV_Phong]
GO
ALTER TABLE [dbo].[PhieuKetQua]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKQ_PDV] FOREIGN KEY([SoPhieuDV])
REFERENCES [dbo].[PhieuDichVu] ([SoPhieuDV])
GO
ALTER TABLE [dbo].[PhieuKetQua] CHECK CONSTRAINT [FK_PhieuKQ_PDV]
GO
ALTER TABLE [dbo].[PhieuKhamBenh]  WITH CHECK ADD  CONSTRAINT [FK_PhieuKhamBenh_TiepDonBenhNhan] FOREIGN KEY([SoPhieu])
REFERENCES [dbo].[TiepDonBenhNhan] ([SoPhieu])
GO
ALTER TABLE [dbo].[PhieuKhamBenh] CHECK CONSTRAINT [FK_PhieuKhamBenh_TiepDonBenhNhan]
GO
ALTER TABLE [dbo].[TiepDonBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_TiepDonBenhNhan_BacSi] FOREIGN KEY([BacSi])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TiepDonBenhNhan] CHECK CONSTRAINT [FK_TiepDonBenhNhan_BacSi]
GO
ALTER TABLE [dbo].[TiepDonBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_TiepDonBenhNhan_BenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[TiepDonBenhNhan] CHECK CONSTRAINT [FK_TiepDonBenhNhan_BenhNhan]
GO
ALTER TABLE [dbo].[TiepDonBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_TiepDonBenhNhan_NhanVien] FOREIGN KEY([NhanVienTiepDon])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TiepDonBenhNhan] CHECK CONSTRAINT [FK_TiepDonBenhNhan_NhanVien]
GO
ALTER TABLE [dbo].[TiepDonBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_TiepDonBenhNhan_PhongKham] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongKham] ([MaPhong])
GO
ALTER TABLE [dbo].[TiepDonBenhNhan] CHECK CONSTRAINT [FK_TiepDonBenhNhan_PhongKham]
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhaKhoa] SET  READ_WRITE 
GO
