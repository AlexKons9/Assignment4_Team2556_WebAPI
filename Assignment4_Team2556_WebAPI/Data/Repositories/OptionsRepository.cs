using Assignment4_Team2556_WebAPI.Models;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class OptionsRepository : IGenericRepository<Option>
    {

        private readonly ApplicationDbContext _context;


        public OptionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Option> AddOrUpdateAsync(Option entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<Option?> GetAsync(int? id)
        {
            return await _context.Options.FirstAsync(c => c.OptionId == id);
        }


        public async Task<IList<Option>> GetAllAsync() // Get all options that exist in db
        {
            return await _context.Options.ToListAsync();
        }


        public async Task<IList<Option>> GetAllQuestionOptionsAsync(int questionId) // get all options of a certain questionId
        {
            return await _context.Options.Where(x => x.QuestionId == questionId).ToListAsync();
        }

        // we dont need it but it's there
        public async Task<bool> RemoveAsync(Option entity)
        {
            _context.Options.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
