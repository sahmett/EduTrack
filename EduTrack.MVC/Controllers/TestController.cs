using Microsoft.AspNetCore.Mvc;
using EduTrack.Application.Models.Auth;
using Microsoft.AspNetCore.Identity;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly AccountController _authController;

    public TestController(AccountController authController)
    {
        _authController = authController;
    }

}
