USE [master]
GO
/****** Object:  Database [OpreatingRoom]    Script Date: 23/06/2022 20:18:15 ******/
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
/****** Object:  Table [dbo].[classes]    Script Date: 23/06/2022 20:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[idClass] [int] IDENTITY(1,1) NOT NULL,
	[className] [varchar](50) NOT NULL,
 CONSTRAINT [PK__class__17317A5A289B23AC] PRIMARY KEY CLUSTERED 
(
	[idClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deviceForSurgery]    Script Date: 23/06/2022 20:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deviceForSurgery](
	[idDFS] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[doctor]    Script Date: 23/06/2022 20:18:15 ******/
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
/****** Object:  Table [dbo].[room]    Script Date: 23/06/2022 20:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room](
	[idRoom] [int] IDENTITY(1,1) NOT NULL,
	[isFull] [bit] NOT NULL,
	[date] [datetime] NOT NULL,
	[idClass] [int] NOT NULL,
 CONSTRAINT [PK__room__E5F8C226C7366020] PRIMARY KEY CLUSTERED 
(
	[idRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[scheduling]    Script Date: 23/06/2022 20:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[scheduling](
	[schedulingCode] [int] IDENTITY(1,1) NOT NULL,
	[schedulingDate] [date] NOT NULL,
	[schedulingHour] [time](7) NOT NULL,
	[idRoom] [int] NOT NULL,
	[surgeryCode] [int] NOT NULL,
	[duringSurg] [time](7) NOT NULL,
 CONSTRAINT [PK__scheduli__5DBC14757C96D4ED] PRIMARY KEY CLUSTERED 
(
	[schedulingCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specialDevice]    Script Date: 23/06/2022 20:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specialDevice](
	[IdDevice] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[surgery]    Script Date: 23/06/2022 20:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[surgery](
	[surgeryCode] [int] IDENTITY(1,1) NOT NULL,
	[idClass] [int] NOT NULL,
	[priorityLevel] [int] NOT NULL,
	[dangerLevel] [int] NOT NULL,
	[idDoctor] [int] NOT NULL,
	[surgeryDate] [datetime] NOT NULL,
	[duringSurg] [time](7) NOT NULL,
	[hasSches] [bit] NOT NULL,
 CONSTRAINT [PK__surgery__AFB449BE6E4CEE04] PRIMARY KEY CLUSTERED 
(
	[surgeryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 23/06/2022 20:18:15 ******/
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
SET IDENTITY_INSERT [dbo].[classes] ON 

INSERT [dbo].[classes] ([idClass], [className]) VALUES (11, N'orthopedics')
INSERT [dbo].[classes] ([idClass], [className]) VALUES (12, N'neurology')
INSERT [dbo].[classes] ([idClass], [className]) VALUES (13, N'cardiology')
INSERT [dbo].[classes] ([idClass], [className]) VALUES (14, N'oncology')
SET IDENTITY_INSERT [dbo].[classes] OFF
GO
SET IDENTITY_INSERT [dbo].[deviceForSurgery] ON 

