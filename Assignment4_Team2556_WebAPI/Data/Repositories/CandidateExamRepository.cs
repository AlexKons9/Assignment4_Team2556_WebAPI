using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using NuGet.Protocol.Plugins;
using Assignment4_Team2556_WebAPI.Data.Repositories;

namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public class CandidateExamRepository : ICandidateExamRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateExamRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        //
        //Summary: Returns a List of Exams, associated with a certificate
        public async Task<IList<Exam>> GetAllExamsByCertificateId(int certificateId)
        {
            var exams = await _context.Exams.Where(i => i.CertificateId == certificateId).ToListAsync();
            await _context.Entry(exams[0]).Reference(x => x.Certificate).LoadAsync();
            return exams;

        }

        //
        //Summary: Returns a List of all active certificates
        public async Task<IList<Certificate>> GetActiveCertificateList() 
        {
            return await _context.Certificates.Where(v => v.IsActive == true).ToListAsync();
        }

        //
        //Summary: Returns a Candidate Exam that has been completed successfully
        public async Task<IList<CandidateExam>> GetAccomplishedExamsByCandidateId(string candidateId)
        {
            var listOfCandidateExams = await _context.CandidateExams.Where(c => c.CandidateId == candidateId && c.ExamScore>=c.Exam.PassMark).ToListAsync();
            return listOfCandidateExams;
        }

        //
        //Summary: Returns a List of all submitted candidate exams
        public async Task<IList<CandidateExam>> GetAllCandidateExams()
        {
            return await _context.CandidateExams
                .Where(ce => ce.ExamScore != null)
                .Include(m => m.Marker)
                .Include(c => c.Candidate)
                .Include(e => e.Exam).ThenInclude(c => c.Certificate)
                .ToListAsync();
        }

        //
        //Summary: Returns a List of all unmarked submitted candidate exams
        public async Task<IList<CandidateExam>> GetAllUnmarkedCandidateExams()
        {
            return await _context.CandidateExams
                .Where(ce => ce.IsMarked == false && ce.ExamScore != null)
                .Include(m => m.Marker)
                .Include(c => c.Candidate)
                .Include(e => e.Exam).ThenInclude(c => c.Certificate)
                .ToListAsync();
        }

        //
        //Summary: Returns a Candidate Exam by Id
        public async Task<IList<CandidateExam>> GetCandidateExam(int candidateExamId)
        {
            return await _context.CandidateExams
                .Where(ce => ce.CandidateExamId == candidateExamId)
                .Include(m => m.Marker)
                .Include(c => c.Candidate)
                .Include(c => c.QA).ThenInclude(qa => qa.Option).ThenInclude(o => o.Question)
                .Include(e => e.Exam).ThenInclude(c => c.Certificate)
                .ToListAsync();
        }

        //
        //Summary: Returns a List of all MARKED candidate exams By Marker
        public async Task<IList<CandidateExam>> GetAllMarkedCandidateExamsByMarker(string markerId)
        {
            return await _context.CandidateExams
                .Where(ce => ce.MarkerId == markerId && ce.IsMarked == true)
                .Include(m => m.Marker)
                .Include(c => c.Candidate)
                .Include(e => e.Exam).ThenInclude(c => c.Certificate)
                .ToListAsync();
        }

        //
        //Summary: Returns a List of all UNMARKED candidate exams By Marker
        public async Task<IList<CandidateExam>> GetAllUnMarkedCandidateExamsByMarker(string markerId)
        {
            return await _context.CandidateExams
                .Where(ce => (ce.MarkerId == markerId && ce.IsMarked == false))
                .Include(c => c.Candidate)
                .Include(e => e.Exam).ThenInclude(c => c.Certificate)
                .ToListAsync();
        }

        //
        //Summary: Returns a List of Scheduled Exams of a candidate
        public async Task<IList<CandidateExam>> GetScheduledExamsByCandidateId(string candidateId)
        {
            var listOfScheduledCandidateExams = await _context.CandidateExams
                .Where(c => c.CandidateId == candidateId && c.ExamScore == null)
                .Include(c => c.Exam)
                .ThenInclude(e => e.Certificate)
                .ToListAsync();
            return listOfScheduledCandidateExams;
        }

        //
        //Summary: Returns a Scheduled Exam of a candidate
        public async Task<CandidateExam> GetScheduledExamById(int candidateExamId)
        {
            var scheduledCandidateExam = await _context.CandidateExams
                .Where(c => c.CandidateExamId == candidateExamId && c.ExamScore == null)
                .Include(c => c.Exam)
                .ThenInclude(e => e.Certificate)
                .FirstAsync();
       
            return scheduledCandidateExam;
        }

        //
        //Summary: Returns a Candidate Exam that has been submited for marking 
        public async Task<CandidateExam> GetSubmitedCandidateExamById(int id)
        {
            var candidateExam = await _context.CandidateExams.Where(c => c.CandidateExamId == id).FirstAsync();
            await _context.Entry(candidateExam).Reference(x => x.Exam).LoadAsync();
            return candidateExam;   
        }

        //
        //Summary: Returns a List of ExamQuestions, associated with a certain Exam
        public async Task<IList<ExamQuestion>> GetAllExamQuestionsByExamId(int examId)
        {
            return await _context.ExamQuestions.Where(exam => exam.ExamId == examId).Include(eq => eq.Question.Options).ToListAsync();
        }

        //
        //Summary: Saves a Candidate Exam to the database
        public async Task AddSaveChanges(CandidateExam candidateExam)
        {
            // Update here Works As AddOrUpdate
            _context.Update(candidateExam);
            await _context.SaveChangesAsync();
        }

        //
        //Summary: Updates Candidate Exam to the database
        public async Task UpdateAsync(CandidateExam candidateExam)
        {
            _context.Entry(candidateExam).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
