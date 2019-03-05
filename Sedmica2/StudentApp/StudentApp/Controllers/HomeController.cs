using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class HomeController : Controller
    {
        public class HomeIndexVM
        {
            public List<Student> studenti { get; set; }
            public List<Opstina> opstine
 { get; set; }
        }
        MojContext dbContext = new MojContext();

        public IActionResult Index()
        {
            var model = new HomeIndexVM
            {
                studenti = dbContext.Students.OrderByDescending(x => x.ID).ToList(),
                opstine = dbContext.Opstinas.ToList(),
            };
            return View(model);
        }

        public IActionResult StudentDodaj(Student x)
        {
            x.DatumUpisa = DateTime.Now;
            dbContext.Students.Attach(x).State = EntityState.Added;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult OpstinaDodaj(Opstina x)
        {
            dbContext.Opstinas.Attach(x).State = EntityState.Added;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
