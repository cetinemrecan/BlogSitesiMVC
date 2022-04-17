using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
