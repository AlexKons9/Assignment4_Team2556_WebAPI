using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Controllers;

namespace Assignment4_Team2556_WebAPI.Models.DTOModels
{
    public class ExamForm
    {
        public int CandidateExamId { get; set; }
        public List<Question>? Questions { get; set; }
        public List<int>? ChosenOptionsId { get; set; }

        public ExamForm()
        {

        }
    }
}
