DELIMITER //

CREATE OR REPLACE FUNCTION FN_GetMinutosNormales(idLinea TINYINT(4), fecha DATE, minutosSuspendido INT) RETURNS INT
DETERMINISTIC
BEGIN

DECLARE ret INT DEFAULT NULL;

SET ret = (SELECT TIMESTAMPDIFF(MINUTE, HoraDesde, HoraHasta) - minutosSuspendido
FROM Itinerario 
WHERE IdLinea = idLinea AND 
	CASE WHEN WEEKDAY(fecha) = 6 THEN IdTipoDia = 3 
	WHEN WEEKDAY(fecha) = 5 THEN IdTipoDia = 2  
	ELSE IdTipoDia = 1 END);
	
	RETURN (ret);
END//