INSERT [dbo].[deviceForSurgery] ([idDFS], [deviceName], [surgeryCode], [amount], [idDevice]) VALUES (8, N'Acme heart', 1, 1, 1000)
INSERT [dbo].[deviceForSurgery] ([idDFS], [deviceName], [surgeryCode], [amount], [idDevice]) VALUES (9, N'Defibrillator', 2, 1, 1000)
INSERT [dbo].[deviceForSurgery] ([idDFS], [deviceName], [surgeryCode], [amount], [idDevice]) VALUES (10, N'Defibrillator', 3, 2, 1000)
INSERT [dbo].[deviceForSurgery] ([idDFS], [deviceName], [surgeryCode], [amount], [idDevice]) VALUES (11, N'Acme heart', 4, 1, 1000)
SET IDENTITY_INSERT [dbo].[deviceForSurgery] OFF
GO
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (213256685, N'hodaya ohana', 13, CAST(N'2021-12-23T08:00:00.000' AS DateTime), CAST(N'2021-12-23T18:00:00.000' AS DateTime))
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (216543951, N'david cohen', 12, CAST(N'2021-12-23T10:00:00.000' AS DateTime), CAST(N'2021-12-23T21:00:00.000' AS DateTime))
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (315264896, N'idan lev', 14, CAST(N'2021-12-23T10:00:00.000' AS DateTime), CAST(N'2021-12-23T20:00:00.000' AS DateTime))
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (322419276, N'chaya Abu', 11, CAST(N'2021-12-23T08:00:00.000' AS DateTime), CAST(N'2021-12-23T18:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[room] ON 

INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (15, 1, CAST(N'2022-06-23T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (100, 1, CAST(N'2022-06-23T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (120, 1, CAST(N'2022-06-23T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (140, 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (160, 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (161, 1, CAST(N'2022-06-23T00:00:00.000' AS DateTime), 13)
SET IDENTITY_INSERT [dbo].[room] OFF
GO
SET IDENTITY_INSERT [dbo].[scheduling] ON 

INSERT [dbo].[scheduling] ([schedulingCode], [schedulingDate], [schedulingHour], [idRoom], [surgeryCode], [duringSurg]) VALUES (9, CAST(N'2022-06-23' AS Date), CAST(N'00:00:00' AS Time), 15, 1, CAST(N'01:00:00' AS Time))
INSERT [dbo].[scheduling] ([schedulingCode], [schedulingDate], [schedulingHour], [idRoom], [surgeryCode], [duringSurg]) VALUES (10, CAST(N'2022-06-23' AS Date), CAST(N'00:00:00' AS Time), 120, 2, CAST(N'02:30:00' AS Time))
INSERT [dbo].[scheduling] ([schedulingCode], [schedulingDate], [schedulingHour], [idRoom], [surgeryCode], [duringSurg]) VALUES (11, CAST(N'2022-06-23' AS Date), CAST(N'00:00:00' AS Time), 100, 3, CAST(N'04:00:00' AS Time))
INSERT [dbo].[scheduling] ([schedulingCode], [schedulingDate], [schedulingHour], [idRoom], [surgeryCode], [duringSurg]) VALUES (12, CAST(N'2022-06-23' AS Date), CAST(N'00:00:00' AS Time), 161, 4, CAST(N'07:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[scheduling] OFF
GO
SET IDENTITY_INSERT [dbo].[specialDevice] ON 

INSERT [dbo].[specialDevice] ([IdDevice], [deviceName], [isAvailable], [date], [amount]) VALUES (1000, N'Acme heart', 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[specialDevice] ([IdDevice], [deviceName], [isAvailable], [date], [amount]) VALUES (1001, N'Defibrillator', 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[specialDevice] ([IdDevice], [deviceName], [isAvailable], [date], [amount]) VALUES (1002, N'Ultrasound', 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[specialDevice] OFF
GO
SET IDENTITY_INSERT [dbo].[surgery] ON 

INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate], [duringSurg], [hasSches]) VALUES (1, 11, 0, 8, 213256685, CAST(N'2022-06-23T00:00:00.000' AS DateTime), CAST(N'01:00:00' AS Time), 1)
INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate], [duringSurg], [hasSches]) VALUES (2, 13, 0, 8, 213256685, CAST(N'2022-06-23T00:00:00.000' AS DateTime), CAST(N'02:30:00' AS Time), 1)
INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate], [duringSurg], [hasSches]) VALUES (3, 12, 0, 7, 213256685, CAST(N'2022-06-23T00:00:00.000' AS DateTime), CAST(N'04:00:00' AS Time), 1)
INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate], [duringSurg], [hasSches]) VALUES (4, 13, 0, 9, 213256685, CAST(N'2022-06-23T00:00:00.000' AS DateTime), CAST(N'07:00:00' AS Time), 1)
SET IDENTITY_INSERT [dbo].[surgery] OFF
GO
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (0, N'rinatAvital', 123456, 0)
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (207944943, N'YaelAmar', 8426513, 0)
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (212735427, N'rinatAvital', 8426513, 1)
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (315624151, N'danShelom', 8426513, 1)
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (322419276, N'chays', 123456, 0)
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (362581325, N'galyaAmar', 8426513, 0)
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
