USE [master]
GO
/****** Object:  Database [Client Diagram]    Script Date: 23.8.2014 г. 17:00:03 ******/
CREATE DATABASE [Client Diagram]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Client Diagram', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Client Diagram.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Client Diagram_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Client Diagram_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Client Diagram] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Client Diagram].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Client Diagram] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Client Diagram] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Client Diagram] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Client Diagram] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Client Diagram] SET ARITHABORT OFF 
GO
ALTER DATABASE [Client Diagram] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Client Diagram] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Client Diagram] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Client Diagram] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Client Diagram] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Client Diagram] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Client Diagram] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Client Diagram] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Client Diagram] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Client Diagram] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Client Diagram] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Client Diagram] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Client Diagram] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Client Diagram] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Client Diagram] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Client Diagram] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Client Diagram] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Client Diagram] SET RECOVERY FULL 
GO
ALTER DATABASE [Client Diagram] SET  MULTI_USER 
GO
ALTER DATABASE [Client Diagram] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Client Diagram] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Client Diagram] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Client Diagram] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Client Diagram] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Client Diagram', N'ON'
GO
USE [Client Diagram]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 23.8.2014 г. 17:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 23.8.2014 г. 17:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 23.8.2014 г. 17:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 23.8.2014 г. 17:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 23.8.2014 г. 17:00:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (1, N'str. Gen. Gurko 1', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (2, N'str. Sredna Gora ', 3)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (3, N'str. Chernomorska', 4)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (3, N'Africa')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (4, N'North America')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (2, N'Germany', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (3, N'USA', 4)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (1, N'Pesho', N'Peshev', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (2, N'Gancho', N'Ganchev', 1)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (3, N'Stamat', N'Stamatov', 2)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [ContryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [ContryId]) VALUES (2, N'Plovdiv', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [ContryId]) VALUES (3, N'Varna', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [ContryId]) VALUES (4, N'Burgas', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [ContryId]) VALUES (5, N'Munich', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [ContryId]) VALUES (6, N'New York', 3)
INSERT [dbo].[Towns] ([TownId], [Name], [ContryId]) VALUES (7, N'Los Angles', 3)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([ContryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [Client Diagram] SET  READ_WRITE 
GO
