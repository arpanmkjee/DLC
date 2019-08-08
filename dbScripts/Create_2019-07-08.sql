USE [ODMI_DEV]
GO
/****** Object:  Table [dbo].[AppConfig]    Script Date: 8/7/2019 2:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppConfig](
	[AppConfigID] [uniqueidentifier] NOT NULL,
	[ConfigType] [nvarchar](50) NULL,
	[ConfigValue] [nvarchar](100) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_AppConfig] PRIMARY KEY CLUSTERED 
(
	[AppConfigID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [bigint] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](50) NULL,
	[LogData] [nvarchar](max) NULL,
	[Timestamp] [datetime] NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ModuleID] [uniqueidentifier] NOT NULL,
	[ModuleName] [nvarchar](50) NULL,
	[ModuleDataJSON] [nvarchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ping]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ping](
	[PingID] [uniqueidentifier] NOT NULL,
	[RequestID] [uniqueidentifier] NOT NULL,
	[TenantID] [uniqueidentifier] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[ResultsJSON] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ping] PRIMARY KEY CLUSTERED 
(
	[PingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reading]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reading](
	[ReadingID] [uniqueidentifier] NOT NULL,
	[RequestID] [uniqueidentifier] NOT NULL,
	[TenantID] [uniqueidentifier] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[ResultsJSON] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReadingID] PRIMARY KEY CLUSTERED 
(
	[ReadingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestID] [uniqueidentifier] NOT NULL,
	[RequestUserID] [uniqueidentifier] NOT NULL,
	[TenantID] [uniqueidentifier] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[RequestESN] [nvarchar](50) NULL,
	[DataJSON] [nvarchar](max) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [uniqueidentifier] NOT NULL,
	[TenantID] [uniqueidentifier] NULL,
	[RoleName] [nvarchar](50) NULL,
	[SettingsJSON] [nvarchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[TenantID] [uniqueidentifier] NOT NULL,
	[TenantIdentifier] [nvarchar](100) NULL,
	[TenantName] [nvarchar](100) NULL,
	[SettingsJSON] [nvarchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenantData]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantData](
	[TenantDataID] [uniqueidentifier] NOT NULL,
	[TenantID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TenantData] PRIMARY KEY CLUSTERED 
(
	[TenantDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [uniqueidentifier] NOT NULL,
	[TenantID] [uniqueidentifier] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[AuthType] [int] NOT NULL,
	[Password] [nvarchar](100) NULL,
	[AccessToken] [nvarchar](500) NULL,
	[RefreshToken] [nvarchar](500) NULL,
	[TokenLastUpdateTime] [datetime] NULL,
	[LastLoginTime] [datetime] NULL,
	[PasswordResetCode] [nvarchar](50) NULL,
	[PasswordResetCodeTime] [datetime] NULL,
	[SettingsJSON] [nvarchar](max) NULL,
	[Active] [bit] NULL,
	[IsTenantAdmin] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleID] [uniqueidentifier] NOT NULL,
	[RoleID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voltage]    Script Date: 8/7/2019 2:32:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voltage](
	[VoltageID] [uniqueidentifier] NOT NULL,
	[RequestID] [uniqueidentifier] NOT NULL,
	[TenantID] [uniqueidentifier] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[ResultsJSON] [nvarchar](max) NULL,
 CONSTRAINT [PK_Voltage] PRIMARY KEY CLUSTERED 
(
	[VoltageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppConfig] ADD  CONSTRAINT [DF_AppConfig_AppConfigID]  DEFAULT (newid()) FOR [AppConfigID]
GO
ALTER TABLE [dbo].[AppConfig] ADD  CONSTRAINT [DF_AppConfig_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_ModuleID]  DEFAULT (newid()) FOR [ModuleID]
GO
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Ping] ADD  CONSTRAINT [DF_Ping_PingID]  DEFAULT (newid()) FOR [PingID]
GO
ALTER TABLE [dbo].[Reading] ADD  CONSTRAINT [DF_ReadingID_ReadingID]  DEFAULT (newid()) FOR [ReadingID]
GO
ALTER TABLE [dbo].[Request] ADD  CONSTRAINT [DF_Request_RequestID]  DEFAULT (newid()) FOR [RequestID]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_RoleID]  DEFAULT (newid()) FOR [RoleID]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Tenant] ADD  CONSTRAINT [DF_Tenant_TenantID]  DEFAULT (newid()) FOR [TenantID]
GO
ALTER TABLE [dbo].[Tenant] ADD  CONSTRAINT [DF_Tenant_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[TenantData] ADD  CONSTRAINT [DF_TenantData_TenantDataID]  DEFAULT (newid()) FOR [TenantDataID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UserID]  DEFAULT (newid()) FOR [UserID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_AuthType]  DEFAULT ((0)) FOR [AuthType]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsTenantAdmin]  DEFAULT ((0)) FOR [IsTenantAdmin]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_UserRoleID]  DEFAULT (newid()) FOR [UserRoleID]
GO
