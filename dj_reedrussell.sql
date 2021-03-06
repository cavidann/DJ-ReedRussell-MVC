USE [master]
GO
/****** Object:  Database [dj_reedrussell]    Script Date: 24/09/2017 21:58:33 ******/
CREATE DATABASE [dj_reedrussell]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dj_reedrussell', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\dj_reedrussell.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dj_reedrussell_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\dj_reedrussell_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dj_reedrussell] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dj_reedrussell].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dj_reedrussell] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dj_reedrussell] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dj_reedrussell] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dj_reedrussell] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dj_reedrussell] SET ARITHABORT OFF 
GO
ALTER DATABASE [dj_reedrussell] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dj_reedrussell] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dj_reedrussell] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dj_reedrussell] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dj_reedrussell] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dj_reedrussell] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dj_reedrussell] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dj_reedrussell] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dj_reedrussell] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dj_reedrussell] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dj_reedrussell] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dj_reedrussell] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dj_reedrussell] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dj_reedrussell] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dj_reedrussell] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dj_reedrussell] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dj_reedrussell] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dj_reedrussell] SET RECOVERY FULL 
GO
ALTER DATABASE [dj_reedrussell] SET  MULTI_USER 
GO
ALTER DATABASE [dj_reedrussell] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dj_reedrussell] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dj_reedrussell] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dj_reedrussell] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dj_reedrussell] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dj_reedrussell', N'ON'
GO
ALTER DATABASE [dj_reedrussell] SET QUERY_STORE = OFF
GO
USE [dj_reedrussell]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [dj_reedrussell]
GO
/****** Object:  Table [dbo].[album_or_radioshow]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[album_or_radioshow](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cover] [nvarchar](max) NULL,
	[header] [nvarchar](50) NULL,
	[author] [nvarchar](50) NULL,
	[info] [nvarchar](max) NULL,
	[tracklist_id] [int] NULL,
	[page_name_id] [int] NULL,
	[album_type] [nchar](10) NULL,
	[src] [nvarchar](max) NULL,
 CONSTRAINT [PK_album_or_radioshow] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[site_name] [nvarchar](50) NULL,
	[profile] [nvarchar](50) NULL,
 CONSTRAINT [PK_contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[music_types]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[music_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
 CONSTRAINT [PK_music_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[musics]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[music_cover] [nvarchar](max) NULL,
	[music_info] [nvarchar](max) NULL,
	[music_types_id] [int] NULL,
	[music_src] [nvarchar](max) NULL,
 CONSTRAINT [PK_musics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[myadmin]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[myadmin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adminnme] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[myevent]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[myevent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[event_name] [nvarchar](50) NULL,
	[event_info] [nvarchar](max) NULL,
	[eventdatetime] [nvarchar](50) NULL,
	[photo] [nvarchar](max) NULL,
	[event_bk_photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_events] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[page_name]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[page_name](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
 CONSTRAINT [PK_page_name] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tracklist]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tracklist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[music_name] [nvarchar](50) NULL,
	[music_time] [nvarchar](5) NULL,
	[music_src] [nvarchar](max) NULL,
 CONSTRAINT [PK_tracklist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[video_types]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[video_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_video_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[videos]    Script Date: 24/09/2017 21:58:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[videos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cover] [nvarchar](max) NULL,
	[link] [nvarchar](max) NULL,
	[video_types_id] [int] NULL,
 CONSTRAINT [PK_videos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[album_or_radioshow]  WITH CHECK ADD  CONSTRAINT [FK_album_or_radioshow_album_or_radioshow1] FOREIGN KEY([tracklist_id])
REFERENCES [dbo].[tracklist] ([id])
GO
ALTER TABLE [dbo].[album_or_radioshow] CHECK CONSTRAINT [FK_album_or_radioshow_album_or_radioshow1]
GO
ALTER TABLE [dbo].[album_or_radioshow]  WITH CHECK ADD  CONSTRAINT [FK_album_or_radioshow_page_name] FOREIGN KEY([page_name_id])
REFERENCES [dbo].[page_name] ([id])
GO
ALTER TABLE [dbo].[album_or_radioshow] CHECK CONSTRAINT [FK_album_or_radioshow_page_name]
GO
ALTER TABLE [dbo].[musics]  WITH CHECK ADD  CONSTRAINT [FK_musics_music_types] FOREIGN KEY([music_types_id])
REFERENCES [dbo].[music_types] ([id])
GO
ALTER TABLE [dbo].[musics] CHECK CONSTRAINT [FK_musics_music_types]
GO
ALTER TABLE [dbo].[videos]  WITH CHECK ADD  CONSTRAINT [FK_videos_video_types] FOREIGN KEY([video_types_id])
REFERENCES [dbo].[video_types] ([id])
GO
ALTER TABLE [dbo].[videos] CHECK CONSTRAINT [FK_videos_video_types]
GO
USE [master]
GO
ALTER DATABASE [dj_reedrussell] SET  READ_WRITE 
GO
