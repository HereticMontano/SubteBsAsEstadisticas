DELIMITER //

CREATE OR REPLACE FUNCTION FN_GetMinutosNormales(fecha DATE, minutosSuspendido INT) RETURNS INT
DETERMINISTIC
BEGIN
	
	DECLARE ret INT DEFAULT NULL;
	#Se estima que de Lunes a Sabado el subte funciona 18 horas. Y los domingos 15. Los feriados tambine funciona 15, pero no tengo una forma sencilla de reconcerlos.
	IF (WEEKDAY(fecha) = 7) THEN 
		SET ret = (15*60) - minutosSuspendido;	
	ELSE 
		SET ret = (18*60) - minutosSuspendido;
	END IF;
	
	RETURN (ret);
END//

