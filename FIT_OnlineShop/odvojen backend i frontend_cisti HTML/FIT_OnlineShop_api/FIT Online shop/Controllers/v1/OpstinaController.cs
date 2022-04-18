using System.Linq;
using FIT_Online_shop.EF;
using FIT_Online_shop.EntityModels;
using FIT_Online_shop.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers.v1
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class OpstinaController : ControllerBase
    {
        private MojDbContext _dbContext = new MojDbContext();
        // GET api/values

  
        public class ProizvodGetAllVM
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
        }
        private ActionResult GetAllAkcija()
        {
            return Ok(_dbContext.Opstina.Select(s => new ProizvodGetAllVM
            {
                Id = s.Id,
                Naziv = s.Naziv ,
            }).ToList());
        }

        [HttpGet]
        public ActionResult GetAllProba()
        {
            return GetAllAkcija();
        }
    }
}
