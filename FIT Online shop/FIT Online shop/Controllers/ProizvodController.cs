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
        public ActionResult GetAll_QueryP(string MojToken)
        {
            KorisnickiNalog k = MyAuthTokenExtension.GetKorisnikOfAuthToken(MojToken);

            if (k==null)
                return Unauthorized();

            return Ok(_dbContext.Proizvod.ToList());
        }

        [HttpGet]
        public ActionResult GetAll_HeaderP()
        {
            var MojToken = HttpContext.GetMyAuthTokenFromHeader();
            KorisnickiNalog k =MyAuthTokenExtension.GetKorisnikOfAuthToken(MojToken);

            if (k == null)
                return Unauthorized();

            return Ok(_dbContext.Proizvod.ToList());
        }

        [HttpGet]
        public ActionResult GetAll_Proba()
        {

            return Ok(_dbContext.Proizvod.ToList());
        }
    }
}
