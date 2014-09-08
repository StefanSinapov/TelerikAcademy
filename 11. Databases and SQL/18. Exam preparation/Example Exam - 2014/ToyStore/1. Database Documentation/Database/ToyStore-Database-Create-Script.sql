USE [master]
GO
/****** Object:  Database [ToyStore]    Script Date: 7.9.2014 г. 14:19:24 ******/
CREATE DATABASE [ToyStore]

GO
ALTER DATABASE [ToyStore] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToyStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToyStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToyStore] SET RECOVERY FULL 
GO
ALTER DATABASE [ToyStore] SET  MULTI_USER 
GO
ALTER DATABASE [ToyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToyStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ToyStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ToyStore', N'ON'
GO
USE [ToyStore]
GO
/****** Object:  Table [dbo].[AgeRanges]    Script Date: 7.9.2014 г. 14:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeRanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinAge] [int] NOT NULL,
	[MaxAge] [int] NOT NULL,
 CONSTRAINT [PK_AgeRanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7.9.2014 г. 14:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 7.9.2014 г. 14:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Toys]    Script Date: 7.9.2014 г. 14:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[ManufacturerId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Color] [nvarchar](50) NULL,
	[AgeRangeId] [int] NOT NULL,
 CONSTRAINT [PK_Toys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ToysCategories]    Script Date: 7.9.2014 г. 14:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToysCategories](
	[ToyId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ToysCategories] PRIMARY KEY CLUSTERED 
(
	[ToyId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [UI_Manufacturers]    Script Date: 7.9.2014 г. 14:19:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UI_Manufacturers] ON [dbo].[Manufacturers]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_Toys_AgeRanges] FOREIGN KEY([AgeRangeId])
REFERENCES [dbo].[AgeRanges] ([Id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_Toys_AgeRanges]
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD  CONSTRAINT [FK_Toys_Manufacturers] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturers] ([Id])
GO
ALTER TABLE [dbo].[Toys] CHECK CONSTRAINT [FK_Toys_Manufacturers]
GO
ALTER TABLE [dbo].[ToysCategories]  WITH CHECK ADD  CONSTRAINT [FK_ToysCategories_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[ToysCategories] CHECK CONSTRAINT [FK_ToysCategories_Categories]
GO
ALTER TABLE [dbo].[ToysCategories]  WITH CHECK ADD  CONSTRAINT [FK_ToysCategories_Toys] FOREIGN KEY([ToyId])
REFERENCES [dbo].[Toys] ([Id])
GO
ALTER TABLE [dbo].[ToysCategories] CHECK CONSTRAINT [FK_ToysCategories_Toys]
GO
USE [master]
GO
ALTER DATABASE [ToyStore] SET  READ_WRITE 
GO
