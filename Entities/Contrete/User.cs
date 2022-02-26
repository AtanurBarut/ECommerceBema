using Entities.Contrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Contrete
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
