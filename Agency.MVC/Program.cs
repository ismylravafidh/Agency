using Agency.Business.MapProfiles;
using Agency.Business.ViewModels.PortfolioVms;
using Agency.DAL.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Agency.Business;
using Agency.DAL;
using Agency.Core.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(PortfolioMapProfile).Assembly);

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(PortfolioCreateVm).Assembly);
    opt.RegisterValidatorsFromAssembly(typeof(PortfolioUpdateVm).Assembly);
});

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddService();
builder.Services.AddRepository();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );


app.UseStaticFiles();

app.Run();





#region Identity
//builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
//{
//    opt.Password.RequiredLength = 8;
//    opt.Password.RequireNonAlphanumeric = true;
//    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
//    opt.Lockout.MaxFailedAccessAttempts = 2;
//    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);
//}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
#endregion


