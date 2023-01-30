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
        private readonly IOptionsService _optionsService;
        private readonly IQuestionsService _questionsService;

        public OptionsController(IOptionsService serviceOptions, IQuestionsService questionsService)
        {
            _optionsService = serviceOptions;
            _questionsService = questionsService;
        }

        // GET: api/Options
        [HttpGet]
        public async Task<IList<Option>> GetAllOptions()
        {
            return await _optionsService.GetAllAsync();
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IList <Option>>> GetQuestionsOptions(int id)
        {
            var service = _optionsService as OptionsService;

            if (id == null || _optionsService.GetAllAsync == null)
            {
                return NotFound();
            }

            List<Option> options = await service.GetAllQuestionOptionsAsync(id) as List<Option>;

            if (options == null)
            {
                return NotFound();
            }

            return options;
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

                return CreatedAtAction("GetQuestion", new { });
            }

            return Ok();
        }


        // PUT: api/Options/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutOptions(OptionListDTO optionsDTO)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var options = await _optionsService.GetAllQuestionOptionsAsync(optionsDTO.QuestionId);
                    var question = await _questionsService.GetAsync(optionsDTO.QuestionId);
                    var service = _optionsService as OptionsService;
                    var listOfOptions = service.GetOptionsValuesFromDTOModel(optionsDTO, options, question);
                    await service.AddOrUpdateAsync(listOfOptions);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await OptionsExists(optionsDTO.QuestionId))
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
            return Ok();
        }


        private async Task<bool> OptionsExists(int id)
        {
            var options = await _optionsService.GetAllQuestionOptionsAsync(id);
            if (options != null)
            {
                return true;
            }
            return false;
        }
    }
}
