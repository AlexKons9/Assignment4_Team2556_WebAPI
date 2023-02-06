using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface IVoucherService : IGenericService<Voucher>
    {
        Task<IList<Voucher>> GetAllCandidateVouchersAsync(string candidateId);
    }
}
