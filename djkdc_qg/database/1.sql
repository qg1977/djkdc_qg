USE [master]
GO
/****** Object:  Database [books_x]    Script Date: 2017/12/3 16:00:11 ******/
CREATE DATABASE [books_x] ON  PRIMARY 
( NAME = N'books_x', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.FX\MSSQL\DATA\books_x.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'books_x_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.FX\MSSQL\DATA\books_x_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [books_x] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [books_x].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [books_x] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [books_x] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [books_x] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [books_x] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [books_x] SET ARITHABORT OFF 
GO
ALTER DATABASE [books_x] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [books_x] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [books_x] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [books_x] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [books_x] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [books_x] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [books_x] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [books_x] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [books_x] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [books_x] SET  DISABLE_BROKER 
GO
ALTER DATABASE [books_x] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [books_x] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [books_x] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [books_x] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [books_x] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [books_x] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [books_x] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [books_x] SET RECOVERY FULL 
GO
ALTER DATABASE [books_x] SET  MULTI_USER 
GO
ALTER DATABASE [books_x] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [books_x] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'books_x', N'ON'
GO
USE [books_x]
GO
/****** Object:  User [qg1977721]    Script Date: 2017/12/3 16:00:11 ******/
CREATE USER [qg1977721] FOR LOGIN [qg1977721] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[books_xall]    Script Date: 2017/12/3 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books_xall](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ISBN号] [nchar](50) NULL,
	[书名] [nchar](50) NULL,
	[拼音] [nchar](50) NULL,
	[单价] [decimal](8, 2) NULL CONSTRAINT [DF_books_xall_单价]  DEFAULT ((0)),
	[出版日期] [datetime2](7) NULL,
	[册数] [decimal](5, 0) NULL CONSTRAINT [DF_books_xall_册数]  DEFAULT ((0)),
	[出版社ID] [bigint] NULL,
	[类别ID] [bigint] NULL,
 CONSTRAINT [PK_books_xall] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[p_passpass]    Script Date: 2017/12/3 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[p_passpass](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[用户名] [nchar](20) NULL,
	[密码] [nchar](20) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[press]    Script Date: 2017/12/3 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[press](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[出版社] [nchar](100) NULL,
	[拼音] [nchar](100) NULL,
 CONSTRAINT [PK_press] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[types]    Script Date: 2017/12/3 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[types](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[图书类别] [nchar](50) NULL,
	[拼音] [nchar](50) NULL,
 CONSTRAINT [PK_types] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_menu]    Script Date: 2017/12/3 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_menu](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[上级ID] [bigint] NULL,
	[名称] [nchar](50) NULL,
	[表单] [nchar](100) NULL,
	[最大化] [decimal](1, 0) NULL CONSTRAINT [DF_z_menu_最大化]  DEFAULT ((0)),
 CONSTRAINT [PK_z_menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[z_system]    Script Date: 2017/12/3 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[z_system](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[属性] [int] NULL CONSTRAINT [DF_z_system_属性]  DEFAULT ((0)),
	[值] [int] NOT NULL CONSTRAINT [DF_z_system_值]  DEFAULT ((0)),
	[摘要] [nchar](100) NULL,
 CONSTRAINT [PK_z_system] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[z_menu_view]    Script Date: 2017/12/3 16:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[z_menu_view]
AS
WITH CTE1 AS (SELECT     ID, 上级ID, 名称, 表单, 最大化, 0 AS 级数
                                  FROM         dbo.z_menu
                                  WHERE     (上级ID = 0)
                                  UNION ALL
                                  SELECT     A.ID, A.上级ID, A.名称, A.表单, A.最大化, B.级数 + 1 AS Expr1
                                  FROM         dbo.z_menu AS A INNER JOIN
                                                        CTE1 AS B ON A.上级ID = B.ID)
    SELECT     TOP (100) PERCENT ID, 上级ID, 名称, 表单, 最大化, 级数,
                                (SELECT     COUNT(1) AS Expr1
                                  FROM          dbo.z_menu AS z_menu_1
                                  WHERE      (上级ID = CTE1_1.ID)) AS 有下级
     FROM         CTE1 AS CTE1_1
     ORDER BY ID

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[66] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 5
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CTE1_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 171
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'z_menu_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'z_menu_view'
GO
USE [master]
GO
ALTER DATABASE [books_x] SET  READ_WRITE 
GO
