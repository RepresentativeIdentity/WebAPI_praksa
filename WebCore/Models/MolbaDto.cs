using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class MolbaDto
    {
        public int DProtocolID { get; set; }

        public int DProtocolIDNatjecaj { get; set; }

        public DateTime DatumMolbe { get; set; }

        public int RedniBroj { get; set; }

        public int DProtocolIDStudent { get; set; }

        public int InvaliditetInd { get; set; }

        public int PotrebaZaPrilagodenomSobomInd { get; set; }

        public int PotrebaZaAsistentomInd { get; set; }

        public int MozeBitiSmjestenNaKatuInd { get; set; }

        public int MozeBitiSmjestenNa1KatuInd { get; set; }

        public int MozeBitiSmjestenNa2KatuInd { get; set; }

        public int MozeBitiSmjestenNa3KatuInd { get; set; }

        public int MozeBitiSmjestenNa4KatuInd { get; set; }

        public int MozeBitiSmjestenUDvokrevetnojSobiInd { get; set; }

        public int ApsolventZaostajanjeInd { get; set; }

        public int ZalbaNegativnoInd { get; set; }

        public int ZalbaPozitivnoInd { get; set; }
        
        public int ZalbaUvjetnoInd { get; set; }
        
        public int RektorovaNagradaBroj { get; set; }
        
        public int DekanovaNagradaBroj { get; set; }
        
        public int MedunarodnaNagradaBroj { get; set; }
        
        public int DrzavnaNagradaBroj{ get; set; }

    }
}
