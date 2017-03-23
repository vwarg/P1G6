USE [master]
GO
/****** Object:  Database [EHandel]    Script Date: 2017-03-23 11:39:24 ******/
CREATE DATABASE [EHandel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EHandel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EHandel.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EHandel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EHandel_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EHandel] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EHandel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EHandel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EHandel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EHandel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EHandel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EHandel] SET ARITHABORT OFF 
GO
ALTER DATABASE [EHandel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EHandel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EHandel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EHandel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EHandel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EHandel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EHandel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EHandel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EHandel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EHandel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EHandel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EHandel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EHandel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EHandel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EHandel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EHandel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EHandel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EHandel] SET RECOVERY FULL 
GO
ALTER DATABASE [EHandel] SET  MULTI_USER 
GO
ALTER DATABASE [EHandel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EHandel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EHandel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EHandel] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EHandel] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EHandel', N'ON'
GO
USE [EHandel]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adress](
	[ID] [int] NOT NULL,
	[country] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[street] [varchar](50) NOT NULL,
	[zip] [varchar](50) NOT NULL,
	[phone] [varchar](30) NULL,
	[department] [varchar](50) NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](200) NULL,
	[parentCategory] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[url] [text] NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1512,1) NOT NULL,
	[userID] [int] NOT NULL,
	[billingadressID] [int] NOT NULL,
	[deliveryadressID] [int] NOT NULL,
	[total_price] [float] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[dateProcessed] [datetime] NOT NULL,
	[dateFulfilled] [datetime] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderToProduct]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderToProduct](
	[ID] [int] NOT NULL,
	[productID] [int] NOT NULL,
	[orderID] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_OrderToProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceModification]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceModification](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[categoryID] [int] NULL,
	[modifierPercent] [float] NULL,
	[modifierAbsolute] [float] NULL,
	[dateStarts] [datetime] NULL,
	[dateEnds] [datetime] NULL,
 CONSTRAINT [PK_PriceModification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceModToProduct]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceModToProduct](
	[ID] [int] NOT NULL,
	[productID] [int] NOT NULL,
	[modifierID] [int] NOT NULL,
 CONSTRAINT [PK_PriceModToProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1337,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[short_description] [varchar](200) NOT NULL,
	[description] [text] NULL,
	[price] [float] NOT NULL,
	[countPerUnit] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[comment] [text] NULL,
	[image] [text] NULL,
	[video] [text] NULL,
	[status] [int] NOT NULL,
	[manufacturerID] [int] NOT NULL,
	[manufacturer_productnumber] [varchar](20) NOT NULL,
	[categoryID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[phone] [varchar](30) NULL,
	[companyname] [varchar](200) NULL,
	[deliveryadressID] [int] NOT NULL,
	[billingadressID] [int] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2017-03-23 11:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](200) NOT NULL,
	[password] [varchar](200) NOT NULL,
	[contactinfo] [int] NOT NULL,
	[isCompany] [tinyint] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_total_price]  DEFAULT ((0)) FOR [total_price]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_quantity]  DEFAULT ((1)) FOR [quantity]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_isCompany]  DEFAULT ((0)) FOR [isCompany]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Adress] FOREIGN KEY([billingadressID])
REFERENCES [dbo].[Adress] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Adress]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Adress1] FOREIGN KEY([deliveryadressID])
REFERENCES [dbo].[Adress] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Adress1]
GO
ALTER TABLE [dbo].[OrderToProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderToProduct_Orders] FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrderToProduct] CHECK CONSTRAINT [FK_OrderToProduct_Orders]
GO
ALTER TABLE [dbo].[OrderToProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderToProduct_Products] FOREIGN KEY([productID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[OrderToProduct] CHECK CONSTRAINT [FK_OrderToProduct_Products]
GO
ALTER TABLE [dbo].[PriceModToProduct]  WITH CHECK ADD  CONSTRAINT [FK_PriceModToProduct_PriceModification] FOREIGN KEY([modifierID])
REFERENCES [dbo].[PriceModification] ([ID])
GO
ALTER TABLE [dbo].[PriceModToProduct] CHECK CONSTRAINT [FK_PriceModToProduct_PriceModification]
GO
ALTER TABLE [dbo].[PriceModToProduct]  WITH CHECK ADD  CONSTRAINT [FK_PriceModToProduct_Products] FOREIGN KEY([productID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[PriceModToProduct] CHECK CONSTRAINT [FK_PriceModToProduct_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Manufacturer] FOREIGN KEY([manufacturerID])
REFERENCES [dbo].[Manufacturer] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Manufacturer]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_Adress] FOREIGN KEY([deliveryadressID])
REFERENCES [dbo].[Adress] ([ID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_Adress]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_Adress1] FOREIGN KEY([billingadressID])
REFERENCES [dbo].[Adress] ([ID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_Adress1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserInfo] FOREIGN KEY([contactinfo])
REFERENCES [dbo].[UserInfo] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserInfo]
GO
USE [master]
GO
ALTER DATABASE [EHandel] SET  READ_WRITE 
GO
