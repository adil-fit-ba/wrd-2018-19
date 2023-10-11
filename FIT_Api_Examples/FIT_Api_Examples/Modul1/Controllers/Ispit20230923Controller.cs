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
using FIT_Api_Examples.Modul1.Models;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20230923Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20230923Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public object GetTravelFirme()
        {
            return _dbContext.TravelFirma20220924.ToList();
        }

        [HttpGet]
        public object GetRezervacije(string brojIndeksa)
        {
            return _dbContext.Ispit20230715PosaljiZapis
                .Where(x=>string.IsNullOrWhiteSpace(brojIndeksa) || x.BrojIndeksa == brojIndeksa)
                .OrderByDescending(x=>x.ID)
                .ToList();
        }

        [HttpGet]
        public object GetPonuda(string travelfirma)
        {
            var now = DateTime.Now;
            var a = _dbContext.Ispit20230715Destinacija
                .Where(s => s.TravelFirma.Naziv == travelfirma)
                .Take(6)
                .Select(x => new
                {
                    x.ImageUrl,
                    x.MjestoDrzava,
                    x.ID,
                    x.OpisPonude,
                    ZadnjePutovanje = x.Ispit20230715PlaniranoPutovanjeList
                        .Where(pp => pp.DatumPolaska < DateTime.Now)
                        .Select(pp => new
                        {
                            PrijeDana = (now - pp.DatumPolaska).Days,
                            DatumPolaska = pp.DatumPolaska.ToString("dd.MM.yyyy HH-mm"),
                        }).FirstOrDefault(),

                    NaredniPolazak = x.Ispit20230715PlaniranoPutovanjeList
                        .Where(pp=> pp.DatumPolaska>= DateTime.Now)
                        .Select(pp => new
                        {
                            ZaDana = (pp.DatumPolaska - now).Days,
                            DatumPolaska = pp.DatumPolaska.ToString("dd.MM.yyyy"),
                            pp.BrojSlobodnihMjesta,
                            CijenaEUR = pp.CijenaEUR
                        }).FirstOrDefault(),
                    PlaniranaPutovanja=x.Ispit20230715PlaniranoPutovanjeList.OrderBy(pp=>pp.DatumPolaska).Select(pp=>new
                    {
                        pp.ID,
                        pp.BrojSlobodnihMjesta,
                        CijenaEUR = pp.CijenaEUR,
                        DatumPolaska = pp.DatumPolaska.ToString("dd.MM.yyyy"),
                        DatumPovratka = pp.DatumPovratka.ToString("dd.MM.yyyy"),
                        pp.HotelOpis,
                        pp.VrstaPrevoza,
                        brojDana = (pp.DatumPovratka - pp.DatumPolaska).Days,
                    })
                })
                .ToList();
               

            return new
            {
                datumPonude = DateTime.Now.ToString("g"),
                travelfirma = travelfirma?? "Upozorenje. Nema podataka (ponuda) jer nije proslijedjenj query parametar 'travelfirma'! Pogledajte opis na swaggeru. Preuzmite vrijednost 'travelfirme' iz padajuceg menija (HTML SELECT iznad dugmeta BEST OFFERS)... Tri moguće vrijednosti su 'Herc Tours doo', 'Sisic Travel doo', 'Bajro Tours doo'",
                podaci = a
            };
        }


        public class Ispit20230923Posalji
        {
            public string TravelFirmaNaziv { get; set; }
            public string Destinacija { get; set; }
            public string BrojDosjea { get; set; }
            public string[] GostiPutovanja { get; set; }
            public string Message { get; set; }
            public string TelefonKontakt { get; set; }
            public string DatumPolaskaPutovanja{ get; set; }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Ispit20230923Posalji x)
        {
            string remoteIpAddress = "";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                remoteIpAddress += (ip.ToString() + " | ");
            }


            if (string.IsNullOrEmpty(x.DatumPolaskaPutovanja))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: DatumPolaska",
                    Vrijeme = DateTime.Now,
                    IpAdresa = remoteIpAddress
                });


            if (string.IsNullOrEmpty(x.Destinacija))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: DestinacijaDrzava",
                    Vrijeme = DateTime.Now,
                    IpAdresa=remoteIpAddress
                });


            if (string.IsNullOrEmpty(x.TravelFirmaNaziv) || !_dbContext.TravelFirma20220924.Any(t => t.Naziv == x.TravelFirmaNaziv))
            {
                return Ok(new
                {
                    poruka = "Podaci su neispravni: TravelFirma",
                    Vrijeme = DateTime.Now,
                    IpAdresa = remoteIpAddress
                });
            }

            if (string.IsNullOrEmpty(x.BrojDosjea) ||  !new Regex("IB\\d{6}").IsMatch(x.BrojDosjea) )
                return Ok(new
                {
                    poruka = "Podaci su neispravni: BrojIndeksa",
                    Vrijeme = DateTime.Now,
                    IpAdresa = remoteIpAddress
                });
       

            if ( string.IsNullOrEmpty(x.TelefonKontakt))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Telefon",
                    Vrijeme = DateTime.Now,
                    IpAdresa = remoteIpAddress
                });

            Ispit20230715PosaljiZapis entity = new Ispit20230715PosaljiZapis
            {
                Gosti = string.Join("|", x.GostiPutovanja),
                BrojIndeksa = x.BrojDosjea,
                Telefon = x.TelefonKontakt,
                DatumPolaska = x.DatumPolaskaPutovanja,
                DestinacijaDrzava = x.Destinacija,
                TravelFirma = x.TravelFirmaNaziv,
                Poruka = x.Message,
                Vrijeme = DateTime.Now,
                IpAdresa = remoteIpAddress
            };
            _dbContext.Add(entity);

            _dbContext.SaveChanges();

            return Ok( new
            {
                poruka = "Uspjesno evidentirana",
                Vrijeme = entity.Vrijeme,
                IdRezervacije = entity.ID,
                IpAdresa = remoteIpAddress,
            });
        }


      
    }
}
