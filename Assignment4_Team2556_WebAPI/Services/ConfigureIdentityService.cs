using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Services
{
    public static class ConfigureIdentityService
    {
        public static void ConfigureIdentity(this IServiceCollection services) 
        { 
            var builder = services.AddIdentity<User, IdentityRole>(o => 
            { 
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 3;
                o.User.RequireUniqueEmail = false; 
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); }
    }
}
