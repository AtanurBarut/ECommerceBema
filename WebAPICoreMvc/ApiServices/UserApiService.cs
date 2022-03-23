using Core.Utilities.Responses;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPICoreMvc.ApiServices.Interfaces;

namespace WebAPICoreMvc.ApiServices
{
    public class UserApiService : IUserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDetailDto>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Users/GetList");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responsesuccess = await response.Content.ReadFromJsonAsync<ApiDataResponse<IEnumerable<UserDetailDto>>>();
            return responsesuccess.Data.ToList();
        }
    }
}
