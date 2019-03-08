using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
                studenti = dbContext.Students.OrderByDescending(x => x.ID).Take(30).ToList(),
                opstine = dbContext.Opstinas.Where(s=>s.Opis.Length>3).ToList(),
            };
            return View(model);
        }

        public IActionResult StudentDodaj(Student x)
        {
            if (x.Ime == null || x.Prezime == null || x.Ime.Length < 3 || x.Ime.Length < 3)
                return Content("Greska. Parametri 'Ime' i 'Prezime' moraju biti duži od 3 karaktra.");

            x.DatumUpisa = DateTime.Now;
            dbContext.Students.Attach(x).State = EntityState.Added;
            dbContext.SaveChanges();
            return View();
        }

        public IActionResult OpstinaDodaj(Opstina x)
        {
            if (x.Opis == null || x.Opis.Length < 5)
                return Content("Greska. Parametar 'Opis' mora biti duži od 5 karaktra.");
            dbContext.Opstinas.Attach(x).State = EntityState.Added;
            dbContext.SaveChanges();
            return View();
        }

        public IActionResult OpstinaObrisi(int OpstinaID)
        {
            Opstina x = dbContext.Opstinas.Find(OpstinaID);
            dbContext.Opstinas.Remove(x);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult OpstinaGetAllJson()
        {
            var x = dbContext.Opstinas.Where(s => s.Opis.Length > 3).ToList();
            return Json(x);
        }
    }
}
