using System;
<<<<<<< HEAD

namespace Entities.Abstract
{
    public interface ICreatedEntity
    {
        int CreatedUserId { get; set; }
        DateTime CreatedDte { get; set; }
=======
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
   public interface ICreatedEntity
    {
        int CreatedUserId { get; set; }
        DateTime CreatedDate { get; set; }
>>>>>>> 07c7e0a1e22a921d75ac56d3d845e956b326b7d1
    }
}
