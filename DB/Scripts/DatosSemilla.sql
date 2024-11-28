-- Semilla para la tabla Ciudad
INSERT INTO Ciudad (CiudadId, CiudadNombre)
VALUES
    (NEWID(), 'Bogotá'),
    (NEWID(), 'Medellín'),
    (NEWID(), 'Cali'),
    (NEWID(), 'Barranquilla'),
    (NEWID(), 'Cartagena'),
    (NEWID(), 'Manizales'),
    (NEWID(), 'Pereira'),
    (NEWID(), 'Bucaramanga'),
    (NEWID(), 'Ibagué'),
    (NEWID(), 'Villavicencio'),
    (NEWID(), 'Santa Marta'),
    (NEWID(), 'Neiva'),
    (NEWID(), 'Cúcuta'),
    (NEWID(), 'Armenia'),
    (NEWID(), 'Tunja'),
    (NEWID(), 'Popayán'),
    (NEWID(), 'Pasto'),
    (NEWID(), 'Valledupar'),
    (NEWID(), 'Montería'),
    (NEWID(), 'Sincelejo');

-- Semilla para la tabla TipoUsuario
INSERT INTO TipoUsuario (TipoUsuarioId, TipoUsuarioDescripcion)
VALUES
    (NEWID(), 'Cliente'),
    (NEWID(), 'Vendedor');

-- Semilla para la tabla Usuario
DECLARE @CiudadCount INT = (SELECT COUNT(*) FROM Ciudad);
DECLARE @TipoUsuarioClienteId UNIQUEIDENTIFIER = (SELECT TOP 1 TipoUsuarioId FROM TipoUsuario WHERE TipoUsuarioDescripcion = 'Cliente');
DECLARE @TipoUsuarioVendedorId UNIQUEIDENTIFIER = (SELECT TOP 1 TipoUsuarioId FROM TipoUsuario WHERE TipoUsuarioDescripcion = 'Vendedor');

INSERT INTO Usuario (UsuarioId, CiudadId, TipoUsuarioId, UsuarioDocumento, UsuarioNombre, UsuarioApellido, UsuarioCorreo, UsuarioTelefono, UsuarioDireccion)
SELECT TOP 10
    NEWID(),
        (SELECT CiudadId FROM (SELECT TOP 1 CiudadId FROM Ciudad ORDER BY NEWID()) RandomCiudad),
       @TipoUsuarioClienteId,
       '10000000' + CAST(ROW_NUMBER() OVER (ORDER BY NEWID()) AS VARCHAR(5)),
       CONCAT('Cliente', ROW_NUMBER() OVER (ORDER BY NEWID())),
       CONCAT('Apellido', ROW_NUMBER() OVER (ORDER BY NEWID())),
       CONCAT('cliente', ROW_NUMBER() OVER (ORDER BY NEWID()), '@example.com'),
       '300' + RIGHT(CAST(ROW_NUMBER() OVER (ORDER BY NEWID()) + 1000 AS VARCHAR(10)), 7),
    CONCAT('Calle ', ROW_NUMBER() OVER (ORDER BY NEWID()), ' #45-67')
FROM Ciudad;

INSERT INTO Usuario (UsuarioId, CiudadId, TipoUsuarioId, UsuarioDocumento, UsuarioNombre, UsuarioApellido, UsuarioCorreo, UsuarioTelefono, UsuarioDireccion)
SELECT TOP 10
    NEWID(),
        (SELECT CiudadId FROM (SELECT TOP 1 CiudadId FROM Ciudad ORDER BY NEWID()) RandomCiudad),
       @TipoUsuarioVendedorId,
       '20000000' + CAST(ROW_NUMBER() OVER (ORDER BY NEWID()) AS VARCHAR(5)),
       CONCAT('Vendedor', ROW_NUMBER() OVER (ORDER BY NEWID())),
       CONCAT('Apellido', ROW_NUMBER() OVER (ORDER BY NEWID())),
       CONCAT('vendedor', ROW_NUMBER() OVER (ORDER BY NEWID()), '@example.com'),
       '310' + RIGHT(CAST(ROW_NUMBER() OVER (ORDER BY NEWID()) + 1000 AS VARCHAR(10)), 7),
    CONCAT('Carrera ', ROW_NUMBER() OVER (ORDER BY NEWID()), ' #78-89')
FROM Ciudad;

-- Semilla para la tabla EstadoPedido
INSERT INTO EstadoPedido (EstadoPedidoId, EstadoPedidoDescripcion)
VALUES
    (NEWID(), 'Pendiente'),
    (NEWID(), 'Enviado'),
    (NEWID(), 'Entregado');

-- Semilla para la tabla Producto
INSERT INTO Producto (ProductoId, ProductoNombre, ProductoPrecio)
VALUES
    (NEWID(), 'Manzanas', 3000),
    (NEWID(), 'Bananas', 2000),
    (NEWID(), 'Naranjas', 2500),
    (NEWID(), 'Uvas', 5000),
    (NEWID(), 'Mangos', 4000),
    (NEWID(), 'Peras', 3200),
    (NEWID(), 'Papayas', 3500),
    (NEWID(), 'Melones', 4200),
    (NEWID(), 'Sandías', 4500),
    (NEWID(), 'Fresas', 6000),
    (NEWID(), 'Kiwi', 7000),
    (NEWID(), 'Duraznos', 3600),
    (NEWID(), 'Cerezas', 8000),
    (NEWID(), 'Piñas', 3700),
    (NEWID(), 'Limones', 1500),
    (NEWID(), 'Aguacates', 9000),
    (NEWID(), 'Cocos', 5200),
    (NEWID(), 'Ciruelas', 4800),
    (NEWID(), 'Guayabas', 3300),
    (NEWID(), 'Granadillas', 5500);

-- Semilla para la tabla Inventario
INSERT INTO Inventario (InventarioId, VendedorId)
SELECT TOP 10
    NEWID(),
        UsuarioId
FROM Usuario
WHERE TipoUsuarioId = @TipoUsuarioVendedorId;

-- Semilla para la tabla Inventario_Producto
INSERT INTO Inventario_Producto (InventarioId, ProductoId, Cantidad)
SELECT TOP 20
    InventarioId,
        ProductoId,
       ABS(CHECKSUM(NEWID())) % 100 + 1
FROM Inventario
    CROSS JOIN Producto;

-- Semilla para la tabla CarritoCompras
INSERT INTO CarritoCompras (CarritoComprasId, ClienteId, CarritoComprasTotal)
SELECT TOP 10
    NEWID(),
        UsuarioId,
       0
FROM Usuario
WHERE TipoUsuarioId = @TipoUsuarioClienteId;

-- Semilla para la tabla CarritoCompras_Producto
INSERT INTO CarritoCompras_Producto (CarritoComprasId, ProductoId, Cantidad)
SELECT TOP 20
    CarritoComprasId,
        ProductoId,
       ABS(CHECKSUM(NEWID())) % 5 + 1
FROM CarritoCompras
    CROSS JOIN Producto;

-- Semilla para la tabla Pedido
INSERT INTO Pedido (PedidoId, ClienteId, VendedorId, EstadoPedidoId, PedidoFechaCreacion, PedidoFechaEntrega)
SELECT TOP 20
    NEWID(),
        ClienteId,
       (SELECT TOP 1 VendedorId FROM Inventario ORDER BY NEWID()),
       (SELECT TOP 1 EstadoPedidoId FROM EstadoPedido WHERE EstadoPedidoDescripcion = 'Pendiente'),
       GETDATE(),
       DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 10 + 1, GETDATE())
FROM CarritoCompras;