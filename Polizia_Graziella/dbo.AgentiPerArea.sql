
CREATE PROCEDURE [dbo].[AgentiPerArea]
	@codiceArea nchar(5)
AS
BEGIN

	SELECT  AgentiDiPolizia.Nome, AgentiDiPolizia.Cognome, AgentiDiPolizia.CF, AgentiDiPolizia.DataNascita, AgentiDiPolizia.AnniDiServizio
			FROM  Afferenza INNER JOIN
                  AgentiDiPolizia ON Afferenza.IdAgente = AgentiDiPolizia.IdAgente INNER JOIN
                  AreaMetropolitana ON Afferenza.IdArea = AreaMetropolitana.IdArea AND AgentiDiPolizia.IdAgente = AreaMetropolitana.IdAgente
			where AreaMetropolitana.CodiceArea = @codiceArea
	GROUP BY AreaMetropolitana.CodiceArea

	
END