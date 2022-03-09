using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPICoreMvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "http://localhost:11554/api/";

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users/GetList");
            return View(users);
        }
    }
}
