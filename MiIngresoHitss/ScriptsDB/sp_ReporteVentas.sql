-- Validar si el procedimiento almacenado existe y eliminarlo
IF OBJECT_ID('sp_ReporteVentas', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE sp_ReporteVentas;
END
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE sp_ReporteVentas
@FechaInicio DATE,
@FechaFin DATE
AS
BEGIN
    SELECT v.VentaID, v.FechaVenta, v.Cantidad, v.Total, c.Nombre AS Cliente, p.Nombre AS Producto
    FROM Ventas v
    INNER JOIN Clientes c ON v.ClienteID = c.ClienteID
    INNER JOIN Productos p ON v.ProductoID = p.ProductoID
    WHERE v.FechaVenta BETWEEN @FechaInicio AND @FechaFin;
END;
GO
