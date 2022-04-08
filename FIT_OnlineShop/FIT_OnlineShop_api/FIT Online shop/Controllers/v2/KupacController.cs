using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.v2
{
    [Route("api/v2/[controller]/[action]")]
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
    
        [HttpPost]
        public IActionResult Registracija([FromBody]KupacRegistracija x)
        {
            if (_dbContext.Kupac.Any(s => s.KorisnickoIme == x.username))
                return BadRequest("username zauzet");

            _dbContext.Add(new Kupac
            {
                KorisnickoIme = x.username,
                Ime = x.ime,
                Lozinka = x.password,
                Prezime = x.prezime,
            });
            _dbContext.SaveChanges();
            return Ok(new { poruka = "uspješno za " + x.username });
        }

    }
}
