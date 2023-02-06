using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        public CandidateRepository(ApplicationDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<User> AddOrUpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetAsync(string? username)
        {
            var candidate = await _userManager.FindByNameAsync(username);
            return candidate;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _userManager.GetUsersInRoleAsync("Candidate");
        }

        public async Task<bool> RemoveAsync(User candidate)
        {

            _context.Users.Remove(candidate);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
