using BlogSitesi.Models;
using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlogSitesi.Controllers
{
   

    public class BloggerController : Controller
    {

        BloggerManager bm = new BloggerManager(new EfBloggerRepository());

        public IActionResult Index()
        {
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult BloggerEditProfile()
        {
            var bloggervalues = bm.TGetById(1);
            return View(bloggervalues);
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
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
