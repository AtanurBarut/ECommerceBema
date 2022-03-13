using Core.DataAccess.Concrete;
using DataAcccess.Abstract;
using DataAcccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAcccess.Concrete.EntityFremawork
{
    public class EfUserDal:EfBaseRepository<User,ECommerceBemaContext>,IuserDal
    {
    }
}
