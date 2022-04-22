using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class EfMessage2Repository: GenericRepository<Message2>, IMessage2Dal
    {
    }
}
