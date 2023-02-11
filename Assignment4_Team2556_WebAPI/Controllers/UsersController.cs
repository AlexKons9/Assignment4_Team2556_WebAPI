using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Users/GetAllMarkers
        [HttpGet("GetAllMarkers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllMarkers()
        {
            var markers = await _userManager.GetUsersInRoleAsync("Marker");
            return Ok(markers);
        }

        [HttpGet("GetCandidateCredits/{username}")]
        public async Task<ActionResult> GetCandidateCredits(string userName)
        {
            User user = await _userManager.FindByNameAsync(userName);
            int? credits = user.Credits;
            return Ok(credits);
        }
    }
}
