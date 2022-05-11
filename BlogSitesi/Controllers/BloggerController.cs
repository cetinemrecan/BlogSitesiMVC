using BlogSitesi.Models;
using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSitesi.Controllers
{
   

    public class BloggerController : Controller
    {

        BloggerManager bm = new BloggerManager(new EfBloggerRepository());
        UserManager userManager = new UserManager(new EfUserRepository());


        private readonly UserManager<AppUser> _userManager;

        public BloggerController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v=usermail;
            Context c=new Context();
            var bloggerName = c.Bloggers.Where(x => x.BloggerMail == usermail).Select(y => y.BloggerName).FirstOrDefault();
            ViewBag.v2=bloggerName;
            return View();
        }
        public IActionResult BloggerProfile()
        {
            return View();
        }
        
        public IActionResult BloggerMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]

        public PartialViewResult BloggerNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]

        public PartialViewResult BloggerFooterPartial()
        {
            return PartialView();
        }
      
        [HttpGet]
        public async Task<IActionResult> BloggerEditProfile()
        {
            //    Context c = new Context();
            //    var username = User.Identity.Name;
            //    var usermail=c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();
            //    var id=c.Users.Where(x=>x.Email==usermail).Select(y=>y.Id).FirstOrDefault();
            //    var values=userManager.TGetById(id);
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
        }
       
        [HttpPost]
        public async Task<IActionResult> BloggerEditProfile(UserUpdateViewModel model)
        {
            //BloggerValidator bvl = new BloggerValidator();
            //ValidationResult results =bvl.Validate(c);
            //if (results.IsValid)
            //{
                var values= await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.password);
            var result =await _userManager.UpdateAsync(values);
                return RedirectToAction("Index", "Dashboard");

            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
          //return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult BloggerAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult BloggerAdd(AddProfileImage p)
        {
            Blogger w=new Blogger();
            if (p.BloggerImage != null)
            {
                var extension=Path.GetExtension(p.BloggerImage.FileName);
                var newimagename=Guid.NewGuid()+ extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BloggerImageFiles/", newimagename);
                var stream=new FileStream(location, FileMode.Create);
                p.BloggerImage.CopyTo(stream);
                w.BloggerImage = newimagename;
            }
            w.BloggerMail = p.BloggerMail;
            w.BloggerName= p.BloggerName;
            w.BloggerPassword= p.BloggerPassword;
            w.BloggerStatus = true;
            w.BloggerAbout = p.BloggerAbout;
            bm.TUpdate(w);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
