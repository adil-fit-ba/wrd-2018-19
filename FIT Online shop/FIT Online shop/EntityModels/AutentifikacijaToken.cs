using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Online_shop.EntityModels
{
    public class AutentifikacijaToken
    {
        public int Id { get; set; }
        public string TokenString { get; set; }
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }
        public DateTime VrijemeSnimanja{ get; set; }

    }
}
