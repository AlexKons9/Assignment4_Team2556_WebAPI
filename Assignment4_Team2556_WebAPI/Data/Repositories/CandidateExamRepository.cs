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
            return await _context.Exams.Where(i => i.CertificateId == certificateId).ToListAsync();

        }

        //
        //Summary: Returns a List of all active certificates
        public async Task<IList<Certificate>> GetActiveCertificateList() 
        {
            return await _context.Certificates.Where(v => v.IsActive == true).ToListAsync();
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
            _context.Add(candidateExam);
            await _context.SaveChangesAsync();
        }
    }
}
