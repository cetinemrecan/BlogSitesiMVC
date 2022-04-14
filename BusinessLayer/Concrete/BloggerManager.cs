using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BloggerManager:IBloggerService
    {
        IBloggerDal _bloggerDal;

        public BloggerManager(IBloggerDal bloggerDal)
        {
            _bloggerDal = bloggerDal;
        }

        public List<Blogger> GetBloggerById(int id)
        {
           return  _bloggerDal.GetListAll(x=>x.BloggerID == id);    
        }

        public List<Blogger> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Blogger t)
        {
            _bloggerDal.Insert(t);
        }

        public void TDelete(Blogger t)
        {
            throw new NotImplementedException();
        }

        public Blogger TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blogger t)
        {
            throw new NotImplementedException();
        }
    }
}
