using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class CertificateRepository : IGenericRepository<Certificate>
    {
        private readonly ApplicationDbContext _context;

        public CertificateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Certificate> AddOrUpdateAsync(Certificate entity)
        {
            _context.Certificates.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<Certificate>> GetAllAsync()
        {
            var listOfCertificates = await _context.Certificates.ToListAsync();
            // Loads all Topics from the certificate list
            foreach (var certificate in listOfCertificates)
            {
                await _context.Entry(certificate).Collection(x => x.Topics).LoadAsync();
            }
            return listOfCertificates;
        }

        public async Task<Certificate?> GetAsync(int? id)
        {
            if (id != null)
            {
                var certificate = await _context.Certificates.Where(x => x.CertificateId == id).FirstAsync();
                await _context.Entry(certificate).Collection(x => x.Topics).LoadAsync();

                return certificate;
            }
            return null;
        }

        public async Task<bool> RemoveAsync(Certificate? entity)
        {
            if (entity != null)
            {
                _context.Certificates.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
