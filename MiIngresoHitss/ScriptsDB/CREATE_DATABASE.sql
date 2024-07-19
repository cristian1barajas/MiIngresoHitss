-- Cambiar el contexto a la base de datos master
USE master;
GO

-- Validar si la base de datos existe y eliminarla
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'MiIngresoHitss')
BEGIN
    ALTER DATABASE MiIngresoHitss SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MiIngresoHitss;
END
GO

-- Crear la base de datos
CREATE DATABASE MiIngresoHitss;
GO

USE MiIngresoHitss;
GO

-- Validar si las tablas existen y eliminarlas
IF OBJECT_ID('Ventas', 'U') IS NOT NULL
BEGIN
    DROP TABLE Ventas;
END

IF OBJECT_ID('Clientes', 'U') IS NOT NULL
BEGIN
    DROP TABLE Clientes;
END

IF OBJECT_ID('ListasPrecios', 'U') IS NOT NULL
BEGIN
    DROP TABLE ListasPrecios;
END

IF OBJECT_ID('Productos', 'U') IS NOT NULL
BEGIN
    DROP TABLE Productos;
END
GO

-- Crear tabla Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Precio DECIMAL(18,2),
    Stock INT
);
GO

-- Crear tabla ListasPrecios
CREATE TABLE ListasPrecios (
    ListaPrecioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    FechaCreacion DATE
);
GO

-- Crear tabla Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20)
);
GO

-- Crear tabla Ventas
CREATE TABLE Ventas (
    VentaID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT,
    ClienteID INT,
    FechaVenta DATE,
    Cantidad INT,
    Total DECIMAL(18,2),
    CONSTRAINT FK_Ventas_Producto FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    CONSTRAINT FK_Ventas_Cliente FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);
GO

-- Crear tabla ProductoListaPrecio
CREATE TABLE ProductoListaPrecios (
    ProductoID INT,
    ListaPrecioID INT,
    Precio DECIMAL(18,2),
    CONSTRAINT FK_ProductoListaPrecio_Producto FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    CONSTRAINT FK_ProductoListaPrecio_ListaPrecio FOREIGN KEY (ListaPrecioID) REFERENCES ListasPrecios(ListaPrecioID),
    PRIMARY KEY (ProductoID, ListaPrecioID)
);
GO
