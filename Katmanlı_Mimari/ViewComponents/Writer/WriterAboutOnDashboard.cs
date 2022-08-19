using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Katmanlı_Mimari.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();

     

        public IViewComponentResult Invoke() //sisteme otantike olan yazar bilgilerinin gelmesi
        {
            
            var userName = User.Identity.Name;
            ViewBag.v = userName;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();  
            var writerId = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerId);
            return View(values);
        }



    }

}
