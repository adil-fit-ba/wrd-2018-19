using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul1.Controllers;

namespace FIT_Api_Examples.Modul1.Models
{
    public class Ispit20230715PlaniranoPutovanje
    {
        public int ID { get; set; }
        public DateTime DatumPolaska{ get; set; }
        public DateTime DatumPovratka { get; set; }
        public int BrojSlobodnihMjesta { get; set; }
        public double CijenaEUR { get; set; }
        public string VrstaPrevoza { get; set; }
        public string HotelOpis { get; set; }
        public int Ispit20230715DestinacijaID { get; set; }
        public Ispit20230715Destinacija Ispit20230715Destinacija { get; set; }
    }
}
