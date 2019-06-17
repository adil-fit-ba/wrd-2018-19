using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Online_shop.Controllers.v2;

namespace FIT_Online_shop.EntityModels
{
    public class Narudzba
    {
        public int Id { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public float IznosNarudzbe { get; set; }
        public float CijenaDostave { get; set; }
        public string DostavaIme { get; set; }
        public string DostavaTelefon { get; set; }
        public string DostavaPostanskiBroj { get; set; }
        public string DostavaAdresa { get; set; }
        public int? DostavaOpstinaID { get; set; }
        public virtual Opstina DostavaOpstina { get; set; }
        public string Napomena { get; set; }
        public virtual List<NarudzbaStavka> NarudzbaStavka { get; set; } = new List<NarudzbaStavka>();

        public int? KupacID { get; set; }
        public virtual Kupac Kupac{ get; set; }
    }
}
