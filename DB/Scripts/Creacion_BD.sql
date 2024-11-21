CREATE DATABASE Corabastos;

USE Corabastos;

CREATE TABLE TipoUsuario(
	id_tipoUsuario INT PRIMARY KEY IDENTITY(1,1),
	descripcion_tipoUsuario VARCHAR(60) NOT NULL
)

CREATE TABLE Ciudad(
	id_ciudad INT PRIMARY KEY IDENTITY(1,1),
	nombre_ciudad VARCHAR(50) NOT NULL
)

CREATE TABLE Producto(
	id_producto INT PRIMARY KEY IDENTITY(1,1),
	nombre_producto VARCHAR(50) NOT NULL,
	cantidad_producto INT NOT NULL,
	precio_producto INT NOT NULL
)

CREATE TABLE Usuario(
	id_usuario INT PRIMARY KEY IDENTITY(1,1),
	id_ciudad INT NOT NULL,
	id_tipoUsuario INT NOT NULL,
	documento_usuario VARCHAR(13) NOT NULL,
	nombre_usuario VARCHAR(50) NOT NULL,
	apellido_usuario VARCHAR(50) NOT NULL,
	telefono_usuario VARCHAR(10) NOT NULL,
	direccion_usuario VARCHAR(100) NOT NULL,

	CONSTRAINT FK_Ciudad_Usuario FOREIGN KEY(id_ciudad) REFERENCES Ciudad(id_ciudad),
	CONSTRAINT FK_TipoUsuario_Usuario FOREIGN KEY(id_tipoUsuario) REFERENCES TipoUsuario(id_tipoUsuario)
)

CREATE TABLE Inventario(
	id_inventario INT PRIMARY KEY IDENTITY(1,1),
	id_vendedor INT NOT NULL,
	
	CONSTRAINT FK_Usuario_Inventario FOREIGN KEY(id_vendedor) REFERENCES Usuario(id_usuario)
)

CREATE TABLE CarritoCompras(
	id_carritoCompras INT PRIMARY KEY IDENTITY(1,1),
	id_cliente INT NOT NULL,
	total_carritoCompras INT NOT NULL,
	
	CONSTRAINT FK_Usuario_CarritoCompras FOREIGN KEY(id_cliente) REFERENCES Usuario(id_usuario)
)

CREATE TABLE Inventario_Producto(
	id_inventario INT NOT NULL,
	id_producto INT NOT NULL,
	cantidad INT NOT NULL,
	
	CONSTRAINT PK_Inventario_Producto PRIMARY KEY(id_inventario, id_producto)
)

CREATE TABLE CarritoCompras_Producto(
	id_carritoCompras INT NOT NULL,
	id_producto INT NOT NULL,
	cantidad INT NOT NULL,
	
	CONSTRAINT PK_CarritoCompras_Producto PRIMARY KEY(id_carritoCompras, id_producto)
)

CREATE TABLE EstadoPedido(
    id_estadoPedido INT PRIMARY KEY IDENTITY(1,1),
    descripcion_estadoPedido VARCHAR(50) NOT NULL
)

CREATE TABLE Pedido(
    id_pedido INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,   
    id_vendedor INT NOT NULL,
    id_estadoPedido INT NOT NULL,
    fecha_creacionPedido DATETIME NOT NULL,
    fecha_entregaPedido DATETIME  NOT NULL,

    CONSTRAINT FK_Cliente_Pedido FOREIGN KEY(id_cliente) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_Vendedor_Pedido FOREIGN KEY(id_vendedor) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_EstadoPedido_Pedido FOREIGN KEY(id_estadoPedido) REFERENCES EstadoPedido(id_estadoPedido)
)