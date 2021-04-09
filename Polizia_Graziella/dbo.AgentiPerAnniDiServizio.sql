
CREATE PROCEDURE AgentiPerAnniDiServizio
	@anniDiServizio int
AS
BEGIN
	
	SELECT Nome, Cognome, CF, DataNascita, AnniDiServizio
	FROM     AgentiDiPolizia
	WHERE AgentiDiPolizia.AnniDiServizio <= @anniDiServizio
	GROUP BY Nome, Cognome, CF, AnniDiServizio
END