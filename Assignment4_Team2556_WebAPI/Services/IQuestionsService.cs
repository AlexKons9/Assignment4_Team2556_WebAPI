using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface IQuestionsService
    {
        Task<Question> AddOrUpdateAsync(Question question);
        Task<Question?> GetAsync(int id);
        Task<IList<Question>> GetAllAsync();
        Task<bool> RemoveAsync(Question question);
    }
}
