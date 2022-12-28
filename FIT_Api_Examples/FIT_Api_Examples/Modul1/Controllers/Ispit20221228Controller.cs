using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20221228Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20221228Controller(ApplicationDbContext dbContext)
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

        public class Destinacija2VM
        {
            public string MjestoDrzava { get; set; }
            public string ImageUrl { get; set; }
            public double CijenaDolar { get; set; }
            public string OpisPonude { get; set; }
            public List<string> Opcije { get; set; }
            public string AkcijaPoruka { get; set; } = "10% popust";
        }
        private List<Destinacija2VM> listDestinacije => new List<Destinacija2VM>
        {
            new Destinacija2VM
            {
                MjestoDrzava="Turska: Istanbul + Ankara",
                CijenaDolar=2000,
                OpisPonude="21.06.2022. - 5 dana - Hotel ***"     ,
                Opcije = GetOpcije(),
                AkcijaPoruka = "30% akcijski popust",
                ImageUrl= Config.AplikacijURL + "/destinacije/01.jpg"
            } ,

            new Destinacija2VM
            {
                MjestoDrzava="Španija: Madrid",
                CijenaDolar=3000,
                OpisPonude="29.06.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/02.jpg",
                AkcijaPoruka = "20% akcijski popust",
            } ,

            new Destinacija2VM
            {
                MjestoDrzava="Velika Britanija: London",
                CijenaDolar=5000,
                OpisPonude="27.06.2022. - 5 dana - Hotel ****"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/03.jpg",
                AkcijaPoruka = "25% vikend popust",
            } ,
                        new Destinacija2VM
            {
                MjestoDrzava="Eastern Europe: ",
                CijenaDolar=2000,
                OpisPonude="21.09.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/04.jpg"
            } ,
                                    new Destinacija2VM
            {
                MjestoDrzava="Italija",
                CijenaDolar=2000,
                OpisPonude="04.07.2022. - 3 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/05.jpg"
            } ,
                                                new Destinacija2VM
            {
                MjestoDrzava="Švicarske alpe",
                CijenaDolar=5100,
                OpisPonude="05.07.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/06.jpg"
            } ,

                                                  new Destinacija2VM
            {
                MjestoDrzava="Turska: Ankara",
                CijenaDolar=2000,
                OpisPonude="21.07.2022. - 5 dana - Hotel ****"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/01.jpg"
            } ,

            new Destinacija2VM
            {
                MjestoDrzava="Španija i Portugal",
                CijenaDolar=2800,
                OpisPonude="29.07.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/02.jpg"
            } ,

            new Destinacija2VM
            {
                MjestoDrzava="United Kingdom: London",
                CijenaDolar=5000,
                OpisPonude="27.08.2022. - 8 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/03.jpg"
            } ,
                        new Destinacija2VM
            {
                MjestoDrzava="Bosnia and Hercegovina: Mostar",
                CijenaDolar=2000,
                OpisPonude="21.09.2022. - 4 dana - Hotel ****"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/Mostar.jpg"
            } ,
                                    new Destinacija2VM
            {
                MjestoDrzava="Italija i Hrvatska",
                CijenaDolar=2000,
                OpisPonude="04.07.2022. - 3 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                ImageUrl=Config.AplikacijURL +"/destinacije/05.jpg"
            } ,
                                                new Destinacija2VM
            {
                MjestoDrzava="Swiss Alps :-)",
                CijenaDolar=5100,
                OpisPonude="05.07.2022. - 5 dana - Hotel ***"     ,
                   Opcije = GetOpcije(),
                   AkcijaPoruka = "",
                ImageUrl=Config.AplikacijURL +"/destinacije/06.jpg"
            }
        };
        [HttpGet]
        public object GetPonuda()
        {
            var a = listDestinacije
                .GetRandomElements(9)
                ;
            a.ForEach(s => s.Opcije = GetOpcije());

            return new
            {
                datumPonude = DateTime.Now.ToString("g"),
                podaciPonude = a
            };
        }

        public class Ispit20221228Posalji
        {
            public string DestinacijaPrvaSoba { get; set; }
            public string DestinacijaDrugaSoba { get; set; }
            public string Ime_Gosta { get; set; }
            public string Prezime_Gosta { get; set; }
            public string PorukaRezervacije { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Ispit20221228Posalji x)
        {
            if (string.IsNullOrEmpty(x.DestinacijaPrvaSoba))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Destinacija1Soba",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = "Podaci su neispravni"
                });

            if (string.IsNullOrEmpty(x.DestinacijaDrugaSoba))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Destinacija2Soba",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            if (string.IsNullOrEmpty(x.Email) )
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Email",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            if ( string.IsNullOrEmpty(x.Telefon))
                return Ok(new
                {
                    poruka = "Podaci su neispravni: Telefon",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            if (string.IsNullOrEmpty(x.Ime_Gosta) || string.IsNullOrEmpty(x.Prezime_Gosta) )
                return Ok(new
                {
                    poruka = "Podaci su neispravni: ImeGosta ili PrezimeGosta",
                    Vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            return Ok( new
            {
                poruka = "Uspjesno evidentirana",
                Vrijeme = DateTime.Now,
                BrojRezervacije = Class.RandomString(5)
            });
        }



       
    }
}
