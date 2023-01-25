using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [Required]
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int MaximumScore { get; set; }
        public int PassMark { get; set; }





    }
}
