using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }
        public string Status { get; set; }
        public DateTime? DatumRodjenja{ get; set; }
        public DateTime? DatumUpisa{ get; set; }

        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public int? OpstinaRodjenjaId { get; set; }
        public virtual Opstina OpstinaRodjenja { get; set; }

        public int? OpstinaPrebivalistaId { get; set; }
        public virtual Opstina OpstinaPrebivalista { get; set; }

     
    }
}
