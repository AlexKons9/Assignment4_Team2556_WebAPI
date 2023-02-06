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
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateService _service;

        public CertificatesController(ICertificateService service)
        {
            _service = service;
        }

        //
        // GET: api/Certificates
        [HttpGet]
        public async Task<IList<Certificate>> GetAllCertificates()
        {
            return await _service.GetAllAsync();
        }

        //
        // GET: api/Certificates
        [HttpGet("Active")]
        public async Task<IList<Certificate>> GetActiveCertificates()
        {
            var allCertificates = await _service.GetAllAsync();
            IList<Certificate> activeCertificateList = new List<Certificate>();

            foreach (var certificate in allCertificates)
            {
                if (certificate.IsActive)
                {
                    activeCertificateList.Add(certificate);
                }
            }
            return activeCertificateList;
        }

        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> GetCertificate(int? id)
        {
            var certificate = await _service.GetAsync(id); 

            if (certificate == null)
            {
                return NotFound();
            }

            return certificate;
        }

        // PUT: api/Certificates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCertificate(int id, Certificate certificate)
        {
            if (id != certificate.CertificateId)
            {
                return BadRequest();
            }


            try
            {
                await _service.AddOrUpdateAsync(certificate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CertificateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Certificates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Certificate>> PostCertificate(Certificate certificate)
        {
            await _service.AddOrUpdateAsync(certificate);

            return CreatedAtAction("GetCertificate", new { id = certificate.CertificateId }, certificate);
        }

        // DELETE: api/Certificates/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var certificate = await _service.GetAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(certificate);

            return NoContent();
        }

        private async Task<bool> CertificateExists(int id)
        {
            IList<Certificate> listOfCertificates = await _service.GetAllAsync();
            foreach (var certificate in listOfCertificates)
            {
                if (id == certificate.CertificateId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
