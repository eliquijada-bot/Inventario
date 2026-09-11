CREATE DATABASE InventarioDB;
GO

USE InventarioDB;
GO

CREATE TABLE Categorias
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Productos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    CategoriaId INT NOT NULL,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);
GO