using EduTrack.Domain.Identity;
using EduTrack.MVC;
using EduTrack.MVC.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllersWithViews()
    .AddNToastNotifyToastr();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IToastService, ToastService>();

builder.Services.AddHttpClient();

builder.Services.AddDistributedMemoryCache(); // Bellek içi önbellek
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman aþýmý
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication(); //dikkat

app.UseAuthorization();
 
app.UseSession(); //dikkat

app.UseNToastNotify();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
