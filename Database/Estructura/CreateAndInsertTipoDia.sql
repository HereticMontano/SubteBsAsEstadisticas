CREATE TABLE TipoDia(Id TINYINT AUTO_INCREMENT,
Descripcion VARCHAR(50) NOT NULL,
PRIMARY KEY (Id));

INSERT INTO TipoDia(Descripcion) VALUES("Dia de semana");
INSERT INTO TipoDia(Descripcion) VALUES("Sabado");
INSERT INTO TipoDia(Descripcion) VALUES("Domingo");
INSERT INTO TipoDia(Descripcion) VALUES("Feriado");