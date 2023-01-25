using Assignment4_Team2556_WebAPI.Data.ConfigurationSeed;
using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_Team2556_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
           : base(options)
        {
        }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateCertificate> CandidateCertificates { get; set; }
        public virtual DbSet<CandidateExam> CandidateExams { get; set; }
        public virtual DbSet<CandidateExamAnswer> CandidateExamAnswers { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamQuestion>()
                .HasKey(eq => new { eq.QuestionId, eq.ExamId });

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Question)
                .WithMany()
                .HasForeignKey(eq => eq.QuestionId);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Exam)
                .WithMany()
                .HasForeignKey(eq => eq.ExamId);

            modelBuilder.ApplyConfiguration(new CandidatesSeed());
            modelBuilder.ApplyConfiguration(new CertificatesSeed());
            modelBuilder.ApplyConfiguration(new TopicsSeed());
            modelBuilder.ApplyConfiguration(new ExamsSeed());
            modelBuilder.ApplyConfiguration(new QuestionsSeed());
            modelBuilder.ApplyConfiguration(new OptionsSeed());
            modelBuilder.ApplyConfiguration(new ExamQuestionsSeed());

            base.OnModelCreating(modelBuilder);
        }
    }
}
