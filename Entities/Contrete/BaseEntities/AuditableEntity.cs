using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Contrete.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity,UpdatedEntity
    {
        public int CreatedUserId { get ; set; }
        public DateTime CreatedDte { get; set ; }
        public int UpdatedUserId { get ; set ; }
        public DateTime UpdatedDte { get ; set ; }
    }
}
