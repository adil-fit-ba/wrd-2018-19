using System;
using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using FIT_Online_shop.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.v2
{
    [Route("api/v2/[controller]/[action]")]
    [ApiController]
    public class AutentifikcijaController : ControllerBase
    {
        private MojDbContext _dbContext = new MojDbContext();
        // POST api/values
        public class AutentifikacijaLoginPostVM
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        public class AutentifikcijaLoginResultVM
        {
            public string poruka { get; set; }
            public string tokenString { get; set; }
            public string username { get; set; }
            public string ime { get; set; }
            public string prezime { get; set; }
        }

        

        [HttpPost]
        public IActionResult Login([FromBody]AutentifikacijaLoginPostVM x)
        {
            var k = _dbContext.Kupac.SingleOrDefault(s => s.KorisnickoIme == x.username && s.Lozinka == x.password);
            if (k == null)
                return Unauthorized();

            string tokenString = TokenGenerator.Generate(5);
            _dbContext.Add(new AutentifikacijaToken
            {
                KorisnickiNalogId = k.Id,
                VrijemeEvidentiranja = DateTime.Now,
                Vrijednost = tokenString
            });
            _dbContext.SaveChanges();
            return Ok(new AutentifikcijaLoginResultVM
            {
                poruka = "ispravan login",
                tokenString = tokenString,
                username = k.KorisnickoIme,
                ime = k.Ime,
                prezime = k.Prezime
            });
        }


        [HttpDelete]
        public IActionResult Logout()
        {
            KorisnickiNalog k = HttpContext.GetKorisnikOfAuthToken();
            if (k != null)
            {
                _dbContext.Remove(k);
                _dbContext.SaveChanges();
            }

            return Ok();
        }
    }
}
