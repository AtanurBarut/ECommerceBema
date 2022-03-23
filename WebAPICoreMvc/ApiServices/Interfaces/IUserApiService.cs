using Entities.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPICoreMvc.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<List<UserDetailDto>> GetListAsync();
    }
}
