UPDATE stud.Student
SET
	JMBAG = @JMBAG,
	Spol = @Spol,
	RodenjeDatum = @RodenjeDatum,
	ImeRoditelja = @ImeRoditelja,
	MjestoRodjenja = @MjestoRodjenja,
	PbrMjestaRodenja = @PbrMjestaRodenja,
	Mail = @Mail,
	Telefon = @Telefon,
	MjestoStanovanja = @MjestoStanovanja,
	PbrStanovanja = @PbrStanovanja,
	Ulica = @Ulica,
	KucniBroj = @KucniBroj

WHERE DProtocolID = @DprotocolID