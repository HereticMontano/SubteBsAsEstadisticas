CREATE EVENT Recalcular
  ON SCHEDULE
    EVERY 1 DAY
    STARTS '2018-09-02 02:00:00' ON COMPLETION PRESERVE ENABLE 
  DO
     CALL SP_Precalcular();