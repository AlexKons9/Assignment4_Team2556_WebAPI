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
        //Summary: Saves a List of Candidate Exam Answers to the Database
        public async Task AddSaveChanges(IList<CandidateExamAnswer> candidateExamAnswers)
        {
            _context.CandidateExamAnswers.AddRange(candidateExamAnswers);
            await _context.SaveChangesAsync();
        }
    }
}
