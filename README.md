# ShopBridge
1)import Database Backup First
2)Check ConnectionString in both Project Test project->packages.confid and ShopBridge->web.Config. OR Directly Update Entity EDMX with database.
3)Run the Project and call through Following Web URL->  https://localhost:44390/CoponentHomePage



4} Query for Table:

USE [ShopBridge]
GO

/****** Object:  Table [dbo].[component]    Script Date: 16-09-2020 12:27:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[component](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Image] [varbinary](max) NOT NULL,
	[Discription] [nvarchar](max) NULL,
 CONSTRAINT [PK_component] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


