using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class CandidateCertificateService : ICandidateCertificateService
    {
        public IGenericRepository<CandidateCertificate> _repository { get; set; }

        public CandidateCertificateService(IGenericRepository<CandidateCertificate> repository)
        {
            _repository = repository;
        }


        public async Task<CandidateCertificate> AddOrUpdateAsync(CandidateCertificate candidateCertificate)
        {
            return await _repository.AddOrUpdateAsync(candidateCertificate);
        }

        public async Task<CandidateCertificate?> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IList<CandidateCertificate>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> RemoveAsync(CandidateCertificate candidateCertificate)
        {
            return await _repository.RemoveAsync(candidateCertificate);
        }
    }
}
