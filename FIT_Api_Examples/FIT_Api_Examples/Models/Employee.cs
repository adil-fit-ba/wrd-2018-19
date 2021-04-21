﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Models
{
    public class Employee
    { 
        [Key]
        public int id { get; set; }
        public string employee_name { get; set; }
        public float? employee_salary { get; set; }
        public int? employee_age { get; set; }
        public DateTime created_time { get; set; }
    }
}
