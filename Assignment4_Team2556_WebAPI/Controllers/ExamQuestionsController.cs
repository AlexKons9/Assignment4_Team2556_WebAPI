using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamQuestion>>> GetExamQuestions()
        {
            return await _context.ExamQuestions.ToListAsync();
        }

        // GET: api/ExamQuestions/5
        [HttpGet("{examid}")]
        public async Task<ActionResult<IEnumerable<ExamQuestion>>> GetExamQuestion(int examid)
        {
            var examQuestions = await _context.ExamQuestions.Where(id => id.ExamId == examid)
                .Include(e => e.Exam)
                .Include(q => q.Question).ThenInclude(t=>t.Topic)
                .ToListAsync();

            if (examQuestions == null)
            {
                return NotFound();
            }

            return examQuestions;
        }

        // PUT: api/ExamQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutExamQuestion(int id, ExamQuestion examQuestion)
        //{
        //    if (id != examQuestion.QuestionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(examQuestion).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ExamQuestionExists(id))
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

        //// POST: api/ExamQuestions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ExamQuestion>> PostExamQuestion(ExamQuestion examQuestion)
        //{
        //    _context.ExamQuestions.Add(examQuestion);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ExamQuestionExists(examQuestion.QuestionId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetExamQuestion", new { id = examQuestion.QuestionId }, examQuestion);
        //}

        //// DELETE: api/ExamQuestions/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteExamQuestion(int id)
        //{
        //    var examQuestion = await _context.ExamQuestions.FindAsync(id);
        //    if (examQuestion == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ExamQuestions.Remove(examQuestion);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ExamQuestionExists(int id)
        //{
        //    return _context.ExamQuestions.Any(e => e.QuestionId == id);
        //}
    }
}
