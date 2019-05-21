using Microsoft.AspNetCore.Mvc;

namespace WrdFormInfo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
