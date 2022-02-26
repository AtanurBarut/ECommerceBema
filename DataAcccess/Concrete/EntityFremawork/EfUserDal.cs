using DataAcccess.Abstract;
using DataAcccess.Concrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Concrete.EntityFremawork
{
    public class EfUserDal:EfBaseRepository<User,ECommerceBemaContext>,IuserDal
    {
    }
}
