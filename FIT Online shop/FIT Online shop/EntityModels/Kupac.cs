using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Posiljka.Data.EntityModels;

namespace FIT_Online_shop.EntityModels
{
    public class Kupac  :KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
