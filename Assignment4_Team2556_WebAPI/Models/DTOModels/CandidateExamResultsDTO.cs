namespace Assignment4_Team2556_WebAPI.Models.DTOModels
{
    public class CandidateExamResultsDTO
    {
        public List<string[]> ResultsPerTopic { get; set; }
        public DateTime? ExamDate { get; set; }
        public int? ExamScore { get; set; }
        public string? PercentageScore { get; set; }
        public string? TestResult { get; set; }
        public int? NumberOfAwardedMarks { get; set; }
        public int? NumberOfPossibleMakrs { get; set; }

        public CandidateExamResultsDTO()
        {
            ResultsPerTopic = new List<string[]>();
        }
    }
}
