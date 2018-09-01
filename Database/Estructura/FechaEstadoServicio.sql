CREATE TABLE FechaEstadoServicio(
Id INT AUTO_INCREMENT,
Fecha DATE NOT NULL,
IdTipoDia TINYINT NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (IdTipoDia) REFERENCES TipoDia(Id))