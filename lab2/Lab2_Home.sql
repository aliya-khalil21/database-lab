USE [master]
GO
/****** Object:  Database [Lab2_Home]    Script Date: 1/28/2024 8:16:00 PM ******/
CREATE DATABASE [Lab2_Home]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lab2_Home', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Lab2_Home.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Lab2_Home_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Lab2_Home_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Lab2_Home] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lab2_Home].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lab2_Home] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lab2_Home] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lab2_Home] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lab2_Home] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lab2_Home] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lab2_Home] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lab2_Home] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lab2_Home] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lab2_Home] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lab2_Home] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lab2_Home] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lab2_Home] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lab2_Home] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lab2_Home] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lab2_Home] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lab2_Home] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lab2_Home] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lab2_Home] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lab2_Home] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lab2_Home] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lab2_Home] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lab2_Home] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lab2_Home] SET RECOVERY FULL 
GO
ALTER DATABASE [Lab2_Home] SET  MULTI_USER 
GO
ALTER DATABASE [Lab2_Home] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lab2_Home] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lab2_Home] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lab2_Home] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Lab2_Home] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Lab2_Home] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Lab2_Home', N'ON'
GO
ALTER DATABASE [Lab2_Home] SET QUERY_STORE = ON
GO
ALTER DATABASE [Lab2_Home] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Lab2_Home]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 1/28/2024 8:16:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[StudenntRegNo] [nchar](10) NULL,
	[CourseName] [nchar](10) NULL,
	[TimeStamp] [nchar](10) NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/28/2024 8:16:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Course_ID] [nchar](10) NULL,
	[Course_Name] [nchar](10) NULL,
	[Student_Name] [nchar](10) NULL,
	[Teacher_name] [nchar](10) NULL,
	[Semester] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 1/28/2024 8:16:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[Student_Name] [nchar](10) NULL,
	[Course_Name] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/28/2024 8:16:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[RegistrationNumber] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[Department] [nchar](10) NULL,
	[Session] [nchar](10) NULL,
	[Address] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Course] ([Course_ID], [Course_Name], [Student_Name], [Teacher_name], [Semester]) VALUES (N'a         ', N'sd        ', N'vc        ', N'cvdv      ', N'fgjg      ')
INSERT [dbo].[Course] ([Course_ID], [Course_Name], [Student_Name], [Teacher_name], [Semester]) VALUES (N'a         ', N'          ', N'          ', N'          ', N'          ')
INSERT [dbo].[Course] ([Course_ID], [Course_Name], [Student_Name], [Teacher_name], [Semester]) VALUES (N'c         ', N'g         ', N'a         ', N'd         ', N's         ')
GO
INSERT [dbo].[Student] ([RegistrationNumber], [Name], [Department], [Session], [Address]) VALUES (N'          ', N'          ', N'          ', N'          ', N'          ')
INSERT [dbo].[Student] ([RegistrationNumber], [Name], [Department], [Session], [Address]) VALUES (N'a         ', N'b         ', N's         ', N'a         ', N'a         ')
INSERT [dbo].[Student] ([RegistrationNumber], [Name], [Department], [Session], [Address]) VALUES (N'b         ', N'          ', N'          ', N'          ', N'          ')
GO
USE [master]
GO
ALTER DATABASE [Lab2_Home] SET  READ_WRITE 
GO
