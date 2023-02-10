using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ITopicsService
    {
        Task<Topic> AddOrUpdateAsync(Topic topic);
        Task<List<Topic>> AddOrUpdateListOfTopicsAsync(List<Topic> topics, int candidateExam);
        Task<Topic?> GetAsync(int? id);
        Task<IList<Topic>> GetAllAsync();
        Task<bool> RemoveAsync(Topic topic);
    }
}
