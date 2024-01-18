using EduTrack.Application.Models.Category;
using EduTrack.MVC.Models.Content;
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

        //create course
        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Kurs içeriklerini ve kategorileri API'den al
            var courseContentsResponse = await httpClient.GetAsync($"{_apiBaseUrl}/CourseContent/GetAllCourseContents");
            var categoriesResponse = await httpClient.GetAsync($"{_apiBaseUrl}/Category/GetAllCategories");

            var courseContents = new List<CourseContentViewModel>();
            var categories = new List<CategoryViewModel>();

            if (courseContentsResponse.IsSuccessStatusCode)
            {
                var contentsString = await courseContentsResponse.Content.ReadAsStringAsync();
                courseContents = JsonConvert.DeserializeObject<List<CourseContentViewModel>>(contentsString);
            }

            if (categoriesResponse.IsSuccessStatusCode)
            {
                var categoriesString = await categoriesResponse.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(categoriesString);
            }

            // ViewModel'i oluştur ve verileri formda kullan
            var viewModel = new CourseViewModel
            {
                CourseContents = courseContents,
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseViewModel model)
        {
            if (!ModelState.IsValid)
                //return get create course
                return View();

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync($"{_apiBaseUrl}/Course/Create", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CourseList"); // Başarılı oluşturma sonrası yönlendirme
            }

            ModelState.AddModelError(string.Empty, "Course creation failed");
            return View(model);
        }
    }


}


