using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSitesi.ViewComponents.Blogger
{
    public class BloggerAboutOnDashboard:ViewComponent
    {
        BloggerManager bloggerManager = new BloggerManager(new EfBloggerRepository());

        Context c = new Context();


        public  IViewComponentResult Invoke()
        {
           // var user=await _userManager.FindByNameAsync(User.Identity.Name);
            var username = User.Identity.Name;
            ViewBag.v=username;
            var usermail=c.Users.Where(x=> x.UserName == username).Select(y=>y.Email).FirstOrDefault();
            var bloggerID = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerID).FirstOrDefault();
            var values = bloggerManager.GetBloggerById(bloggerID);
            return View(values);
        }
    }
}
