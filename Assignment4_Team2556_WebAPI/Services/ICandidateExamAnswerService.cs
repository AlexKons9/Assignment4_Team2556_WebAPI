using Assignment4_Team2556_WebAPI.Models.DTOModels;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ICandidateExamAnswerService
    {
        Task SaveExamAnswers(ExamForm examForm);
    }
}
