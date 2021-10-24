using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Models;
using FIT_Api_Examples.Models.eUniverzitet;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FIT_Api_Examples.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class OpstinaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public OpstinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Opstina Add([FromBody] OpstinaAddVM x)
        {
            var newEmployee = new Opstina
            {
                description = x.opis,
                drzava_id = x.drzava_id,
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        [HttpGet]
        public List<CmbStavke> GetByDrzava(int drzava_id)
        {
            var data = _dbContext.Opstina.Where(x => x.drzava_id == drzava_id)
                .OrderBy(s => s.description)
                .Select(s => new CmbStavke()
                {
                    id = s.id,
                    opis = s.drzava.naziv + " - " + s.description,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
