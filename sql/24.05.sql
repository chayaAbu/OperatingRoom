USE [master]
GO
/****** Object:  Database [OpreatingRoom]    Script Date: 24/05/2022 10:00:43 ******/
CREATE DATABASE [OpreatingRoom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OpreatingRoom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OpreatingRoom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OpreatingRoom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OpreatingRoom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OpreatingRoom] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OpreatingRoom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OpreatingRoom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OpreatingRoom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OpreatingRoom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OpreatingRoom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OpreatingRoom] SET ARITHABORT OFF 
GO
ALTER DATABASE [OpreatingRoom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OpreatingRoom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OpreatingRoom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OpreatingRoom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OpreatingRoom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OpreatingRoom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OpreatingRoom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OpreatingRoom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OpreatingRoom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OpreatingRoom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OpreatingRoom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OpreatingRoom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OpreatingRoom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OpreatingRoom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OpreatingRoom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OpreatingRoom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OpreatingRoom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OpreatingRoom] SET RECOVERY FULL 
GO
ALTER DATABASE [OpreatingRoom] SET  MULTI_USER 
GO
ALTER DATABASE [OpreatingRoom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OpreatingRoom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OpreatingRoom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OpreatingRoom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OpreatingRoom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OpreatingRoom] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OpreatingRoom', N'ON'
GO
ALTER DATABASE [OpreatingRoom] SET QUERY_STORE = OFF
GO
USE [OpreatingRoom]
GO
/****** Object:  Table [dbo].[classes]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[idClass] [int] NOT NULL,
	[className] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deviceForSurgery]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deviceForSurgery](
	[idDFS] [int] NOT NULL,
	[deviceName] [varchar](50) NOT NULL,
	[surgeryCode] [int] NOT NULL,
	[amount] [int] NULL,
	[idDevice] [int] NULL,
 CONSTRAINT [PK_deviceForSurgery] PRIMARY KEY CLUSTERED 
(
	[idDFS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctor]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctor](
	[idDoctor] [int] NOT NULL,
	[doctorName] [varchar](50) NOT NULL,
	[idClass] [int] NOT NULL,
	[startHour] [datetime] NOT NULL,
	[endHour] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDoctor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room](
	[idRoom] [int] NOT NULL,
	[isFull] [bit] NOT NULL,
	[date] [datetime] NOT NULL,
	[idClass] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[scheduling]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[scheduling](
	[schedulingCode] [int] NOT NULL,
	[schedulingDate] [date] NOT NULL,
	[schedulingHour] [time](7) NOT NULL,
	[idRoom] [int] NOT NULL,
	[surgeryCode] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[schedulingCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specialDevice]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specialDevice](
	[IdDevice] [int] NOT NULL,
	[deviceName] [varchar](50) NOT NULL,
	[isAvailable] [bit] NOT NULL,
	[date] [datetime] NOT NULL,
	[amount] [int] NULL,
 CONSTRAINT [PK__specialD__E7444840C8E3293C] PRIMARY KEY CLUSTERED 
(
	[IdDevice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[surgery]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[surgery](
	[surgeryCode] [int] NOT NULL,
	[idClass] [int] NOT NULL,
	[priorityLevel] [int] NOT NULL,
	[dangerLevel] [int] NOT NULL,
	[idDoctor] [int] NOT NULL,
	[surgeryDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[surgeryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 24/05/2022 10:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[idUser] [int] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[password] [int] NOT NULL,
	[changeAvailable] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[deviceForSurgery]  WITH CHECK ADD  CONSTRAINT [FK_deviceForSurgery_specialDevice] FOREIGN KEY([idDevice])
REFERENCES [dbo].[specialDevice] ([IdDevice])
GO
ALTER TABLE [dbo].[deviceForSurgery] CHECK CONSTRAINT [FK_deviceForSurgery_specialDevice]
GO
ALTER TABLE [dbo].[deviceForSurgery]  WITH CHECK ADD  CONSTRAINT [FK_deviceForSurgery_surgery] FOREIGN KEY([surgeryCode])
REFERENCES [dbo].[surgery] ([surgeryCode])
GO
ALTER TABLE [dbo].[deviceForSurgery] CHECK CONSTRAINT [FK_deviceForSurgery_surgery]
GO
ALTER TABLE [dbo].[doctor]  WITH CHECK ADD  CONSTRAINT [FK_doctor_class] FOREIGN KEY([idClass])
REFERENCES [dbo].[classes] ([idClass])
GO
ALTER TABLE [dbo].[doctor] CHECK CONSTRAINT [FK_doctor_class]
GO
ALTER TABLE [dbo].[room]  WITH CHECK ADD  CONSTRAINT [FK_room_class] FOREIGN KEY([idClass])
REFERENCES [dbo].[classes] ([idClass])
GO
ALTER TABLE [dbo].[room] CHECK CONSTRAINT [FK_room_class]
GO
ALTER TABLE [dbo].[scheduling]  WITH CHECK ADD  CONSTRAINT [FK_scheduling_room] FOREIGN KEY([idRoom])
REFERENCES [dbo].[room] ([idRoom])
GO
ALTER TABLE [dbo].[scheduling] CHECK CONSTRAINT [FK_scheduling_room]
GO
ALTER TABLE [dbo].[scheduling]  WITH CHECK ADD  CONSTRAINT [FK_scheduling_surgery] FOREIGN KEY([surgeryCode])
REFERENCES [dbo].[surgery] ([surgeryCode])
GO
ALTER TABLE [dbo].[scheduling] CHECK CONSTRAINT [FK_scheduling_surgery]
GO
ALTER TABLE [dbo].[surgery]  WITH CHECK ADD  CONSTRAINT [FK_surgery_class] FOREIGN KEY([idClass])
REFERENCES [dbo].[classes] ([idClass])
GO
ALTER TABLE [dbo].[surgery] CHECK CONSTRAINT [FK_surgery_class]
GO
ALTER TABLE [dbo].[surgery]  WITH CHECK ADD  CONSTRAINT [FK_surgery_doctor] FOREIGN KEY([idDoctor])
REFERENCES [dbo].[doctor] ([idDoctor])
GO
ALTER TABLE [dbo].[surgery] CHECK CONSTRAINT [FK_surgery_doctor]
GO
USE [master]
GO
ALTER DATABASE [OpreatingRoom] SET  READ_WRITE 
GO
