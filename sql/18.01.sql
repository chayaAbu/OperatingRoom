USE [OperatingRoom]
GO
/****** Object:  Table [dbo].[class]    Script Date: 18/01/2022 09:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[class](
	[idClass] [int] NOT NULL,
	[className] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deviceForSurgery]    Script Date: 18/01/2022 09:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deviceForSurgery](
	[idDFS] [int] NOT NULL,
	[idDevice] [int] NOT NULL,
	[surgeryCode] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDFS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctor]    Script Date: 18/01/2022 09:24:36 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room]    Script Date: 18/01/2022 09:24:36 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[scheduling]    Script Date: 18/01/2022 09:24:36 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specialDevice]    Script Date: 18/01/2022 09:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specialDevice](
	[IdDevice] [int] NOT NULL,
	[deviceName] [varchar](50) NOT NULL,
	[isAvailable] [bit] NOT NULL,
	[date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDevice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[surgery]    Script Date: 18/01/2022 09:24:36 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 18/01/2022 09:24:36 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[class] ([idClass], [className]) VALUES (11, N'orthopedics')
INSERT [dbo].[class] ([idClass], [className]) VALUES (12, N'neurology')
INSERT [dbo].[class] ([idClass], [className]) VALUES (13, N'cardiology')
INSERT [dbo].[class] ([idClass], [className]) VALUES (14, N'oncology')
GO
INSERT [dbo].[deviceForSurgery] ([idDFS], [idDevice], [surgeryCode]) VALUES (500, 1000, 1)
INSERT [dbo].[deviceForSurgery] ([idDFS], [idDevice], [surgeryCode]) VALUES (501, 1001, 4)
GO
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (213256685, N'hodaya ohana', 13, CAST(N'2021-12-23T08:00:00.000' AS DateTime), CAST(N'2021-12-23T18:00:00.000' AS DateTime))
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (216543951, N'david cohen', 12, CAST(N'2021-12-23T10:00:00.000' AS DateTime), CAST(N'2021-12-23T21:00:00.000' AS DateTime))
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (315264896, N'idan lev', 14, CAST(N'2021-12-23T10:00:00.000' AS DateTime), CAST(N'2021-12-23T20:00:00.000' AS DateTime))
INSERT [dbo].[doctor] ([idDoctor], [doctorName], [idClass], [startHour], [endHour]) VALUES (322419276, N'chaya Abu', 11, CAST(N'2021-12-23T08:00:00.000' AS DateTime), CAST(N'2021-12-23T18:00:00.000' AS DateTime))
GO
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (100, 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (120, 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (140, 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[room] ([idRoom], [isFull], [date], [idClass]) VALUES (160, 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime), 11)
GO
INSERT [dbo].[specialDevice] ([IdDevice], [deviceName], [isAvailable], [date]) VALUES (1000, N'Acme heart', 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[specialDevice] ([IdDevice], [deviceName], [isAvailable], [date]) VALUES (1001, N'Defibrillator', 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[specialDevice] ([IdDevice], [deviceName], [isAvailable], [date]) VALUES (1002, N'Ultrasound', 0, CAST(N'2021-12-23T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate]) VALUES (1, 11, 5, 7, 322419276, CAST(N'2021-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate]) VALUES (2, 12, 6, 9, 216543951, CAST(N'2021-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate]) VALUES (3, 11, 9, 3, 322419276, CAST(N'2021-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[surgery] ([surgeryCode], [idClass], [priorityLevel], [dangerLevel], [idDoctor], [surgeryDate]) VALUES (4, 13, 4, 6, 213256685, CAST(N'2021-12-23T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (207944943, N'YaelAmar', 8426513, 0)
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (212735427, N'rinatAvital', 8426513, 1)
INSERT [dbo].[user] ([idUser], [userName], [password], [changeAvailable]) VALUES (315624151, N'danShelom', 8426513, 1)
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
REFERENCES [dbo].[class] ([idClass])
GO
ALTER TABLE [dbo].[doctor] CHECK CONSTRAINT [FK_doctor_class]
GO
ALTER TABLE [dbo].[room]  WITH CHECK ADD  CONSTRAINT [FK_room_class] FOREIGN KEY([idClass])
REFERENCES [dbo].[class] ([idClass])
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
REFERENCES [dbo].[class] ([idClass])
GO
ALTER TABLE [dbo].[surgery] CHECK CONSTRAINT [FK_surgery_class]
GO
ALTER TABLE [dbo].[surgery]  WITH CHECK ADD  CONSTRAINT [FK_surgery_doctor] FOREIGN KEY([idDoctor])
REFERENCES [dbo].[doctor] ([idDoctor])
GO
ALTER TABLE [dbo].[surgery] CHECK CONSTRAINT [FK_surgery_doctor]
GO
