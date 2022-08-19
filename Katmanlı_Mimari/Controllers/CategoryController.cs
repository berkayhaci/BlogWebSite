using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Katmanlı_Mimari.Controllers
{
    
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository()); //burada parantez içerisine DAL bekler.Ef
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
