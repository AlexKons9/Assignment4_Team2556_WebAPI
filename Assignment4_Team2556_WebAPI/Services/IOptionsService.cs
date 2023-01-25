using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface IOptionsService
    {
        Task<Option> AddOrUpdateAsync(Option option);
        Task<Option?> GetAsync(int id);
        Task<IList<Option>> GetAllQuestionOptionsAsync(int questionId);
        Task<IList<Option>> GetAllAsync();
        Task<bool> RemoveAsync(Option option);
    }
}
