using System;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Models
{
    public class Project
    { 
        [Key]
        public int id { get; set; }
        public string description { get; set; }
    }
}
