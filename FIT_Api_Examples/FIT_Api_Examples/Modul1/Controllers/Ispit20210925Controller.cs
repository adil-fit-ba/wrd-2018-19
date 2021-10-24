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
    public class Ispit20210925Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Ispit20210925Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
       
        [HttpGet]
        public List<Student4VM> FindByExpertType(string type)
        {
            return Helper.Data.listRadnici.Where(s=> string.IsNullOrEmpty(type) || s.RadnoMjesto == type).ToList().GetRandomElements(4);
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
    }
}
