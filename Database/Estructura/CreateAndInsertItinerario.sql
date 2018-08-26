CREATE TABLE Itinerario(Id INT AUTO_INCREMENT,
IdLinea TINYINT NOT NULL,
IdTipoDia TINYINT NOT NULL,
HoraDesde TIME NOT NULL,  
HoraHasta TIME NOT NULL,  
FechaItinerario DATE NOT NULL,
PRIMARY KEY (Id), 
FOREIGN KEY (IdLinea) REFERENCES Linea(Id),
FOREIGN KEY (IdTipoDia) REFERENCES TipoDia(Id));



#Inserto los horarios de semana
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(1,1,'05:30','23:27','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(2,1,'05:30','23:30','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(3,1,'05:30','23:21','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(4,1,'05:30','23:25','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(5,1,'05:30','23:29','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(6,1,'05:30','23:53','2018-08-25');

#Inserto los horarios del Sabado
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(1,2,'06:00','23:58','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(2,2,'06:00','23:53','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(3,2,'06:00','23:47','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(4,2,'06:00','23:51','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(5,2,'06:00','23:58','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(6,2,'06:00','00:23','2018-08-25');

#Inserto los horarios del Domingo
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(1,3,'08:00','22:36','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(2,3,'08:00','22:28','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(3,3,'08:00','22:23','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(4,3,'08:00','22:58','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(5,3,'08:00','22:35','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(6,3,'08:00','22:53','2018-08-25');

#Inserto los horarios de feriados
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(1,4,'08:00','22:36','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(2,4,'08:00','22:28','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(3,4,'08:00','22:23','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(4,4,'08:00','22:58','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(5,4,'08:00','22:35','2018-08-25');
INSERT INTO Itinerario(IdLinea, IdTipoDia, HoraDesde, HoraHasta, FechaItinerario) VALUES(6,4,'08:00','22:53','2018-08-25');
