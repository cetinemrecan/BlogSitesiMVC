using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class RegisterController : Controller
    {
        BloggerManager bm = new BloggerManager(new EfBloggerRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Blogger b)
        {
            BloggerValidator bv = new BloggerValidator();
            ValidationResult result = bv.Validate(b);
            if (result.IsValid)
            {
                b.BloggerStatus = true;
                b.BloggerAbout = "Deneme Test";
                bm.TAdd(b);
                return RedirectToAction("Index", "Blog");

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
