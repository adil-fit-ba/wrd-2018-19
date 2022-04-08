using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using FIT_Online_shop.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.v1
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private MojDbContext _dbContext = new MojDbContext();
        // GET api/values
        [HttpGet]
        public ActionResult GetAllQ(string token)
        {
            KorisnickiNalog k = MyAuthTokenExtension.GetKorisnikOfAuthToken(token);
            if (k == null)
                return Unauthorized();

            return GetAllAkcija();
        }

        [HttpGet]
        public ActionResult GetAllH()
        {
            string token = HttpContext.GetMyAuthToken();
            KorisnickiNalog k = MyAuthTokenExtension.GetKorisnikOfAuthToken(token);
            if (k == null)
                return Unauthorized();

            return GetAllAkcija();
        }
        public class ProizvodGetAllVM
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public float Cijena { get; set; }
            public string JedinicaMjere { get; set; }
            public string Slika { get; set; }
        }
        private ActionResult GetAllAkcija()
        {
            return Ok(_dbContext.Proizvod.Select(s => new ProizvodGetAllVM
            {
                Cijena = s.Cijena,
                Id = s.Id,
                JedinicaMjere = s.JedinicaMjere,
                Naziv = s.Naziv ,
                Slika=s.slikaUrl
            }).ToList());
        }

        [HttpGet]
        public ActionResult GetAllProba()
        {
            return GetAllAkcija();
        }
    }
}
