using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class Option
    {
        [Key]
        public int OptionId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public string? Description{ get; set; }
        public bool IsCorrect { get; set; }
    }
}