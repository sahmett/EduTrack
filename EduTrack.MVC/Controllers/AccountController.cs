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
        _apiBaseUrl = "https://localhost:7254/api"; // Replace with your API URL
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(); // Return your login view
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
            HttpContext.Session.SetString("Token", loginResponse.Token); // Tokenı oturumda sakla
            // İsteğe bağlı olarak, kullanıcının e-postasını da oturumda saklayabilirsiniz
            HttpContext.Session.SetString("Email", loginResponse.Email);

            return RedirectToAction("Index", "Home"); // Güvenli bir sayfaya yönlendir
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt");
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(); // Kayıt görünümünü döndür
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
            HttpContext.Session.SetString("Token", registerResponse.Token); // Tokenı oturumda sakla
            HttpContext.Session.SetString("Email", registerResponse.Email);

            return RedirectToAction("Index", "Home"); // Kayıttan sonra güvenli bir sayfaya yönlendir
        }

        // API'dan başarısız bir yanıt geldiğinde hata mesajını ekle
        ModelState.AddModelError(string.Empty, "Registration failed");
        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Token"); // Remove the token from the session
        return RedirectToAction("Login");
    }

    // Other actions...
}
