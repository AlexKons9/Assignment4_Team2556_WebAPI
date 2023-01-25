using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Debugger.Contracts.HotReload;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class OptionsService : IOptionsService
    {
        public IGenericRepository<Option> _repository { get; set; }

        public OptionsService(IGenericRepository<Option> repository)
        {
            _repository = repository;
        }


        //calls repository and add or updates one option
        public async Task<Option> AddOrUpdateAsync(Option option)
        {
            return await _repository.AddOrUpdateAsync(option);
        }

        //calls repository and add or updates list of options
        public async Task<IList<Option>> AddOrUpdateAsync(IList<Option> options)
        {
            foreach (var option in options)
            {
                await _repository.AddOrUpdateAsync(option);
            }
            return options;
        }

        // Get One Option of Certain question
        public async Task<Option?> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        // gets only options of certain question
        public async Task<IList<Option>> GetAllQuestionOptionsAsync(int questionId) 
        {
            var optionRepository = _repository as OptionsRepository;
            return await optionRepository.GetAllQuestionOptionsAsync(questionId);
        }

        // gets all options of entire db
        public async Task<IList<Option>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // we dont need this but it's here!
        public async Task<bool> RemoveAsync(Option option)
        {
            return await _repository.RemoveAsync(option);
        }




        // Makes the selections names of dropdownlist
        public List<SelectListItem> CreateOptionsSelectListForDropDownList(int number) // CreateDropDownListForOptions
        {
            List<SelectListItem> items = new List<SelectListItem>();

            for (var i = 1; i <= number; i++)
            {
                items.Add(new SelectListItem { Value = $"{i}", Text = $"Option {i}" });
            }

            return items;
        }

        // Method that pass values from dto object to list of Options
        public  IList<Option> GetOptionsValuesFromDTOModel(OptionListDTO optionsDTO, IList<Option> listOfOptions, Question question)
        {

            listOfOptions[0].Description = optionsDTO.Description1;
            listOfOptions[1].Description = optionsDTO.Description2;
            listOfOptions[2].Description = optionsDTO.Description3;
            listOfOptions[3].Description = optionsDTO.Description4;

            for (int i = 0; i < listOfOptions.Count; i++)
            {
                listOfOptions[i].QuestionId = question.QuestionId;
                listOfOptions[i].Question = question;
                if (optionsDTO.CorrectAnswer == i + 1)
                {
                    listOfOptions[i].IsCorrect = true; // -1
                }
                else
                {
                    listOfOptions[i].IsCorrect = false;
                }
            }

            question.Options = listOfOptions;
            

            return listOfOptions;
        }

        // Method that pass values from List<Option> object to DTOModel
        public OptionListDTO PassOptionValuesToDTOModel(IList<Option> options)
        {
            int correctAnswer = 0;
            for (var i = 0; i < options.Count(); i++)
            {
                if (options[i].IsCorrect) // if the answer is true, then pass it over
                {
                    correctAnswer = i + 1;
                }
            }
            if(options.Count > 0)
            {
                OptionListDTO optionListDTO = new OptionListDTO()
                {
                    QuestionId = options[0].QuestionId,
                    Description1 = options[0].Description,
                    Description2 = options[1].Description,
                    Description3 = options[2].Description,
                    Description4 = options[3].Description,
                    CorrectAnswer = correctAnswer
                };
                return optionListDTO;
            }

            return new OptionListDTO();
        }
    }
}
