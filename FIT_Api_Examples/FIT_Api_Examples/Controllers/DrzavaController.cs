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
    public class DrzavaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DrzavaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public class DrzavaAddVM
        {
            public string opis { get; set; }
        }

        [HttpPost]
        public Drzava Add([FromBody] DrzavaAddVM x)
        {
            var newEmployee = new Drzava
            {
                naziv = x.opis,
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        [HttpGet]
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Drzava
                .OrderBy(s => s.naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.id,
                    opis = s.naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
