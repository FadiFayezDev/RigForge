using Microsoft.AspNetCore.Mvc;

namespace RigForge.MVC.Areas.CPUs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
