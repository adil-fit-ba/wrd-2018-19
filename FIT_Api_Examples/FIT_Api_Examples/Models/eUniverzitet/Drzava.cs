using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Models.eUniverzitet
{
    public class Drzava
    { 
        [Key]
        public int id { get; set; }
        public string description { get; set; }
    }
}
