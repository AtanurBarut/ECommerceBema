using Core.DataAccess;
using Entities.Concrete;

namespace DataAcccess.Abstract
{
    public interface IUserDal:IBaseRepository<User>
    {
    }
}
