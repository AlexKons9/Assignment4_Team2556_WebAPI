using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class CandidateCertificateRepository : IGenericRepository<CandidateCertificate>
    {
        private readonly ApplicationDbContext _context;
        public CandidateCertificateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CandidateCertificate> AddOrUpdateAsync(CandidateCertificate entity)
        {
            _context.CandidateCertificates.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<CandidateCertificate>> GetAllAsync()
        {
            return await _context.CandidateCertificates.ToListAsync();
        }

        public async Task<CandidateCertificate?> GetAsync(int? id)
        {
            return await _context.CandidateCertificates.FirstAsync(c => c.CandidateCertificateId == id);
        }

        public async Task<bool> RemoveAsync(CandidateCertificate entity)
        {
            _context.CandidateCertificates.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<CandidateCertificate>> GetAllCandidateCertificatesByUserNameAsync(string id)
        {
            return await _context.CandidateCertificates
                .Include(cc => cc.CandidateExam)
                .ThenInclude(ce => ce.Candidate)
                .Include(cc => cc.CandidateExam)
                .ThenInclude(ce => ce.Exam)
                .ThenInclude(e => e.Certificate)
                .Where(cc => cc.CandidateExam.CandidateId == id)
                .ToListAsync();
        }
    }
}
