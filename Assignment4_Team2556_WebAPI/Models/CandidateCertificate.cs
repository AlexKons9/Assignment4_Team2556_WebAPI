using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class CandidateCertificate
    {
        [Key]
        public int CandidateCertificateId { get; set; }
        [Required]
        public CandidateExam CandidateExam { get; set; }  //CandidateExam
        
    }
}
