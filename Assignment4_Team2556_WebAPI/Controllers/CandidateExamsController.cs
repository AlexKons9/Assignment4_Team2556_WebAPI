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

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICandidateExamService _candidateExamService;
        private readonly ICandidateExamAnswerService _candidateExamAnswerService;

        public CandidateExamsController(ApplicationDbContext context, ICandidateExamService candidateExamService, ICandidateExamAnswerService candidateExamAnswerService)
        {
            _context = context;
            _candidateExamService = candidateExamService;
            _candidateExamAnswerService = candidateExamAnswerService;
        }

        // GET: api/CandidateExams
        [HttpGet]
        public async Task<IList<Certificate>> GetCandidateExams()
        {
            return await _candidateExamService.GetActiveCertificateList();
        }

        //// GET: api/CandidateExams/ExamResults/5
        [HttpGet("ExamResults/{id}")]
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

            ExamForm examForm = await _candidateExamService.GenerateExamForm(examDetailsDTO.CandidateId, examDetailsDTO.CertificateId);

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
