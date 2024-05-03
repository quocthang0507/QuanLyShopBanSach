USE [master]
GO
/****** Object:  Database [QuanLySach]    Script Date: 5/1/2024 11:08:58 AM ******/
CREATE DATABASE [QuanLySach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLySach', FILENAME = N'C:\Users\quoct\QuanLySach.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLySach_log', FILENAME = N'C:\Users\quoct\QuanLySach_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLySach] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLySach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLySach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLySach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLySach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLySach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLySach] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLySach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLySach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLySach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLySach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLySach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLySach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLySach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLySach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLySach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLySach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLySach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLySach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLySach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLySach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLySach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLySach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLySach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLySach] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLySach] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLySach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLySach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLySach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLySach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLySach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLySach] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLySach] SET QUERY_STORE = OFF
GO
USE [QuanLySach]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 5/1/2024 11:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSach] [int] NOT NULL,
	[TenSach] [nvarchar](100) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaTien] [int] NOT NULL,
	[NgayMua] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoSach]    Script Date: 5/1/2024 11:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoSach](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiSach] [nvarchar](50) NOT NULL,
	[TenSach] [nvarchar](100) NOT NULL,
	[TacGia] [nvarchar](50) NOT NULL,
	[NhaXuatBan] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaTien] [int] NOT NULL,
 CONSTRAINT [PK_KhoSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KhoSach] ON 

INSERT [dbo].[KhoSach] ([Id], [LoaiSach], [TenSach], [TacGia], [NhaXuatBan], [SoLuong], [GiaTien]) VALUES (1, N'Văn học nước ngoài', N'Nhà Giả Kim', N'Paulo Coelho', N'Hà Nội', 100, 55100)
INSERT [dbo].[KhoSach] ([Id], [LoaiSach], [TenSach], [TacGia], [NhaXuatBan], [SoLuong], [GiaTien]) VALUES (2, N'Kỹ năng sống', N'Tâm Lý Học Hành Vi', N'Khương Nguy', N'Hà Nội', 100, 70400)
INSERT [dbo].[KhoSach] ([Id], [LoaiSach], [TenSach], [TacGia], [NhaXuatBan], [SoLuong], [GiaTien]) VALUES (3, N'Văn học', N'Thiên Tài Bên Trái, Kẻ Điên Bên Phải', N'Cao Minh', N'Thế giới', 100, 116000)
INSERT [dbo].[KhoSach] ([Id], [LoaiSach], [TenSach], [TacGia], [NhaXuatBan], [SoLuong], [GiaTien]) VALUES (4, N'Kỹ năng sống', N'38 Lá Thư Tỷ Phú John Davison Rockefeller Gửi Cho Con Trai', N'Bizbooks', N'Hồng Đức', 90, 110600)
SET IDENTITY_INSERT [dbo].[KhoSach] OFF
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK__DonHangToKhoSach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[KhoSach] ([Id])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK__DonHangToKhoSach]
GO
USE [master]
GO
ALTER DATABASE [QuanLySach] SET  READ_WRITE 
GO
