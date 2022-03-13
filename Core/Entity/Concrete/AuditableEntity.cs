using Core.Enttity.Abstract;
using System;

namespace Entities.Concrete.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity,IUpdateEntity
    {
        public int CreatedUserId { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public int? UpdateUserId { get ; set ; }
        public DateTime? UpdateDate { get ; set ; }
    }
}
