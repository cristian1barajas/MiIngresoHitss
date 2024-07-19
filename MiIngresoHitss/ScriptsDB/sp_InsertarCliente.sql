-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_InsertarCliente', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_InsertarCliente;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_InsertarCliente
@Nombre NVARCHAR(100),
@Email NVARCHAR(100),
@Telefono NVARCHAR(20)
AS
BEGIN
    INSERT INTO Clientes (Nombre, Email, Telefono)
    VALUES (@Nombre, @Email, @Telefono);
END;
GO
