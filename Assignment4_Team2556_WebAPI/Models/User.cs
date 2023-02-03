using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class User : IdentityUser
    {
        //[Required]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        //[Required]
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? NativeLanguage { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoIdType { get; set; }
        public string? PhotoIdNumber { get; set; }
        public DateTime? PhotoIssueDate { get; set; }
        //[Required]
        //public string? Email { get; set; }
        public string? AddressLine { get; set; }
        public string? AddressLine2 { get; set; }
        public string? CountryOfResidence { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? LandlineNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
