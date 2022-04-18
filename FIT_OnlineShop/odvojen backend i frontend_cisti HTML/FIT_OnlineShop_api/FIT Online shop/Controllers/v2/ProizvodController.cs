using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using FIT_Online_shop.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.v2
{
    [Route("api/v2/[controller]/[action]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
   
        private MojDbContext _dbContext = new MojDbContext();

        public class ProizvodGetAllVM
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public float Cijena { get; set; }
            public string JedinicaMjere { get; set; }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            KorisnickiNalog k = HttpContext.GetKorisnikOfAuthToken();
            if (k == null)
                return Unauthorized();

            return Ok(_dbContext.Proizvod.Select(s => new ProizvodGetAllVM
            {
                Cijena = s.Cijena,
                Id = s.Id,
                JedinicaMjere = s.JedinicaMjere,
                Naziv = s.Naziv
            }).ToList());
        }
        [HttpGet]
        public ActionResult GetAllBezAutorizacije(string naziv=null)
        {

            return Ok(_dbContext.Proizvod
                .Where(p=>naziv==null || p.Naziv.ToLower().Contains(naziv.ToLower())        )
                .Select(s => new ProizvodGetAllVM
            {
                Cijena = s.Cijena,
                Id = s.Id,
                JedinicaMjere = s.JedinicaMjere,
                Naziv = s.Naziv
            }).ToList());
        }
    }
}
