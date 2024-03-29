USE [master]
GO
/****** Object:  Database [Northern_Lights_Hospital]    Script Date: 2022-10-12 13:45:07 ******/
CREATE DATABASE [Northern_Lights_Hospital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Northern_Lights_Hospital', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Northern_Lights_Hospital.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Northern_Lights_Hospital_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Northern_Lights_Hospital_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Northern_Lights_Hospital] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Northern_Lights_Hospital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Northern_Lights_Hospital] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET ARITHABORT OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET RECOVERY FULL 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET  MULTI_USER 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Northern_Lights_Hospital] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Northern_Lights_Hospital] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Northern_Lights_Hospital', N'ON'
GO
ALTER DATABASE [Northern_Lights_Hospital] SET QUERY_STORE = OFF
GO
USE [Northern_Lights_Hospital]
GO
/****** Object:  Table [dbo].[Admission]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admission](
	[IDAdmission] [int] IDENTITY(1,1) NOT NULL,
	[chirurgie_programmee] [bit] NOT NULL,
	[date_admission] [date] NOT NULL,
	[date_chirurgie] [date] NULL,
	[date_du_congé] [date] NULL,
	[televiseur] [bit] NOT NULL,
	[telephone] [bit] NOT NULL,
	[NSS] [int] NOT NULL,
	[Numero_lit] [int] NOT NULL,
	[IDMedecin] [int] NOT NULL,
 CONSTRAINT [PK_Admission] PRIMARY KEY CLUSTERED 
(
	[IDAdmission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lit]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lit](
	[Numero_lit] [int] IDENTITY(1,1) NOT NULL,
	[occupe] [bit] NOT NULL,
	[IDType] [int] NOT NULL,
	[IDDepartement] [int] NOT NULL,
 CONSTRAINT [PK_Lit] PRIMARY KEY CLUSTERED 
(
	[Numero_lit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medecin]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medecin](
	[IDMedecin] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[prenom] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Medecin] PRIMARY KEY CLUSTERED 
(
	[IDMedecin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[NSS] [int] IDENTITY(1,1) NOT NULL,
	[date_naissance] [date] NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[prenom] [nchar](50) NOT NULL,
	[adresse] [nchar](100) NULL,
	[ville] [nchar](50) NOT NULL,
	[province] [nchar](50) NOT NULL,
	[code_postal] [nchar](10) NULL,
	[telephone] [nchar](20) NULL,
	[IDAssurance] [int] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[NSS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AdminLitMedPatient]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AdminLitMedPatient]
AS
SELECT   dbo.Admission.IDAdmission AS NoAdmission, dbo.Lit.Numero_lit AS NoLit, dbo.Admission.date_admission AS Admission, dbo.Admission.date_du_congé AS Congé, 
                         dbo.Lit.occupe AS [Status du lit], dbo.Medecin.nom AS Médecin, dbo.Patient.nom AS [Prénom Patient], dbo.Patient.prenom AS [Nom Patient]
FROM         dbo.Admission INNER JOIN
                         dbo.Lit ON dbo.Admission.Numero_lit = dbo.Lit.Numero_lit INNER JOIN
                         dbo.Medecin ON dbo.Admission.IDMedecin = dbo.Medecin.IDMedecin INNER JOIN
                         dbo.Patient ON dbo.Admission.NSS = dbo.Patient.NSS
WHERE     (dbo.Lit.occupe = 1)
GO
/****** Object:  Table [dbo].[Assurance]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assurance](
	[IDAssurance] [int] IDENTITY(1,1) NOT NULL,
	[nom_compagnie] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Assurance] PRIMARY KEY CLUSTERED 
(
	[IDAssurance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departement]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departement](
	[IDDepartement] [int] IDENTITY(1,1) NOT NULL,
	[nom_departement] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Departement] PRIMARY KEY CLUSTERED 
(
	[IDDepartement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Lit]    Script Date: 2022-10-12 13:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Lit](
	[IDType] [int] IDENTITY(1,1) NOT NULL,
	[description] [nchar](25) NOT NULL,
 CONSTRAINT [PK_Type_Lit] PRIMARY KEY CLUSTERED 
(
	[IDType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admission] ON 

INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (3, 0, CAST(N'2022-10-11' AS Date), NULL, CAST(N'2022-10-12' AS Date), 0, 0, 4, 1, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (4, 0, CAST(N'2022-10-11' AS Date), NULL, CAST(N'2022-10-12' AS Date), 0, 0, 1, 2, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (5, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 3, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (6, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 4, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (7, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 6, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (8, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 14, 7, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (9, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 9, 8, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (10, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 10, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (11, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 11, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (12, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 9, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (13, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 5, 1)
INSERT [dbo].[Admission] ([IDAdmission], [chirurgie_programmee], [date_admission], [date_chirurgie], [date_du_congé], [televiseur], [telephone], [NSS], [Numero_lit], [IDMedecin]) VALUES (14, 0, CAST(N'2022-10-11' AS Date), NULL, NULL, 0, 0, 1, 12, 1)
SET IDENTITY_INSERT [dbo].[Admission] OFF
GO
SET IDENTITY_INSERT [dbo].[Assurance] ON 

INSERT [dbo].[Assurance] ([IDAssurance], [nom_compagnie]) VALUES (1, N'Pas assuré                                        ')
INSERT [dbo].[Assurance] ([IDAssurance], [nom_compagnie]) VALUES (2, N'Croix Bleue                                       ')
INSERT [dbo].[Assurance] ([IDAssurance], [nom_compagnie]) VALUES (3, N'Desjardins                                        ')
INSERT [dbo].[Assurance] ([IDAssurance], [nom_compagnie]) VALUES (4, N'Manuvie                                           ')
INSERT [dbo].[Assurance] ([IDAssurance], [nom_compagnie]) VALUES (5, N'Sunlife                                           ')
INSERT [dbo].[Assurance] ([IDAssurance], [nom_compagnie]) VALUES (6, N'RAMQ                                              ')
SET IDENTITY_INSERT [dbo].[Assurance] OFF
GO
SET IDENTITY_INSERT [dbo].[Departement] ON 

INSERT [dbo].[Departement] ([IDDepartement], [nom_departement]) VALUES (1, N'chirurgie                                         ')
INSERT [dbo].[Departement] ([IDDepartement], [nom_departement]) VALUES (2, N'médecine                                          ')
INSERT [dbo].[Departement] ([IDDepartement], [nom_departement]) VALUES (3, N'pédiatrie                                         ')
INSERT [dbo].[Departement] ([IDDepartement], [nom_departement]) VALUES (4, N'médecine d''urgence                                ')
SET IDENTITY_INSERT [dbo].[Departement] OFF
GO
SET IDENTITY_INSERT [dbo].[Lit] ON 

INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (1, 0, 1, 1)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (2, 0, 2, 1)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (3, 1, 3, 2)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (4, 1, 1, 2)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (5, 1, 2, 2)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (6, 1, 3, 3)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (7, 1, 1, 3)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (8, 1, 2, 3)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (9, 1, 3, 3)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (10, 1, 1, 4)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (11, 1, 2, 4)
INSERT [dbo].[Lit] ([Numero_lit], [occupe], [IDType], [IDDepartement]) VALUES (12, 1, 3, 4)
SET IDENTITY_INSERT [dbo].[Lit] OFF
GO
SET IDENTITY_INSERT [dbo].[Medecin] ON 

INSERT [dbo].[Medecin] ([IDMedecin], [nom], [prenom]) VALUES (1, N'Gagnon                                            ', N'Guylaine                                          ')
INSERT [dbo].[Medecin] ([IDMedecin], [nom], [prenom]) VALUES (2, N'Charron                                           ', N'Roger                                             ')
INSERT [dbo].[Medecin] ([IDMedecin], [nom], [prenom]) VALUES (3, N'Larivière                                         ', N'Ethan                                             ')
INSERT [dbo].[Medecin] ([IDMedecin], [nom], [prenom]) VALUES (4, N'Picotte                                           ', N'Sarah                                             ')
SET IDENTITY_INSERT [dbo].[Medecin] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (1, CAST(N'1920-01-01' AS Date), N'Langdeau                                          ', N'Robert                                            ', N'123 rosiers                                                                                         ', N'Terrebonne                                        ', N'Qc                                                ', N'T7R 9E9   ', N'654-654-6544        ', 1)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (2, CAST(N'1930-01-01' AS Date), N'Forget                                            ', N'Bob                                               ', N'234 petunias                                                                                        ', N'Montreal                                          ', N'QC                                                ', N'R4E 5R6   ', N'321-321-3213        ', 2)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (3, CAST(N'1940-01-01' AS Date), N'Jeans                                             ', N'Billy                                             ', N'345 Marguerites                                                                                     ', N'Québec                                            ', N'QC                                                ', N'G8R 0E4   ', N'421-654-7894        ', 3)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (4, CAST(N'1950-01-01' AS Date), N'Roy                                               ', N'Steve                                             ', N'425 Lilas                                                                                           ', N'Joliette                                          ', N'QC                                                ', N'V8F 8G8   ', N'357-456-9823        ', 4)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (5, CAST(N'1960-01-01' AS Date), N'Noel                                              ', N'Pere                                              ', N'1 Pole Nord                                                                                         ', N'Pole Nord                                         ', N'QC                                                ', N'H0H 0H0   ', N'777-777-7777        ', 5)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (6, CAST(N'1970-01-01' AS Date), N'Berthier                                          ', N'Rémi                                              ', N'223 Muguets                                                                                         ', N'Alma                                              ', N'QC                                                ', N'R5T 6Y7   ', N'888-888-8888        ', 6)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (7, CAST(N'1980-01-01' AS Date), N'Bérubé                                            ', N'Aline                                             ', N'954 Brasier                                                                                         ', N'Laval                                             ', N'QC                                                ', N'X9E 6R5   ', N'999-999-9999        ', 1)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (8, CAST(N'1980-01-01' AS Date), N'Descanettes                                       ', N'Yvan                                              ', N'145 Joliette                                                                                        ', N'Rigaud                                            ', N'QC                                                ', N'D4R 5F6   ', N'111-111-1111        ', 1)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (9, CAST(N'1990-01-01' AS Date), N'Gagné                                             ', N'Denise                                            ', N'42 Cannelle                                                                                         ', N'Banff                                             ', N'AB                                                ', N'Z9Z 9Z9   ', N'222-222-2222        ', 2)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (10, CAST(N'2000-01-01' AS Date), N'Tremblay                                          ', N'Justine                                           ', N'47 Érables                                                                                          ', N'Gaspé                                             ', N'QC                                                ', N'B7R 9T5   ', N'333-333-3333        ', 3)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (11, CAST(N'2010-01-01' AS Date), N'Roy                                               ', N'PeeWee                                            ', N'32 Merisiers                                                                                        ', N'Lévis                                             ', N'QC                                                ', N'G6V 5K7   ', N'444-444-4444        ', 4)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (12, CAST(N'2020-01-01' AS Date), N'Garon                                             ', N'Georges                                           ', N'1 Mélèzes                                                                                           ', N'Sorel                                             ', N'QC                                                ', N'F6F 7F9   ', N'555-555-5555        ', 5)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (13, CAST(N'2022-01-01' AS Date), N'Isis                                              ', N'Osiris                                            ', N'777 Rêves                                                                                           ', N'Hawai                                             ', N'QC                                                ', N'Z9Z 9Z9   ', N'666-666-6666        ', 1)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (14, CAST(N'2022-10-02' AS Date), N'martin                                            ', N'martin                                            ', N'12 des cougars                                                                                      ', N'loin                                              ', N'qc                                                ', N'h0h0h0    ', N'1231231234          ', 1)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (15, CAST(N'2022-01-30' AS Date), N'mom                                               ', N'boucher                                           ', N'12 des violettes                                                                                    ', N'lévis                                             ', N'qc                                                ', N'h0h0h0    ', N'4584584587          ', 1)
INSERT [dbo].[Patient] ([NSS], [date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (16, CAST(N'2022-10-11' AS Date), N'asdf                                              ', N'sad                                               ', N'                                                                                                    ', N'asd                                               ', N'asd                                               ', N'          ', N'                    ', 1)
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[Type_Lit] ON 

INSERT [dbo].[Type_Lit] ([IDType], [description]) VALUES (1, N'Public                   ')
INSERT [dbo].[Type_Lit] ([IDType], [description]) VALUES (2, N'Semi-Privée              ')
INSERT [dbo].[Type_Lit] ([IDType], [description]) VALUES (3, N'Privée                   ')
SET IDENTITY_INSERT [dbo].[Type_Lit] OFF
GO
ALTER TABLE [dbo].[Admission]  WITH CHECK ADD  CONSTRAINT [FK_Admission_Lit] FOREIGN KEY([Numero_lit])
REFERENCES [dbo].[Lit] ([Numero_lit])
GO
ALTER TABLE [dbo].[Admission] CHECK CONSTRAINT [FK_Admission_Lit]
GO
ALTER TABLE [dbo].[Admission]  WITH CHECK ADD  CONSTRAINT [FK_Admission_Medecin] FOREIGN KEY([IDMedecin])
REFERENCES [dbo].[Medecin] ([IDMedecin])
GO
ALTER TABLE [dbo].[Admission] CHECK CONSTRAINT [FK_Admission_Medecin]
GO
ALTER TABLE [dbo].[Admission]  WITH CHECK ADD  CONSTRAINT [FK_Admission_Patient] FOREIGN KEY([NSS])
REFERENCES [dbo].[Patient] ([NSS])
GO
ALTER TABLE [dbo].[Admission] CHECK CONSTRAINT [FK_Admission_Patient]
GO
ALTER TABLE [dbo].[Lit]  WITH CHECK ADD  CONSTRAINT [FK_Lit_Departement] FOREIGN KEY([IDDepartement])
REFERENCES [dbo].[Departement] ([IDDepartement])
GO
ALTER TABLE [dbo].[Lit] CHECK CONSTRAINT [FK_Lit_Departement]
GO
ALTER TABLE [dbo].[Lit]  WITH CHECK ADD  CONSTRAINT [FK_Lit_Type_Lit] FOREIGN KEY([IDType])
REFERENCES [dbo].[Type_Lit] ([IDType])
GO
ALTER TABLE [dbo].[Lit] CHECK CONSTRAINT [FK_Lit_Type_Lit]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Assurance] FOREIGN KEY([IDAssurance])
REFERENCES [dbo].[Assurance] ([IDAssurance])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Assurance]
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
         Configuration = "(H (1 [50] 2 [25] 3))"
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
         Configuration = "(H (2 [66] 3))"
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
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Admission"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Lit"
            Begin Extent = 
               Top = 6
               Left = 286
               Bottom = 136
               Right = 456
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Medecin"
            Begin Extent = 
               Top = 6
               Left = 494
               Bottom = 119
               Right = 664
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patient"
            Begin Extent = 
               Top = 6
               Left = 702
               Bottom = 136
               Right = 872
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 1440
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1395
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AdminLitMedPatient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AdminLitMedPatient'
GO
USE [master]
GO
ALTER DATABASE [Northern_Lights_Hospital] SET  READ_WRITE 
GO
