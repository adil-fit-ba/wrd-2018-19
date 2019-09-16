using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Online_shop.EntityModels
{
    public class NarudzbaStavka
    {
        public int Id { get; set; }
        public virtual Narudzba Narudzba{ get; set; }
        public int NarudzbaID { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public int ProizvodID { get; set; }
        public float Kolicina { get; set; }
        public float Sirina { get; set; }
        public float Visina { get; set; }
        public string OpcijaModel { get; set; }
        public string StranaOtvora { get; set; }
    }
}
