IF NOT EXISTS(SELECT * FROM sys.databases WHERE name='universidad')
BEGIN
CREATE DATABASE [universidad]
END;
GO

USE [universidad];
GO

CREATE  TABLE universidad.dbo.curso ( 
	id_curso             int      NOT NULL,
	nombre               nvarchar(max)      NOT NULL,
	semestre             nvarchar(50)      NOT NULL,
	valor_creditos       nvarchar(50)      NOT NULL,
	CONSTRAINT pk_curso PRIMARY KEY  ( id_curso ) 
 );
GO

CREATE  TABLE universidad.dbo.estudiante ( 
	carnet               nvarchar(50)      NOT NULL,
	nombres              nvarchar(max)      NOT NULL,
	apellidos            nvarchar(max)      NOT NULL,
	carrera              nvarchar(100)      NOT NULL,
	correo               nvarchar(100)      NOT NULL,
	telefono             nvarchar(50)      NOT NULL,
	genero               nvarchar(50)      NOT NULL,
	fecha_ingreso        date      NOT NULL,
	CONSTRAINT pk_estudiante PRIMARY KEY  ( carnet ) 
 );
GO

CREATE  TABLE universidad.dbo.asignacion ( 
	id_asignacion        int    IDENTITY(1,1)  NOT NULL,
	carnet               nvarchar(50)      NOT NULL,
	id_curso             int      NOT NULL,
	seccion              nvarchar(50)      NOT NULL,
	fecha_realizacion    date      NOT NULL,
	semestre             nvarchar(50)      NOT NULL,
	anho                 nvarchar(10)      NOT NULL,
	CONSTRAINT pk_asignacion PRIMARY KEY  ( id_asignacion ) 
 );
GO

ALTER TABLE universidad.dbo.asignacion ADD CONSTRAINT fk_asignacion_curso FOREIGN KEY ( id_curso ) REFERENCES universidad.dbo.curso( id_curso );
GO

ALTER TABLE universidad.dbo.asignacion ADD CONSTRAINT fk_asignacion_estudiante FOREIGN KEY ( carnet ) REFERENCES universidad.dbo.estudiante( carnet );
GO

INSERT INTO universidad.dbo.curso( id_curso, nombre, semestre, valor_creditos ) VALUES ( 111, 'Anatomia', 'Tercero', '3');
INSERT INTO universidad.dbo.curso( id_curso, nombre, semestre, valor_creditos ) VALUES ( 245, 'Matematicas', 'Tercero', '3');
INSERT INTO universidad.dbo.curso( id_curso, nombre, semestre, valor_creditos ) VALUES ( 456, 'Biologia', 'Tercero', '3');
INSERT INTO universidad.dbo.estudiante( carnet, nombres, apellidos, carrera, correo, telefono, genero, fecha_ingreso ) VALUES ( '201825167', 'Laura', 'Angelica', 'Enfermeria', 'laura@mail.edu', '45475234', 'Femenino', '2018-01-01');
INSERT INTO universidad.dbo.estudiante( carnet, nombres, apellidos, carrera, correo, telefono, genero, fecha_ingreso ) VALUES ( '201825865', 'Susan', 'Regina', 'Enfermeria', 'susan@mail.edu', '45341234', 'Femenino', '2018-01-01');
INSERT INTO universidad.dbo.estudiante( carnet, nombres, apellidos, carrera, correo, telefono, genero, fecha_ingreso ) VALUES ( '201845244', 'Maria', 'Antonieta', 'Enfermeria', 'maria@mail.edu', '41641234', 'Femenino', '2018-01-01');
