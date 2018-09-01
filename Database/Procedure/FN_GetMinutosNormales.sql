#Para un tipo de linea y de fecha en particular retorna los minutos de funcionamiento normal
DELIMITER //

CREATE OR REPLACE FUNCTION FN_GetMinutosNormales(idLinea TINYINT(4), idFecha INT, minutosSuspendido INT) RETURNS INT
DETERMINISTIC
BEGIN
		
	CREATE TEMPORARY TABLE fechaData (Fecha DATE, IdTipoDia TINYINT);
	INSERT INTO fechaData 
	SELECT Fecha, IdTipoDia
	FROM FechaEstadoServicio
	WHERE Id = idFecha;
	
	/*El itinerario del subte a partir de alguna fecha puede ser distinto, por eso obtengo todos los 
	itinerarios menor a la fecha del calculo y lo ordeno decreciente para quedarme con el itinerario mas cercano a la fecha del calculo*/
	RETURN (SELECT TIMESTAMPDIFF(MINUTE, IT.HoraDesde, IT.HoraHasta) - minutosSuspendido
	FROM (SELECT  I.* FROM Itinerario I
			WHERE I.IdLinea = idLinea AND 
			I.IdTipoDia = (SELECT IdTipoDia FROM fechaData) AND 
			I.FechaItinerario <= (SELECT Fecha FROM fechaData) 
			ORDER BY I.FechaItinerario DESC LIMIT 1) IT);	

END//
