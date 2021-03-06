USE [master]
GO
/****** Object:  Database [EFCoreAPI]    Script Date: 31.01.2022 19:55:49 ******/
CREATE DATABASE [EFCoreAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EFCoreAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EFCoreAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EFCoreAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EFCoreAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EFCoreAPI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EFCoreAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EFCoreAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EFCoreAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EFCoreAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EFCoreAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EFCoreAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [EFCoreAPI] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EFCoreAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EFCoreAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EFCoreAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EFCoreAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EFCoreAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EFCoreAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EFCoreAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EFCoreAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EFCoreAPI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EFCoreAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EFCoreAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EFCoreAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EFCoreAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EFCoreAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EFCoreAPI] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EFCoreAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EFCoreAPI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EFCoreAPI] SET  MULTI_USER 
GO
ALTER DATABASE [EFCoreAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EFCoreAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EFCoreAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EFCoreAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EFCoreAPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EFCoreAPI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EFCoreAPI] SET QUERY_STORE = OFF
GO
USE [EFCoreAPI]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31.01.2022 19:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 31.01.2022 19:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[Id_Result] [int] IDENTITY(1,1) NOT NULL,
	[Num_Result] [float] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[Id_Result] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 31.01.2022 19:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id_Subject] [int] IDENTITY(1,1) NOT NULL,
	[Name_Subject] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id_Subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 31.01.2022 19:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id_User] [int] IDENTITY(1,1) NOT NULL,
	[Name_User] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220105084516_UserEntity', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220105101757_UserSubjectRelation', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220105153433_SubjectResultRelation', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220105153737_SubjectResultRelation2', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220105154556_SubjectResultRelation3', N'6.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220105160638_SubjectResultRelation4', N'6.0.1')
GO
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (2, 5.5, 3)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (3, 4.5, 3)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (4, 3.5, 3)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (6, 6, 5)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (7, 5, 3)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (8, 5, 6)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (9, 4.5, 4)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (10, 5.5, 1)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (11, 4, 7)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (12, 6, 11)
INSERT [dbo].[Results] ([Id_Result], [Num_Result], [SubjectId]) VALUES (13, 5, 15)
SET IDENTITY_INSERT [dbo].[Results] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (1, N'Math', 1)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (3, N'English', 1)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (4, N'Musique', 3)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (5, N'Info', 5)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (6, N'Sport', 3)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (7, N'Français', 7)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (11, N'Java', 1)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (12, N'Chimie', 11)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (14, N'Biologie', 8)
INSERT [dbo].[Subjects] ([Id_Subject], [Name_Subject], [UserId]) VALUES (15, N'Physique', 13)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (1, N'Hiago', N'1234')
INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (3, N'LUck', N'45678')
INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (5, N'Epsic', N'maccaud')
INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (6, N'Obi', N'Wan')
INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (7, N'karo', N'973664sdf')
INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (8, N'Sam', N'Sung')
INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (11, N'Ronaldo', N'54367')
INSERT [dbo].[Users] ([Id_User], [Name_User], [Password]) VALUES (13, N'Armstrong', N'756345')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Results_SubjectId]    Script Date: 31.01.2022 19:55:49 ******/
CREATE NONCLUSTERED INDEX [IX_Results_SubjectId] ON [dbo].[Results]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subjects_UserId]    Script Date: 31.01.2022 19:55:49 ******/
CREATE NONCLUSTERED INDEX [IX_Subjects_UserId] ON [dbo].[Subjects]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id_Subject])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Subjects_SubjectId]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id_User])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [EFCoreAPI] SET  READ_WRITE 
GO
