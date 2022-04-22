using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IActionResult Inbox()
        {
            int id = 2;
            var values = mm.GetInboxListByBlogger(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
           var value=mm.TGetById(id);
            return View(value);
        }
    }
}
