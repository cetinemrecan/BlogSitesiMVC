using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blogger
{
    public class BloggerNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();

        }
    }
}
