using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TODOWebApp.Models;

namespace TODOWebApp.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7040/api");
        private readonly HttpClient _httpClient;
        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/user/GetAll").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            return View(userList);
        }

        [HttpGet]
        public async Task<IActionResult> ViewTasks(Guid userId)
        {
            ViewData["UserId"] = userId;
            List<TodoTaskViewModel> tasksList = new List<TodoTaskViewModel>();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/todotask/GetById/{userId}"); // Ensure you have this API endpoint
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                tasksList = JsonConvert.DeserializeObject<List<TodoTaskViewModel>>(data);
            }

            return View(tasksList); // Return a view displaying the tasks
        }

    }
}

