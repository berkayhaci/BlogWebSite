using Microsoft.AspNetCore.Mvc;

namespace Katmanlı_Mimari.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {

            return View();
        }
    }
}
