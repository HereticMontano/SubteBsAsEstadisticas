DELIMITER //

CREATE OR REPLACE PROCEDURE SP_Precalcular()
BEGIN

	DELETE FROM Precalculado;

	-- Sumo todos los estados del mismo tipo para la misma linea y dia y lo guardo en un temp
	DROP TEMPORARY TABLE IF EXISTS SumEstados;
	CREATE TEMPORARY TABLE SumEstados (IdLinea TINYINT, IdEstado TINYINT, IdFecha INT, Minutos INT);
	INSERT INTO SumEstados 
	SELECT IdLinea, IdEstado, IdFecha, SUM(FN_GetMinutos(HoraDesde, HoraHasta)) Minutos 
	FROM EstadoServicio 
	GROUP BY IdFecha, IdLinea, IdEstado;
	
	-- TODO: Tiene que haber una forma mas eficiente de hacer esto.	
	INSERT INTO Precalculado(IdLinea, MinutosSuspendida, MinutosDemora, MinutosLimitada, IdFecha)
	SELECT DISTINCT SE.IdLinea,
	IFNULL((SELECT Minutos FROM SumEstados WHERE IdFecha = SE.IdFecha AND IdLinea = SE.IdLinea AND IdEstado = 2),0),
	IFNULL((SELECT Minutos FROM SumEstados WHERE IdFecha = SE.IdFecha AND IdLinea = SE.IdLinea AND IdEstado = 3),0),
	IFNULL((SELECT Minutos FROM SumEstados WHERE IdFecha = SE.IdFecha AND IdLinea = SE.IdLinea AND IdEstado = 4),0), FE.Id
	FROM FechaEstadoServicio FE
	JOIN SumEstados SE ON SE.IdFecha = FE.Id;


	-- Agrego las lineas que como estuvieron funcionando normalmente todo el dia, no existe en EstadoServicio
	INSERT INTO Precalculado(IdLinea, IdFecha) 
	SELECT L.Id, FE.Id	
	FROM FechaEstadoServicio FE
   JOIN Linea L ON L.Id NOT IN (SELECT P.IdLinea FROM Precalculado P WHERE P.IdFecha = FE.Id);
	
	UPDATE Precalculado SET MinutosNormal = FN_GetMinutosNormales(IdLinea, IdFecha, MinutosSuspendida + MinutosDemora + MinutosLimitada);

END//