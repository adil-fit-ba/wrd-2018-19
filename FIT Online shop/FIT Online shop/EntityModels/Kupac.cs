using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Online_shop.EntityModels
{
    public class Kupac
    {
        public int Id { get; set; }

        public string Username{ get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
