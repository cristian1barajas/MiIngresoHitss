-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_ObtenerListasPrecios', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_ObtenerListasPrecios;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_ObtenerListasPrecios
AS
BEGIN
    SELECT * FROM ListasPrecios;
END;
GO
