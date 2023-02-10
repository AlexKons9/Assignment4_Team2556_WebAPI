using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ITopicsService
    {
        Task<Topic> AddOrUpdateAsync(Topic topic);
        Task<List<Topic>> AddListOfTopicsAsync(List<string> topics, int candidateExam);
        Task<IList<Topic>> AddOrUpdateListOfTopicsAsync(List<Topic> topics);
        Task<IList<Topic>> GetAllTopicsOfCertificate(int certificateId);
        Task<Topic?> GetAsync(int? id);
        Task<IList<Topic>> GetAllAsync();
        Task<bool> RemoveAsync(Topic topic);
    }
}
