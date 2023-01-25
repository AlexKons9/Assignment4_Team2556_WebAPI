using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4_Team2556_WebAPI.Data.ConfigurationSeed
{
    public class TopicsSeed : IEntityTypeConfiguration<Topic>
    {
        

        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasData
            (
                new Topic
                {
                    TopicId = 1,
                    TopicDescription = "FrontEnd Java Foundation",
                    CertificateId = 1 //certificate JavaFound
                },

                new Topic
                {
                    TopicId = 2,
                    TopicDescription = "BackEnd Java Foundation",
                    CertificateId = 1 //certificate JavaFound
                },

                new Topic
                {
                    TopicId = 3,
                    TopicDescription = "FrontEnd Java Advanced",
                    CertificateId = 2, //certificate JavaAdv
                },

                new Topic
                {
                    TopicId = 4,
                    TopicDescription = "BackEnd Java Advanced",
                    CertificateId = 2, //certificate JavaAdv
                },

                new Topic
                {
                    TopicId = 5,
                    TopicDescription = "FrontEnd C# Foundation",
                    CertificateId = 3,
                },

                new Topic
                {
                    TopicId = 6,
                    TopicDescription = "BackEnd C# Foundation",
                    CertificateId = 3,
                },

                new Topic
                {
                    TopicId = 7,
                    TopicDescription = "FrontEnd C# Advanced",
                    CertificateId = 4
                },

                new Topic
                {
                    TopicId = 8,
                    TopicDescription = "BacktEnd C# Advanced",
                    CertificateId = 4,
                },

                new Topic
                {
                    TopicId = 9,
                    TopicDescription = "FrontEnd Javascript Foundation",
                    CertificateId = 5,
                },

                new Topic
                {
                    TopicId = 10,
                    TopicDescription = "BackEnd Javascript Foundation",
                    CertificateId = 5,
                },

                new Topic
                {
                    TopicId = 11,
                    TopicDescription = "FrontEnd Javascript Advanced",
                    CertificateId = 6,
                },

                new Topic
                {
                    TopicId = 12,
                    TopicDescription = "BacktEnd Javascript Advanced",
                    CertificateId = 6,
                }
            );
        }
    }
}
