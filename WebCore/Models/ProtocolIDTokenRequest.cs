using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class ProtocolIDTokenRequest
    {

        public int ProtocolID { get; set; }

        public string OIB { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string JMBAG { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }

    }
}
