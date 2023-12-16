-- =============================================
-- Author:		Mario Beltran
-- Create Date: 2023/11/1
-- Description: Procedimientos tabla Users
-- =============================================
PRINT 'Creacion procedimientos tabla Users'
IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME LIKE 'db_sp_Users%')
BEGIN
    DROP PROCEDURE dbo.db_sp_Users_Get
	DROP PROCEDURE dbo.db_sp_Users_Set
	DROP PROCEDURE dbo.db_sp_Users_Det
	DROP PROCEDURE dbo.db_sp_Users_Active
END

PRINT 'Creacion procedimiento usuario Get '
GO
CREATE PROCEDURE dbo.db_sp_Users_Get
	@Id								VARCHAR(36),
	@Nombre                         VARCHAR(1000),
	@Usuario 						VARCHAR(40),
	@Usuario_validacion				VARCHAR(40),
	@Contraseña						VARCHAR(60),
	@Contraseña_validacion			VARCHAR(60),
	@Rol							VARCHAR(200),
	@Estado							INT 
AS 
BEGIN
	SELECT Id, Nombre, Usuario, Contraseña, Rol, Estado, Eliminado, Fecha_log		
		FROM dbo.Users
		WHERE Id = CASE WHEN ISNULL(@Id,'')='' THEN Id ELSE @Id END
		AND Nombre LIKE CASE WHEN ISNULL(@Nombre,'')='' THEN Nombre ELSE '%'+@Nombre+'%' END
		AND Usuario LIKE CASE WHEN ISNULL(@Usuario,'')='' THEN Usuario ELSE '%'+@Usuario+'%' END
		AND Usuario = CASE WHEN ISNULL(@Usuario_validacion,'')='' THEN Usuario ELSE @Usuario_validacion END
		AND Contraseña LIKE CASE WHEN ISNULL(@Contraseña,'')='' THEN Contraseña ELSE '%'+@Contraseña+'%' END
		AND Contraseña = CASE WHEN ISNULL(@Contraseña_validacion,'')='' THEN Contraseña ELSE @Contraseña_validacion END
		AND Rol LIKE CASE WHEN ISNULL(@Rol,'')='' THEN Rol ELSE '%'+@Rol+'%' END
		AND Estado = CASE WHEN ISNULL(@Estado,0) = 1 THEN 1 ELSE
			CASE WHEN ISNULL(@Estado,0) = 0 THEN 0 ELSE Estado END END
		AND Eliminado = 0
END

PRINT 'Creacion procedimiento usuario Set '
GO
CREATE PROCEDURE dbo.db_sp_Users_Set
	@Id				VARCHAR(36),
	@Nombre         VARCHAR(1000),
	@Usuario 		VARCHAR(40),
	@Contraseña		VARCHAR(60), 
	@Rol			VARCHAR(200), 
	@Estado			BIT,
	@Operacion		VARCHAR(01)
AS
BEGIN
	IF @Operacion = 'I'
	BEGIN
			INSERT INTO dbo.Users(Id,Nombre, Usuario, Contraseña, Rol)
			VALUES(@Id,@Nombre, @Usuario, @Contraseña, @Rol)
	END
	ELSE
	BEGIN
		IF @Operacion = 'A'
		BEGIN
			UPDATE dbo.Users
			SET Nombre = @Nombre, Usuario = @Usuario, Contraseña = @Contraseña, @Rol = Rol, Estado = @Estado
			WHERE Id = @Id
		END
	END
END

PRINT 'Creacion procedimiento usuario Del '
GO
CREATE PROCEDURE dbo.db_sp_Users_Del
	@Id VARCHAR(36)
AS
BEGIN
	UPDATE dbo.Users
	SET Eliminado = 1
	WHERE Id = @Id
END 

PRINT 'Creacion procedimiento usuario Active '
GO
CREATE PROCEDURE dbo.db_sp_Users_Active
	@Id VARCHAR(36),
	@Estado BIT
AS
BEGIN
	UPDATE dbo.Users
	SET Estado = @Estado
	WHERE Id = @Id
END
GO
