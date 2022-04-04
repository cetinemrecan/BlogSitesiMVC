using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values=bm.GetList();

            return View(values);
        }
    }
}
