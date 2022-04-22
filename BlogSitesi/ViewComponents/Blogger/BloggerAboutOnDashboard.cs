using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogSitesi.ViewComponents.Blogger
{
    public class BloggerAboutOnDashboard:ViewComponent
    {
        BloggerManager bloggerManager = new BloggerManager(new EfBloggerRepository());

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var bloggerID = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerID).FirstOrDefault();
            var values = bloggerManager.GetBloggerById(bloggerID);
            return View(values);
        }
    }
}
