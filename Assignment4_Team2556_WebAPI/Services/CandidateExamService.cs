using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class CandidateExamService : ICandidateExamService
    {
        private readonly ICandidateExamRepository _candidateExamRepository;

        public CandidateExamService(ICandidateExamRepository candidateExamRepository)
        {
            _candidateExamRepository = candidateExamRepository;
        }


        //
        // Summary: Returns a list of active certificates
        public async Task<IList<Certificate>> GetActiveCertificateList()
        {
            return await _candidateExamRepository.GetActiveCertificateList();
        }


        //
        //Summary: Returns the ExamForm DTO
        public async Task<ExamForm> GenerateExamForm(int candidateId, int certificateId)
        {
            //Create list of Exams associated with a certificate
            IList<Exam> exams = await _candidateExamRepository.GetAllExamsByCertificateId(certificateId);

            //Randomly select an exam from Exam List above
            Exam? randomlySelectedExam = exams.OrderBy(a => new Random().Next()).FirstOrDefault();

            //Retrieve the ExamQuestions associated by the randomly Selected Exam
            IList<ExamQuestion> examQuestions = await _candidateExamRepository.GetAllExamQuestionsByExamId(randomlySelectedExam.ExamId);

            //Create a List of Questions, composed of the questions associated with the exam
            List<Question> questions = new List<Question>();
            foreach (var examQuestion in examQuestions)
            {
                questions.Add(examQuestion.Question);
            }

            //Create the CandidateExam object and save to database
            CandidateExam candidateExam = new CandidateExam()
            {
                ExamId = randomlySelectedExam.ExamId,
                CandidateId = candidateId,
                ExamDate = DateTime.Now,
                AssessmentTestCode = "Some Code"
            };
            await _candidateExamRepository.AddSaveChanges(candidateExam);

            //Create a new examForm object - DTO
            ExamForm examForm = new ExamForm()
            {
                CandidateExamId = candidateExam.CandidateExamId,
                Questions = questions
            };

            return examForm;
        }

    }
}
