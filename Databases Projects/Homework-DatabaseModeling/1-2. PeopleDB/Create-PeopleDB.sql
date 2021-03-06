USE [master]
GO
/****** Object:  Database [PeopleDB]    Script Date: 10-Jul-13 14:54:39 ******/
CREATE DATABASE [PeopleDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PeopleDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PeopleDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PeopleDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PeopleDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PeopleDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PeopleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PeopleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PeopleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PeopleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PeopleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PeopleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PeopleDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PeopleDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PeopleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PeopleDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PeopleDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PeopleDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PeopleDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PeopleDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PeopleDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PeopleDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PeopleDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PeopleDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PeopleDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PeopleDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PeopleDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PeopleDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PeopleDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PeopleDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PeopleDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PeopleDB] SET  MULTI_USER 
GO
ALTER DATABASE [PeopleDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PeopleDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PeopleDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PeopleDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PeopleDB', N'ON'
GO
USE [PeopleDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 10-Jul-13 14:54:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 10-Jul-13 14:54:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10-Jul-13 14:54:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 10-Jul-13 14:54:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 10-Jul-13 14:54:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (1, N'жк. "Младост" 42', 1)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (2, N'бул. "Г. М. Димитров" 22', 1)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (3, N'бул. "Христо Ботев" 15', 2)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (4, N'SW19 5AE', 3)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (5, N'SW1A 2PW', 3)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (6, N'Sir Matt Busby Way 22', 4)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (7, N'Great Ancoats Street 15', 4)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (8, N'"Первой улице" 23', 5)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (9, N'First street 11', 10)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (10, N'Fourth street 3', 10)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (11, N'108 Chestnut Street', 8)
INSERT [dbo].[Addresses] ([Id], [Address], [TownId]) VALUES (12, N'102 Yorkville', 8)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (3, N'North America')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (4, N'Africa')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (2, N'England', 1)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (3, N'Russia', 2)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (4, N'China', 2)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (5, N'Canada', 3)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (6, N'USA', 3)
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (7, N'Egypt', 4)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (1, N'Иван', N'Пешов', 1)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (3, N'Пешо', N'Иванов', 2)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (4, N'Гошо', N'Гошов', 3)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (5, N'Bill', N'Morgan', 4)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (6, N'John', N'Silver', 5)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (7, N'Phil', N'Silver', 5)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (8, N'Ben', N'Button', 6)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (9, N'James', N'John', 7)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (11, N'Анастасия', N'Атанасова', 8)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (12, N'Sandra', N'Bell', 9)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (13, N'Joshua', N'James', 10)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (14, N'Robin', N'Gold', 11)
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [AddressId]) VALUES (15, N'Sarah', N'Milles', 12)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (2, N'Varna', 1)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (3, N'London', 2)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (4, N'Manchester', 2)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (5, N'Moscow', 3)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (6, N'Beijing', 4)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (7, N'Ottawa', 5)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (8, N'Toronto', 5)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (9, N'Cairo', 7)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (10, N'New York', 6)
INSERT [dbo].[Towns] ([Id], [Name], [CountryId]) VALUES (11, N'Washington', 6)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [PeopleDB] SET  READ_WRITE 
GO
