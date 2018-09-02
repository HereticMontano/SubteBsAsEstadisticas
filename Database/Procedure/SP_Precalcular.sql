DELIMITER //

CREATE OR REPLACE PROCEDURE SP_Precalcular()
BEGIN

	DELETE FROM Precalculado;
	
	INSERT INTO Precalculado(IdLinea, MinutosSuspendida, IdFecha) 
	SELECT ES.IdLinea, SUM(TIMESTAMPDIFF(MINUTE, ES.HoraDesde, ES.HoraHasta)), FE.Id		
	FROM FechaEstadoServicio FE 
	JOIN EstadoServicio ES ON ES.IdFecha = FE.Id 
	WHERE ES.IdEstado = 2
	GROUP BY Es.IdLinea;
	
	UPDATE Precalculado SET MinutosNormal = FN_GetMinutosNormales(IdLinea, IdFecha, MinutosSuspendida);

END//