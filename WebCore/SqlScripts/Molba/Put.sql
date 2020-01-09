update stud.molba
set 
	InvaliditetInd = @InvaliditetInd, 
	PotrebaZaPrilagodenomSobomInd = @PotrebaZaPrilagodenomSobomInd,
	PotrebaZaAsistentomInd = @PotrebaZaAsistentomInd, 
	MozeBitiSmjestenNaKatuInd = @MozeBitiSmjestenNaKatuInd, 
	MozeBitiSmjestenNa1KatuInd = @MozeBitiSmjestenNa1KatuInd, 
	MozeBitiSmjestenNa2KatuInd = @MozeBitiSmjestenNa2KatuInd, 
	MozeBitiSmjestenNa3KatuInd = @MozeBitiSmjestenNa3KatuInd,
	MozeBitiSmjestenNa4KatuInd = @MozeBitiSmjestenNa4KatuInd, 
	MozeBitiSmjestenUDvokrevetnojSobiInd = @MozeBitiSmjestenUDvokrevetnojSobiInd, 
	ApsolventZaostajanjeInd = @ApsolventZaostajanjeInd, 
	ZalbaNegativnoInd = @ZalbaNegativnoInd, 
	ZalbaPozitivnoInd = @ZalbaPozitivnoInd,
	ZalbaUvjetnoInd = @ZalbaUvjetnoInd, 
	RektorovaNagradaBroj = @RektorovaNagradaBroj, 
	DekanovaNagradaBroj = @DekanovaNagradaBroj,
	MedunarodnaNagradaBroj = @MedunarodnaNagradaBroj, 
	DrzavnaNagradaBroj = @DrzavnaNagradaBroj

where DProtocolID = 8103182 