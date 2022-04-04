using BlogSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogSitesi.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>()
            {
                new UserComment
                {
                    ID=1,
                    UserName="Emrecan"
                },
                new UserComment()
                {
                    ID=2,
                    UserName="Pınar"
                },
                  new UserComment()
                {
                    ID=3,
                    UserName="Aslan"
                }
            };
            return View(commentvalues);
        }
    }
}
