using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Online_shop.EntityModels
{
    public class Proizvod
    {
        public string slikaUrl { get; set; }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public string JedinicaMjere { get; set; }
        public int LikeCounter { get;  set; }
        public virtual List<ProizvodOpcije> ProizvodOpcijes{ get;  set; }
    }
}
