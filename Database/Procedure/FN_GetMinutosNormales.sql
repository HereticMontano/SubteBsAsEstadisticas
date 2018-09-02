#Para un tipo de linea y de fecha en particular retorna los minutos de funcionamiento normal
DELIMITER //

CREATE OR REPLACE FUNCTION FN_GetMinutosNormales(idLinea TINYINT(4), idFecha INT, minutosSuspendido INT) RETURNS INT
DETERMINISTIC
BEGIN
		
	DROP TEMPORARY TABLE IF EXISTS fechaData;
	CREATE TEMPORARY TABLE fechaData (Fecha DATE, IdTipoDia TINYINT);
	INSERT INTO fechaData 
	SELECT Fecha, IdTipoDia
	FROM FechaEstadoServicio
	WHERE Id = idFecha;
	
	/*
	El case esta porque si tengo un itinerario que termina a las 00hs como por ejemplo la H el resultado de la diferencia no es el buscado, 
	asique resto la diferencia a la cantidad de minutos en un dia. 
	
	El itinerario del subte a partir de alguna fecha puede ser distinto, por eso obtengo todos los 
	itinerarios menor a la fecha del estado del servicio  y lo ordeno decreciente para quedarme con el itinerario vigente a la fecha del estado del servicio.
	*/
	RETURN (SELECT (CASE WHEN HoraDesde < HoraHasta 
								THEN TIMESTAMPDIFF(MINUTE,HoraDesde ,HoraHasta) 
								ELSE 1440 - TIMESTAMPDIFF(MINUTE, HoraHasta, HoraDesde) END) - minutosSuspendido
	FROM (SELECT I.* FROM Itinerario I
			WHERE I.IdLinea = idLinea AND 
			I.IdTipoDia = (SELECT IdTipoDia FROM fechaData) AND 
			I.FechaItinerario <= (SELECT Fecha FROM fechaData) 
			ORDER BY I.FechaItinerario DESC LIMIT 1) IT);	

END//
