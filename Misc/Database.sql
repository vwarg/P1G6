USE [master]
GO
/****** Object:  Database [EHandel]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[Adress]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[OrderToProduct]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[PriceModification]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[PriceModToProduct]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 2017-03-23 13:31:50 ******/
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
	[parentProduct] [int] NOT NULL,
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
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 2017-03-23 13:31:50 ******/
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
/****** Object:  StoredProcedure [dbo].[GenerateCSharp]    Script Date: 2017-03-23 13:31:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerateCSharp] 
	-- Add the parameters for the stored procedure here
	@TableName varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Result varchar(max) = 'public class ' + @TableName + '
{'

select @Result = @Result + '
    public ' + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; }
'
from
(
    select 
        replace(col.name, ' ', '_') ColumnName,
        column_id ColumnId,
        case typ.name 
            when 'bigint' then 'long'
            when 'binary' then 'byte[]'
            when 'bit' then 'bool'
            when 'char' then 'string'
            when 'date' then 'DateTime'
            when 'datetime' then 'DateTime'
            when 'datetime2' then 'DateTime'
            when 'datetimeoffset' then 'DateTimeOffset'
            when 'decimal' then 'decimal'
            when 'float' then 'float'
            when 'image' then 'byte[]'
            when 'int' then 'int'
            when 'money' then 'decimal'
            when 'nchar' then 'string'
            when 'ntext' then 'string'
            when 'numeric' then 'decimal'
            when 'nvarchar' then 'string'
            when 'real' then 'double'
            when 'smalldatetime' then 'DateTime'
            when 'smallint' then 'short'
            when 'smallmoney' then 'decimal'
            when 'text' then 'string'
            when 'time' then 'TimeSpan'
            when 'timestamp' then 'DateTime'
            when 'tinyint' then 'byte'
            when 'uniqueidentifier' then 'Guid'
            when 'varbinary' then 'byte[]'
            when 'varchar' then 'string'
            else 'UNKNOWN_' + typ.name
        end ColumnType,
        case 
            when col.is_nullable = 1 and typ.name in ('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier') 
            then '?' 
            else '' 
        end NullableSign
    from sys.columns col
        join sys.types typ on
            col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id
    where object_id = object_id(@TableName)
) t
order by ColumnId

set @Result = @Result  + '
}'

print @Result
END

GO
/****** Object:  DdlTrigger [GenCS]    Script Date: 2017-03-23 13:31:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [GenCS] ON DATABASE 
	FOR ALTER_TABLE
AS 
	DECLARE @eventData XML,
	@tName VARCHAR(max);
	SET @eventData = eventdata();
	SET @tName = @eventData.value('data(/EVENT_INSTANCE/ObjectName)[1]', 'SYSNAME');
	EXEC [dbo].[GenerateCSharp] @TableName=@tName;

GO
ENABLE TRIGGER [GenCS] ON DATABASE
GO
USE [master]
GO
ALTER DATABASE [EHandel] SET  READ_WRITE 
GO
