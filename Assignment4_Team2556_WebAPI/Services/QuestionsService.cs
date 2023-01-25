using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Data.Repositories;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class QuestionsService : IQuestionsService
    {
        public IGenericRepository<Question> _repository { get; set; }

        public QuestionsService(IGenericRepository<Question> repository)
        {
            _repository = repository;
        }


        public async Task<Question> AddOrUpdateAsync(Question question)
        {
            return await _repository.AddOrUpdateAsync(question);
        }

        public async Task<Question?> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IList<Question>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> RemoveAsync(Question question)
        {
            return await _repository.RemoveAsync(question);
        }
    }
}
