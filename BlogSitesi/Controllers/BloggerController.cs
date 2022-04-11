using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
   

    public class BloggerController : Controller
    {
        
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
    }
}
