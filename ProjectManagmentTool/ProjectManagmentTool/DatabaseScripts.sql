USE [ProjectManagment]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/10/2018 6:53:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AddProject_tb]    Script Date: 2/10/2018 6:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddProject_tb](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[CodeName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[Duration] [int] NULL,
	[UploadFilePath] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_AddProject_tb] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssignPerson_tb]    Script Date: 2/10/2018 6:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignPerson_tb](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_AssignPerson_tb] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment_tb]    Script Date: 2/10/2018 6:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment_tb](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[TaskId] [int] NULL,
	[Comment] [nvarchar](50) NULL,
 CONSTRAINT [PK_Comment_tb] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Priority_tb]    Script Date: 2/10/2018 6:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority_tb](
	[PriorityId] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [nvarchar](50) NULL,
 CONSTRAINT [PK_Priority_tb] PRIMARY KEY CLUSTERED 
(
	[PriorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task_tb]    Script Date: 2/10/2018 6:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task_tb](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[UserId] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[DueDate] [date] NULL,
	[Priority] [nvarchar](50) NULL,
 CONSTRAINT [PK_Task_tb] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserModels]    Script Date: 2/10/2018 6:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModels](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Designation] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.UserModels] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AssignPerson_tb]  WITH CHECK ADD  CONSTRAINT [FK_AssignPerson_tb_AddProject_tb] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[AddProject_tb] ([ProjectId])
GO
ALTER TABLE [dbo].[AssignPerson_tb] CHECK CONSTRAINT [FK_AssignPerson_tb_AddProject_tb]
GO
ALTER TABLE [dbo].[AssignPerson_tb]  WITH CHECK ADD  CONSTRAINT [FK_AssignPerson_tb_UserModels] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserModels] ([UserId])
GO
ALTER TABLE [dbo].[AssignPerson_tb] CHECK CONSTRAINT [FK_AssignPerson_tb_UserModels]
GO
ALTER TABLE [dbo].[Task_tb]  WITH CHECK ADD  CONSTRAINT [FK_Task_tb_UserModels] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserModels] ([UserId])
GO
ALTER TABLE [dbo].[Task_tb] CHECK CONSTRAINT [FK_Task_tb_UserModels]
GO
ALTER TABLE [dbo].[Task_tb]  WITH CHECK ADD  CONSTRAINT [FK_Task_tb_UserModels1] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserModels] ([UserId])
GO
ALTER TABLE [dbo].[Task_tb] CHECK CONSTRAINT [FK_Task_tb_UserModels1]
GO
