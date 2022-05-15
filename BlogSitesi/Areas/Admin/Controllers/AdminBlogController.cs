using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager blogManager1 = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = blogManager1.GetBlogListWithCategory();

            return View(values);
        }
    }
}
