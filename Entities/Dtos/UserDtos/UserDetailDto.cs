using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserDtos
{
    public class UserDetailDto:IDto
    {
<<<<<<< HEAD
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
=======
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
<<<<<<< HEAD
>>>>>>> 07c7e0a1e22a921d75ac56d3d845e956b326b7d1
        public string Password { get; set; }
=======
        //public string Password { get; set; }
>>>>>>> ebccce6d942a2ad4b8e0fbb9104a1d7c4fe0d15a
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
<<<<<<< HEAD
        public string Adress { get; set; }
=======
        public string Adres { get; set; }
>>>>>>> 07c7e0a1e22a921d75ac56d3d845e956b326b7d1
    }
}
