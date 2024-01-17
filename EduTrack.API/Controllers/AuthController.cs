using EduTrack.Application.Models.Auth;
using EduTrack.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly TokenService _tokenService;

    public AuthController(UserManager<User> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequest registrationRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User
        {
            UserName = registrationRequest.UserName, // Kullanıcı adı olarak e-posta kullanılıyor
            Email = registrationRequest.Email,
            FirstName = registrationRequest.FirstName,
            LastName = registrationRequest.LastName,
            CreatedByUserId ="codemaster" // Set this field appropriately
            // Diğer gerekli alanlar
        };

        var result = await _userManager.CreateAsync(user, registrationRequest.Password);

        if (result.Succeeded)
        {
            var token = _tokenService.CreateToken(user);
            return Ok(new { Email = user.Email, Token = token }); // Token ile birlikte yanıt döndürülüyor
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return BadRequest("Kullanıcı adı veya şifre hatalı.");
        }

        var token = _tokenService.CreateToken(user);
        return Ok(new { Email = user.Email, Token = token }); // Token ile birlikte yanıt döndürülüyor
    }

}
