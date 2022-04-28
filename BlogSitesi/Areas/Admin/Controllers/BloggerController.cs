using BlogSitesi.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlogSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BloggerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BloggerList()
        {
            var jsonBloggers=JsonConvert.SerializeObject(bloggers);
            return Json(jsonBloggers);
        }

        public static List<BloggerClass> bloggers = new List<BloggerClass>
        {
            new BloggerClass
            {
                ID = 1,
                Name ="Ayşe"

            },
             new BloggerClass
            {
                ID = 2,
                Name ="Ahmet"

            },
              new BloggerClass
            {
                ID = 3,
                Name ="Buse"

            }
        };

    }
}
