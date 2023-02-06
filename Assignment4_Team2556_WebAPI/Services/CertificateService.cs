using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly IGenericRepository<Certificate> _repository;

        public CertificateService(IGenericRepository<Certificate> repository)
        {
            _repository = repository;
        }

        public async Task<Certificate> AddOrUpdateAsync(Certificate entity)
        {
            return await _repository.AddOrUpdateAsync(entity);
        }

        public async Task<IList<Certificate>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Certificate?> GetAsync(int? id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<bool> RemoveAsync(Certificate? entity)
        {
            return !await _repository.RemoveAsync(entity);
        }
    }
}
