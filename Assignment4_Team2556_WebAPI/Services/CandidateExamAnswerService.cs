using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class CandidateExamAnswerService : ICandidateExamAnswerService
    {
        private readonly ICandidateExamAnswerRepository _repository;

        public CandidateExamAnswerService(ICandidateExamAnswerRepository repository)
        {
            _repository = repository;
        }

        //
        //Summary: Gets the Answered Questions of the certain given Exam
        public async Task<IList<CandidateExamAnswer>> GetListOfCandidateExamAnswersById(int id)
        {
            return await _repository.GetListOfCandidateExamAnswersById(id);
        }

        //
        //Summary: Saves the chosen answers of the candidate to the database
        public async Task SaveExamAnswers(ExamForm examForm)
        {
            // Iterate over the Ids of the chosen options and save to list
            var candidateExamAnswers = new List<CandidateExamAnswer>();
            foreach (var chosenOptionId in examForm.ChosenOptionsId)
            {
                // Create a candidate exam answer
                var candidateExamAnswer = new CandidateExamAnswer
                {
                    CandidateExamId = examForm.CandidateExamId,
                    OptionId = chosenOptionId
                };

                //Add candidate Exam Answer to the list
                candidateExamAnswers.Add(candidateExamAnswer);
            }

            // Save the candidate exam answers to the database
            await _repository.AddSaveChanges(candidateExamAnswers);
        }
        
    }
}
