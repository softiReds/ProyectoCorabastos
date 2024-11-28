CREATE
DATABASE Corabastos;
USE
Corabastos;

-- Tabla Ciudades
CREATE TABLE Ciudad
(
    CiudadId     UNIQUEIDENTIFIER PRIMARY KEY,
    CiudadNombre NVARCHAR(50) NOT NULL
);

-- Tabla TiposUsuario
CREATE TABLE TipoUsuario
(
    TipoUsuarioId          UNIQUEIDENTIFIER PRIMARY KEY,
    TipoUsuarioDescripcion NVARCHAR(20) NOT NULL
);

-- Tabla Usuarios
CREATE TABLE Usuario
(
    UsuarioId        UNIQUEIDENTIFIER PRIMARY KEY,
    CiudadId         UNIQUEIDENTIFIER NOT NULL,
    TipoUsuarioId    UNIQUEIDENTIFIER NOT NULL,
    UsuarioDocumento NVARCHAR(13) NOT NULL,
    UsuarioNombre    NVARCHAR(50) NOT NULL,
    UsuarioApellido  NVARCHAR(50) NOT NULL,
    UsuarioCorreo    NVARCHAR(80) NOT NULL,
    UsuarioTelefono  NVARCHAR(10) NOT NULL,
    UsuarioDireccion NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Ciudad_Usuario FOREIGN KEY (CiudadId) REFERENCES Ciudad (CiudadId),
    CONSTRAINT FK_TipoUsuario_Usuario FOREIGN KEY (TipoUsuarioId) REFERENCES TipoUsuario (TipoUsuarioId)
);

-- Tabla EstadoPedidos
CREATE TABLE EstadoPedido
(
    EstadoPedidoId          UNIQUEIDENTIFIER PRIMARY KEY,
    EstadoPedidoDescripcion NVARCHAR(30) NOT NULL
);

-- Tabla Pedidos
CREATE TABLE Pedido
(
    PedidoId            UNIQUEIDENTIFIER PRIMARY KEY,
    ClienteId           UNIQUEIDENTIFIER NOT NULL,
    VendedorId          UNIQUEIDENTIFIER NOT NULL,
    EstadoPedidoId      UNIQUEIDENTIFIER NOT NULL,
    PedidoFechaCreacion DATETIME         NOT NULL,
    PedidoFechaEntrega  DATETIME         NOT NULL,
    CONSTRAINT FK_Cliente_Pedido FOREIGN KEY (ClienteId) REFERENCES Usuario (UsuarioId),
    CONSTRAINT FK_Vendedor_Pedido FOREIGN KEY (VendedorId) REFERENCES Usuario (UsuarioId),
    CONSTRAINT FK_EstadoPedido_Pedido FOREIGN KEY (EstadoPedidoId) REFERENCES EstadoPedido (EstadoPedidoId)
);

-- Tabla Inventarios
CREATE TABLE Inventario
(
    InventarioId UNIQUEIDENTIFIER PRIMARY KEY,
    VendedorId   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Vendedor_Inventario FOREIGN KEY (VendedorId) REFERENCES Usuario (UsuarioId)
);

-- Tabla CarritosCompras
CREATE TABLE CarritoCompras
(
    CarritoComprasId    UNIQUEIDENTIFIER PRIMARY KEY,
    ClienteId           UNIQUEIDENTIFIER NOT NULL,
    CarritoComprasTotal INT              NOT NULL,
    CONSTRAINT FK_Cliente_CarritoCompras FOREIGN KEY (ClienteId) REFERENCES Usuario (UsuarioId)
);

-- Tabla Productos
CREATE TABLE Producto
(
    ProductoId     UNIQUEIDENTIFIER PRIMARY KEY,
    ProductoNombre NVARCHAR(100) NOT NULL,
    ProductoPrecio INT NOT NULL
);

-- Tabla InventarioProductos
CREATE TABLE Inventario_Producto
(
    InventarioId UNIQUEIDENTIFIER NOT NULL,
    ProductoId   UNIQUEIDENTIFIER NOT NULL,
    Cantidad     INT              NOT NULL,
    CONSTRAINT PK_InventarioProducto PRIMARY KEY (InventarioId, ProductoId),
    CONSTRAINT FK_Producto_InventarioProducto FOREIGN KEY (ProductoId) REFERENCES Producto (ProductoId),
    CONSTRAINT FK_Inventario_InventarioProducto FOREIGN KEY (InventarioId) REFERENCES Inventario (InventarioId)
);

-- Tabla CarritoComprasProductos
CREATE TABLE CarritoCompras_Producto
(
    CarritoComprasId UNIQUEIDENTIFIER NOT NULL,
    ProductoId       UNIQUEIDENTIFIER NOT NULL,
    Cantidad         INT              NOT NULL,
    CONSTRAINT PK_CarritoComprasProducto PRIMARY KEY (CarritoComprasId, ProductoId),
    CONSTRAINT FK_Producto_CarritoComprasProducto FOREIGN KEY (ProductoId) REFERENCES Producto (ProductoId),
    CONSTRAINT FK_CarritoCompras_CarritoComprasProducto FOREIGN KEY (CarritoComprasId) REFERENCES CarritoCompras (CarritoComprasId)
);
