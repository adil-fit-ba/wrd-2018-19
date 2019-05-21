using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KupacController : ControllerBase
    {
        public class KupacRegistracija
        {
            public string username { get; set; }
            public string password { get; set; }
            public string ime { get; set; }
            public string prezime { get; set; }
        }
        private MojDbContext _dbContext = new MojDbContext();
        // POST api/values
        [HttpPost]
        public IActionResult RegistracijaForm([FromForm]KupacRegistracija x)
        {
            _dbContext.Add(new Kupac
            {
                KorisnickoIme = x.username,
                Ime = x.ime,
                Lozinka = x.password,
                Prezime = x.prezime,
            });
            _dbContext.SaveChanges();
            return Ok("uspješno za " + x.username);
        }
        [HttpPost]
        public IActionResult RegistracijaJson([FromBody]KupacRegistracija x)
        {
            _dbContext.Add(new Kupac
            {
                KorisnickoIme = x.username,
                Ime = x.ime,
                Lozinka = x.password,
                Prezime = x.prezime,
            });
            _dbContext.SaveChanges();
            return Ok(new {poruka = "uspješno za " + x.username});
        }
    }
}
