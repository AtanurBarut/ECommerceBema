using Core.Utilities.Responses;
using Entities.Dtos.Auth;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}
