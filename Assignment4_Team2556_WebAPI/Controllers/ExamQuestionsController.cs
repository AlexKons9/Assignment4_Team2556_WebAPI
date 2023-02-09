using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ExamQuestion>>> GetExamQuestions()
        {
            return await _context.ExamQuestions.ToListAsync();
        }

        // GET: api/ExamQuestions/5
        [HttpGet("{examid}")]
        [Authorize(Roles = "Admin")]
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
        [HttpPost("Edit/{examId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ExamQuestion>> PutExamQuestion(int examId, List<int> examQestions)
        {
            var prevExamQuestions = await _context.ExamQuestions.Where(eq => eq.ExamId == examId).ToListAsync();
            if (prevExamQuestions !=null) { 
            foreach (var prevQuestion in prevExamQuestions)
            {
                _context.ExamQuestions.Remove(prevQuestion);
                _context.SaveChanges();
            }
            }

            ExamQuestion examQuestion = new();
            examQuestion.ExamId = examId;

            foreach (var question in examQestions)
            {
                examQuestion.QuestionId = question;
                await _context.ExamQuestions.AddAsync(examQuestion);
                await _context.SaveChangesAsync();
            }

            //if (id != examquestion.questionid)
            //{
            //    return badrequest();
            //}

            //_context.entry(examquestion).state = entitystate.modified;

            //try
            //{
            //    await _context.savechangesasync();
            //}
            //catch (dbupdateconcurrencyexception)
            //{
            //    if (!examquestionexists(id))
            //    {
            //        return notfound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return CreatedAtAction("GetExamQuestion", new { id = examQuestion.QuestionId }, examQuestion);
        }

        //// POST: api/ExamQuestions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ExamQuestion>> PostExamQuestion(int examId,List<int> examQuestions)
        {
            ExamQuestion examQuestion = new();
            examQuestion.ExamId = examId;
            
            foreach (var question in examQuestions) 
            {   
                 examQuestion.QuestionId = question;
                await _context.ExamQuestions.AddAsync(examQuestion);
                await _context.SaveChangesAsync();
            }
        //    try
        //    {
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

            return CreatedAtAction("GetExamQuestion", new { id = examQuestion.QuestionId }, examQuestion);
        }

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
