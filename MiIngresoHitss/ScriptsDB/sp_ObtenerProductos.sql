-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_ObtenerProductos', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_ObtenerProductos;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SELECT * FROM Productos;
END;
GO
