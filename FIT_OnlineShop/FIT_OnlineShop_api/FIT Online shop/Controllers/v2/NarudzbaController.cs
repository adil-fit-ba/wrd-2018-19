using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using FIT_Online_shop.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.v2
{
    [Route("api/v2/[controller]/[action]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        public class NarudzbaDodajStavka
        {
            public string proizvodID { get; set; }
            public string kolicina { get; set; }
        }
        public class NarudzbaDodaj
        {
            public string dostavaOpstinaID;
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
            KorisnickiNalog korisnickiNalog = HttpContext.GetKorisnikOfAuthToken();
            if (korisnickiNalog == null)
                return Unauthorized();

            Narudzba narudzba = new Narudzba()
            {
                CijenaDostave = 10,
                DostavaAdresa = x.dostavaAdresa,
                DostavaIme = x.dostavaIme,
                DostavaOpstinaID = x.dostavaOpstinaID==""?(int?) null: int.Parse(x.dostavaOpstinaID),
                DostavaPostanskiBroj = x.dostavaPostanskiBroj,
                DostavaTelefon = x.dostavaTelefon,
                Napomena = x.napomena,
                DatumNarudzbe = DateTime.Now,
                KupacID = korisnickiNalog.Id,
            };
            narudzba.IznosNarudzbe = 0;
            x.stavke.ForEach(a =>
            {
                narudzba.NarudzbaStavka.Add(new NarudzbaStavka
                {
                    ProizvodID = int.Parse(a.proizvodID),
                    Kolicina = float.Parse(a.kolicina),
                    NarudzbaID = narudzba.Id
                });
                float cijena = _dbContext.Proizvod.Where(p=>p.Id == int.Parse(a.proizvodID)).Select(s=>s.Cijena).FirstOrDefault();
                narudzba.IznosNarudzbe += float.Parse(a.kolicina) * cijena;
            });
                  
            _dbContext.Add(narudzba);
           
            _dbContext.SaveChanges();
            return Ok(new { poruka = "uspješno" });
        }

        public class NarudzbaGetAllVM
        {
            public DateTime datumNarudzbe { get; set; }
            public string napomena { get; set; }
            public string dostavaTelefon { get; set; }
            public string dostavaOpstina { get; set; }
            public string dostavaPostanskiBroj { get; set; }
            public string dostavaAdresa { get; set; }
            public string dostavaIme { get; set; }
            public float cijenaDostave { get; set; }
            public float iznosNarudzbe { get; set; }
            public int narudzbaId { get; set; }
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            KorisnickiNalog k = HttpContext.GetKorisnikOfAuthToken();
            if (k == null)
                return Unauthorized();

            return Ok(_dbContext.Narudzba.Where(s=>s.KupacID == k.Id).Select(x => new NarudzbaGetAllVM
            {
                narudzbaId = x.Id,
                cijenaDostave = x.CijenaDostave,
                iznosNarudzbe = x.IznosNarudzbe,
                dostavaAdresa = x.DostavaAdresa,
                dostavaIme = x.DostavaIme,
                dostavaOpstina = x.DostavaOpstina!=null?x.DostavaOpstina.Naziv:"",
                dostavaPostanskiBroj = x.DostavaPostanskiBroj,
                dostavaTelefon = x.DostavaTelefon,
                napomena = x.Napomena,
                datumNarudzbe = x.DatumNarudzbe,
            }).ToList());
        }
    }
}
