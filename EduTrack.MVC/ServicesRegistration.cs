using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using EduTrack.Domain.Identity;
using System.Text;
using Microsoft.AspNetCore.Identity;
using EduTrack.API.Services;
using Microsoft.EntityFrameworkCore;
using EduTrack.MVC.Services;

namespace EduTrack.MVC
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IToastService, ToastService>();

            return services;
        }
    }
}
