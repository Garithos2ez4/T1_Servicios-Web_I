CREATE DATABASE LibreriaBD;
GO

-- Usar la base de datos
USE LibreriaBD;
GO

-- Crear tablas
CREATE TABLE Autores (
    AutorID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Nacionalidad NVARCHAR(50)
);

CREATE TABLE Libros (
    LibroID INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(100),
    Genero NVARCHAR(50),
    AñoPublicacion INT,
    ISBN NVARCHAR(20),
    AutorID INT,
    FOREIGN KEY (AutorID) REFERENCES Autores(AutorID)
);


-- Insertar registros
INSERT INTO Autores (Nombre, Nacionalidad)
VALUES ('Gabriel García Márquez', 'Colombiana'),
       ('Isabel Allende', 'Chilena'),
       ('Mario Vargas Llosa', 'Peruana');

INSERT INTO Libros (Titulo, Genero, AñoPublicacion, ISBN, AutorID)
VALUES ('Cien años de soledad', 'Realismo Mágico', 1967, '978-0307474728', 1),
       ('La casa de los espíritus', 'Novela', 1982, '978-0060883287', 2),
       ('La ciudad y los perros', 'Ficción', 1963, '978-8420412179', 3);
GO

-- Hasta aqui llega el script de la T1, aquí en adelante es parte del team 

-- SP de autores
CREATE PROCEDURE sp_ListarAutores AS
BEGIN
    SELECT AutorID, Nombre, Nacionalidad FROM Autores;
END
GO

CREATE PROCEDURE sp_InsertarAutor
    @Nombre NVARCHAR(100),
    @Nacionalidad NVARCHAR(50)
AS
BEGIN
    INSERT INTO Autores (Nombre, Nacionalidad) VALUES (@Nombre, @Nacionalidad);
END
GO

CREATE PROCEDURE sp_EditarAutor
    @AutorID INT,
    @Nombre NVARCHAR(100),
    @Nacionalidad NVARCHAR(50)
AS
BEGIN
    UPDATE Autores SET Nombre = @Nombre, Nacionalidad = @Nacionalidad WHERE AutorID = @AutorID;
END
GO

-- SP de libros
CREATE PROCEDURE sp_ListarLibros AS
BEGIN
    SELECT LibroID, Titulo, Genero, AñoPublicacion, ISBN, AutorID FROM Libros;
END
GO

CREATE PROCEDURE sp_InsertarLibro
    @Titulo NVARCHAR(100),
    @Genero NVARCHAR(50),
    @AñoPublicacion INT,
    @ISBN NVARCHAR(20),
    @AutorID INT
AS
BEGIN
    INSERT INTO Libros (Titulo, Genero, AñoPublicacion, ISBN, AutorID)
    VALUES (@Titulo, @Genero, @AñoPublicacion, @ISBN, @AutorID);
END
GO

CREATE PROCEDURE sp_EditarLibro
    @LibroID INT,
    @Titulo NVARCHAR(100),
    @Genero NVARCHAR(50),
    @AñoPublicacion INT,
    @ISBN NVARCHAR(20),
    @AutorID INT
AS
BEGIN
    UPDATE Libros
    SET Titulo = @Titulo, Genero = @Genero, AñoPublicacion = @AñoPublicacion, ISBN = @ISBN, AutorID = @AutorID
    WHERE LibroID = @LibroID;
END
GO

