using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
