using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public interface ICandidateExamRepository
    {
        Task<IList<Certificate>> GetActiveCertificateList();
        Task<CandidateExam> GetSubmitedCandidateExamById(int id);
        Task<IList<CandidateExam>> GetAccomplishedExamsByCandidateId(string candidateId);
        Task<IList<CandidateExam>> GetScheduledExamsByCandidateId(string candidateId);
        Task<IList<Exam>> GetAllExamsByCertificateId(int certificateId);
        Task<IList<ExamQuestion>> GetAllExamQuestionsByExamId(int examId);
        Task AddSaveChanges(CandidateExam candidateExam);
    }
}
