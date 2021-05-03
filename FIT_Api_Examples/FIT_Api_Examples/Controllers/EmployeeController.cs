using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Models;
using FIT_Api_Examples.Models.eUniverzitet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

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
        public class EmployeeAddVM
        {
            public string employee_name { get; set; }
            public float? employee_salary { get; set; }
            public int? employee_age { get; set; }
        }

        [HttpPost]
        public Employee Add([FromBody] EmployeeAddVM x)
        {
            var newEmployee = new Employee
            {
                employee_age = x.employee_age,
                employee_name = x.employee_name,
                employee_salary = x.employee_salary,
                profile_image = Config.SlikeURL + "empty.png",
                created_time = DateTime.Now
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }
        public class EmployeeUpdateVM
        {
            public float? employee_salary { get; set; }
            public int? employee_age { get; set; }
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] EmployeeUpdateVM x)
        {
            Employee employee = _dbContext.Employees.Find(id);

            if (employee == null)
                return BadRequest("pogresan ID");

            employee.employee_age = x.employee_age;
            employee.employee_salary = x.employee_salary;

            _dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Employee employee = _dbContext.Employees.Find(id);

            if (employee == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(employee);

            _dbContext.SaveChanges();
            return Ok(employee);
        }

        public class EmployeeGetAllVM
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
        public PagedList<EmployeeGetAllVM> GetAllPaged(string name, int page_number, int items_per_page)
        {
            var data = _dbContext.Employees.Where(x => name == null || x.employee_name.StartsWith(name)).OrderByDescending(s => s.id)
                .Select(s => new EmployeeGetAllVM
                {
                    id = s.id,
                    employee_name = s.employee_name,
                    employee_salary = s.employee_salary,
                    employee_age = s.employee_age,
                    created_time = s.created_time,
                    profile_image = s.profile_image,
                    task_count = _dbContext.ProjectTask.Count(p => p.employee_id == s.id)
                })
                .AsQueryable();
            return PagedList<EmployeeGetAllVM>.Create(data, page_number, items_per_page);
        }

        [HttpGet]
        public List<EmployeeGetAllVM> GetAll(string name)
        {
            var data = _dbContext.Employees.Where(x => name == null || x.employee_name.StartsWith(name)).OrderByDescending(s => s.id)
                .Select(s => new EmployeeGetAllVM
                {
                    id = s.id,
                    employee_name = s.employee_name,
                    employee_salary = s.employee_salary,
                    employee_age = s.employee_age,
                    created_time = s.created_time,
                    profile_image = s.profile_image,
                    task_count = _dbContext.ProjectTask.Count(p => p.employee_id == s.id)

                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        public class EmployeeImageAddVM
        {
            public IFormFile profile_image { set; get; }
        }

        [HttpPost("{id}")]
        public Employee AddProfileImage(int id, [FromForm] EmployeeImageAddVM x)
        {
            Employee employee = _dbContext.Employees.Find(id);

            if (x.profile_image != null && employee != null)
            {
                string ekstenzija = Path.GetExtension(x.profile_image.FileName);
                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.profile_image.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                employee.profile_image = Config.SlikeURL + filename;
                _dbContext.SaveChanges();
            }

            return employee;
        }
    }
}
