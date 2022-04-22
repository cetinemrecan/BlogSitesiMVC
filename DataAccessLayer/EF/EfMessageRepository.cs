﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public List<Message2> GetListWithMessageByBlogger(int id)
        {
            throw new NotImplementedException();
        }
    }
}
