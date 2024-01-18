using EduTrack.Application.Models.Category;

using EduTrack.MVC.Models.Education;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace EduTrack.MVC.Controllers
{
    public class EducationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public EducationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = "https://localhost:7254/api";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CourseViewModel> courses = new List<CourseViewModel>();
            var httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage result = await httpClient.GetAsync($"{_apiBaseUrl}/course/GetAllCourses");
            if (result.IsSuccessStatusCode)
            {
                courses = await result.Content.ReadFromJsonAsync<List<CourseViewModel>>();
                return View(courses);
            }
            return View(courses);
        }

        // Create Category
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategory model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync($"{_apiBaseUrl}/category/createcategory", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Category creation failed");
            return View(model);
        }
    }
}

