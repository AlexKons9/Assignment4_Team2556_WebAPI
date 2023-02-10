using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Assignment4_Team2556_WebAPI.Services;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITopicsService _service;

        public TopicsController(ApplicationDbContext context, ITopicsService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Topics
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IList<Topic>> GetTopics()
        {
            return await _service.GetAllAsync(); ;
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            var topic = await _service.GetAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.TopicId)
            {
                return BadRequest();
            }

            try
            {
                var updatedTopic = _service.AddOrUpdateAsync(topic);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            await _service.AddOrUpdateAsync(topic);

            return CreatedAtAction("GetTopic", new { id = topic.TopicId }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _service.GetAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(topic);

            return NoContent();
        }

        private bool TopicExists(int id)
        {
            var topic = _service.GetAsync(id);
            if (topic == null)
            {
                return false;
            }
            return true;
        }
    }
}
