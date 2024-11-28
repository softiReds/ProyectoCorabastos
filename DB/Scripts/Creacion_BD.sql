CREATE
DATABASE Corabastos;
USE
Corabastos;

-- Tabla Ciudades
CREATE TABLE Ciudad
(
    CiudadId     VARCHAR(80) PRIMARY KEY,
    CiudadNombre VARCHAR(50) NOT NULL
);

-- Tabla TiposUsuario
CREATE TABLE TipoUsuario
(
    TipoUsuarioId          VARCHAR(80) PRIMARY KEY,
    TipoUsuarioDescripcion VARCHAR(20) NOT NULL
);

-- Tabla Usuarios
CREATE TABLE Usuario
(
    UsuarioId        VARCHAR(80) PRIMARY KEY,
    CiudadId         VARCHAR(80)  NOT NULL,
    TipoUsuarioId    VARCHAR(80)  NOT NULL,
    UsuarioDocumento VARCHAR(13)  NOT NULL,
    UsuarioNombre    VARCHAR(50)  NOT NULL,
    UsuarioApellido  VARCHAR(50)  NOT NULL,
    UsuarioCorreo    VARCHAR(80)  NOT NULL,
    UsuarioTelefono  VARCHAR(10)  NOT NULL,
    UsuarioDireccion VARCHAR(100) NOT NULL,
    CONSTRAINT FK_Ciudad_Usuario FOREIGN KEY (CiudadId) REFERENCES Ciudad (CiudadId),
    CONSTRAINT FK_TipoUsuario_Usuario FOREIGN KEY (TipoUsuarioId) REFERENCES TipoUsuario (TipoUsuarioId)
);

-- Tabla EstadoPedidos
CREATE TABLE EstadoPedido
(
    EstadoPedidoId          VARCHAR(80) PRIMARY KEY,
    EstadoPedidoDescripcion VARCHAR(30) NOT NULL
);

-- Tabla Pedidos
CREATE TABLE Pedido
(
    PedidoId            VARCHAR(80) PRIMARY KEY,
    ClienteId           VARCHAR(80) NOT NULL,
    VendedorId          VARCHAR(80) NOT NULL,
    EstadoPedidoId      VARCHAR(80) NOT NULL,
    PedidoFechaCreacion DATETIME    NOT NULL,
    PedidoFechaEntrega  DATETIME    NOT NULL,
    CONSTRAINT FK_Cliente_Pedido FOREIGN KEY (ClienteId) REFERENCES Usuario (UsuarioId),
    CONSTRAINT FK_Vendedor_Pedido FOREIGN KEY (VendedorId) REFERENCES Usuario (UsuarioId),
    CONSTRAINT FK_EstadoPedido_Pedido FOREIGN KEY (EstadoPedidoId) REFERENCES EstadoPedido (EstadoPedidoId)
);

-- Tabla Inventarios
CREATE TABLE Inventario
(
    InventarioId VARCHAR(80) PRIMARY KEY,
    VendedorId   VARCHAR(80) NOT NULL,
    CONSTRAINT FK_Vendedor_Inventario FOREIGN KEY (VendedorId) REFERENCES Usuario (UsuarioId)
);

-- Tabla CarritosCompras
CREATE TABLE CarritoCompras
(
    CarritoComprasId    VARCHAR(80) PRIMARY KEY,
    ClienteId           VARCHAR(80) NOT NULL,
    CarritoComprasTotal INT         NOT NULL,
    CONSTRAINT FK_Cliente_CarritoCompras FOREIGN KEY (ClienteId) REFERENCES Usuario (UsuarioId)
);

-- Tabla Productos
CREATE TABLE Producto
(
    ProductoId       VARCHAR(80) PRIMARY KEY,
    ProductoNombre   VARCHAR(100) NOT NULL,
    ProductoCantidad INT          NOT NULL,
    ProductoPrecio   INT          NOT NULL
);

-- Tabla InventarioProductos
CREATE TABLE Inventario_Producto
(
    InventarioId VARCHAR(80) NOT NULL,
    ProductoId   VARCHAR(80) NOT NULL,
    Cantidad     INT         NOT NULL,
    CONSTRAINT PK_InventarioProducto PRIMARY KEY (InventarioId, ProductoId),
    CONSTRAINT FK_Producto_InventarioProducto FOREIGN KEY (ProductoId) REFERENCES Producto (ProductoId),
    CONSTRAINT FK_Inventario_InventarioProducto FOREIGN KEY (InventarioId) REFERENCES Inventario (InventarioId)
);

-- Tabla CarritoComprasProductos
CREATE TABLE CarritoCompras_Producto
(
    CarritoComprasId VARCHAR(80) NOT NULL,
    ProductoId       VARCHAR(80) NOT NULL,
    Cantidad         INT         NOT NULL,
    CONSTRAINT PK_CarritoComprasProducto PRIMARY KEY (CarritoComprasId, ProductoId),
    CONSTRAINT FK_Producto_CarritoComprasProducto FOREIGN KEY (ProductoId) REFERENCES Producto (ProductoId),
    CONSTRAINT FK_CarritoCompras_CarritoComprasProducto FOREIGN KEY (CarritoComprasId) REFERENCES CarritoCompras (CarritoComprasId)
);
