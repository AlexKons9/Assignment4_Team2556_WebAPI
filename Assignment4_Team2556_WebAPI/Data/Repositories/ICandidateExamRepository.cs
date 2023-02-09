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
        Task<IList<CandidateExam>> GetAllCandidateExams();
        Task<IList<CandidateExam>> GetAllMarkedCandidateExamsByMarker(string markerId);
        Task<IList<CandidateExam>> GetAllUnMarkedCandidateExamsByMarker(string markerId);
        Task<IList<CandidateExam>> GetCandidateExam(int candidateExamId);
        Task<IList<CandidateExam>> GetAllUnmarkedCandidateExams();
        Task UpdateAsync(CandidateExam candidateExam);
    }
}
