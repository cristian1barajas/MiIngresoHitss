-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_ActualizarListaPrecio', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_ActualizarListaPrecio;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_ActualizarListaPrecio
@ListaPrecioID INT,
@Nombre NVARCHAR(100),
@FechaCreacion DATE
AS
BEGIN
    UPDATE ListasPrecios
    SET Nombre = @Nombre, FechaCreacion = @FechaCreacion
    WHERE ListaPrecioID = @ListaPrecioID;
END;
GO
