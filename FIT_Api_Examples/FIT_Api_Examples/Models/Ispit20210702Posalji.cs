using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Api_Examples.Models
{
    public class Ispit20210702Posalji
    {
        public int ID { get; set; }
        public string ImePrezime { get; set; }
        public string Naslov { get; set; }
        public string Poruka { get; set; }
        public string ZaposlenikID { get; set; }
        public DateTime DatumVrijeme { get; set; }
    }
}
