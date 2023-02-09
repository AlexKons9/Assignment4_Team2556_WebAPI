using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class VouchersRepository : IGenericRepository<Voucher>
    {
        private readonly ApplicationDbContext _context;

        public VouchersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // 
        //Summary: Add or Update Voucher
        public async Task<Voucher> AddOrUpdateAsync(Voucher entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // 
        //Summary: Gets all vouchers of the specific Candidate
        public async Task<IList<Voucher>> GetAllCandidateVouchersAsync(string candidateId)
        {
            var vouchers = await _context.Vouchers.Where(x => x.CandidateId == candidateId && x.IsClaimed == false).ToListAsync();

            foreach (var voucher in vouchers)
            {
                await _context.Entry(voucher).Reference(x => x.Candidate).LoadAsync();
                await _context.Entry(voucher).Reference(x => x.Certificate).LoadAsync();
            }
            return vouchers;
        }

        public async Task<IList<Voucher>> GetAllAsync()
        {
            var vouchers = await _context.Vouchers.ToListAsync();
            foreach (var voucher in vouchers)
            {
                await _context.Entry(voucher).Reference(x => x.Candidate).LoadAsync();
                await _context.Entry(voucher).Reference(x => x.Certificate).LoadAsync();
            }
            return vouchers;
        }

        //
        //Summary: Gets A voucher and load its properties
        public async Task<Voucher?> GetAsync(int? id)
        {
            if (id != null)
            {
                var voucher = await _context.Vouchers.Where(x => x.VoucherId == id).FirstAsync();
                await _context.Entry(voucher).Reference(x => x.Candidate).LoadAsync();
                await _context.Entry(voucher).Reference(x => x.Certificate).LoadAsync();
                return voucher;
            }
            return null;
        }

        //
        //Summary: Gets A voucher and load its properties by descripton
        public async Task<Voucher?> GetAsyncByDescription(string? voucherDescription)
        {
            if (voucherDescription != null)
            {
                var voucher = await _context.Vouchers.Where(x => x.Description == voucherDescription && x.IsClaimed == false).FirstAsync();
                await _context.Entry(voucher).Reference(x => x.Candidate).LoadAsync();
                await _context.Entry(voucher).Reference(x => x.Certificate).LoadAsync();
                return voucher;
            }
            return null;
        }


        public async Task<bool> RemoveAsync(Voucher entity)
        {
            if (entity != null)
            {
                _context.Vouchers.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
