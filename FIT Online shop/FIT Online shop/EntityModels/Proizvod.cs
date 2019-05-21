using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Online_shop.EntityModels
{
    public class Proizvod
    {
        public int Id { get; set; }
        public int Naziv { get; set; }
        public float Cijena { get; set; }
        public string JedinicaMjere { get; set; }
    }
}
