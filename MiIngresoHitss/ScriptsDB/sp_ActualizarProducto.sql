-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_ActualizarProducto', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_ActualizarProducto;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_ActualizarProducto
@ProductoID INT,
@Nombre NVARCHAR(100),
@Descripcion NVARCHAR(500),
@Precio DECIMAL(18,2),
@Stock INT
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock
    WHERE ProductoID = @ProductoID;
END;
GO
