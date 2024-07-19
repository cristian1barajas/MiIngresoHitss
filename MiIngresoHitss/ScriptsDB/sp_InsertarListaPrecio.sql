-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_InsertarListaPrecio', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_InsertarListaPrecio;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_InsertarListaPrecio
@Nombre NVARCHAR(100),
@FechaCreacion DATE
AS
BEGIN
    INSERT INTO ListasPrecios (Nombre, FechaCreacion)
    VALUES (@Nombre, @FechaCreacion);
END;
GO
