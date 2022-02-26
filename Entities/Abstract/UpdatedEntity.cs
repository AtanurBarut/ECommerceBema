using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface UpdatedEntity
    {
        int UpdatedUserId { get; set; }
        DateTime UpdatedDte { get; set; }
    }
}
