-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_InsertarProducto', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_InsertarProducto;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_InsertarProducto
@Nombre NVARCHAR(100),
@Descripcion NVARCHAR(500),
@Precio DECIMAL(18,2),
@Stock INT
AS
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Precio, Stock)
    VALUES (@Nombre, @Descripcion, @Precio, @Stock);
END;
GO
