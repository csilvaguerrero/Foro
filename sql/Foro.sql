CREATE DATABASE Foro;

USE Foro;

CREATE TABLE Usuarios(
	
	idUsuario TINYINT PRIMARY KEY IDENTITY,
	nombre VARCHAR(70) NOT NULL,
	apellidos VARCHAR(200) NOT NULL,
	correo VARCHAR(200) NOT NULL UNIQUE,
	usuario VARCHAR(30) NOT NULL,
	contrasenia VARCHAR(256) NOT NULL

);

INSERT INTO Usuarios(nombre, apellidos, correo, usuario, contrasenia)
VALUES('Cristian', 'Silva Guerrero', 'cristiansg84@gmail.com', 'admin', 'admin');