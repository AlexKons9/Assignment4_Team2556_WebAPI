using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        [Required]
        public string TopicDescription { get; set; }
        [Required]
        public int CertificateId { get; set; }
        public Certificate? Certificate { get; set; }
    }
}