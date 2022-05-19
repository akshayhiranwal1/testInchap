USE [VehicleFinance]
GO
/****** Object:  Table [dbo].[FinanceRateRange]    Script Date: 19/05/2022 02:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinanceRateRange](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_FinanceRateRange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinanceType]    Script Date: 19/05/2022 02:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinanceType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_FinanceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Make]    Script Date: 19/05/2022 02:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Make](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 19/05/2022 02:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FkVehicleTypeId] [int] NULL,
	[FkFinanceTypeId] [int] NULL,
	[FkMakeId] [int] NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleFinanceRateMapping]    Script Date: 19/05/2022 02:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleFinanceRateMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FkFinanceRateId] [int] NULL,
	[FkVehicleId] [int] NULL,
	[RateValue] [decimal](18, 2) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_VehicleFinanceRateMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 19/05/2022 02:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FinanceRateRange] ON 
GO
INSERT [dbo].[FinanceRateRange] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (1, N'0-3 Months', N'three months', 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, 0)
GO
INSERT [dbo].[FinanceRateRange] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (2, N'3-6 Months', N'six months', 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, 0)
GO
INSERT [dbo].[FinanceRateRange] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (3, N'6-12 Months', N'twelve months', 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, 0)
GO
INSERT [dbo].[FinanceRateRange] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (4, N'12+ Months', N'more then twelve months', 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, CAST(N'2022-05-18T14:00:34.483' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[FinanceRateRange] OFF
GO
SET IDENTITY_INSERT [dbo].[FinanceType] ON 
GO
INSERT [dbo].[FinanceType] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (4, N'Personal Loan', N'Personal Loan', 1, CAST(N'2022-05-18T14:04:06.470' AS DateTime), 1, CAST(N'2022-05-18T14:04:06.470' AS DateTime), 1, 0)
GO
INSERT [dbo].[FinanceType] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (5, N'Flexible Finance', N'Flexible Finance', 1, CAST(N'2022-05-18T14:33:16.807' AS DateTime), 1, CAST(N'2022-05-18T14:33:16.807' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[FinanceType] OFF
GO
SET IDENTITY_INSERT [dbo].[Make] ON 
GO
INSERT [dbo].[Make] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (1, N'Audi', N'Audi', 1, CAST(N'2022-05-18T15:06:20.967' AS DateTime), 1, CAST(N'2022-05-18T15:06:20.967' AS DateTime), 1, 0)
GO
INSERT [dbo].[Make] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (2, N'BMW', N'BMW', 1, CAST(N'2022-05-18T15:06:20.967' AS DateTime), 1, CAST(N'2022-05-18T15:06:20.967' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Make] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 
GO
INSERT [dbo].[Vehicle] ([Id], [FkVehicleTypeId], [FkFinanceTypeId], [FkMakeId], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 1, 5, 1, N'Audi', N'audi', 1, CAST(N'2022-05-18T14:32:50.680' AS DateTime), 1, CAST(N'2022-05-18T14:32:50.680' AS DateTime), 1, 0)
GO
INSERT [dbo].[Vehicle] ([Id], [FkVehicleTypeId], [FkFinanceTypeId], [FkMakeId], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (2, 3, 5, 2, N'BMW Bike', N'BMW Bike', 1, CAST(N'2022-05-18T15:11:57.580' AS DateTime), 1, CAST(N'2022-05-18T15:11:57.580' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleFinanceRateMapping] ON 
GO
INSERT [dbo].[VehicleFinanceRateMapping] ([Id], [FkFinanceRateId], [FkVehicleId], [RateValue], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 1, 2, CAST(5.00 AS Decimal(18, 2)), 1, CAST(N'2022-05-18T15:13:01.560' AS DateTime), 1, CAST(N'2022-05-18T15:13:01.560' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleFinanceRateMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleType] ON 
GO
INSERT [dbo].[VehicleType] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (1, N'Car', N'Car', 1, CAST(N'2022-05-18T13:59:01.547' AS DateTime), 1, CAST(N'2022-05-18T13:59:01.547' AS DateTime), 1, 0)
GO
INSERT [dbo].[VehicleType] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (2, N'Van', N'Van', 1, CAST(N'2022-05-18T13:59:01.547' AS DateTime), 1, CAST(N'2022-05-18T13:59:01.547' AS DateTime), 1, 0)
GO
INSERT [dbo].[VehicleType] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive], [IsDeleted]) VALUES (3, N'Bike', N'Bike', 1, CAST(N'2022-05-18T13:59:01.547' AS DateTime), 1, CAST(N'2022-05-18T13:59:01.547' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
GO
ALTER TABLE [dbo].[FinanceRateRange] ADD  CONSTRAINT [DF_FinanceRateRange_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[FinanceRateRange] ADD  CONSTRAINT [DF_FinanceRateRange_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[FinanceRateRange] ADD  CONSTRAINT [DF_FinanceRateRange_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[FinanceType] ADD  CONSTRAINT [DF_FinanceType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[FinanceType] ADD  CONSTRAINT [DF_FinanceType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[FinanceType] ADD  CONSTRAINT [DF_FinanceType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Make] ADD  CONSTRAINT [DF_Make_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Make] ADD  CONSTRAINT [DF_Make_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Make] ADD  CONSTRAINT [DF_Make_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Vehicle_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Vehicle_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_Vehicle_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[VehicleFinanceRateMapping] ADD  CONSTRAINT [DF_VehicleFinanceRateMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[VehicleFinanceRateMapping] ADD  CONSTRAINT [DF_VehicleFinanceRateMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[VehicleFinanceRateMapping] ADD  CONSTRAINT [DF_VehicleFinanceRateMapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[VehicleType] ADD  CONSTRAINT [DF_VehicleType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[VehicleType] ADD  CONSTRAINT [DF_VehicleType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[VehicleType] ADD  CONSTRAINT [DF_VehicleType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_FinanceType] FOREIGN KEY([FkFinanceTypeId])
REFERENCES [dbo].[FinanceType] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_FinanceType]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Make] FOREIGN KEY([FkMakeId])
REFERENCES [dbo].[Make] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Make]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleType] FOREIGN KEY([FkVehicleTypeId])
REFERENCES [dbo].[VehicleType] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleType]
GO
ALTER TABLE [dbo].[VehicleFinanceRateMapping]  WITH CHECK ADD  CONSTRAINT [FK_VehicleFinanceRateMapping_FinanceRateRange] FOREIGN KEY([FkFinanceRateId])
REFERENCES [dbo].[FinanceRateRange] ([Id])
GO
ALTER TABLE [dbo].[VehicleFinanceRateMapping] CHECK CONSTRAINT [FK_VehicleFinanceRateMapping_FinanceRateRange]
GO
ALTER TABLE [dbo].[VehicleFinanceRateMapping]  WITH CHECK ADD  CONSTRAINT [FK_VehicleFinanceRateMapping_Vehicle] FOREIGN KEY([FkVehicleId])
REFERENCES [dbo].[Vehicle] ([Id])
GO
ALTER TABLE [dbo].[VehicleFinanceRateMapping] CHECK CONSTRAINT [FK_VehicleFinanceRateMapping_Vehicle]
GO
