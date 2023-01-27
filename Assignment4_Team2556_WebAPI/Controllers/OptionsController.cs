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
    public class OptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptionsService _optionsService;
        private readonly IQuestionsService _questionsService;

        public OptionsController(IOptionsService serviceOptions, IQuestionsService questionsService,ApplicationDbContext context)
        {
            _context=context;
            _optionsService = serviceOptions;
            _questionsService = questionsService;
        }

        //// GET: api/Options
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
        //{
        //    return await _context.Options.ToListAsync();
        //}

        //// GET: api/Options/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Option>> GetOption(int id)
        //{
        //    var option = await _context.Options.FindAsync(id);

        //    if (option == null)
        //    {
        //        return NotFound();
        //    }

        //    return option;
        //}

        // PUT: api/Options/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption(int id, Option option)
        {
            if (id != option.OptionId)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST: api/Options
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OptionListDTO>> PostOption(OptionListDTO options)
        {
            if (ModelState.IsValid)
            {
                var question = await _questionsService.GetAsync(options.QuestionId);
                //await _context.Entry(question).Reference( x => x.Topic).LoadAsync(); 

                IList<Option> newlistOfOptions = new List<Option>()
                {
                new Option {},
                new Option {},
                new Option {},
                new Option {}
                };

                var service = _optionsService as OptionsService;
                // This method takes all values from dto and passes it to List<Option>
                var listOfOptions = service.GetOptionsValuesFromDTOModel(options, newlistOfOptions, question);
                await service.AddOrUpdateAsync(listOfOptions);

                return  CreatedAtAction("GetQuestion", new {});
            }

            return Ok();
        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var option = await _context.Options.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            _context.Options.Remove(option);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionExists(int id)
        {
            return _context.Options.Any(e => e.OptionId == id);
        }
    }
}
