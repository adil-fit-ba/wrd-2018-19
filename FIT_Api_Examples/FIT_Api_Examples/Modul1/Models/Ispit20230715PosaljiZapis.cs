using System;
using System.Collections.Generic;

namespace FIT_Api_Examples.Modul1.Models
{
   

    public class Ispit20230715PosaljiZapis
    {
        public int ID { get; set; }
        public string TravelFirma { get; set; }
        public string DestinacijaDrzava { get; set; }
        public string BrojIndeksa { get; set; }
        public string Gosti { get; set; }
        public string Poruka { get; set; }
        public string Telefon { get; set; }
        public DateTime Vrijeme { get; set; }
        public int? Ispit20230715PlaniranoPutovanjeId { get; set; }
        public Ispit20230715PlaniranoPutovanje Ispit20230715PlaniranoPutovanje { get; set; }
        public string IpAdresa { get; set; }
        public string DatumPolaska { get; set; }
    }
}
