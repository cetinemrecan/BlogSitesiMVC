using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blogger
{
    public class BloggerMessageNotification:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var values = mm.GetInboxListByBlogger(id);
            return View(values);

        }

    }
}
