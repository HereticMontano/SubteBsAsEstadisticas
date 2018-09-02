DELIMITER //

CREATE OR REPLACE PROCEDURE SP_Precalcular()
BEGIN

	DELETE FROM Precalculado;
	
	/*
	El case esta porque si tengo una linea que no funciono hasta las 00hs la diferencia no es el dato buscado, 
	asique resto la diferencia a la cantidad de minutos en un dia. 
	*/
	INSERT INTO Precalculado(IdLinea, MinutosSuspendida, IdFecha) 
	SELECT ES.IdLinea, (CASE WHEN ES.HoraDesde < ES.HoraHasta 
								THEN TIMESTAMPDIFF(MINUTE, ES.HoraDesde , ES.HoraHasta) 
								ELSE 1440 - TIMESTAMPDIFF(MINUTE, ES.HoraHasta, ES.HoraDesde) END), FE.Id		
	FROM FechaEstadoServicio FE 
	JOIN EstadoServicio ES ON ES.IdFecha = FE.Id 
	WHERE ES.IdEstado = 2
	GROUP BY Es.IdLinea;
	
	
	INSERT INTO Precalculado(IdLinea, MinutosSuspendida, IdFecha) 
	SELECT L.Id, 0, FE.Id	
	FROM FechaEstadoServicio FE
	JOIN Precalculado P ON P.idFecha = Fe.id
   JOIN Linea L ON L.Id <> P.idLinea;
	
	UPDATE Precalculado SET MinutosNormal = FN_GetMinutosNormales(IdLinea, IdFecha, MinutosSuspendida);

END//