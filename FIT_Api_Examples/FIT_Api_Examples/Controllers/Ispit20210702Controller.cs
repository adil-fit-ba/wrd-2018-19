using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Models;
using FIT_Api_Examples.Models.eUniverzitet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FIT_Api_Examples.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20210702Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20210702Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public class Student4VM
        {
            public string ImePrezime { get; set; }
            public string RadnoMjesto { get; set; }
            public string Opis { get; set; }
            public string SlikaPutanja { get; set; }
            public string ID { get; set; }
        }

        List<Student4VM> list => new List<Student4VM>
            {
                new Student4VM
                {   ID = "1",
                    ImePrezime = "Radnik 00001",
                    RadnoMjesto = "CEO",
                    Opis = "Phasellus 1 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team2.png"
                }  ,
                new Student4VM
                {   ID = "2",
                    ImePrezime = "Radnik 00002",
                    RadnoMjesto = "Astronaut",
                    Opis = "Phasellus 2 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team3.png"
                },
                new Student4VM
                {   ID = "3",
                    ImePrezime = "Radnik 00003",
                    RadnoMjesto = "Pilot",
                    Opis = "Phasellus 3 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team4.png"
                },
                new Student4VM
                {   ID = "4",
                    ImePrezime = "Radnik 00004",
                    RadnoMjesto = "Project Manager",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team1.png"
                }
                ,
                new Student4VM
                {   ID = "5",
                    ImePrezime = "Radnik 00005",
                    RadnoMjesto = "Laborant",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team5.png"
                },
                new Student4VM
                {   ID = "6",
                    ImePrezime = "Radnik 00006",
                    RadnoMjesto = "Rektor",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team6.png"
                },
                new Student4VM
                {   ID = "7",
                    ImePrezime = "Radnik 00007",
                    RadnoMjesto = "Profesor",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team7.png"
                },
                new Student4VM
                {   ID = "8",
                    ImePrezime = "Radnik 00008",
                    RadnoMjesto = "Asisten",
                    Opis = "Phasellus 4 eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.",
                    SlikaPutanja = "https://restapiexample.wrd.app.fit.ba/profile_images/team8.png"
                }
            };
        
        [HttpGet]
        public List<Student4VM> Get4Studenta()
        {
            return list.GetRandomElements(4);
        }
        [HttpGet]
        public List<Student4VM> Get8Studenta()
        {
            return list.GetRandomElements(8);
        }

        [HttpPost]
        public Ispit20210702Posalji Add([FromBody] Ispit20210702Posalji x)
        {
            var novi = new Ispit20210702Posalji
            {
                ImePrezime = x.ImePrezime,
                Naslov = x.Naslov,
                Poruka = x.Poruka,
                Telefon = x.Telefon,
          
                DatumVrijeme = DateTime.Now
            };
            _dbContext.Add(novi);
            _dbContext.SaveChanges();

            return novi;
        }

        [HttpGet]
        public List<Ispit20210702Posalji> Get()
        {
            return _dbContext.Ispit20210702Posalji.OrderByDescending(s => s.ID).Take(50).ToList();
        }
    }
}
