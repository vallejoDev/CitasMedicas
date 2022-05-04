CREATE TABLE [dbo].[Parte] (
  [IdParte] uniqueidentifier NOT NULL,
  PRIMARY KEY CLUSTERED ([IdParte])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
CREATE TABLE [dbo].[TipoParteRole] (
  [IdTipoParteRole] int NOT NULL IDENTITY,
  [Nombre] nvarchar(255) NULL,
  PRIMARY KEY CLUSTERED ([IdTipoParteRole])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
CREATE TABLE [dbo].[ParteRole] (
  [IdParteRole] int NOT NULL IDENTITY,
  [IdTipoParteRole] int NULL,
  [IdParte] uniqueidentifier NULL,
  PRIMARY KEY CLUSTERED ([IdParteRole])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
  
)
CREATE TABLE [dbo].[Persona] (
  [IdParte] uniqueidentifier NOT NULL,
  [Nombre] nvarchar(128) NULL,
  [ApellidoPaterno] nvarchar(128) NULL,
  [ApellidoMaterno] nvarchar(128) NULL,
  [Correo] nvarchar(255) NULL,
  PRIMARY KEY CLUSTERED ([IdParte])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
)
CREATE TABLE [dbo].[Logine] (
  [IdLogine] int NOT NULL IDENTITY,
  [IdParte] uniqueidentifier NOT NULL,
  [UserName] nvarchar(255) NULL,
  PRIMARY KEY CLUSTERED ([IdLogine])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
)
CREATE TABLE [dbo].[AgendaMedica] (
  [IdAgenda] int NOT NULL IDENTITY,
  [IdParteRoleDoctor] int NULL,
  [IdParteRolePaciente] int NULL,
  [IdHorario] int NULL,
  [Fecha] date NULL,
  PRIMARY KEY CLUSTERED ([IdAgenda])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
  
)
CREATE TABLE [dbo].[Horario] (
  [IdHorario] int NOT NULL IDENTITY,
  [HoraInicio] int NULL,
  PRIMARY KEY CLUSTERED ([IdHorario])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

ALTER TABLE dbo.ParteRole ADD CONSTRAINT [fk_ParteRole_Parte_1] FOREIGN KEY ([IdParte]) REFERENCES [dbo].[Parte] ([IdParte])
ALTER TABLE dbo.ParteRole ADD CONSTRAINT [fk_ParteRole_TipoParteRole_1] FOREIGN KEY ([IdTipoParteRole]) REFERENCES [dbo].[TipoParteRole] ([IdTipoParteRole])
ALTER TABLE dbo.Persona ADD CONSTRAINT [fk_Persona_Parte_1] FOREIGN KEY ([IdParte]) REFERENCES [dbo].[Parte] ([IdParte])
ALTER TABLE dbo.Logine ADD CONSTRAINT [fk_Logine_Parte_1] FOREIGN KEY ([IdParte]) REFERENCES [dbo].[Parte] ([IdParte])
ALTER TABLE dbo.AgendaMedica ADD CONSTRAINT [fk_AgendaMedica_ParteRole_1] FOREIGN KEY ([IdParteRoleDoctor]) REFERENCES [dbo].[ParteRole] ([IdParteRole])
ALTER TABLE dbo.AgendaMedica ADD CONSTRAINT [fk_AgendaMedica_ParteRole_2] FOREIGN KEY ([IdParteRolePaciente]) REFERENCES [dbo].[ParteRole] ([IdParteRole])
ALTER TABLE dbo.AgendaMedica ADD CONSTRAINT [fk_AgendaMedica_Horario_1] FOREIGN KEY ([IdHorario]) REFERENCES [dbo].[Horario] ([IdHorario])