using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Katmanlı_Mimari.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet] //sayfa yüklenince.Filtreleme işlemleri ya da kategori işlemleri varsa sayfa yüklenirken listelenmesini istediklerimiz
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // sayfada buton tetiklenince
        public IActionResult Index(Writer p)
        {
            WriterValidator wv=new WriterValidator();
            ValidationResult results = wv.Validate(p); // p den gelen değerleri validatör ediceksin 

            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.TAdd(p); //parametreden gelen writer manager a ekliyoruz

                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors) //itemları dolaşır hatalı olanda hata mesajı patladır
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
