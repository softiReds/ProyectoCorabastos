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