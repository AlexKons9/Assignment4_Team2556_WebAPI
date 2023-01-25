using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4_Team2556_WebAPI.Data.ConfigurationSeed
{
    public class CertificatesSeed : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasData
            (
                new Certificate
                {
                    CertificateId = 1,
                    Title = "Java Foundation",
                    IsActive = true 
                },

                new Certificate
                {
                    CertificateId = 2,
                    Title = "Java Advanced",
                    IsActive = true
                },

                new Certificate
                {
                    CertificateId = 3,
                    Title = "C# Foundation",
                    IsActive = false
                },

                new Certificate
                {
                    CertificateId = 4,
                    Title = "C# Advanced",
                    IsActive = false
                },

                new Certificate
                {
                    CertificateId = 5,
                    Title = "Javascript Foundation",
                    IsActive = false
                },

                new Certificate
                {
                    CertificateId = 6,
                    Title = "Javascript Advanced",
                    IsActive = false
                },

                new Certificate
                {
                    CertificateId = 7,
                    Title = "C++",
                    IsActive = false
                }
            );
        }
    }
}
