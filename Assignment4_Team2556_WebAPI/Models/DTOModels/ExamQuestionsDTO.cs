namespace Assignment4_Team2556_WebAPI.Models.DTOModels
{
    public class ExamQuestionsDTO
    {
        public int ExamId { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
