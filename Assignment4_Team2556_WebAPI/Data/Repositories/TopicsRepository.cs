using Assignment4_Team2556_WebAPI.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class TopicsRepository : IGenericRepository<Topic>
    {

        private readonly ApplicationDbContext _context;

        public TopicsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Topic> AddOrUpdateAsync(Topic entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Topic> AddTopicAsync(Topic topic)
        {
           
            await _context.AddAsync(topic);
            await _context.SaveChangesAsync();
            return topic;
        }



        public async Task<Topic?> GetAsync(int? id)
        {
            var topic = await _context.Topics.FirstAsync(c => c.TopicId == id);
            await _context.Entry(topic).Reference(x => x.Certificate).LoadAsync();
            return topic;
        }

        public async Task<IList<Topic>> GetAllAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<IList<Topic>> GetAllTopicsOfCertificate(int certificateId)
        {
            var listOfTopics = await _context.Topics.Where(x => x.CertificateId == certificateId ).ToListAsync();
            return listOfTopics;
        }

        public async Task<bool> RemoveAsync(Topic entity)
        {
            _context.Topics.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
