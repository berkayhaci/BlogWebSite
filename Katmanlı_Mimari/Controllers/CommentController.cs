using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Katmanlı_Mimari.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = 4;
            cm.CommentAdd(p);

            return PartialView();
        }
        //public PartialViewResult CommentListByBlog(int id) //blogtaki yorum listesi
        //{
        //    var values = cm.GetList(id); //getlist içerisinde where şartı blog id 
        //    return PartialView(values);
        //}
    }
}
