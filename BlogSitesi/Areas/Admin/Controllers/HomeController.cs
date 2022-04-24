using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
