using Microsoft.AspNetCore.Http;

namespace BlogSitesi.Models
{
    public class AddProfileImage
    {
        public int BloggerID { get; set; }
        public string BloggerName { get; set; }
        public string BloggerAbout { get; set; }
        public IFormFile BloggerImage { get; set; }
        public string BloggerMail { get; set; }
        public string BloggerPassword { get; set; }
        public bool BloggerStatus { get; set; }
    }
}
