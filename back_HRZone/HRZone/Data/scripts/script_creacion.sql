-- ==================================================
-- Author:		Mario Beltran
-- Create Date: 9/12/2023
-- Description: creacion de la DB para HRZone
-- ==================================================

PRINT 'creacion de la DB'
IF NOT EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME = 'HRZone')
BEGIN
    CREATE DATABASE HRZone
END 
GO

USE HRZone
GO

PRINT 'creacion de la tabla Users'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'Users')
BEGIN
    CREATE TABLE dbo.Users(
        Id            VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT '', /*id interno del registro*/
        Nombre        VARCHAR(1000) NOT NULL DEFAULT '', /*nombre del usuario*/
        Usuario       VARCHAR(1000) NOT NULL DEFAULT '', /*nombre de usuario de la cuenta*/
        Contraseña    VARCHAR(255) NOT NULL DEFAULT '', /*Contraseña del usuario */
        Rol           VARCHAR(60) NOT NULL DEFAULT 'Cliente', /*Rol del usuario*/
        Estado		  BIT NOT NULL DEFAULT 1, /*id interno del registro*/
		Eliminado	  BIT NOT NULL DEFAULT 0, /*id interno del registro*/
        Fecha_log     SMALLDATETIME DEFAULT CURRENT_TIMESTAMP /*log fecha*/)ON [PRIMARY]
	ALTER TABLE dbo.Users ADD CONSTRAINT 
		PK_Users PRIMARY KEY CLUSTERED (Id) ON [PRIMARY] 
END
GO

PRINT 'creacion de la tabla de HRzone'
IF NOT EXISTS(SELECT NAME FROM sysobjects WHERE NAME = 'HRzone')
BEGIN
	CREATE TABLE dbo.HRzone(
		Id				VARCHAR(36) NOT NULL DEFAULT '', /*id interno del registro*/
        Id_users		VARCHAR(36) NOT NULL DEFAULT '', /*id interno del registro*/
		BMPMax			INTEGER NOT NULL DEFAULT 0, /*nombre del proceso*/	
        Light			FLOAT NOT NULL DEFAULT 0, /*nombre del proceso*/
        Intensive		FLOAT NOT NULL DEFAULT 0, /*nombre del proceso*/
        Aerobic			FLOAT NOT NULL DEFAULT 0, /*nombre del proceso*/
        Anaerobic		FLOAT NOT NULL DEFAULT 0, /*nombre del proceso*/
        VoMax 			FLOAT NOT NULL DEFAULT 0, /*nombre del proceso*/        
		Eliminado		BIT NOT NULL DEFAULT 0, /*id interno del registro*/
        Fecha_log       SMALLDATETIME DEFAULT CURRENT_TIMESTAMP /*log fecha*/) ON [PRIMARY]
	ALTER TABLE dbo.HRzone ADD CONSTRAINT 
		PK_HRzone PRIMARY KEY CLUSTERED (Id) ON [PRIMARY]
   ALTER TABLE dbo.HRzone ADD CONSTRAINT
		FK_HRzone_user FOREIGN KEY (Id_users) REFERENCES dbo.Users(Id)
END 
GO