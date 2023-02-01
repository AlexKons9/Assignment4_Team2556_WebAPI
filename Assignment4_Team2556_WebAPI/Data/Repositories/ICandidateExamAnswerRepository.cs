using Assignment4_Team2556_WebAPI.Models;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public interface ICandidateExamAnswerRepository
    {
        Task AddSaveChanges(IList<CandidateExamAnswer> candidateExamAnswers);
        Task <IList<CandidateExamAnswer>> GetListOfCandidateExamAnswersById(int id);
    }
}
