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

        [HttpGet]
        public List<Employee> GetAll()
        {
            return _dbContext.Employees.OrderByDescending(s=>s.id).ToList();
        }
    }
}
