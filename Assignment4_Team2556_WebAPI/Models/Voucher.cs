namespace Assignment4_Team2556_WebAPI.Models
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public string? Description { get; set; }
        public int CertificateId { get; set; }
        public Certificate? Certificate { get; set; }
        public string? CandidateId { get; set; }
        public User? Candidate { get; set; }
    }
}
