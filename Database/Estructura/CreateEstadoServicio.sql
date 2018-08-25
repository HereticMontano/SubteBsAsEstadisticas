CREATE TABLE EstadoServicio(Id INT AUTO_INCREMENT,
IdLinea TINYINT NOT NULL,
IdEstado TINYINT NOT NULL, 
FechaDesde TIMESTAMP NOT NULL, 
FechaHasta TIMESTAMP NULL DEFAULT NULL, 
Descripcion VARCHAR(255), PRIMARY KEY (Id), FOREIGN KEY (IdLinea) REFERENCES Linea(Id), FOREIGN KEY (IdEstado) REFERENCES Estado(Id))