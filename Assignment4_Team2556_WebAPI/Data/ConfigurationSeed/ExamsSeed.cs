using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4_Team2556_WebAPI.Data.ConfigurationSeed
{
    public class ExamsSeed : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasData
            (
                new Exam()
                {
                    ExamId = 1,
                    CertificateId = 1, // JavaFound
                    MaximumScore = 3,
                    PassMark = 2
                },

                new Exam()
                {
                    ExamId = 2,
                    CertificateId = 1, // JavaFound
                    MaximumScore = 3,
                    PassMark = 2
                },

                new Exam()
                {
                    ExamId = 3,
                    CertificateId = 2, // JavaAdv
                    MaximumScore = 3,
                    PassMark = 2
                },

                new Exam()
                {
                    ExamId = 4,
                    CertificateId = 2, // JavaAdv
                    MaximumScore = 3,
                    PassMark = 2
                }
            );
        }
    }
}
