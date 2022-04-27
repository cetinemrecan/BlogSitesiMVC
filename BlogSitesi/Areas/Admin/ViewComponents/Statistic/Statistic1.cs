using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace BlogSitesi.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1=bm.GetList().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string api = "0da8c7a0892f9c248cb2a45bc30917e1";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            //XDocument document = XDocument.Load(connection);
            //ViewBag.v4 = document.Descendants("temperature")
            //    .ElementAt(0)
            //    .Attributes("value").Value;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

           return View();
        }

    }
}
