using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class VouchersService : IVoucherService
    {
        private readonly IGenericRepository<Voucher> _repository;
        private readonly ICertificateService _certificateService;
        private readonly UserManager<User> _userManager;


        public VouchersService(IGenericRepository<Voucher> repository, ICertificateService certificateService,UserManager<User> userManager)
        {
            _repository = repository;
            _certificateService = certificateService;
            _userManager = userManager;
        }


        
        public async Task<Voucher> AddOrUpdateAsync(Voucher entity)
        {
            return await _repository.AddOrUpdateAsync(entity);
        }


        public async Task<Voucher> AddVoucherAsync(int CertificateId, string candidateUsername)
        {
            var certificate = await _certificateService.GetAsync(CertificateId);
            var candidate = await _userManager.FindByNameAsync(candidateUsername);

            var voucher = new Voucher()
            {
                Description = "VC" + RandomString(10),
                CertificateId = CertificateId,
                Certificate = certificate,
                CandidateId = candidate.Id,
                Candidate = candidate
            };

            await _repository.AddOrUpdateAsync(voucher);

            return voucher;
        }


        public async Task<IList<Voucher>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IList<Voucher>> GetAllCandidateVouchersAsync(string candidateUsername)
        {
            var user = await _userManager.FindByNameAsync(candidateUsername);
            var repo = _repository as VouchersRepository;
            var vouchers = await repo.GetAllCandidateVouchersAsync(user.Id);
            return vouchers;
            
        }

        public async Task<Voucher?> GetAsync(int? id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Voucher?> GetAsyncByDescription(string? voucherDescription)
        {
            var repo = _repository as VouchersRepository;
            return await repo.GetAsyncByDescription(voucherDescription);
        }


        public async Task<bool> RemoveAsync(Voucher entity)
        {
            return await _repository.RemoveAsync(entity);
        }



        //
        //Summary: Produces Random Alpharithmetic Generated String (lenght depends on the input inserted)
        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
