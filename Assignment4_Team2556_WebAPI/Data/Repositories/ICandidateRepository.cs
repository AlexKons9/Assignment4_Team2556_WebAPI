using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public interface ICandidateRepository
    {
        Task<User> AddOrUpdateAsync(User user);
        Task<User?> GetAsync(string? username);
        Task<IList<User>> GetAllAsync();
        Task<bool> RemoveAsync(User user);
    }
}
