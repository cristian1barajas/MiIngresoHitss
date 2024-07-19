-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_ObtenerClientes', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_ObtenerClientes;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_ObtenerClientes
AS
BEGIN
    SELECT * FROM Clientes;
END;
GO
