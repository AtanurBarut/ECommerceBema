using Business.Abstract;
using DataAcccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IuserDal _userDal;
        public UserService(IuserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                LastName = userAddDto.LastName,
                Adress = userAddDto.Adress,
                //Todo:CreatedDate ve CreatedUserId alanları düzenlenecek.
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                DateOfBirth = userAddDto.DateOfBirth,
                Email = userAddDto.Email,
                FirstName = userAddDto.FirstName,
                Gender = userAddDto.Gender,
                Password = userAddDto.Password,
                UserName = userAddDto.UserName

            };

            var userAdd = await _userDal.AddAsync(user);

            UserDto userDto = new UserDto
            {
                LastName = userAdd.LastName,
                Adress = userAdd.Adress,
                DateOfBirth = userAdd.DateOfBirth,
                Email = userAdd.Email,
                FirstName = userAdd.FirstName,
                Gender = userAdd.Gender,
                UserName = userAdd.UserName,
                Id = userAdd.Id,
            };
            return userDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                UserDto userDto = new UserDto()
                {
                    Adress = user.Adress,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Password = user.Password
                };
                return userDto;
            }
            return null;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserDetailDto()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    DateOfBirth = item.DateOfBirth,
                    UserName = item.UserName,
                    Adres = item.Adress,
                    Email = item.Email,
                    Id = item.Id,
                });
            }
            return userDetailDtos;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            User user = new User()
            {
                LastName = userUpdateDto.LastName,
                Adress = userUpdateDto.Adress,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                FirstName = userUpdateDto.FirstName,
                Gender = userUpdateDto.Gender,
                UserName = userUpdateDto.UserName,
                Id = userUpdateDto.Id,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                Password = userUpdateDto.Password,
                UpdateDate = DateTime.Now,
                UpdateUserId = 1,
            };
            var userUpdate = await _userDal.UpdateAsync(user);
            UserUpdateDto newuserUpdateDto = new UserUpdateDto()
            {
                LastName = userUpdate.LastName,
                Adress = userUpdate.Adress,
                DateOfBirth = userUpdate.DateOfBirth,
                Email = userUpdate.Email,
                FirstName = userUpdate.FirstName,
                Gender = userUpdate.Gender,
                UserName = userUpdate.UserName,
                Id = userUpdate.Id,
                Password = userUpdate.Password,
            };
            return newuserUpdateDto;
        }
    }
}
