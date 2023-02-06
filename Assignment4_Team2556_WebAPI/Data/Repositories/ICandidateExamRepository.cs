using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public interface ICandidateExamRepository
    {
        Task<IList<Certificate>> GetActiveCertificateList();
        Task<CandidateExam> GetSubmitedCandidateExamById(int id);
        Task<IList<Exam>> GetAllExamsByCertificateId(int certificateId);
        Task<IList<ExamQuestion>> GetAllExamQuestionsByExamId(int examId);
        Task AddSaveChanges(CandidateExam candidateExam);
        Task<IList<CandidateExam>> GetAllCandidateExams();
    }
}
