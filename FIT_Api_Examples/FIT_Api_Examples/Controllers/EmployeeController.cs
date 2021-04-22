using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]

        public Employee Get(int id)
        {
            return _dbContext.Employees.Find(id);
        }
        
       [HttpPost()]

        public Employee Post([FromBody]Employee employee)
        {
            employee.profile_image = "https://restapiexample.wrd.app.fit.ba/profile_images/empty.png";
            var result = _dbContext.Add(employee).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public class EmployeeVM
        {
            public int id { get; set; }
            public string employee_name { get; set; }
            public float? employee_salary { get; set; }
            public int? employee_age { get; set; }
            public DateTime created_time { get; set; }
            public string profile_image { get; set; }
            public int task_count { get; set; }
        }
        [HttpGet]
        public List<EmployeeVM> GetAll()
        {
            return _dbContext.Employees.OrderByDescending(s=>s.id)
                .Select(s=>new EmployeeVM
                {
                    id=s.id,
                    employee_name = s.employee_name,
                    employee_salary = s.employee_salary,
                    employee_age = s.employee_age,
                    created_time = s.created_time,
                    profile_image = s.profile_image,
                    task_count = _dbContext.ProjectTask.Count(p => p.employee_id==s.id)

                })
                .ToList();
        }
    }
}
