CREATE DATABASE Foro;

USE Foro;

CREATE TABLE Usuarios(
	
	idUsuario TINYINT PRIMARY KEY IDENTITY,
	nombre VARCHAR(70) NOT NULL,
	apellidos VARCHAR(200) NOT NULL,
	correo VARCHAR(200) NOT NULL UNIQUE,
	usuario VARCHAR(30) NOT NULL UNIQUE,
	fechaRegistro DATETIME NOT NULL,
	contrasenia VARCHAR(256) NOT NULL,
	rol CHAR(1) NOT NULL CHECK(rol = 'a' OR rol = 'b' OR rol = 'p' OR rol = 'o')
	-- admin BIT NOT NULL

);

CREATE TABLE Categorias(

	idCategoria TINYINT PRIMARY KEY IDENTITY,
	nombre VARCHAR(40) NOT NULL,
	descripcion VARCHAR(100) NOT NULL,
	imagen VARCHAR(50) NOT NULL

);

CREATE TABLE Preguntas(

	idPregunta SMALLINT PRIMARY KEY IDENTITY,
	titulo VARCHAR(100) NOT NULL UNIQUE,
	descripcion VARCHAR(1000) NOT NULL,	
	fechaPublicacion DATETIME NOT NULL,
	idCategoria TINYINT FOREIGN KEY REFERENCES Categorias(idCategoria) NOT NULL,
	idUsuario TINYINT FOREIGN KEY REFERENCES Usuarios(idUsuario) NOT NULL
	
);

CREATE TABLE Comentarios(

	idComentario SMALLINT PRIMARY KEY IDENTITY,
	descripcion VARCHAR(2000) NOT NULL,
	fechaPublicacion DATETIME NOT NULL,
	idUsuario TINYINT FOREIGN KEY REFERENCES Usuarios(idUsuario) ON UPDATE CASCADE ON DELETE CASCADE,
	idPregunta SMALLINT FOREIGN KEY REFERENCES Preguntas(idPregunta) ON UPDATE CASCADE ON DELETE CASCADE
	
);

INSERT INTO Usuarios(nombre, apellidos, correo, usuario, fechaRegistro, contrasenia)
VALUES('Cristian', 'Silva Guerrero', 'cristiansg84@gmail.com', 'admin', GETDATE(),'admin');

INSERT INTO Categorias(nombre, descripcion, imagen)
VALUES('General', 'Temas que abarcan la actualidad', 'general'),
('Electrónica', 'Robótica, circuitos, componentes...', 'electronica'),
('Videojuegos', 'Últimos lanzamientos, plataformas...', 'videojuegos'),
('Informática', 'Desarrollo, computación...', 'informatica'),
('Mecánica', 'Vehículos', 'mecanica'),
('Deporte', 'Futbol, baloncesto, tenis', 'deporte'),
('Música', 'Últimos lanzamientos de discos, géneros musicales...', 'musica'),
('Empleo', 'Ofertas de empleo, demanda...', 'empleo'),
('Películas', 'Novedades sobre las últimas películas', 'pelicula');

INSERT INTO Preguntas(titulo, descripcion, fechaPublicacion, idCategoria, idUsuario)
VALUES('Titulo1', 'Es descripcion', GETDATE(), 1, 1),
('Titulo2', 'Es descripcion', GETDATE(), 1, 1),
('Titulo3', 'Es descripcion', GETDATE(), 1, 1),
('Titulo4', 'Es descripcion', GETDATE(), 2, 1),
('Titulo5', 'Es descripcion', GETDATE(), 1, 1),
('Titulo6', 'Es descripcion', GETDATE(), 1, 1),
('Titulo7', 'Es descripcion', GETDATE(), 4, 1);

INSERT INTO Comentarios(descripcion, fechaPublicacion, idUsuario, idPregunta)
VALUES('asdasd', GETDATE(), 1, 1),
('asdasd', GETDATE(), 1, 1),
('asdasd', GETDATE(), 1, 1),
('asdasd', GETDATE(), 1, 3),
('asdasd', GETDATE(), 1, 5);