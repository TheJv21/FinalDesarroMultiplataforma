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

CREATE PROCEDURE eliminar_asignacion
    @id_asignacion INT
AS
BEGIN
    DELETE FROM asignacion
    WHERE id_asignacion = @id_asignacion;
END;;
GO

CREATE PROCEDURE eliminar_curso
    @id_curso INT
AS
BEGIN
    DELETE FROM curso
    WHERE id_curso = @id_curso;
END;;
GO

CREATE PROCEDURE eliminar_estudiante
    @carnet NVARCHAR(50)
AS
BEGIN
    DELETE FROM estudiante
    WHERE carnet = @carnet;
END;;
GO

CREATE PROCEDURE listar_asignacion
AS
BEGIN
    SELECT * FROM asignacion;
END;;
GO

CREATE PROCEDURE listar_curso
AS
BEGIN
    SELECT * FROM curso;
END;;
GO

CREATE PROCEDURE listar_estudiante
AS
BEGIN
    SELECT * FROM estudiante;
END;;
GO

CREATE PROCEDURE modificar_asignacion
    @id_asignacion INT,
    @carnet NVARCHAR(50),
    @id_curso INT,
    @seccion NVARCHAR(50),
    @fecha_realizacion DATE,
    @semestre NVARCHAR(50),
    @anho NVARCHAR(10)
AS
BEGIN
    UPDATE asignacion
    SET carnet = @carnet,
        id_curso = @id_curso,
        seccion = @seccion,
        fecha_realizacion = @fecha_realizacion,
        semestre = @semestre,
        anho = @anho
    WHERE id_asignacion = @id_asignacion;
END;;
GO

CREATE PROCEDURE modificar_curso
    @id_curso INT,
    @nombre NVARCHAR(MAX),
    @semestre NVARCHAR(50),
    @valor_creditos NVARCHAR(50)
AS
BEGIN
    UPDATE curso
    SET nombre = @nombre,
        semestre = @semestre,
        valor_creditos = @valor_creditos
    WHERE id_curso = @id_curso;
END;;
GO

CREATE PROCEDURE modificar_estudiante
    @carnet NVARCHAR(50),
    @nombres NVARCHAR(MAX),
    @apellidos NVARCHAR(MAX),
    @carrera NVARCHAR(100),
    @correo NVARCHAR(100),
    @telefono NVARCHAR(50),
    @genero NVARCHAR(50),
    @fecha_ingreso DATE
AS
BEGIN
    UPDATE estudiante
    SET nombres = @nombres,
        apellidos = @apellidos,
        carrera = @carrera,
        correo = @correo,
        telefono = @telefono,
        genero = @genero,
        fecha_ingreso = @fecha_ingreso
    WHERE carnet = @carnet;
END;;
GO

CREATE PROCEDURE registrar_asignacion
    @carnet NVARCHAR(50),
    @id_curso INT,
    @seccion NVARCHAR(50),
    @fecha_realizacion DATE,
    @semestre NVARCHAR(50),
    @anho NVARCHAR(10)
AS
BEGIN
    INSERT INTO asignacion (carnet, id_curso, seccion, fecha_realizacion, semestre, anho)
    VALUES (@carnet, @id_curso, @seccion, @fecha_realizacion, @semestre, @anho);
END;;
GO

CREATE PROCEDURE registrar_curso
    @id_curso INT,
    @nombre NVARCHAR(MAX),
    @semestre NVARCHAR(50),
    @valor_creditos NVARCHAR(50)
AS
BEGIN
    INSERT INTO curso (id_curso, nombre, semestre, valor_creditos)
    VALUES (@id_curso, @nombre, @semestre, @valor_creditos);
END;;
GO

CREATE PROCEDURE registrar_estudiante
    @carnet NVARCHAR(50),
    @nombres NVARCHAR(MAX),
    @apellidos NVARCHAR(MAX),
    @carrera NVARCHAR(100),
    @correo NVARCHAR(100),
    @telefono NVARCHAR(50),
    @genero NVARCHAR(50),
    @fecha_ingreso DATE
AS
BEGIN
    INSERT INTO estudiante (carnet, nombres, apellidos, carrera, correo, telefono, genero, fecha_ingreso)
    VALUES (@carnet, @nombres, @apellidos, @carrera, @correo, @telefono, @genero, @fecha_ingreso);
END;;
GO

INSERT INTO universidad.dbo.curso( id_curso, nombre, semestre, valor_creditos ) VALUES ( 111, 'Anatomia', 'Tercero', '3');
INSERT INTO universidad.dbo.curso( id_curso, nombre, semestre, valor_creditos ) VALUES ( 245, 'Matematicas', 'Tercero', '3');
INSERT INTO universidad.dbo.curso( id_curso, nombre, semestre, valor_creditos ) VALUES ( 456, 'Biologia', 'Tercero', '3');
INSERT INTO universidad.dbo.estudiante( carnet, nombres, apellidos, carrera, correo, telefono, genero, fecha_ingreso ) VALUES ( '201825167', 'Laura', 'Angelica', 'Enfermeria', 'laura@mail.edu', '45475234', 'Femenino', '2018-01-01');
INSERT INTO universidad.dbo.estudiante( carnet, nombres, apellidos, carrera, correo, telefono, genero, fecha_ingreso ) VALUES ( '201825865', 'Susan', 'Regina', 'Enfermeria', 'susan@mail.edu', '45341234', 'Femenino', '2018-01-01');
INSERT INTO universidad.dbo.estudiante( carnet, nombres, apellidos, carrera, correo, telefono, genero, fecha_ingreso ) VALUES ( '201845244', 'Maria', 'Antonieta', 'Enfermeria', 'maria@mail.edu', '41641234', 'Femenino', '2018-01-01');
INSERT INTO universidad.dbo.asignacion( carnet, id_curso, seccion, fecha_realizacion, semestre, anho ) VALUES ( '201825865', 111, 'A', '2023-05-22', 'Tercero', '2023');
