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

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IQuestionsService _questionsService;
        private readonly ITopicsService _topicsService;

        public QuestionsController(IQuestionsService questionsService, ITopicsService topicsService) //, ApplicationDbContext context
        {
            //_context = context;
            _questionsService = questionsService;
            _topicsService = topicsService;
        }

        // GET: api/Questions
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            //return await _context.Questions.ToListAsync();
            var questions = await _questionsService.GetAllAsync();
            return Ok(questions);
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            //var question = await _context.Questions.FindAsync(id);
            var question = await _questionsService.GetAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/5  --> UPDATE
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            //_context.Entry(question).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                TopicsService tService = _topicsService as TopicsService;
                var topic = await tService.GetAsync(question.TopicId);
                question.Topic = topic;
                await _questionsService.AddOrUpdateAsync(question);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(question);
        }


        //FRONTEND --> Create Create FORM
        //!!!!!CREATE A GET METHOD WHICH DISPLAYS A FORM TO BE USED TO FILL IN THE QUESTION OBJECT FOR THE HTTPPOST METHOD BELOW!!!!!


        // POST: api/Questions --> CREATE
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            TopicsService tservice = _topicsService as TopicsService;
            question.Topic = await tservice.GetAsync(question.TopicId);
            await _questionsService.AddOrUpdateAsync(question);
            return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            //var question = await _context.Questions.FindAsync(id);
            var question = await _questionsService.GetAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            //_context.Questions.Remove(question);
            //await _context.SaveChangesAsync();
            await _questionsService.RemoveAsync(question);

            return Ok();
        }

        private bool QuestionExists(int id)
        {
            //return _context.Questions.Any(e => e.QuestionId == id);
            if (_questionsService.GetAsync(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
