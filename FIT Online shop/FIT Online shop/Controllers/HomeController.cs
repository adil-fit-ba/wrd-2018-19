using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Online_shop.EF;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Online_shop.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}