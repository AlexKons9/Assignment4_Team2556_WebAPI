using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Services;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenericService<Voucher> _service;

        public VouchersController(ApplicationDbContext context, IGenericService<Voucher> service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Vouchers
        [HttpGet]
        public async Task<IEnumerable<Voucher>> GetVouchers()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Vouchers/Candidate
        [HttpGet("Candidate")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetCandidateVouchers(string candidateUserName)
        {
            var serv = _service as VouchersService;
            var vouchers = await serv.GetAllCandidateVouchersAsync(candidateUserName);

            if (candidateUserName == null)
            {
                return NotFound();
            }
            return Ok(vouchers);
        }

        // GET: api/Vouchers/GetVoucher
        [HttpGet("GetVoucher")]
        public async Task<ActionResult<Voucher>> GetVoucher(string? voucherDescription)
        {
            var serv = _service as IVoucherService;
            var voucher = await serv.GetAsyncByDescription(voucherDescription);

            if (voucher == null)
            {
                return NotFound();
            }

            return voucher;
        }

        // POST: api/Vouchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(int certificateId, string userName)
        {
            var serv = _service as VouchersService;
            var voucher = await serv.AddVoucherAsync(certificateId, userName);

            return CreatedAtAction("GetVoucher", new { id = voucher.VoucherId }, voucher);
        }

        // DELETE: api/Vouchers/Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteVoucher(string voucherDescription)
        {
            var serv = _service as IVoucherService;
            var voucher = await serv.GetAsyncByDescription(voucherDescription);
            if (voucher == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(voucher);

            return NoContent();
        }

        //private bool VoucherExists(int id)
        //{
        //    return _context.Vouchers.Any(e => e.VoucherId == id);
        //}


        //// PUT: api/Vouchers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutVoucher(int id, Voucher voucher)
        //{
        //    if (id != voucher.VoucherId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(voucher).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VoucherExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
    }
}
