using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Online_shop.EF;
using Microsoft.AspNetCore.Mvc;
using Posiljka.Data.EntityModels;
using Posiljka.Web.Helper.webapi;

namespace FIT_Online_shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private MojDbContext _dbContext = new MojDbContext();
        // GET api/values
        [HttpGet]
        public ActionResult GetAll(string token)
        {
            KorisnickiNalog k = MyAuthTokenExtension.GetKorisnikOfAuthToken(token);
            if (k==null)
                return Unauthorized();

            return Ok(_dbContext.Proizvod.ToList());
        }

        [HttpGet]
        public ActionResult GetAllProba()
        {

            return Ok(_dbContext.Proizvod.ToList());
        }
    }
}
