using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blogger
{
    public class BloggerMessageNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();

        }

    }
}
