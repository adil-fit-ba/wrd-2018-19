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
    public class Ispit20230126Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20230126Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public class Destinacija2VM
        {
            public string Mjesto_Drzava { get; set; }
            public string SlikaUrl { get; set; }
            public double OsnovnaCijenaDolar { get; set; }
            public string DatumOpis { get; set; }
            public string AkcijaPoruka { get; set; } = "10% popust";
        }
        private List<Destinacija2VM> listDestinacije => new List<Destinacija2VM>
        {
            new Destinacija2VM
            {
                Mjesto_Drzava="Turska: Istanbul + Ankara",
                OsnovnaCijenaDolar=2000,
                DatumOpis="21.06.2022. - 5 dana - Hotel ***"     ,
                AkcijaPoruka = "30% akcijski popust",
                SlikaUrl= Config.AplikacijURL + "/destinacije/01.jpg"
            } ,

            new Destinacija2VM
            {
                Mjesto_Drzava="Španija: Madrid",
                OsnovnaCijenaDolar=3000,
                DatumOpis="29.06.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/02.jpg",
                AkcijaPoruka = "20% akcijski popust",
            } ,

            new Destinacija2VM
            {
                Mjesto_Drzava="Velika Britanija: London",
                OsnovnaCijenaDolar=5000,
                DatumOpis="27.06.2022. - 5 dana - Hotel ****"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/03.jpg",
                AkcijaPoruka = "25% vikend popust",
            } ,
                        new Destinacija2VM
            {
                Mjesto_Drzava="Eastern Europe: ",
                OsnovnaCijenaDolar=2000,
                DatumOpis="21.09.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/04.jpg"
            } ,
                                    new Destinacija2VM
            {
                Mjesto_Drzava="Italija",
                OsnovnaCijenaDolar=2000,
                DatumOpis="04.07.2022. - 3 dana - Hotel ***"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/05.jpg"
            } ,
                                                new Destinacija2VM
            {
                Mjesto_Drzava="Švicarske alpe",
                OsnovnaCijenaDolar=5100,
                DatumOpis="05.07.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/06.jpg"
            } ,

                                                  new Destinacija2VM
            {
                Mjesto_Drzava="Turska: Ankara",
                OsnovnaCijenaDolar=2000,
                DatumOpis="21.07.2022. - 5 dana - Hotel ****"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/01.jpg"
            } ,

            new Destinacija2VM
            {
                Mjesto_Drzava="Španija i Portugal",
                OsnovnaCijenaDolar=2800,
                DatumOpis="29.07.2022. - 5 dana - Hotel ***"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/02.jpg"
            } ,

            new Destinacija2VM
            {
                Mjesto_Drzava="United Kingdom: London",
                OsnovnaCijenaDolar=5000,
                DatumOpis="27.08.2022. - 8 dana - Hotel ***"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/03.jpg"
            } ,
                        new Destinacija2VM
            {
                Mjesto_Drzava="Bosnia and Hercegovina: Mostar",
                OsnovnaCijenaDolar=2000,
                DatumOpis="21.09.2022. - 4 dana - Hotel ****"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/Mostar.jpg"
            } ,
                                    new Destinacija2VM
            {
                Mjesto_Drzava="Italija i Hrvatska",
                OsnovnaCijenaDolar=2000,
                DatumOpis="04.07.2022. - 3 dana - Hotel ***"     ,
                SlikaUrl=Config.AplikacijURL +"/destinacije/05.jpg"
            } ,
                                                new Destinacija2VM
            {
                Mjesto_Drzava="Swiss Alps :-)",
                OsnovnaCijenaDolar=5100,
                DatumOpis="05.07.2022. - 5 dana - Hotel ***"     ,
                   AkcijaPoruka = "",
                SlikaUrl=Config.AplikacijURL +"/destinacije/06.jpg"
            }
        };
        [HttpGet]
        public object GetPonuda()
        {
            List<Destinacija2VM> a = listDestinacije
                .GetRandomElements(9);

            return a;
        }

        public class IspitPosalji
        {
            public string DestinacijaPrvaSoba { get; set; }
            public string DestinacijaDrugaSoba { get; set; }
            public string ImeKlijenta { get; set; }
            public string PrezimeKlijenta { get; set; }
            public string EmailAdresa { get; set; }
            public string MobitelBroj { get; set; }
        }


        [HttpPost]
        public ActionResult Add([FromBody] IspitPosalji x)
        {
            if (string.IsNullOrEmpty(x.DestinacijaPrvaSoba))
                return Ok(new
                {
                    porukaKlijenta = "Podaci su neispravni: Destinacija1Soba",
                    vrijeme = DateTime.Now,
                    BrojRezervacije = "Podaci su neispravni"
                });

            if (string.IsNullOrEmpty(x.DestinacijaDrugaSoba))
                return Ok(new
                {
                    porukaKlijenta = "Podaci su neispravni: Destinacija2Soba",
                    vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            if (string.IsNullOrEmpty(x.EmailAdresa) )
                return Ok(new
                {
                    porukaKlijenta = "Podaci su neispravni: Email",
                    vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            if ( string.IsNullOrEmpty(x.MobitelBroj))
                return Ok(new
                {
                    porukaKlijenta = "Podaci su neispravni: Telefon",
                    vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            if (string.IsNullOrEmpty(x.ImeKlijenta) || string.IsNullOrEmpty(x.PrezimeKlijenta) )
                return Ok(new
                {
                    porukaKlijenta = "Podaci su neispravni: ImeGosta ili PrezimeGosta",
                    vrijeme = DateTime.Now,
                    BrojRezervacije = "000-000"
                });

            return Ok( new
            {
                porukaKlijenta = "Uspjesno evidentirana",
                vrijeme = DateTime.Now,
                BrojRezervacije = Class.RandomString(5)
            });
        }



       
    }
}
