USE [master]
GO
/****** Object:  Database [Bioskop]    Script Date: 21-Feb-20 18:37:43 ******/
CREATE DATABASE [Bioskop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bioskop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Bioskop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bioskop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Bioskop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Bioskop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bioskop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bioskop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bioskop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bioskop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bioskop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bioskop] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bioskop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bioskop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bioskop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bioskop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bioskop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bioskop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bioskop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bioskop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bioskop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bioskop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bioskop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bioskop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bioskop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bioskop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bioskop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bioskop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bioskop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bioskop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bioskop] SET  MULTI_USER 
GO
ALTER DATABASE [Bioskop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bioskop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bioskop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bioskop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bioskop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bioskop] SET QUERY_STORE = OFF
GO
USE [Bioskop]
GO
/****** Object:  Table [dbo].[tblDobavljac]    Script Date: 21-Feb-20 18:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDobavljac](
	[DobavljacID] [int] IDENTITY(1,1) NOT NULL,
	[NazivDobavljaca] [nvarchar](50) NULL,
	[AdresaDobavljaca] [nvarchar](50) NULL,
	[KontaktDobavljaca] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbDobavljac] PRIMARY KEY CLUSTERED 
(
	[DobavljacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFilm]    Script Date: 21-Feb-20 18:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFilm](
	[FilmID] [int] IDENTITY(1,1) NOT NULL,
	[NazivFilma] [nvarchar](50) NULL,
	[GodinaObjavljivanja] [int] NULL,
	[ZanrID] [int] NULL,
	[KorisnikID] [int] NULL,
	[ZaposleniID] [int] NULL,
 CONSTRAINT [PK_TbFilm] PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKorisnik]    Script Date: 21-Feb-20 18:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKorisnik](
	[KorisnikID] [int] IDENTITY(1,1) NOT NULL,
	[ImeKorisnika] [nvarchar](50) NULL,
	[PrezimeKorisnika] [nvarchar](50) NULL,
	[BrojRacuna] [int] NULL,
	[AdresaClana] [nvarchar](50) NULL,
	[KontaktClana] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbKorisnik] PRIMARY KEY CLUSTERED 
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNabavka]    Script Date: 21-Feb-20 18:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNabavka](
	[NabavkaID] [int] IDENTITY(1,1) NOT NULL,
	[KolicinaRobe] [int] NULL,
	[DatumNabavke] [date] NULL,
	[CijenaRobe] [int] NULL,
	[FilmID] [int] NULL,
	[DobavljacID] [int] NULL,
 CONSTRAINT [PK_tblNabavka] PRIMARY KEY CLUSTERED 
(
	[NabavkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblZanrFilma]    Script Date: 21-Feb-20 18:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblZanrFilma](
	[ZanrID] [int] IDENTITY(1,1) NOT NULL,
	[Zanr] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbZanrFilma] PRIMARY KEY CLUSTERED 
(
	[ZanrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblZaposleni]    Script Date: 21-Feb-20 18:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblZaposleni](
	[ZaposleniID] [int] IDENTITY(1,1) NOT NULL,
	[ImeZaposlenog] [nvarchar](50) NULL,
	[PreimeZaposlenog] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_TbZaposleni] PRIMARY KEY CLUSTERED 
(
	[ZaposleniID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblFilm]  WITH CHECK ADD  CONSTRAINT [FK_TbFilm_TbKorisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[tblKorisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[tblFilm] CHECK CONSTRAINT [FK_TbFilm_TbKorisnik]
GO
ALTER TABLE [dbo].[tblFilm]  WITH CHECK ADD  CONSTRAINT [FK_TbFilm_TbZanrFilma] FOREIGN KEY([ZanrID])
REFERENCES [dbo].[tblZanrFilma] ([ZanrID])
GO
ALTER TABLE [dbo].[tblFilm] CHECK CONSTRAINT [FK_TbFilm_TbZanrFilma]
GO
ALTER TABLE [dbo].[tblFilm]  WITH CHECK ADD  CONSTRAINT [FK_TbFilm_TbZaposleni] FOREIGN KEY([ZaposleniID])
REFERENCES [dbo].[tblZaposleni] ([ZaposleniID])
GO
ALTER TABLE [dbo].[tblFilm] CHECK CONSTRAINT [FK_TbFilm_TbZaposleni]
GO
ALTER TABLE [dbo].[tblNabavka]  WITH CHECK ADD  CONSTRAINT [FK_TbNabavka_TbDobavljac] FOREIGN KEY([DobavljacID])
REFERENCES [dbo].[tblDobavljac] ([DobavljacID])
GO
ALTER TABLE [dbo].[tblNabavka] CHECK CONSTRAINT [FK_TbNabavka_TbDobavljac]
GO
ALTER TABLE [dbo].[tblNabavka]  WITH CHECK ADD  CONSTRAINT [FK_TbNabavka_TbFilm] FOREIGN KEY([FilmID])
REFERENCES [dbo].[tblFilm] ([FilmID])
GO
ALTER TABLE [dbo].[tblNabavka] CHECK CONSTRAINT [FK_TbNabavka_TbFilm]
GO
USE [master]
GO
ALTER DATABASE [Bioskop] SET  READ_WRITE 
GO
