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
using Microsoft.EntityFrameworkCore.Internal;

namespace FIT_Api_Examples.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ispit20210601Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20210601Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Ispit20210601Posalji Add([FromBody] Ispit20210601Posalji x)
        {
            var novi = new Ispit20210601Posalji
            {
                Ime = x.Ime,
                Adresa = x.Adresa,
                Grad = x.Grad,
                LicniBrojKupca = x.LicniBrojKupca,
                Upit = x.Upit,
            };
            _dbContext.Add(novi);
            _dbContext.SaveChanges();

            return novi;
        }

        [HttpGet]
        public List<Ispit20210601Posalji> Get()
        {
            return _dbContext.Ispit20210601Posalji.OrderByDescending(s=>s.ID).Take(50).ToList();
        }

    }
}
