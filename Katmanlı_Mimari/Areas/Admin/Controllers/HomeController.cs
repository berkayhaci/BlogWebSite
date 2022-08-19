using Microsoft.AspNetCore.Mvc;

namespace Katmanlı_Mimari.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
