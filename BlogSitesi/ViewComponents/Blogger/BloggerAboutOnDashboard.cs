using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blogger
{
    public class BloggerAboutOnDashboard:ViewComponent
    {
        BloggerManager bloggerManager = new BloggerManager(new EfBloggerRepository());

        public IViewComponentResult Invoke()
        {
          var values = bloggerManager.GetBloggerById(1);
            return View(values);
        }
    }
}
