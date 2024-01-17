using EduTrack.MVC.Models.Auth;
using EduTrack.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EduTrack.MVC.Controllers
{
    public class AuthController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7254/api"); //SSL 44396
        private readonly HttpClient _client;
        private readonly IToastService _toastService;

        public AuthController(IToastService toastService)
        {
            _toastService = toastService;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var loginViewModel = new AuthLoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);


            var json = JsonConvert.SerializeObject(loginViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            HttpResponseMessage result = await _client.PostAsync(_client.BaseAddress + "/auth/login", data);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                var authResponseModel = JsonConvert.DeserializeObject<AuthResponseModel>(response);

                //if (authResponseModel.Succeeded)
                //{
                //    _toastService.SuccessMessage("You've successfully logged in to the application.");
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{

                //    foreach (var error in authResponseModel.Errors)
                //    {
                //        ModelState.AddModelError(error.Code, error.Message);
                //    }
                //    return View(loginViewModel);
                //}
                return View(loginViewModel);
            }
            else
            {
                _toastService.FailureMessage("Login request failed. Please try again.");
                return View(loginViewModel);
            }
        }
    }
}
