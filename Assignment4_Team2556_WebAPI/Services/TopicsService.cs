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

        public async Task<IList<Topic>> AddOrUpdateListOfTopicsAsync(List<Topic> topics)
        {
            foreach (var topic in topics)
            {
                await _repository.AddOrUpdateAsync(topic);
            }
            return topics;
        }

        public async Task<List<Topic>> AddListOfTopicsAsync (List<string> topics, int certificateId)
        {
            var repo = _repository as TopicsRepository;
            List<Topic> listOfTopics = new();
            foreach (var topic in topics)
            {
                Topic newTopic = new Topic();
                newTopic.CertificateId = certificateId;
                newTopic.TopicDescription = topic;
                await repo.AddTopicAsync(newTopic);
                listOfTopics.Add(newTopic);
            }
            return listOfTopics;
        }

        public async Task<Topic?> GetAsync(int? id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IList<Topic>> GetAllTopicsOfCertificate(int certificateId)
        {
            var repo = _repository as TopicsRepository;
            return await repo.GetAllTopicsOfCertificate(certificateId);
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
