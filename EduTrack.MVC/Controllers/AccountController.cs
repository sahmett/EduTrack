using System.Net.Http;
using System.Threading.Tasks;
using EduTrack.MVC.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


public class AccountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiBaseUrl;

    public AccountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _apiBaseUrl = "https://localhost:7254/api"; 
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.PostAsJsonAsync($"{_apiBaseUrl}/auth/login", model);

        if (response.IsSuccessStatusCode)
        {
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseViewModel>();
            HttpContext.Session.SetString("Token", loginResponse.Token); 
            
            HttpContext.Session.SetString("Email", loginResponse.Email);

            return RedirectToAction("Index", "Home"); 
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt");
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.PostAsJsonAsync($"{_apiBaseUrl}/auth/register", model);

        if (response.IsSuccessStatusCode)
        {
            var registerResponse = await response.Content.ReadFromJsonAsync<LoginResponseViewModel>();
            HttpContext.Session.SetString("Token", registerResponse.Token); 
            HttpContext.Session.SetString("Email", registerResponse.Email);

            return RedirectToAction("Index", "Home"); 
        }

        
        ModelState.AddModelError(string.Empty, "Registration failed");
        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Token"); 
        return RedirectToAction("Login");
    }

}
