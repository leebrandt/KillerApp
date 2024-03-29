USE [master]
GO
/****** Object:  Database [KillerApp]    Script Date: 08/18/2011 00:11:48 ******/
CREATE DATABASE [KillerApp] ON  PRIMARY 
( NAME = N'KillerApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\KillerApp.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KillerApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\KillerApp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KillerApp] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KillerApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KillerApp] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [KillerApp] SET ANSI_NULLS OFF
GO
ALTER DATABASE [KillerApp] SET ANSI_PADDING OFF
GO
ALTER DATABASE [KillerApp] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [KillerApp] SET ARITHABORT OFF
GO
ALTER DATABASE [KillerApp] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [KillerApp] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [KillerApp] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [KillerApp] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [KillerApp] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [KillerApp] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [KillerApp] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [KillerApp] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [KillerApp] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [KillerApp] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [KillerApp] SET  DISABLE_BROKER
GO
ALTER DATABASE [KillerApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [KillerApp] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [KillerApp] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [KillerApp] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [KillerApp] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [KillerApp] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [KillerApp] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [KillerApp] SET  READ_WRITE
GO
ALTER DATABASE [KillerApp] SET RECOVERY FULL
GO
ALTER DATABASE [KillerApp] SET  MULTI_USER
GO
ALTER DATABASE [KillerApp] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [KillerApp] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'KillerApp', N'ON'
GO
USE [KillerApp]
GO
/****** Object:  Table [dbo].[Killers]    Script Date: 08/18/2011 00:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Killers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[RealName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Killers] ON
INSERT [dbo].[Killers] ([ID], [Name], [RealName]) VALUES (1, N'Joker', N'Unknown')
INSERT [dbo].[Killers] ([ID], [Name], [RealName]) VALUES (2, N'Mickey Knox', N'Mickey Knox')
INSERT [dbo].[Killers] ([ID], [Name], [RealName]) VALUES (3, N'The Crow', N'Eric Draven')
SET IDENTITY_INSERT [dbo].[Killers] OFF
/****** Object:  Table [dbo].[Weapons]    Script Date: 08/18/2011 00:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weapons](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Killer_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Victims]    Script Date: 08/18/2011 00:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Victims](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[DateOfDeath] [datetime] NULL,
	[Killer_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK63A28AC5AD8FFAA0]    Script Date: 08/18/2011 00:11:49 ******/
ALTER TABLE [dbo].[Weapons]  WITH CHECK ADD  CONSTRAINT [FK63A28AC5AD8FFAA0] FOREIGN KEY([Killer_id])
REFERENCES [dbo].[Killers] ([ID])
GO
ALTER TABLE [dbo].[Weapons] CHECK CONSTRAINT [FK63A28AC5AD8FFAA0]
GO
/****** Object:  ForeignKey [FK13047B93AD8FFAA0]    Script Date: 08/18/2011 00:11:49 ******/
ALTER TABLE [dbo].[Victims]  WITH CHECK ADD  CONSTRAINT [FK13047B93AD8FFAA0] FOREIGN KEY([Killer_id])
REFERENCES [dbo].[Killers] ([ID])
GO
ALTER TABLE [dbo].[Victims] CHECK CONSTRAINT [FK13047B93AD8FFAA0]
GO
