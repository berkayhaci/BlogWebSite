using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Katmanlı_Mimari.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Katmanlı_Mimari.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //[Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;

            Context c =new Context();
            var writerName = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;

            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPArtial()
        {
            return PartialView();
        }
        
        [HttpGet]
        public async Task<IActionResult> WriterEditProfil()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            return View();

            //Context c = new Context();
            //var userName = User.Identity.Name;
            //var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();

            //var writerId = c.Writers.Where(x => x.WriterEmail == userMail).Select(y => y.WriterID).FirstOrDefault();
            //var writerValue = wm.TGetById(writerId);
            //return View(writerValue);
        }
        
        [HttpPost]
        public IActionResult WriterEditProfil(Writer p)
        {
            WriterValidator writerValidator= new WriterValidator();
            ValidationResult result = writerValidator.Validate(p);

            if (result.IsValid)
            {
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w =new Writer ();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName=Guid.NewGuid() + extension;
                var location =Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/WriterImageFiles" ,newImageName);
                var stream=new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterEmail = p.WriterEmail;
            w.WriterPassword = p.WriterPassword;
            w.WriterName = p.WriterName;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;

            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }



    }
}
