CREATE TABLE Precalculado(Id INT AUTO_INCREMENT,
IdLinea TINYINT NOT NULL,
MinutosNormal INT,
MinutosSuspendida INT NOT NULL,
Fecha TIMESTAMP NOT NULL,  
PRIMARY KEY (Id), FOREIGN KEY (IdLinea) REFERENCES Linea(Id))