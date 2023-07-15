using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul1.Controllers;

namespace FIT_Api_Examples.Modul1.Models
{
    public class Ispit20230715Destinacija
    {
        public int ID { get; set; }
        public string MjestoDrzava { get; set; }
        public string ImageUrl { get; set; }
        public string OpisPonude { get; set; }
        public int TravelFirmaID { get; set; }
        public Ispit20220924Controller.TravelFirma TravelFirma { get; set; }
        public string AkcijaPoruka { get; set; } = "";
        public List<Ispit20230715PlaniranoPutovanje> Ispit20230715PlaniranoPutovanjeList { get; set; }
    }
}
