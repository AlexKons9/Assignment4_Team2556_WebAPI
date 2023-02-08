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
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExamsController : ControllerBase
    {
        private readonly ICandidateExamService _candidateExamService;
        private readonly ICandidateExamAnswerService _candidateExamAnswerService;
        private readonly IGenericService<Voucher> _voucherService;
        private readonly UserManager<User> _userManager;

        public CandidateExamsController(ICandidateExamService candidateExamService, ICandidateExamAnswerService candidateExamAnswerService, IGenericService<Voucher> voucherService, UserManager<User> userManager)
        {
            _candidateExamService = candidateExamService;
            _candidateExamAnswerService = candidateExamAnswerService;
            _voucherService = voucherService;
            _userManager = userManager;
        }

        // GET: api/CandidateExams
        [HttpGet]
        public async Task<IList<Certificate>> GetCandidateExams()
        {
            return await _candidateExamService.GetActiveCertificateList();
        }


        // GET: api/CandidateExams/Certificates
        // Gets all the passed exams of a candidate
        [HttpGet("Certificates")]
        public async Task<IList<CandidateExam>> GetCandidatePassedExams(string userName)
        {
            User user = await _userManager.FindByNameAsync(userName);
            return await _candidateExamService.GetAccomplishedExamsByCandidateId(user.Id);
        }


        //// GET: api/CandidateExams/ExamResults/5
        [HttpGet("ExamResults/{id}")]
        [Authorize(Roles = "Candidate,Admin")]
        public async Task<ActionResult<CandidateExamResultsDTO>> GetCandidateExamResults(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CandidateExamResultsDTO candidateExamResults = await _candidateExamService.GetMarksOfTheSubmitedExam(id);

            return Ok(candidateExamResults);
        }

        //// GET: api/CandidateExams/ExamForm
        [HttpPost("ExamForm")]
        public async Task<ActionResult<ExamDetailsDTO>> GetCandidateExam(ExamDetailsDTO examDetailsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await _userManager.FindByNameAsync(examDetailsDTO.UserName);
            ExamForm examForm;

            if(examDetailsDTO.ExamDate == null)
            {
                examForm = await _candidateExamService.GenerateExamForm(user.Id, examDetailsDTO.CertificateId);
            }
            else
            {
                examForm = await _candidateExamService.GenerateExamForm(user.Id, examDetailsDTO.CertificateId, examDetailsDTO.ExamDate);
            }


            return Ok(examForm);
        }

        // This controller checks if the voucher belongs to the user and fetches the exam
        //// GET: api/CandidateExams/InsertVoucher
        [HttpPost("InsertVoucher/{username}")]
        public async Task<ActionResult<ExamDetailsDTO>> GetCandidateExamWithVoucher(string userName, Voucher voucher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await _userManager.FindByNameAsync(userName);

            if(voucher.CandidateId != user.Id && voucher.IsClaimed == true)
            {
                return BadRequest("The voucher is not valid! ");
            }
               

            ExamForm examForm = await _candidateExamService.GenerateExamForm(user.Id, voucher.CertificateId);


            return Ok(examForm);
        }

        //// PUT: api/CandidateExams/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCandidateExam(int id, CandidateExam candidateExam)
        //{
        //    if (id != candidateExam.CandidateExamId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(candidateExam).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CandidateExamExists(id))
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

        // POST: api/CandidateExams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult<ExamForm>> PostCandidateExam(ExamForm examForm)
        {
            if (!ModelState.IsValid) // Validate the exam form
            {
                return BadRequest(ModelState);
            }

            if (examForm.ChosenOptionsId == null) //Handler if exam is submitted blank
            {
                return Ok();
            }

            await _candidateExamAnswerService.SaveExamAnswers(examForm); //Process and save submitted answers

            return Ok(examForm);// Redirect to the Home page
        }

        //// DELETE: api/CandidateExams/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCandidateExam(int id)
        //{
        //    var candidateExam = await _context.CandidateExams.FindAsync(id);
        //    if (candidateExam == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CandidateExams.Remove(candidateExam);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CandidateExamExists(int id)
        //{
        //    return _context.CandidateExams.Any(e => e.CandidateExamId == id);
        //}
    }
}
