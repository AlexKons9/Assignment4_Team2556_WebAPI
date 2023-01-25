using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class CandidateExamAnswer
    {
        [Key]
        public int CandidateExamAnswerId { get; set; }
        public int CandidateExamId { get; set; }
        public CandidateExam? CandidateExam { get; set; }
        public int OptionId { get; set; }
        public Option? Option { get; set; }
        //public string SubmittedOption { get; set; }
        //public string CorrectAnswer { get; set; } //we need correct Answer


    }
}