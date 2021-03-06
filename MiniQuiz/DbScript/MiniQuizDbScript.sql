USE [MiniQuiz]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/25/2020 12:53:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Options]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Options](
	[OptionsId] [int] IDENTITY(1,1) NOT NULL,
	[OptionText] [nvarchar](max) NOT NULL,
	[QuestionId] [int] NOT NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[OptionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](max) NOT NULL,
	[CorrectOption] [int] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAnswers]    Script Date: 8/25/2020 12:53:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAnswers](
	[UserAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[OptionChosen] [int] NOT NULL,
 CONSTRAINT [PK_UserAnswers] PRIMARY KEY CLUSTERED 
(
	[UserAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821212807_initialmig', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200822192204_updatecolumn', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200823221425_User_Details', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200824183543_madecolumnnullable', N'3.1.7')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ef2dd831-18b6-4632-888a-19b5ae6c02d7', N'ife.muyiwa54@gmail.com', N'IFE.MUYIWA54@GMAIL.COM', N'ife.muyiwa54@gmail.com', N'IFE.MUYIWA54@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEA78b/bf80WT5InwnNVifPyp3d5gieQeJpXlhKxbEmukiourJZlCzl1hsyo5DMQasA==', N'LUPVDCXGSN43UTUTZP7FAAI4OUMAOMNB', N'57b1cc6b-1b24-4cdd-afd5-3d2887c8aa9f', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Options] ON 

INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (1006, N'Arica', 2003)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (1007, N'Puente Alto', 2003)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (1008, N'Santiago', 2003)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (1009, N'Antofagasta', 2003)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2010, N'Canada', 3004)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2011, N'Russia', 3004)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2012, N'Nigeria', 3004)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2013, N'Vatican City', 3004)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2014, N'Bill Clinton', 3005)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2015, N'Barack Obama', 3005)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2016, N'Donald Trump', 3005)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2017, N'Andrew Cuomo', 3005)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2018, N'Chickenpox', 3006)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2019, N'Smallpox', 3006)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2020, N'HIV', 3006)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2021, N'COVID-19', 3006)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2022, N'13', 3007)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2023, N'12', 3007)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2024, N'10', 3007)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2025, N'15', 3007)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2026, N'1996', 3008)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2027, N'1970', 3008)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2028, N'1984', 3008)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2029, N'1973', 3008)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2030, N'Negra Modelo', 3009)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2031, N'Modelo Especial', 3009)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2032, N'Corona', 3009)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2033, N'Victoria', 3009)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2034, N'King’s Landing', 3010)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2035, N'Dragonstone', 3010)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2036, N'Winterfell', 3010)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2037, N'Highgarden', 3010)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2038, N'Elvis Presley', 3011)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2039, N'Drake', 3011)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2040, N'Jay-Z', 3011)
INSERT [dbo].[Options] ([OptionsId], [OptionText], [QuestionId]) VALUES (2041, N'Cardi B', 3011)
SET IDENTITY_INSERT [dbo].[Options] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (2003, N'What is the capital of Chile?', 3)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3004, N'What is the smallest country in the world?', 4)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3005, N'who is the president of US?', 3)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3006, N'The first successful vaccine was introduced by Edward Jenner in 1796. Which disease did it guard against?', 2)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3007, N'How many players are there in a rugby league team?', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3008, N' In which year did Britain originally join the EEC, now known as the European Union?', 4)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3009, N'What is the most famous Mexican beer?', 3)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3010, N'What is the capital of Westeros in Game of Thrones?', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuestionText], [CorrectOption]) VALUES (3011, N'Which singer has the most UK Number One singles ever?', 1)
SET IDENTITY_INSERT [dbo].[Questions] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Email]) VALUES (1, N'ife.muyiwa54@gmail.com')
INSERT [dbo].[User] ([UserId], [Email]) VALUES (2, N'JioophoeNIX@outlook.com')
INSERT [dbo].[User] ([UserId], [Email]) VALUES (1002, N'john.ojo@opensourcecomunity.org')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserAnswers] ON 

INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (2, 1, 2003, 3)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (4, 2, 2003, 2)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (7, 1, 3004, 4)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (1002, 1, 3005, 3)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (1003, 1, 3006, 3)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (1004, 1, 3007, 1)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (1005, 1, 3008, 2)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (1006, 1, 3009, 3)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (1007, 1, 3010, 1)
INSERT [dbo].[UserAnswers] ([UserAnswerId], [UserId], [QuestionId], [OptionChosen]) VALUES (1008, 1, 3011, 2)
SET IDENTITY_INSERT [dbo].[UserAnswers] OFF
ALTER TABLE [dbo].[Questions] ADD  DEFAULT ((0)) FOR [CorrectOption]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
