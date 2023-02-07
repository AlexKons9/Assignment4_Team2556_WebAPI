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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateCertificatesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly ICandidateCertificateService _service;

        public CandidateCertificatesController(ICandidateCertificateService service)
        {
            _service = service;
        }

        // GET: api/CandidateCertificates
        [HttpGet]
        [Authorize(Roles = "Admin,Marker")]
        public async Task<ActionResult<IEnumerable<CandidateCertificate>>> GetCandidateCertificates()
        {
            var candidateCertificates = await _service.GetAllAsync();
            return Ok(candidateCertificates);
        }

        // GET: api/CandidateCertificates/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Marker")]
        public async Task<ActionResult<CandidateCertificate>> GetCandidateCertificate(int id)
        {
            var candidateCertificate = await _service.GetAsync(id);

            if (candidateCertificate == null)
            {
                return NotFound();
            }

            return Ok(candidateCertificate);
        }

        //// PUT: api/CandidateCertificates/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCandidateCertificate(int id, CandidateCertificate candidateCertificate)
        //{
        //    if (id != candidateCertificate.CandidateCertificateId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(candidateCertificate).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CandidateCertificateExists(id))
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

        // POST: api/CandidateCertificates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin,Marker")]
        public async Task<ActionResult<CandidateCertificate>> PostCandidateCertificate(CandidateCertificate candidateCertificate)
        {
            await _service.AddOrUpdateAsync(candidateCertificate);
            return CreatedAtAction("GetCandidateCertificate", new { id = candidateCertificate.CandidateCertificateId }, candidateCertificate);
        }

        // DELETE: api/CandidateCertificates/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCandidateCertificate(int id)
        {
            var candidateCertificate = await _service.GetAsync(id);
            if (candidateCertificate == null)
            {
                return NotFound();
            }

            _service.RemoveAsync(candidateCertificate);
             return Ok();
        }

        private bool CandidateCertificateExists(int id)
        {
            if (_service.GetAsync(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
