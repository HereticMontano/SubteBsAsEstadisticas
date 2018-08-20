DELIMITER //

CREATE OR REPLACE PROCEDURE db.SP_Precalcular()
BEGIN

DELETE Precalculado

INSERT INTO Precalculado(IdLinea,MinutosSuspendida, Fecha) 
SELECT ES.idLinea, SUM(TIMESTAMPDIFF(MINUTE, ES.FechaDesde, ES.FechaHasta)), CONCAT_WS(' ', DATE(ES.FechaDesde), '00:00:00') 
FROM EstadoServicio ES 
WHERE ES.IdEstado = 2
GROUP BY YEAR(ES.FechaDesde), MONTH(ES.FechaDesde), DAY(ES.FechaDesde)

UPDATE Precalculado SET MinutosNormal = FN_GetMinutosNormales(Fecha, MinutosSuspendida)

END 
//