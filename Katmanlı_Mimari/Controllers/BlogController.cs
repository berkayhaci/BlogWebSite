using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using DataAccessLayer.Concrete;

namespace Katmanlı_Mimari.Controllers
{
    
    public class BlogController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.GetBlogWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id; //buradaki id değeri viewcomponent ile taşınan değerdir. taşınırken bloga ait yorumları listeler
            var values=bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            Context c = new Context();  
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values=bm.GetListWithCategoryByWriterBm(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd() //sayfa yüklenirken geleceği için dropdown kısmına atadık kategorileri
        {
            
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p )
        {
            
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerId;
                bm.TAdd(p);

                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var _blogValue = bm.TGetById(id); 
            bm.TDelete(_blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id) //güncelleme işlemi öncesinde o değerin buraya çağırılması gerek
        {
            var _blogValue = bm.TGetById(id); // view sayfasına taşır blog değerlerini
            List<SelectListItem> _categoryValue = (from a in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = a.CategoryName,
                                                       Value = a.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.catValue= _categoryValue;
            return View(_blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerId;

            var blogValue = bm.TGetById(p.BlogID); //burası güncelleme tarihini blog oluşum tarihi olarak kalmasını sağlar
            
            p.BlogCreateDate=DateTime.Parse(blogValue.BlogCreateDate.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }



    }
}
