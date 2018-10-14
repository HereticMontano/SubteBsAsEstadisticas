CREATE TABLE Estado(Id TINYINT AUTO_INCREMENT, Descripcion VARCHAR(100) NOT NULL, PRIMARY KEY (Id));

INSERT INTO Estado(Descripcion) VALUES ("Normal");
INSERT INTO Estado(Descripcion) VALUES ("Suspendido");
INSERT INTO Estado(Descripcion)  VALUES("Demora");
INSERT INTO Estado(Descripcion)  VALUES("Limitado");