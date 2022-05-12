using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class EfMessage2Repository: GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendBoxWithMessageByBlogger(int id)
        {
            using (var c=new Context())
            {
                return c.Message2s.Include(x=>x.ReceiverUser).Where(y=>y.SenderID == id).ToList();
            }
        }

        public List<Message2> GetInboxWithMessageByBlogger(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }

        }

     
    }
}
