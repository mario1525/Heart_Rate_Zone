-- ========================================================
-- Author:		Mario Beltran
-- Create Date: 9/12/2023
-- Description: Procedimientos Almacenados tabla HRzone
-- ========================================================
PRINT 'Creacion procedimientos tabla dbo.Productos'
IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME LIKE 'db_sp_Productos%')
BEGIN
	DROP PROCEDURE dbo.db_sp_HRzone_Get
	DROP PROCEDURE dbo.db_sp_HRzone_Set
	DROP PROCEDURE dbo.db_sp_HRzone_Del
	DROP PROCEDURE dbo.db_sp_HRzone_Active
END

PRINT 'Creacion procedimiento get'
GO

CREATE PROCEDURE dbo.db_sp_HRzone_Get
	@Id					VARCHAR(36),
	@Id_users			VARCHAR(36), 
	@BMPMax				INTEGER ,
    @Light				FLOAT , 
    @Intensive			FLOAT, 
    @Aerobic			FLOAT , 
    @Anaerobic			FLOAT , 
    @VoMax				FLOAT
AS 
BEGIN
	SELECT Id, Id_users, BMPMax, Light, Intensive, Aerobic, Anaerobic, VoMax, Fecha_log, Eliminado		
	FROM dbo.HRzone
	WHERE (Id = ISNULL(@Id, Id) OR ISNULL(@Id, '') = '')
	AND (Id_users = ISNULL(@Id_users, Id_users) OR ISNULL(@Id_users, '') = '')
	AND (BMPMax = ISNULL(@BMPMax, BMPMax) OR ISNULL(@BMPMax, '') = '')
	AND (Light = ISNULL(@Light, Light) OR ISNULL(@Light, '') = '')
	AND (Intensive = ISNULL(@Intensive, Intensive) OR ISNULL(@Intensive, '') = '')
	AND (Aerobic = ISNULL(@Aerobic, Aerobic) OR ISNULL(@Aerobic, '') = '')
	AND (Anaerobic = ISNULL(@Anaerobic, Anaerobic) OR ISNULL(@Anaerobic, '') = '')
	AND (VoMax = ISNULL(@VoMax, VoMax) OR ISNULL(@VoMax, '') = '')
	AND Eliminado = 0
END


PRINT 'Creacion procedimiento set'
GO
CREATE PROCEDURE dbo.db_sp_HRzone_Set
	@Id					VARCHAR(36),
	@Id_users			VARCHAR(36), 
	@BMPMax				INTEGER ,
    @Light				FLOAT , 
    @Intensive			FLOAT, 
    @Aerobic			FLOAT , 
    @Anaerobic			FLOAT , 
    @VoMax				FLOAT,
	@Operacion			VARCHAR(01)
AS
BEGIN
	IF @Operacion = 'I'
	BEGIN
			INSERT INTO dbo.HRzone(Id, Id_users, BMPMax, Light, Intensive, Aerobic, Anaerobic, VoMax)
			VALUES(@Id, @Id_users, @BMPMax, @Light, @Intensive, @Aerobic, @Anaerobic, @VoMax)
	END
	ELSE
	BEGIN
		IF @Operacion = 'A'
		BEGIN
			UPDATE dbo.HRzone
			SET Id_users = @Id_users, BMPMax = @BMPMax, Light =  @Light, Intensive = @Intensive, Aerobic = @Aerobic, Anaerobic = @Anaerobic, VoMax = @VoMax
			WHERE Id = @Id
		END
	END
END

PRINT 'Creacion procedimiento Del'
GO
CREATE PROCEDURE dbo.db_sp_HRzone_Del
	@Id VARCHAR(36)
AS
BEGIN
	UPDATE dbo.HRzone
	SET Eliminado = 1
	WHERE Id = @Id
END 

