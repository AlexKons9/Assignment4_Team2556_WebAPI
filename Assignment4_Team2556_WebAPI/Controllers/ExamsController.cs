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

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenericService<Exam> _service;

        public ExamsController(ApplicationDbContext context, IGenericService<Exam> service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            var exams = await _service.GetAllAsync();
            return Ok(exams);            
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            //var exam = await _context.Exams.FindAsync(id);
            var exam = await _service.GetAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        //// PUT: api/Exams/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutExam(int id, Exam exam)
        //{
        //    if (id != exam.ExamId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(exam).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ExamExists(id))
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

        //// POST: api/Exams
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            //_context.Exams.Add(exam);
            //await _context.SaveChangesAsync();
            await _service.AddOrUpdateAsync(exam);

            return CreatedAtAction("GetExam", new { id = exam.ExamId }, exam);
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _service.GetAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            await _service.RemoveAsync(exam);
            return Ok();
        }

        //private bool ExamExists(int id)
        //{
        //    return _context.Exams.Any(e => e.ExamId == id);
        //}
    }
}
