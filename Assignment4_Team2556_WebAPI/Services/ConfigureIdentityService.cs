using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Services
{
    public static class ConfigureIdentityService
    {
        //
        // Summary: Identity Configuration for User and IdentiyRoles.  Configures the necessary services for the IServiceCollection interface
        public static void ConfigureIdentity(this IServiceCollection services) //the 'this' keyword declares that the ConfigureIdentity is as extension method.  Extension methods allow you to add methods without changing the original code.
        { 
            var builder = services.AddIdentity<User, IdentityRole>(o =>   //Add Identiy is used to configure the password and user requirements for identity
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
