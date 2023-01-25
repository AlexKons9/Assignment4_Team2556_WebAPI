using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Data.Repositories;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class TopicsService : ITopicsService
    {

        private readonly IGenericRepository<Topic> _repository;

        public TopicsService(IGenericRepository<Topic> repository)
        {
            _repository = repository;
        }

        public async Task<Topic> AddOrUpdateAsync(Topic topic)
        {
            return await _repository.AddOrUpdateAsync(topic);
        }

        public async Task<Topic> GetAsync(int? id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IList<Topic>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> RemoveAsync(Topic topic)
        {
            return await _repository.RemoveAsync(topic);
        }
    }
}
