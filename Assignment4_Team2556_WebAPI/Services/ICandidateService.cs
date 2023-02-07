using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ICandidateService
    {
        Task<User> AddOrUpdateAsync(User user);
        Task<User?> GetAsync(string? username);
        Task<IList<User>> GetAllAsync();
        Task<bool> RemoveAsync(User user);
    }
}
