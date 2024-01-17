using EduTrack.MVC.Models.Course;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EduTrack.MVC.Controllers
{
    public class CourseController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7254/api"); //SSL 44396

        private readonly HttpClient _client;

        public CourseController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CourseViewModel> courses = new List<CourseViewModel>();
            HttpResponseMessage result = await _client.GetAsync(_client.BaseAddress + "/course/GetAllCourses");
            if (result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync().Result;
                courses = JsonConvert.DeserializeObject<List<CourseViewModel>>(response);
                return View(courses);
            }
            return View(courses);
        }



    }
}
