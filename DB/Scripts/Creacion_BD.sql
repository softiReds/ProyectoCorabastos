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

	CONSTRAINT FK_Ciudad FOREIGN KEY(id_ciudad) REFERENCES Ciudad(id_ciudad),
	CONSTRAINT FK_TipoUsuario FOREIGN KEY(id_tipoUsuario) REFERENCES TipoUsuario(id_tipoUsuario)
)

