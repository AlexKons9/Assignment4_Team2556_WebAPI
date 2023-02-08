using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class QuestionsRepository : IGenericRepository<Question>
    {

        private readonly ApplicationDbContext _context;


        public QuestionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Question> AddOrUpdateAsync(Question entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Question> GetAsync(int? id)
        {
            var question = await _context.Questions.FindAsync(id);
            await _context.Entry(question).Reference(x => x.Topic).LoadAsync();
            await _context.Entry(question).Collection(x => x.Options).LoadAsync();
            return question;
        }

        public async Task<IList<Question>> GetAllAsync()
        {
            return await _context.Questions
                .Include(t=>t.Topic)
                .ThenInclude(c=>c.Certificate)
                .ToListAsync();
        }

        public async Task<bool> RemoveAsync(Question question)
        {
            
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
