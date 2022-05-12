using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult Inbox()
        {
            
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var bloggerID = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerID).FirstOrDefault();
            var values = mm.GetInboxListByBlogger(bloggerID);
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
