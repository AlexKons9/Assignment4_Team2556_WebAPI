using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [DataType(DataType.MultilineText)]
   
        public string DescriptionStem { get; set; } //HTML
        public int? TopicId { get; set; }
        public Topic? Topic { get; set; }
        //public string CorrectAnswer { get; set; }
        public virtual IList<Option>? Options { get; set; }
    }
}