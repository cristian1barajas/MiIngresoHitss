-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_EliminarCliente', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_EliminarCliente;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_EliminarCliente
@ClienteID INT
AS
BEGIN
    DELETE FROM Clientes WHERE ClienteID = @ClienteID;
END;
GO
