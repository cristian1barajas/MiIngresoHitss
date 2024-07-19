-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_EliminarListaPrecio', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_EliminarListaPrecio;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_EliminarListaPrecio
@ListaPrecioID INT
AS
BEGIN
    DELETE FROM ListasPrecios WHERE ListaPrecioID = @ListaPrecioID;
END;
GO
