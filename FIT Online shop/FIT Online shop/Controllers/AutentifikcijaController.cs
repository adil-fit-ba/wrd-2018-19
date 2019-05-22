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
    public class AutentifikcijaController : ControllerBase
    {
        private MojDbContext _dbContext = new MojDbContext();
        // POST api/values
        public class AutentifikcijaLogin
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        [HttpPost]
        public IActionResult LoginForm([FromForm]AutentifikcijaLogin x)
        {
            return LoginAkcija(x);
        }

        private IActionResult LoginAkcija(AutentifikcijaLogin x)
        {
            var k = _dbContext.Kupac.SingleOrDefault(s => s.KorisnickoIme == x.username && s.Lozinka == x.password);
            if (k == null)
                return Unauthorized();

            string tokenString = Tokenizer.TokenGenerator.Generate(5);
            _dbContext.Add(new AutentifikacijaToken
            {
                KorisnickiNalogId = k.Id,
                VrijemeEvidentiranja = DateTime.Now,
                Vrijednost = tokenString
            });
            _dbContext.SaveChanges();
            return Ok(new
            {
                poruka = "ispravan login",
                tokenString = tokenString,
                username = k.KorisnickoIme,
                ime = k.Ime,
                prezime = k.Prezime
            });
        }

        [HttpPost]
        public IActionResult LoginJson([FromBody]AutentifikcijaLogin x)
        {
            return LoginAkcija(x);
        }


        // DELETE api/values/5
        [HttpGet]
        public ActionResult Logout(string MojToken)
        {
            var x = _dbContext.AutentifikacijaToken.Where(s => s.Vrijednost == MojToken).FirstOrDefault();

            _dbContext.Remove(x);
            _dbContext.SaveChanges();

            return Ok(new
            {
                poruka = "uspješan logout"
            });

        }
    }
}
