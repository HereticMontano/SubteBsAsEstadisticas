DELIMITER //

CREATE OR REPLACE PROCEDURE SP_Precalcular()
BEGIN

	DELETE FROM Precalculado;
	
	INSERT INTO Precalculado(IdLinea, MinutosSuspendida, Fecha) 
	SELECT ES.IdLinea, SUM(TIMESTAMPDIFF(MINUTE, ES.HoraDesde, ES.HoraHasta)), ES.Fecha
	FROM EstadoServicio ES 
	WHERE ES.IdEstado = 2
	GROUP BY YEAR(ES.Fecha), MONTH(ES.Fecha), DAY(ES.Fecha), Es.IdLinea;
	
	UPDATE Precalculado SET MinutosNormal = FN_GetMinutosNormales(Fecha, MinutosSuspendida);

END//