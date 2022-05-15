using BusinessLayer.Concrete;
using DataAccessLayer.EF;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AdminCommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            var values = _commentManager.GetCommentwithBlog();
            return View();
        }
    }
}
