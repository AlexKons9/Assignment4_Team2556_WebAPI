using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4_Team2556_WebAPI.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }
        public string Title { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public bool IsActive { get; set; }
    }
}