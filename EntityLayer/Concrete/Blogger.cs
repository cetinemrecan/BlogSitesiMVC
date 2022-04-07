using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blogger
    {
        [Key]
        public int BloggerID { get; set; }
        public string BloggerName { get; set; }
        public string BloggerAbout { get; set; }
        public string BloggerImage { get; set; }
        public string BloggerMail { get; set; }
        public string BloggerPassword { get; set; }
        public bool BloggerStatus { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
