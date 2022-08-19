using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Katmanlı_Mimari.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            Context c = new Context();

            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();

            var writerId = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerId).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
