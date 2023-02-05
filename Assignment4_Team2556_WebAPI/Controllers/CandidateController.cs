using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Assignment4_Team2556_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService ,UserManager<User> userManager, ApplicationDbContext context) //, ApplicationDbContext context
        {
            _userManager = userManager;
            _context = context;
            _candidateService = candidateService;

        }
        // GET: api/Candidate
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var candidates = await _candidateService.GetAllAsync();
            //var candidates = await _userManager.GetUsersInRoleAsync("Candidate");
            return Ok(candidates);
        }
        //GET: api/Candidate/5
        [HttpGet("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> GetCandidate(string username)
        {
            //var question = await _context.Questions.FindAsync(id);
            var candidate = await _candidateService.GetAsync(username);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        //// PUT: api/Questions/5  --> UPDATE
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUser(string username, User user)
        {
            await _userManager.UpdateAsync(user);
            //if username != user.UserName)
            //{
            //    return BadRequest();
            //}

            ////_context.Entry(question).State = EntityState.Modified;

            //try
            //{
            //    //await _context.SaveChangesAsync();
            //    TopicsService tService = _topicsService as TopicsService;
            //    var topic = await tService.GetAsync(question.TopicId);
            //    question.Topic = topic;
            //    await _questionsService.AddOrUpdateAsync(question);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!QuestionExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return Ok(user);
        }



        //// DELETE: api/Questions/5
        //[HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> DeleteQuestion(int id)
        //{
        //    //var question = await _context.Questions.FindAsync(id);
        //    var question = await _questionsService.GetAsync(id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    //_context.Questions.Remove(question);
        //    //await _context.SaveChangesAsync();
        //    await _questionsService.RemoveAsync(question);

        //    return Ok();
        //}

        //private bool QuestionExists(int id)
        //{
        //    //return _context.Questions.Any(e => e.QuestionId == id);
        //    if (_questionsService.GetAsync(id) != null)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
