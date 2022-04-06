using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
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
            b.BloggerStatus = true;
            b.BloggerAbout = "Deneme Test";
            bm.BloggerAdd(b);
            return RedirectToAction("Index", "Blog");
        }
    }
}
