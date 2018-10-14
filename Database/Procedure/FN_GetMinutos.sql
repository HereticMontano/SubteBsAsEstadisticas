
#Para un tipo de linea y de fecha en particular retorna los minutos de funcionamiento normal
DELIMITER //

CREATE OR REPLACE FUNCTION FN_GetMinutos(horaDesde TIME, horaHasta TIME) RETURNS INT
DETERMINISTIC
BEGIN

	/*
	El case esta porque si tengo una linea que no funciono hasta las 00hs la diferencia no es el dato buscado, 
	asique resto la diferencia a la cantidad de minutos en un dia. 
	*/
	 
	 RETURN CASE WHEN horaDesde < horaHasta 
								THEN TIMESTAMPDIFF(MINUTE, horaDesde , horaHasta) 
								ELSE 1440 - TIMESTAMPDIFF(MINUTE, horaHasta, horaDesde) END;

END//



	