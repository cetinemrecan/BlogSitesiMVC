using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSitesi.Controllers
{
 
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

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
            
            var usermail = User.Identity.Name;
            var bloggerID=c.Bloggers.Where(x=>x.BloggerMail==usermail).Select(y=>y.BloggerID).FirstOrDefault();
            var values=bm.GetListWithCategoryByBloggerBm(bloggerID);
          
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   { Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

           
            var usermail = User.Identity.Name;
            var bloggerID = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerID).FirstOrDefault();


            BlogValidator blv = new BlogValidator();
            ValidationResult result = blv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.BloggerID = bloggerID;
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
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByBlogger");

        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var bloggerID = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerID).FirstOrDefault();

            p.BloggerID=bloggerID;
            p.BlogCreateDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByBlogger");
        }
    }
}
