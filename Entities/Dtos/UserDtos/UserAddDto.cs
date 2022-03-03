using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserDtos
{
    public class UserAddDto:IDto
    {
        public string UserName { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public string FirstName { get; set; }
        public string Lastname { get; set; }
=======
        public string FirsName { get; set; }
=======
        public string FirstName { get; set; }
>>>>>>> ebccce6d942a2ad4b8e0fbb9104a1d7c4fe0d15a
        public string LastName { get; set; }
>>>>>>> 07c7e0a1e22a921d75ac56d3d845e956b326b7d1
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
