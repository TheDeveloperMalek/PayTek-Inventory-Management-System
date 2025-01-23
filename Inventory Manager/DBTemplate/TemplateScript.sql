USE [Public]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryReport]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryReport](
	[Product ID] [int] NOT NULL,
	[Product Barcode] [nvarchar](50) NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Barcode] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[Specification] [nvarchar](50) NULL,
	[Date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReport]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReport](
	[Product ID] [int] NOT NULL,
	[Product Barcode] [int] NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](70) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier ID] [int] NULL,
	[Supplier Name] [nvarchar](50) NULL,
	[Product ID] [int] NOT NULL,
	[Product Barcode] [int] NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NULL,
	[Date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Usertype] [nvarchar](50) NOT NULL,
	[Last modified] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer ID] [int] NOT NULL,
	[Customer Name] [nvarchar](50) NOT NULL,
	[Product ID] [int] NOT NULL,
	[Product Barcode] [int] NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
	[Date] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 23/01/2025 11:12:16 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Roles] ([Username], [Password], [Usertype], [Last modified]) VALUES (N'malek', N'100 113 103 104 117 118', N'developer', CAST(N'2025-01-23' AS Date))
GO
INSERT [dbo].[Roles] ([Username], [Password], [Usertype], [Last modified]) VALUES (N'admin', N'100 103 112 108 113', N'admin', CAST(N'2025-07-01' AS Date))
GO
INSERT [dbo].[Roles] ([Username], [Password], [Usertype], [Last modified]) VALUES (N'user', N'120 118 104 117', N'user', CAST(N'2025-07-01' AS Date))
GO
