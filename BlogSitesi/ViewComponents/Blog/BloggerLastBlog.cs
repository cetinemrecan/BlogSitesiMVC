using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blog
{
    public class BloggerLastBlog:ViewComponent
    {
        BlogManager bm=new BlogManager( new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListByBlogger(1);
            return View(values);
        }
    }
}
