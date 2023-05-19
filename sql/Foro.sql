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

CREATE TABLE Categorias(

	idCategoria TINYINT PRIMARY KEY IDENTITY,
	nombre VARCHAR(40) NOT NULL,
	descripcion VARCHAR(100) NOT NULL

);

CREATE TABLE Preguntas(

	idPregunta SMALLINT PRIMARY KEY IDENTITY,
	titulo VARCHAR(100) NOT NULL,
	descripcion VARCHAR(1000) NOT NULL,	
	fechaPublicacion DATETIME NOT NULL,
	idCategoria TINYINT FOREIGN KEY REFERENCES Categorias(idCategoria) NULL,
	idUsuario TINYINT FOREIGN KEY REFERENCES Usuarios(idUsuario) NOT NULL
	
);

CREATE TABLE Comentarios(

	idComentario SMALLINT PRIMARY KEY IDENTITY,
	descripcion VARCHAR(2000) NOT NULL,
	fechaPublicacion DATETIME NOT NULL,
	idUsuario TINYINT FOREIGN KEY REFERENCES Usuarios(idUsuario) NOT NULL
	
);

INSERT INTO Usuarios(nombre, apellidos, correo, usuario, contrasenia)
VALUES('Cristian', 'Silva Guerrero', 'cristiansg84@gmail.com', 'admin', 'admin');

INSERT INTO Categorias(nombre, descripcion)
VALUES('General', 'asd'),
('Electrónica', 'asd'),
('Deporte', 'asd'),
('Videojuegos', 'asd'),
('Informática', 'asd'),
('Mecánica', 'asd'),
('Música', 'asd'),
('Empleo', 'asd'),
('Películas', 'asd');

INSERT INTO Preguntas(titulo, descripcion)
VALUES('Titulo1', 'Es descripcion'),
('Titulo2', 'Es descripcion'),
('Titulo3', 'Es descripcion'),
('Titulo4', 'Es descripcion'),
('Titulo5', 'Es descripcion'),
('Titulo6', 'Es descripcion'),
('Titulo7', 'Es descripcion');