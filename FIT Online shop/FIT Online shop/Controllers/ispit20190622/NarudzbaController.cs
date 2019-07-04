using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using FIT_Online_shop.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.ispit1
{
    [Route("api/ispit20190622/[controller]/[action]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        public class NarudzbaDodaj
        {
            public string dostavaOpstinaID;
            public string dostavaAdresa { get; set; }
            public string dostavaIme { get; set; }
            public string dostavaPostanskiBroj { get; set; }
            public string dostavaTelefon { get; set; }
            public string napomena { get; set; }
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
                DostavaOpstinaID = null,
                DostavaPostanskiBroj = x.dostavaPostanskiBroj,
                DostavaTelefon = x.dostavaTelefon,
                Napomena = x.napomena,
                DatumNarudzbe = DateTime.Now,
                KupacID = 1,
            };
            narudzba.IznosNarudzbe = 80;
                  
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
            return Ok(_dbContext.Narudzba.Take(50).OrderByDescending(s=>s.Id).Select(x => new NarudzbaGetAllVM
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

        [HttpGet]
        public ActionResult Find(string name="")
        {
            return Ok(_dbContext.Narudzba.Take(50).OrderByDescending(s => s.Id).Where(q=>q.DostavaIme != null && q.DostavaIme.ToLower().StartsWith(name.ToLower())).Select(x => new NarudzbaGetAllVM
            {
                narudzbaId = x.Id,
                cijenaDostave = x.CijenaDostave,
                iznosNarudzbe = x.IznosNarudzbe,
                dostavaAdresa = x.DostavaAdresa,
                dostavaIme = x.DostavaIme,
                dostavaOpstina = x.DostavaOpstina != null ? x.DostavaOpstina.Naziv : "",
                dostavaPostanskiBroj = x.DostavaPostanskiBroj,
                dostavaTelefon = x.DostavaTelefon,
                napomena = x.Napomena,
                datumNarudzbe = x.DatumNarudzbe,
            }).ToList());
        }
    }
}
