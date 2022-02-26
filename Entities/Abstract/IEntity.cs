using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class IEntity
    {
        /// <summary>
        /// Veritabanın da karşılık gelen tablolarda olacak
        /// </summary>
        int Id { get; set; }
    }
}
