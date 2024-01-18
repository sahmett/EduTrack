using EduTrack.MVC.Models.Content;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace EduTrack.MVC.Controllers
{
    public class ContentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public ContentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = "https://localhost:7254/api";
        }
        [HttpGet]
        public IActionResult CreateCourseContent()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseContent(CreateCourseContentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync($"{_apiBaseUrl}/CourseContent/CreateCourseContent", model);

            if (response.IsSuccessStatusCode)
            {
                //redirect to Education/Index
                return RedirectToAction("Index", "Education");     
            }

            ModelState.AddModelError(string.Empty, "Course content creation failed");
            return View(model);
        }
    }
}
