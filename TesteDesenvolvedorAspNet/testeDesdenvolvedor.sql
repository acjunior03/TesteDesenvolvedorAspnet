USE [master]
GO
/****** Object:  Database [DesenvolvedorAspNet]    Script Date: 10/12/2020 22:40:51 ******/
CREATE DATABASE [DesenvolvedorAspNet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DesenvolvedorAspNet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DesenvolvedorAspNet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DesenvolvedorAspNet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DesenvolvedorAspNet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DesenvolvedorAspNet] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DesenvolvedorAspNet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DesenvolvedorAspNet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET ARITHABORT OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET  MULTI_USER 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DesenvolvedorAspNet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DesenvolvedorAspNet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DesenvolvedorAspNet] SET QUERY_STORE = OFF
GO
USE [DesenvolvedorAspNet]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/12/2020 22:40:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[NomeCliente] [nvarchar](max) NOT NULL,
	[CPF] [nchar](11) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 10/12/2020 22:40:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[IdProduto] [bigint] IDENTITY(1,1) NOT NULL,
	[NomeProduto] [nvarchar](max) NOT NULL,
	[IdCliente] [bigint] NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[IdProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Produto] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Produto]  WITH NOCHECK ADD  CONSTRAINT [FK_Produto_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Produto] NOCHECK CONSTRAINT [FK_Produto_Cliente]
GO
USE [master]
GO
ALTER DATABASE [DesenvolvedorAspNet] SET  READ_WRITE 
GO
