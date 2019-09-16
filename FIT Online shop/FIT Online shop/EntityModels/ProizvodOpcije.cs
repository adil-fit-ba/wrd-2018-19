using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Online_shop.EntityModels
{
    public class ProizvodOpcije
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public Proizvod Proizvod{ get; set; }
        public int ProizvodId{ get; set; }
    }
}
