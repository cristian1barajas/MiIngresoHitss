USE MiIngresoHitss;

-- Insertar datos en la tabla Productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock) VALUES
('Producto A', 'Descripción del Producto A', 100.00, 10),
('Producto B', 'Descripción del Producto B', 150.00, 20),
('Producto C', 'Descripción del Producto C', 200.00, 15);

-- Insertar datos en la tabla Clientes
INSERT INTO Clientes (Nombre, Email, Telefono) VALUES
('Cliente 1', 'cliente1@example.com', '123456789'),
('Cliente 2', 'cliente2@example.com', '987654321'),
('Cliente 3', 'cliente3@example.com', '456123789');

-- Insertar datos en la tabla ListasPrecios
INSERT INTO ListasPrecios (Nombre, FechaCreacion) VALUES
('Lista de Precios 1', GETDATE()),
('Lista de Precios 2', GETDATE());

-- Insertar datos en la tabla ProductoListaPrecio
INSERT INTO ProductoListaPrecios (ProductoID, ListaPrecioID, Precio) VALUES
(1, 1, 90.00),
(2, 1, 135.00),
(3, 2, 180.00);

-- Insertar datos en la tabla Ventas
INSERT INTO Ventas (ProductoID, ClienteID, FechaVenta, Cantidad, Total) VALUES
(1, 1, GETDATE(), 2, 180.00),
(2, 2, GETDATE(), 1, 150.00),
(3, 3, GETDATE(), 3, 600.00);
