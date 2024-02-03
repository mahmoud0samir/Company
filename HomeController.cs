using Microsoft.AspNetCore.Mvc;

namespace PortalDEmoooo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
