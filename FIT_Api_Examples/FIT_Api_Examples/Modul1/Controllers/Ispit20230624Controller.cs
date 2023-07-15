using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20230624Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20230624Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        private List<string> GetOpcije()
        {
            return Helper.Data.opcije.GetRandomElements(4).OrderBy(a=>a).ToList();
        }

        [HttpGet]
        public object GetTravelFirme()
        {
            return _dbContext.TravelFirma20220924.ToList();
        }

        [HttpGet]
        public object GetRezervacije(string brojIndeksa)
        {
            return _dbContext.Ispit20230624PosaljiZapis.Where(x=>string.IsNullOrWhiteSpace(brojIndeksa) || x.BrojIndeksa == brojIndeksa).OrderByDescending(x=>x.Id).ToList();
        }

        [HttpGet]
        public object GetPonuda(string travelfirma)
        {
            var a = _dbContext.DestinacijaVM20220924.Where(s => s.TravelFirma.Naziv == travelfirma)
                .Include(s => s.TravelFirma)
                .ToList()
                .Select(x => new
                {
                    x.AkcijaPoruka,
                    x.CijenaDolar,
                    x.ImageUrl,
                    x.MjestoDrzava,
                    x.ID,
                    x.OpisPonude,
                    Sobe=Sobe.GetRandomElements(3),
                })
                .GetRandomElements(9);
               

            return new
            {
                datumPonude = DateTime.Now.ToString("g"),
                travelfirma = travelfirma?? "Upozorenje. Nema podataka (ponuda) jer nije proslijedjenj query parametar 'travelfirma'! Pogledajte opis na swaggeru. Preuzmite vrijednost 'travelfirme' iz padajuceg menija (HTML SELECT iznad dugmeta BEST OFFERS)... Tri moguće vrijednosti su 'Herc Tours doo', 'Sisic Travel doo', 'Bajro Tours doo'",
                podaci = a
            };
        }


        public class Ispit20230624Posalji
        {
            public string TravelFirma { get; set; }
            public string DestinacijaDrzava { get; set; }
            public string BrojIndeksa { get; set; }
            public List<string> Gosti { get; set; }
            public string Poruka { get; set; }
            public string Telefon { get; set; }
            public string OznakaSoba { get; set; }
        }

        public class Soba
        {
            public Soba(int maxBrojGostiju, string oznakaSobe, double cijenaDoplate)
            {
                MaxBrojGostiju = maxBrojGostiju;
                OznakaSobe = oznakaSobe;
                CijenaDoplate = cijenaDoplate;
            }

            public double CijenaDoplate { get; set; }
            public int MaxBrojGostiju { get; set; }
            public string OznakaSobe { get; set; }
        }

        public static List<Soba> Sobe => new List<Soba>
        {
            new (3, "Apratman C3 - sa balkonom", 0),
            new (4, "Apartman C4", 50),
            new (5, "Apartman C5", 230),
            new (2, "Dvokrevetna soba- Hotel ABC", 299.90),
        };
        public class Ispit20230624PosaljiZapis
        {
            public int? Id { get; set; }
            public string DestinacijaDrzava { get; set; }
            public string BrojIndeksa { get; set; }
            public string Gosti { get; set; }
            public string Poruka { get; set; }
            public string Telefon { get; set; }
            public DateTime Vrijeme { get; set; }
            public string OznakaSoba { get; set; }
            public string ipAdresa { get; set; }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Ispit20230624Posalji x)
        {
            string remoteIpAddress = "";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                remoteIpAddress += (ip.ToString() + " | ");
            }
            

            if (string.IsNullOrEmpty(x.DestinacijaDrzava))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Destinacija1Soba",
                    Vrijeme = DateTime.Now,
                    IpAdresa=remoteIpAddress
                });


            if (string.IsNullOrEmpty(x.TravelFirma) || !_dbContext.TravelFirma20220924.Any(t => t.Naziv == x.TravelFirma))
            {
                return Ok(new
                {
                    poruka = "Podaci su neispravni: TravelFirma",
                    Vrijeme = DateTime.Now,
                    IpAdresa = remoteIpAddress
                });
            }

            if (string.IsNullOrEmpty(x.BrojIndeksa) ||  !new Regex("IB\\d{6}").IsMatch(x.BrojIndeksa) )
                return Ok(new
                {
                    poruka = "Podaci su neispravni: BrojIndeksa",
                    Vrijeme = DateTime.Now,
                    IpAdresa = remoteIpAddress
                });

            if ( string.IsNullOrEmpty(x.Telefon))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Telefon",
                    Vrijeme = DateTime.Now,
                    IpAdresa = remoteIpAddress
                });

            Ispit20230624PosaljiZapis entity = new Ispit20230624PosaljiZapis
            {
                Gosti = string.Join("|", x.Gosti),
                BrojIndeksa = x.BrojIndeksa,
                Telefon = x.Telefon,
                DestinacijaDrzava = x.DestinacijaDrzava,
                OznakaSoba = x.OznakaSoba,
                Poruka = x.Poruka,
                Vrijeme = DateTime.Now,
                ipAdresa = remoteIpAddress
            };
            _dbContext.Add(entity);

            _dbContext.SaveChanges();

            return Ok( new
            {
                poruka = "Uspjesno evidentirana",
                Vrijeme = entity.Vrijeme,
                IdRezervacije = entity.Id,
                IpAdresa = remoteIpAddress,
            });
        }



       
    }
}
