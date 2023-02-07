using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ICandidateCertificateService
    {
        Task<CandidateCertificate> AddOrUpdateAsync(CandidateCertificate candidateCertificate);
        Task<CandidateCertificate?> GetAsync(int id);
        Task<IList<CandidateCertificate>> GetAllAsync();
        Task<bool> RemoveAsync(CandidateCertificate candidateCertificate);

    }
}
