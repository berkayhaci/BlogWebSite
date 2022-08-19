using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Katmanlı_Mimari.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager( new EfAboutRepository());
        public IActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }
       
    }
}
