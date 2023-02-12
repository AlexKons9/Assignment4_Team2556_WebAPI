using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class ExamRepository : IGenericRepository<Exam>
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Exam> AddOrUpdateAsync(Exam exam)
        {
            _context.Update(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task<IList<Exam>> GetAllAsync()
        {
            var exams = await _context.Exams.ToListAsync();
            foreach (var exam in exams)
            {
                await _context.Entry(exam).Reference(x => x.Certificate).LoadAsync();
            }
            return exams;
        }

        public async Task<Exam?> GetAsync(int? id)
        {
            var exam = await _context.Exams.Where(x => x.ExamId == id)
                                           .Include(v => v.Certificate).FirstAsync();
            return exam;
        }

        public async Task<bool> RemoveAsync(Exam exam)
        {
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
