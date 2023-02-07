using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Models.DTOModels;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class CandidateService : ICandidateService
    {
        public ICandidateRepository _repository { get; set; }

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }


        public async Task<User> AddOrUpdateAsync(User candidate)
        {
            return await _repository.AddOrUpdateAsync(candidate);
        }

        public async Task<User?> GetAsync(string? username)
        {
            return await _repository.GetAsync(username);
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> RemoveAsync(User candidate)
        {
            return await _repository.RemoveAsync(candidate);
        }
    }
}
