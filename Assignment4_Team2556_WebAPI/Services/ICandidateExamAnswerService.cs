using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Models.DTOModels;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ICandidateExamAnswerService
    {
        Task SaveExamAnswers(ExamForm examForm);
        Task<IList<CandidateExamAnswer>> GetListOfCandidateExamAnswersById(int id);
    }
}
