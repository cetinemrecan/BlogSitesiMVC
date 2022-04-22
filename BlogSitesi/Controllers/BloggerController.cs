using BlogSitesi.Models;
using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace BlogSitesi.Controllers
{
   

    public class BloggerController : Controller
    {

        BloggerManager bm = new BloggerManager(new EfBloggerRepository());
        [Authorize]

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v=usermail;
            Context c=new Context();
            var bloggerName = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerName).FirstOrDefault();
            ViewBag.v2=bloggerName;
            return View();
        }
        public IActionResult BloggerProfile()
        {
            return View();
        }
        
        public IActionResult BloggerMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]

        public PartialViewResult BloggerNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]

        public PartialViewResult BloggerFooterPartial()
        {
            return PartialView();
        }
      
        [HttpGet]
        public IActionResult BloggerEditProfile()
        {
            Context c = new Context();

            var usermail = User.Identity.Name;
         
            var bloggerID = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerID).FirstOrDefault();
            
            var bloggervalues = bm.TGetById(bloggerID);
            return View(bloggervalues);
        }
       
        [HttpPost]
        public IActionResult BloggerEditProfile(Blogger c)
        {
            BloggerValidator bvl = new BloggerValidator();
            ValidationResult results =bvl.Validate(c);
            if (results.IsValid)
            {
               bm.TUpdate(c);
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
          return View();
        }
       
        [HttpGet]
        public IActionResult BloggerAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult BloggerAdd(AddProfileImage p)
        {
            Blogger w=new Blogger();
            if (p.BloggerImage != null)
            {
                var extension=Path.GetExtension(p.BloggerImage.FileName);
                var newimagename=Guid.NewGuid()+ extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BloggerImageFiles/", newimagename);
                var stream=new FileStream(location, FileMode.Create);
                p.BloggerImage.CopyTo(stream);
                w.BloggerImage = newimagename;
            }
            w.BloggerMail = p.BloggerMail;
            w.BloggerName= p.BloggerName;
            w.BloggerPassword= p.BloggerPassword;
            w.BloggerStatus = true;
            w.BloggerAbout = p.BloggerAbout;
            bm.TUpdate(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
