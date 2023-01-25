using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class ExamQuestion
    {
        //[Key, Column(Order = 0)]
        public int QuestionId { get; set; }
        public Question Question  { get; set; }
        //[Key, Column(Order = 1)]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}