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
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService) 
        {
            _candidateService = candidateService;
        }
        // GET: api/Candidate
        [HttpGet]
        [Authorize(Roles = "Admin,QualityControl")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var candidates = await _candidateService.GetAllAsync();
            //var candidates = await _userManager.GetUsersInRoleAsync("Candidate");
            return Ok(candidates);
        }
        //GET: api/Candidate/candidate
        [HttpGet("{username}")]
        [Authorize(Roles = "Admin,QualityControl")]
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

        //// PUT: api/Candidate/candidate  --> UPDATE
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUser(User user)
        {
            //if username != user.UserName)
            //{
            //    return BadRequest();
            //}

            ////_context.Entry(question).State = EntityState.Modified;

            //try
            //{

            await _candidateService.AddOrUpdateAsync(user);
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



        // DELETE: api/Candidate/{username}
        [HttpDelete("{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuestion(string username)
        {
            var candidate = await _candidateService.GetAsync(username);
            if (candidate == null)
            {
                return NotFound();
            };
            await _candidateService.RemoveAsync(candidate);

            return Ok();
        }

        //private bool CandidateExists(string? username)
        //{
        //    //return _context.Questions.Any(e => e.QuestionId == id);
        //    if (_candidateService.GetAsync(username) != null)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
