using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using Katmanlı_Mimari.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Katmanlı_Mimari.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager; //sisteme otantike olmak için

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInVM p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index","Login");
                }

            }
            return View();
        }



    }
}
//Context c = new Context();
//var value = c.Writers.FirstOrDefault(x => x.WriterEmail == p.WriterEmail && x.WriterPassword == p.WriterPassword);

//if (value != null)
//{
//    HttpContext.Session.SetString("username", p.WriterEmail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}
//[HttpPost]
//public async Task<IActionResult> Index(Writer p)
//{
//    Context c =new Context();
//    var dataValue = c.Writers.FirstOrDefault(x => x.WriterEmail == p.WriterEmail && x.WriterPassword == p.WriterPassword);
//    if (dataValue !=null)
//    {
//        var claims = new List<Claim> //claim adında talep oluştur.Kullanıcı bilgilerini tutar liste şeklinde kullanıcaz
//        {
//            new Claim(ClaimTypes.Name,p.WriterEmail)
//        };
//        var useridentity = new ClaimsIdentity(claims, "a"); 
//        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);

//        await HttpContext.SignInAsync(claimsPrincipal);
//        return RedirectToAction("Index","Dashboard");

//    }
//    else
//    {
//        return View();
//    }
//}