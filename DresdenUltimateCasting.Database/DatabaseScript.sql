USE [DUCCADB]
GO
/****** Object:  Table [dbo].[ActorImages]    Script Date: 2/14/2020 11:54:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorImages](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ActorId] [int] NOT NULL,
	[ImageUrl] [varchar](500) NULL,
	[DisplayOrder] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 2/14/2020 11:54:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[CharacterId] [int] NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
	[AlsoKnownFor] [nvarchar](255) NULL,
	[Description] [nvarchar](510) NULL,
	[RankOrder] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 2/14/2020 11:54:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[CharacterId] [int] IDENTITY(1,1) NOT NULL,
	[FactionId] [int] NOT NULL,
	[CharacterName] [nvarchar](120) NOT NULL,
	[CharacterDescription] [nvarchar](765) NULL,
	[CharacterNotes] [nvarchar](510) NULL,
PRIMARY KEY CLUSTERED 
(
	[CharacterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterTags]    Script Date: 2/14/2020 11:54:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterTags](
	[CharacterId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_CharacterTags] PRIMARY KEY CLUSTERED 
(
	[CharacterId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factions]    Script Date: 2/14/2020 11:54:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factions](
	[FactionId] [int] IDENTITY(1,1) NOT NULL,
	[FactionName] [nvarchar](125) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[FactionDescription] [nvarchar](510) NULL,
PRIMARY KEY CLUSTERED 
(
	[FactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 2/14/2020 11:54:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [varchar](50) NOT NULL,
	[TagDescription] [varchar](510) NULL,
PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActorImages] ADD  DEFAULT ((1)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Actors] ADD  DEFAULT ((1)) FOR [RankOrder]
GO
ALTER TABLE [dbo].[ActorImages]  WITH CHECK ADD  CONSTRAINT [FK_ActorImages_ToActors] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([ActorId])
GO
ALTER TABLE [dbo].[ActorImages] CHECK CONSTRAINT [FK_ActorImages_ToActors]
GO
ALTER TABLE [dbo].[Actors]  WITH CHECK ADD  CONSTRAINT [FK_Actors_ToCharacters] FOREIGN KEY([CharacterId])
REFERENCES [dbo].[Characters] ([CharacterId])
GO
ALTER TABLE [dbo].[Actors] CHECK CONSTRAINT [FK_Actors_ToCharacters]
GO
ALTER TABLE [dbo].[Characters]  WITH CHECK ADD  CONSTRAINT [FK_Characters_ToFaction] FOREIGN KEY([FactionId])
REFERENCES [dbo].[Factions] ([FactionId])
GO
ALTER TABLE [dbo].[Characters] CHECK CONSTRAINT [FK_Characters_ToFaction]
GO
ALTER TABLE [dbo].[CharacterTags]  WITH CHECK ADD  CONSTRAINT [FK_CharacterTags_ToCharacters] FOREIGN KEY([CharacterId])
REFERENCES [dbo].[Characters] ([CharacterId])
GO
ALTER TABLE [dbo].[CharacterTags] CHECK CONSTRAINT [FK_CharacterTags_ToCharacters]
GO
ALTER TABLE [dbo].[CharacterTags]  WITH CHECK ADD  CONSTRAINT [FK_CharacterTags_ToTags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([TagId])
GO
ALTER TABLE [dbo].[CharacterTags] CHECK CONSTRAINT [FK_CharacterTags_ToTags]
GO
