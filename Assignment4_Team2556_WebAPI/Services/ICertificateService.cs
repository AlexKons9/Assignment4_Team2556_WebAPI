using Assignment4_Team2556_WebAPI.Models;
using NuGet.Protocol.Core.Types;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ICertificateService
    {
        Task<Certificate> AddOrUpdateAsync(Certificate entity);
        Task<IList<Certificate>> GetAllAsync();
        Task<Certificate?> GetAsync(int? id);
        Task<bool> RemoveAsync(Certificate? entity);
        
    }
}
