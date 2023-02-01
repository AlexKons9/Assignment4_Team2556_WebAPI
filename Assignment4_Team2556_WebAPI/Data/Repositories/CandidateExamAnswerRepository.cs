using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class CandidateExamAnswerRepository : ICandidateExamAnswerRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateExamAnswerRepository(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }

        //
        //Summary: Gets the Answered Questions of the certain given Exam
        public async Task<IList<CandidateExamAnswer>> GetListOfCandidateExamAnswersById(int id)
        {
            var examAnswers = await _context.CandidateExamAnswers.Where(x => x.CandidateExamId == id).ToListAsync();

            // load elements we need
            foreach (var answer in examAnswers)
            {
                await _context.Entry(answer).Reference(x => x.Option).LoadAsync();
            }

            return examAnswers;
        }

        //
        //Summary: Saves a List of Candidate Exam Answers to the Database
        public async Task AddSaveChanges(IList<CandidateExamAnswer> candidateExamAnswers)
        {
            _context.CandidateExamAnswers.AddRange(candidateExamAnswers);
            await _context.SaveChangesAsync();
        }
    }
}
