
declare  @DProtocolIDStudent int
declare @DProtocolIDPrethodno int
declare @DProtocolIDNatjecaj int

--provjeri da li veæ postoji upisana molba za odabranog studenta i natjèaj
declare @DProtocolIDExistingMolba int
select TOP 1 @DProtocolIDExistingMolba = DProtocolID FROM STUD.Molba
		  where DProtocolIDStudent =  @DProtocolIDStudent AND  DProtocolIDNatjecaj = @DProtocolIDNatjecaj

IF  @DProtocolIDPrethodno IS NULL AND @DProtocolIDExistingMolba IS NOT NULL
	begin
		declare @DProtocolIDExistingMolbaString varchar(max)
		SET @DProtocolIDExistingMolbaString = CAST(@DProtocolIDExistingMolba AS VARCHAR(max))

		raiserror('Veæ postoji upisana molba %s',16,1, @DProtocolIDExistingMolbaString)
	end


INSERT INTO dbo.DProtocol
(
    FProtocolID,
    DocumentTypeID,
    DocText,
    DocDate,
	SIDUserCreated,
	DocStatus -- 20
)
values(
    1083,
    11,
    'TestMolba',
	GetDate(),
	24,
	20
)

declare @DProtocolID int
SELECT @DProtocolID = SCOPE_IDENTITY()

declare @rb integer

select @rb = COALESCE(MAX(RedniBroj),0) + 1
from STUD.Molba
where DProtocolIDNatjecaj = @DProtocolIDNatjecaj

INSERT INTO STUD.Molba
(
	DProtocolID, 
	DProtocolIDNatjecaj, 
	DatumMolbe, 
	RedniBroj, 
	DProtocolIDStudent, 
	InvaliditetInd, 
	PotrebaZaPrilagodenomSobomInd,
	PotrebaZaAsistentomInd, 
	MozeBitiSmjestenNaKatuInd, 
	MozeBitiSmjestenNa1KatuInd, 
	MozeBitiSmjestenNa2KatuInd, 
	MozeBitiSmjestenNa3KatuInd,
	MozeBitiSmjestenNa4KatuInd, 
	MozeBitiSmjestenUDvokrevetnojSobiInd, 
	ApsolventZaostajanjeInd, 
	ZalbaNegativnoInd, 
	ZalbaPozitivnoInd,
	ZalbaUvjetnoInd, 
	RektorovaNagradaBroj, 
	DekanovaNagradaBroj,
	MedunarodnaNagradaBroj, 
	DrzavnaNagradaBroj
)
values (
	@DProtocolID,
	6252318, 
	'2018-11-07', 
	@rb, 
	5863183, 
	@InvaliditetInd, 
	@PotrebaZaPrilagodenomSobomInd,
	@PotrebaZaAsistentomInd, 
	@MozeBitiSmjestenNaKatuInd, 
	@MozeBitiSmjestenNa1KatuInd, 
	@MozeBitiSmjestenNa2KatuInd, 
	@MozeBitiSmjestenNa3KatuInd,
	@MozeBitiSmjestenNa4KatuInd, 
	@MozeBitiSmjestenUDvokrevetnojSobiInd, 
	@ApsolventZaostajanjeInd, 
	@ZalbaNegativnoInd, 
	@ZalbaPozitivnoInd,
	@ZalbaUvjetnoInd, 
	@RektorovaNagradaBroj, 
	@DekanovaNagradaBroj,
	@MedunarodnaNagradaBroj, 
	@DrzavnaNagradaBroj
)
