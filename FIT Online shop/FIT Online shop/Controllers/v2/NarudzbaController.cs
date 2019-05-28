using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.v2
{
    [Route("api/v2/[controller]/[action]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        public class NarudzbaDodajStavka
        {
            public int proizvodID { get; set; }
            public float kolicina { get; set; }
        }
        public class NarudzbaDodaj
        {
            public int dostavaOpstinaID;
            public string dostavaAdresa { get; set; }
            public string dostavaIme { get; set; }
            public string dostavaPostanskiBroj { get; set; }
            public string dostavaTelefon { get; set; }
            public string napomena { get; set; }
            public List<NarudzbaDodajStavka> stavke { get; set; }
        }
        private MojDbContext _dbContext = new MojDbContext();
    
        [HttpPost]
        public IActionResult Dodaj([FromBody]NarudzbaDodaj x)
        {
            Narudzba narudzba = new Narudzba()
            {
                CijenaDostave = 10,
                DostavaAdresa = x.dostavaAdresa,
                DostavaIme = x.dostavaIme,
                DostavaOpstinaID = x.dostavaOpstinaID,
                DostavaPostanskiBroj = x.dostavaPostanskiBroj,
                DostavaTelefon = x.dostavaTelefon,
                Napomena = x.napomena,
                DatumNarudzbe = DateTime.Now,
            };
            narudzba.IznosNarudzbe = 0;
            x.stavke.ForEach(a =>
            {
                narudzba.NarudzbaStavka.Add(new NarudzbaStavka
                {
                    Id = a.proizvodID,
                    Kolicina = a.kolicina,
                    NarudzbaID = narudzba.Id
                });
                float cijena = _dbContext.Proizvod.Where(p=>p.Id == a.proizvodID).Select(s=>s.Cijena).FirstOrDefault();
                narudzba.IznosNarudzbe += a.kolicina * cijena;
            });

            _dbContext.Add(narudzba);
           
            _dbContext.SaveChanges();
            return Ok(new { poruka = "uspješno" });
        }

    }
}
