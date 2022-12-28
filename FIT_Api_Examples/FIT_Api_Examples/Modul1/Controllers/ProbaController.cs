using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Modul1.Models;
using FIT_Api_Examples.Modul1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProbaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProbaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet()]
        public ActionResult Get()
        {
            return Ok("ok");
        }

        
    }
}
