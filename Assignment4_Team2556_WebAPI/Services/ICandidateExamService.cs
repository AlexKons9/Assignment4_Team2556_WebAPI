using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Models.DTOModels;

namespace Assignment4_Team2556_WebAPI.Services
{
    public interface ICandidateExamService
    {
        Task<IList<Certificate>> GetActiveCertificateList();
        Task<CandidateExam> GetSubmitedCandidateExamById(int id);
        Task<CandidateExamResultsDTO> GetMarksOfTheSubmitedExam(int candidateExamId);
        Task<ExamForm> GenerateExamForm(string userId, int certificateId);
        Task<IList<CandidateExam>> GetAllCandidateExams();



    }
}
