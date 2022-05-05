using BlogSitesi.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
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
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }





        //[HttpPost]
        //public async Task< IActionResult> Index(Blogger p)
        //{
        //  Context c=new Context();
        //    var datavalue = c.Bloggers.FirstOrDefault(x => x.BloggerMail == p.BloggerMail && x.BloggerPassword == p.BloggerPassword);
        //    if (datavalue != null)
        //    {
        //        var claims = new List<Claim>() //claim=> talep
        //        {
        //            new Claim(ClaimTypes.Name, p.BloggerMail)
        //        };
        //        var useridentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
            
        //}
    }
}

//Context c = new Context();
//var datavalue = c.Bloggers.FirstOrDefault(x => x.BloggerMail == p.BloggerMail && x.BloggerPassword == p.BloggerPassword);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", p.BloggerMail);
//    return RedirectToAction("Index", "Blogger");
//}
//else
//{
//    return View();
//}