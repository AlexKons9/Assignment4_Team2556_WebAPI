using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
