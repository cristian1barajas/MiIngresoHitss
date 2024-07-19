-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_ActualizarCliente', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_ActualizarCliente;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_ActualizarCliente
@ClienteID INT,
@Nombre NVARCHAR(100),
@Email NVARCHAR(100),
@Telefono NVARCHAR(20)
AS
BEGIN
    UPDATE Clientes
    SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono
    WHERE ClienteID = @ClienteID;
END;
GO
