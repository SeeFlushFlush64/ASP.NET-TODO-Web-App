using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TODOWebApp.DTO.TodoTaskFolderDTO;
using TODOWebApp.Models;

namespace TODOWebApp.Controllers
{
    public class TodoTaskController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7040/api");
        private readonly HttpClient _httpClient;
        public TodoTaskController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Create(Guid userId)
        {
            var model = new CreateTodoTaskViewModel { UserId = userId }; // Initialize with UserId
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoTaskViewModel model)
        {
      
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await _httpClient.PostAsync($"{_httpClient.BaseAddress}/todotask/Create/{model.UserId}", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Task added";
                    return RedirectToAction("ViewTasks", "User", new { userId = model.UserId });
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(model);
            }
            return View(model);
        }
    }
}
