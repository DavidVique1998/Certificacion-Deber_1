USE [master]
GO
/****** Object:  Database [DBEscolastico]    Script Date: 30/07/2020 12:55:04 ******/
CREATE DATABASE [DBEscolastico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBEscolastico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.CERTIFICACION\MSSQL\DATA\DBEscolastico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBEscolastico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.CERTIFICACION\MSSQL\DATA\DBEscolastico_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBEscolastico] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBEscolastico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBEscolastico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBEscolastico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBEscolastico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBEscolastico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBEscolastico] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBEscolastico] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBEscolastico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBEscolastico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBEscolastico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBEscolastico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBEscolastico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBEscolastico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBEscolastico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBEscolastico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBEscolastico] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBEscolastico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBEscolastico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBEscolastico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBEscolastico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBEscolastico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBEscolastico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBEscolastico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBEscolastico] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBEscolastico] SET  MULTI_USER 
GO
ALTER DATABASE [DBEscolastico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBEscolastico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBEscolastico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBEscolastico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBEscolastico] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBEscolastico] SET QUERY_STORE = OFF
GO
USE [DBEscolastico]
GO
/****** Object:  Table [dbo].[alumno]    Script Date: 30/07/2020 12:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumno](
	[idalumno] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[cedula] [varchar](15) NULL,
	[fecha_nacimiento] [date] NULL,
	[lugar_nacimiento] [varchar](50) NULL,
	[sexo] [nchar](10) NULL,
 CONSTRAINT [PK_alumno] PRIMARY KEY CLUSTERED 
(
	[idalumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[area]    Script Date: 30/07/2020 12:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[idarea] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[cordinador] [varchar](50) NULL,
 CONSTRAINT [PK_area] PRIMARY KEY CLUSTERED 
(
	[idarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[calificacion]    Script Date: 30/07/2020 12:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calificacion](
	[idcalificacion] [int] IDENTITY(1,1) NOT NULL,
	[valor] [decimal](4, 2) NULL,
	[fecha] [datetime] NULL,
	[unidad] [smallint] NULL,
	[idmatricula] [int] NOT NULL,
 CONSTRAINT [PK_calificacion] PRIMARY KEY CLUSTERED 
(
	[idcalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materia]    Script Date: 30/07/2020 12:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materia](
	[idmateria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[nrc] [varbinary](5) NULL,
	[creditos] [smallint] NULL,
	[idarea] [int] NOT NULL,
 CONSTRAINT [PK_materia] PRIMARY KEY CLUSTERED 
(
	[idmateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[matricula]    Script Date: 30/07/2020 12:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[matricula](
	[idmatricula] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[costo] [decimal](4, 2) NULL,
	[estado] [nchar](1) NULL,
	[tipo] [nchar](1) NULL,
	[idalumno] [int] NOT NULL,
	[idmateria] [int] NOT NULL,
 CONSTRAINT [PK_matricula] PRIMARY KEY CLUSTERED 
(
	[idmatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[alumno] ON 

INSERT [dbo].[alumno] ([idalumno], [nombres], [apellidos], [cedula], [fecha_nacimiento], [lugar_nacimiento], [sexo]) VALUES (2, N'David', N'Vique', N'0605065665', CAST(N'1998-12-02' AS Date), N'Riobamba', N'M         ')
INSERT [dbo].[alumno] ([idalumno], [nombres], [apellidos], [cedula], [fecha_nacimiento], [lugar_nacimiento], [sexo]) VALUES (3, N'David', N'Vique', N'0605065665', CAST(N'1998-12-30' AS Date), N'Riobamba', N'M         ')
INSERT [dbo].[alumno] ([idalumno], [nombres], [apellidos], [cedula], [fecha_nacimiento], [lugar_nacimiento], [sexo]) VALUES (4, N'David', N'Vique', N'0605065664', CAST(N'1998-12-30' AS Date), N'Riobamba', N'M         ')
SET IDENTITY_INSERT [dbo].[alumno] OFF
SET IDENTITY_INSERT [dbo].[area] ON 

INSERT [dbo].[area] ([idarea], [nombre], [cordinador]) VALUES (1, N'Certificacion', N'Ing Dieguito')
INSERT [dbo].[area] ([idarea], [nombre], [cordinador]) VALUES (2, N'Software', N'Ing Espinosa')
INSERT [dbo].[area] ([idarea], [nombre], [cordinador]) VALUES (3, N'Inteligencia Artifical', N'Ing Jose Carrillo')
SET IDENTITY_INSERT [dbo].[area] OFF
ALTER TABLE [dbo].[calificacion]  WITH CHECK ADD  CONSTRAINT [FK_calificacion_matricula] FOREIGN KEY([idmatricula])
REFERENCES [dbo].[matricula] ([idmatricula])
GO
ALTER TABLE [dbo].[calificacion] CHECK CONSTRAINT [FK_calificacion_matricula]
GO
ALTER TABLE [dbo].[materia]  WITH CHECK ADD  CONSTRAINT [FK_materia_area] FOREIGN KEY([idarea])
REFERENCES [dbo].[area] ([idarea])
GO
ALTER TABLE [dbo].[materia] CHECK CONSTRAINT [FK_materia_area]
GO
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [FK_matricula_alumno] FOREIGN KEY([idalumno])
REFERENCES [dbo].[alumno] ([idalumno])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [FK_matricula_alumno]
GO
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [FK_matricula_materia] FOREIGN KEY([idmateria])
REFERENCES [dbo].[materia] ([idmateria])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [FK_matricula_materia]
GO
USE [master]
GO
ALTER DATABASE [DBEscolastico] SET  READ_WRITE 
GO
