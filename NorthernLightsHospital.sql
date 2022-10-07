USE [Northern_Lights_Hospital]
GO
/****** Object:  Table [dbo].[Admission]    Script Date: 2022-09-29 18:26:14 ******/
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
/****** Object:  Table [dbo].[Assurance]    Script Date: 2022-09-29 18:26:14 ******/
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
/****** Object:  Table [dbo].[Departement]    Script Date: 2022-09-29 18:26:14 ******/
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
/****** Object:  Table [dbo].[Lit]    Script Date: 2022-09-29 18:26:14 ******/
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
/****** Object:  Table [dbo].[Medecin]    Script Date: 2022-09-29 18:26:14 ******/
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
/****** Object:  Table [dbo].[Patient]    Script Date: 2022-09-29 18:26:14 ******/
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
/****** Object:  Table [dbo].[Type_Lit]    Script Date: 2022-09-29 18:26:14 ******/
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
INSERT [dbo].[Assurance] ([nom_compagnie]) VALUES (N'Pas assuré                                        ')
INSERT [dbo].[Assurance] ([nom_compagnie]) VALUES (N'Croix Bleue                                       ')
INSERT [dbo].[Assurance] ([nom_compagnie]) VALUES (N'Desjardins                                        ')
INSERT [dbo].[Assurance] ([nom_compagnie]) VALUES (N'Manuvie                                           ')
INSERT [dbo].[Assurance] ([nom_compagnie]) VALUES (N'Sunlife                                           ')
INSERT [dbo].[Assurance] ([nom_compagnie]) VALUES (N'RAMQ                                              ')
GO
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'anesthésiologie                                   ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'médecine de laboratoire                           ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'chirurgie                                         ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'imagerie médicale                                 ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'médecine                                          ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'médecine dentaire                                 ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'médecine générale                                 ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'médecine préventive                               ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'médecine d''urgence                                ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'obstétrique et de gynécologie                     ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'pédiatrie                                         ')
INSERT [dbo].[Departement] ([nom_departement]) VALUES (N'pharmacie                                         ')
GO
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 1, 1)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 1, 2)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 1, 3)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 2, 4)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 2, 5)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 2, 6)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 3, 7)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 3, 8)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 3, 9)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 1, 10)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 2, 11)
INSERT [dbo].[Lit] ([occupe], [IDType], [IDDepartement]) VALUES (0, 3, 12)
GO
INSERT [dbo].[Medecin] ([nom], [prenom]) VALUES (N'Gagnon                                            ', N'Guylaine                                          ')
INSERT [dbo].[Medecin] ([nom], [prenom]) VALUES (N'Charron                                           ', N'Roger                                             ')
INSERT [dbo].[Medecin] ([nom], [prenom]) VALUES (N'Larivière                                         ', N'Ethan                                             ')
INSERT [dbo].[Medecin] ([nom], [prenom]) VALUES (N'Picotte                                           ', N'Sarah                                             ')
GO
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1920-01-01' AS Date), N'Langdeau                                          ', N'Robert                                            ', N'123 rosiers                                                                                         ', N'Terrebonne                                        ', N'Qc                                                ', N'T7R 9E9   ', N'654-654-6544        ', 1)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1930-01-01' AS Date), N'Forget                                            ', N'Bob                                               ', N'234 petunias                                                                                        ', N'Montreal                                          ', N'QC                                                ', N'R4E 5R6   ', N'321-321-3213        ', 2)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1940-01-01' AS Date), N'Jeans                                             ', N'Billy                                             ', N'345 Marguerites                                                                                     ', N'Québec                                            ', N'QC                                                ', N'G8R 0E4   ', N'421-654-7894        ', 3)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1950-01-01' AS Date), N'Roy                                               ', N'Steve                                             ', N'425 Lilas                                                                                           ', N'Joliette                                          ', N'QC                                                ', N'V8F 8G8   ', N'357-456-9823        ', 4)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1960-01-01' AS Date), N'Noel                                              ', N'Pere                                              ', N'1 Pole Nord                                                                                         ', N'Pole Nord                                         ', N'QC                                                ', N'H0H 0H0   ', N'777-777-7777        ', 5)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1970-01-01' AS Date), N'Berthier                                          ', N'Rémi                                              ', N'223 Muguets                                                                                         ', N'Alma                                              ', N'QC                                                ', N'R5T 6Y7   ', N'888-888-8888        ', 6)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1980-01-01' AS Date), N'Bérubé                                            ', N'Aline                                             ', N'954 Brasier                                                                                         ', N'Laval                                             ', N'QC                                                ', N'X9E 6R5   ', N'999-999-9999        ', 1)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1980-01-01' AS Date), N'Descanettes                                       ', N'Yvan                                              ', N'145 Joliette                                                                                        ', N'Rigaud                                            ', N'QC                                                ', N'D4R 5F6   ', N'111-111-1111        ', 1)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'1990-01-01' AS Date), N'Gagné                                             ', N'Denise                                            ', N'42 Cannelle                                                                                         ', N'Banff                                             ', N'AB                                                ', N'Z9Z 9Z9   ', N'222-222-2222        ', 2)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'2000-01-01' AS Date), N'Tremblay                                          ', N'Justine                                           ', N'47 Érables                                                                                          ', N'Gaspé                                             ', N'QC                                                ', N'B7R 9T5   ', N'333-333-3333        ', 3)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'2010-01-01' AS Date), N'Roy                                               ', N'PeeWee                                            ', N'32 Merisiers                                                                                        ', N'Lévis                                             ', N'QC                                                ', N'G6V 5K7   ', N'444-444-4444        ', 4)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'2020-01-01' AS Date), N'Garon                                             ', N'Georges                                           ', N'1 Mélèzes                                                                                           ', N'Sorel                                             ', N'QC                                                ', N'F6F 7F9   ', N'555-555-5555        ', 5)
INSERT [dbo].[Patient] ([date_naissance], [nom], [prenom], [adresse], [ville], [province], [code_postal], [telephone], [IDAssurance]) VALUES (CAST(N'2022-01-01' AS Date), N'Isis                                              ', N'Osiris                                            ', N'777 Rêves                                                                                           ', N'Hawai                                             ', N'QC                                                ', N'Z9Z 9Z9   ', N'666-666-6666        ', 1)
GO
INSERT [dbo].[Type_Lit] ([description]) VALUES (N'Public                   ')
INSERT [dbo].[Type_Lit] ([description]) VALUES (N'Semi-Privée              ')
INSERT [dbo].[Type_Lit] ([description]) VALUES (N'Privée                   ')
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