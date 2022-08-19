using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Katmanlı_Mimari.ViewComponents.Blog
{
    public class WriterLastBlog :ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetBlogListByWriter(writerId);
            return View(values);
        }
    }
}
