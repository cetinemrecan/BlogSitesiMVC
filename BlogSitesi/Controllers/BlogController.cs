using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();

            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values=bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByBlogger()
        {
          var values= bm.GetBlogListByBlogger(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator blv = new BlogValidator();
            ValidationResult result = blv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.BloggerID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByBlogger", "Blog");

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
    }
}
