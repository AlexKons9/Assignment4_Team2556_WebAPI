using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models.DTOModels;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Assignment4_Team2556_WebAPI.Services
{
    public class CandidateExamService : ICandidateExamService
    {
        private readonly ICandidateExamRepository _candidateExamRepository;
        private readonly ICandidateExamAnswerService _candidateExamAnswerService;
        private readonly IQuestionsService _questionsService;
        private readonly IOptionsService _optionsService;

        public CandidateExamService(ICandidateExamRepository candidateExamRepository, 
                                    ICandidateExamAnswerService candidateExamAnswerService, 
                                    IQuestionsService questionsService,
                                    IOptionsService optionsService)
        {
            _candidateExamRepository = candidateExamRepository;
            _candidateExamAnswerService = candidateExamAnswerService;
            _questionsService = questionsService;
            _optionsService = optionsService;
        }


        //
        // Summary: Returns a list of active certificates
        public async Task<IList<Certificate>> GetActiveCertificateList()
        {
            return await _candidateExamRepository.GetActiveCertificateList();
        }

        // Summary: Returns a list of all candidate exams
        public async Task<IList<CandidateExam>> GetAllCandidateExams()
        {
            return await _candidateExamRepository.GetAllCandidateExams();
        }

        //
        //Summary: Returns a List of all candidate exams By Marker
        public async Task<IList<CandidateExam>> GetAllCandidateExamsByMarker(string markerId)
        {
            return await _candidateExamRepository.GetAllCandidateExamsByMarker(markerId);
        }


        //Summary: Returns a Candidate Exam that has been submited for marking 
        public async Task<CandidateExam> GetSubmitedCandidateExamById(int id)
        {
            return await _candidateExamRepository.GetSubmitedCandidateExamById(id);
        }


        //
        //Summary: This method marks the given answers and pass the results in the CandidateExam
        public async Task<CandidateExamResultsDTO> GetMarksOfTheSubmitedExam(int candidateExamId)
        {
            //Gets the created CandidateExam
            var candidateExam = await  GetSubmitedCandidateExamById(candidateExamId);
            // Gets a list of submited Answers of the Certin Exam
            var listOfCandidateExamAnswers = await _candidateExamAnswerService.GetListOfCandidateExamAnswersById(candidateExamId);
            if (candidateExam.ExamScore == null)
            {
                // method to pass marks to CandidateExam
                PassResultsFromCandidateExamAnswersToCandidateExam(candidateExam, listOfCandidateExamAnswers);
                await _candidateExamRepository.AddSaveChanges(candidateExam);
            }
            // method that passes data to a DTOmodel and return it to show the final results
            CandidateExamResultsDTO result = await GetResultsForCandidateExam(candidateExam, listOfCandidateExamAnswers);

            return result;
        }


        //
        //Summary: Returns the ExamForm DTO
        public async Task<ExamForm> GenerateExamForm(string userId, int certificateId)
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
                CandidateId = userId,
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

        //
        //Summary: Pass Exam answers from a submited exam to Calculate the Result and to store in the CandidateExam all the details
        public void PassResultsFromCandidateExamAnswersToCandidateExam(CandidateExam exam, IList<CandidateExamAnswer> answers)
        {
            int correctAnswers = 0;
            int totalQuestions = 0;
            int passMark = exam.Exam.PassMark;

            foreach (var answer in answers)
            {
                totalQuestions++;
                if (answer.Option.IsCorrect)
                {
                    correctAnswers++;
                }
            }

            exam.ExamScore = correctAnswers;
            exam.PercentageScore = $"{correctAnswers}/{totalQuestions}";

            //Determines if Failed Or Passed the Exam
            if(correctAnswers >= passMark)
            {
                exam.TestResult = "PASS";
                exam.NumberOfAwardedMarks = 1; 
                exam.NumberOfPossibleMakrs = 0; 
            }
            else
            {
                exam.TestResult = "FAIL";
                exam.NumberOfAwardedMarks = 0;
                exam.NumberOfPossibleMakrs = 1;
            }
        }

        //
        //Summary: Passes data from an already submited Exam to a DTO model in order pass the Details of the given Exam
        public async Task<CandidateExamResultsDTO> GetResultsForCandidateExam (CandidateExam exam, IList<CandidateExamAnswer> answers)
        {

            // Pass the data from the Exam to DTO model 
            var examResults = new CandidateExamResultsDTO()
            {
                ExamDate = exam.ExamDate,
                ExamScore = exam.ExamScore,
                PercentageScore = exam.PercentageScore,
                TestResult = exam.TestResult,
                NumberOfAwardedMarks = exam.NumberOfAwardedMarks,
                NumberOfPossibleMakrs = exam.NumberOfPossibleMakrs,
            };

            List<string> topics = new List<string> ();
            
            foreach (var answer in answers)
            {
                // We call the next two objects in order to Load The childern entities we need
                // In the GetAsync method we Load the nav properties
                var option = await _optionsService.GetAsync(answer.OptionId);
                await _questionsService.GetAsync(option.QuestionId);

                // Adds in the list all the topics of every question (and duplicates)
                topics.Add(answer.Option.Question.Topic.TopicDescription);
            }

            //Gets all distinct Topics
            IEnumerable<string> uniqueTopics = topics.Distinct();

            //Here we will store the Answers Given Per Topic
            List<string[]> answersPerTopic = new List<string[]> ();

            //Iterate over Topic
            foreach (var uniqueTopic in uniqueTopics)
            {
                int correctAnswers = 0;
                int totalQuestions = 0; 
                
                // Iterate over answer over Topic To see which answer in on the specific Topic
                // and if is correct
                foreach (var answer in answers)
                {
                    if (answer.Option.Question.Topic.TopicDescription == uniqueTopic)
                    {
                        if(answer.Option.IsCorrect)
                        {
                            correctAnswers++;
                        }
                        totalQuestions++;
                    }
                }
                // This add to and List<string[]> {Topic, correct Answers given, total Questions of each topic}
                answersPerTopic.Add(new string[3] { uniqueTopic, correctAnswers.ToString(), totalQuestions.ToString()});
            }

            examResults.ResultsPerTopic = answersPerTopic;

            return examResults;
        }
    }
}
