using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Katmanlı_Mimari.Controllers
{
    public class NewsController : Controller
    {
        NewsletterManager nm = new NewsletterManager(new EfNewsletterRepository());
        public PartialViewResult AddMailSubs()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMailSubs(NewsLetter p)
        {
            p.MailStatus = true;
            nm.TAdd(p);
            return PartialView();
        }
    }
}
