using BlogSitesi.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult GetBloggerByID(int bloggerid)
        {
            var findBlogger=bloggers.FirstOrDefault(x=>x.ID==bloggerid);
            var jsonBloggers=JsonConvert.SerializeObject(findBlogger);
            return Json(jsonBloggers);
        }

        [HttpPost]
        public IActionResult AddBlogger(BloggerClass w)
        {
            bloggers.Add(w);
            var jsonBloggers=JsonConvert.SerializeObject(w);
            return Json(jsonBloggers);

        }

        public IActionResult DeleteBlogger(int id)
        {
            var blogger =bloggers.FirstOrDefault(x=>x.ID==id);
            bloggers.Remove(blogger);
            return Json(blogger);
        }

        public IActionResult UpdateBlogger(BloggerClass w)
        {
            var blogger=bloggers.FirstOrDefault(x=>x.ID==w.ID);
            blogger.Name= w.Name;
            var jsonBlogger=JsonConvert.SerializeObject(blogger);
            return Json(jsonBlogger);
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
