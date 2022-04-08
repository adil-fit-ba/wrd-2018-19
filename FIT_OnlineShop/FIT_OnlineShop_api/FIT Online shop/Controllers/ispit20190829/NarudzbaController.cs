using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using FIT_Online_shop.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.ispit20190829
{
    [Route("api/ispit20190829/[controller]/[action]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        public class KupiDodaj
        {
            public string dostavaGrad { get; set; }
            public string dostavaAdresa { get; set; }
            public string dostavaIme { get; set; }
            public string dostavaTelefon { get; set; }
            public int ProizvodId { get; set; }
            public float Kolicina { get; set; }
        }

        private MojDbContext _dbContext = new MojDbContext();

        [HttpPost]
        public IActionResult Dodaj([FromBody] KupiDodaj x)
        {

            Narudzba narudzba = new Narudzba()
            {
                CijenaDostave = 10,
                DostavaAdresa = x.dostavaAdresa + " " + x.dostavaGrad,
                DostavaIme = x.dostavaIme,
                DostavaOpstinaID = null,
                DostavaPostanskiBroj = "",
                DostavaTelefon = x.dostavaTelefon,
                Napomena = "",
                DatumNarudzbe = DateTime.Now,
                KupacID = 1,
            };
            Proizvod proizvod = _dbContext.Proizvod.Find(x.ProizvodId);


            narudzba.IznosNarudzbe = x.Kolicina * proizvod.Cijena;


            NarudzbaStavka stavka = new NarudzbaStavka();
            stavka.Kolicina = x.Kolicina;
            stavka.ProizvodID = x.ProizvodId;
            stavka.Narudzba = narudzba;

            _dbContext.Add(narudzba);
            _dbContext.Add(stavka);

            _dbContext.SaveChanges();
            return Ok(new {poruka = "uspješno"});
        }

        public class ProizvodiGetAll
        {
            public int proizvodID { get; set; }
            public int likeCounter { get; set; }
            public string naziv{ get; set; }
            public float cijena { get; set; }
            public string jedinicaMjere{ get; set; }
        }

        [HttpGet]
        public ActionResult GetProizvodiAll()
        {
            return Ok(_dbContext.Proizvod.OrderBy(s => s.Naziv).Select(x => new ProizvodiGetAll
            {
                proizvodID = x.Id,
                naziv = x.Naziv,
                cijena = x.Cijena,
                jedinicaMjere = x.JedinicaMjere,
                likeCounter = x.LikeCounter
            }).ToList());
        }

        [HttpGet]
        public ActionResult GetNarudzbeAll()
        {
            return Ok(_dbContext.NarudzbaStavka.OrderByDescending(s => s.Id).Take(50).Select(x => new 
            {
                proizvodID = x.Proizvod.Id,
                naziv = x.Proizvod.Naziv,
                cijena = x.Proizvod.Cijena,
                kolicina = x.Kolicina,
                iznos = x.Kolicina * x.Proizvod.Cijena,
                jedinicaMjere = x.Proizvod.JedinicaMjere,
                likeCounter = x.Proizvod.LikeCounter,
                dostavaIme = x.Narudzba.DostavaIme,
                dostavaAdresa = x.Narudzba.DostavaAdresa,
                datumNarudzbe = x.Narudzba.DatumNarudzbe,
                dostavaTelefon = x.Narudzba.DostavaTelefon,
            }).ToList());
        }

        [HttpGet]
        public ActionResult Like(int proizvodId)
        {
            var x = _dbContext.Proizvod.Find(proizvodId);
            x.LikeCounter++;
            _dbContext.SaveChanges();
            return Ok(new { poruka = "uspješno", proizvodId, x.LikeCounter });
        }
    }
}
