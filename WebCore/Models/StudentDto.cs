using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class StudentDto
    {
        public string OIB { get; set; }

        public string JMBAG { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Spol { get; set; }

        public DateTime RodenjeDatum { get; set; }

        public string ImeRoditelja { get; set; }

        public string BrIndeksa { get; set; }

        public string PbrMjestaRodenja { get; set; }

        public string PbrStanovanja { get; set; }

        public string Ulica { get; set; }

        public string KucniBroj { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }

        public string UlicaBoravista { get; set; }

        public string KucniBrBoravista { get; set; }

        public int _GodinaStudija { get; set; }

        public DateTime PravaDo_ISSP { get; set; }

        public string VU_ISSP { get; set; }

        public string AdresaPrebivalista_ISSP { get; set; }

        // dodatak
        public string MjestoRodjenja { get; set; }

        public string MjestoStanovanja { get; set; }

        public int DProtocolID { get; set; }

    }
}
