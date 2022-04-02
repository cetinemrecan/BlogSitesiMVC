using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
