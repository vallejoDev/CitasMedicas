CREATE OR ALTER PROCEDURE [dbo].[CreateParteRole]
    @IdTipoParteRole INT
  , @Nombre NVARCHAR(128)
  , @ApellidoPaterno NVARCHAR(128)
  , @ApellidoMaterno NVARCHAR(128)
  , @Correo NVARCHAR(255)
AS
SET NOCOUNT ON;
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	DECLARE @Id AS UNIQUEIDENTIFIER;
	DECLARE @IdParteRole AS INT;
	SET @Id = NEWID();
	INSERT INTO dbo.Parte
	(
		IdParte
	)
	VALUES
	(@Id);
	INSERT INTO dbo.ParteRole
	(
		IdTipoParteRole
	  , IdParte
	)
	VALUES
	(@IdTipoParteRole, @Id);
	SET @IdParteRole = SCOPE_IDENTITY();
	INSERT INTO dbo.Persona
	(
		IdParte
	  , Nombre
	  , ApellidoPaterno
	  , ApellidoMaterno
	  , Correo
	)
	VALUES
	(@Id, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Correo);
	SELECT @IdParteRole;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
SET NOCOUNT OFF;
GO