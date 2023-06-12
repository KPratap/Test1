USE [RRSDashboard]
GO

/****** Object:  Table [dbo].[YardiClients]    Script Date: 6/5/2023 6:24:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[YardiClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RrsId] [varchar](20) NULL,
	[Enabled] [bit] NULL,
	[Automate] [bit] NULL,
	[Url] [varchar](100) NULL,
	[UserId] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Server] [varchar](50) NULL,
	[DatabaseId] [varchar](50) NULL,
	[Platform] [varchar](50) NULL,
	[YardiPropId] [varchar](50) NULL,
	[PmcName] [varchar](50) NULL
) ON [PRIMARY]
GO


