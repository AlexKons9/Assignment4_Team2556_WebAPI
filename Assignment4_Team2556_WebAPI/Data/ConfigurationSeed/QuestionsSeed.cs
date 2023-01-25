using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4_Team2556_WebAPI.Data.ConfigurationSeed
{
    public class QuestionsSeed : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData
            (
                //For ExamId 1 - certificate JavaFound
                new Question()
                {
                    QuestionId = 1,
                    DescriptionStem = "lorem1",
                    TopicId = 1, //FrontEnd Java Foundation
                },
                new Question()
                {
                    QuestionId = 2,
                    DescriptionStem = "lorem2",
                    TopicId = 1, //FrontEnd Java Foundation
                },
                new Question()
                {
                    QuestionId = 3,
                    DescriptionStem = "lorem3",
                    TopicId = 2, //BackEnd Java Foundation
                },


                //For ExamId 2  - certificate JavaFound
                new Question()
                {
                    QuestionId = 4,
                    DescriptionStem = "lorem4",
                    TopicId = 1, //FrontEnd Java Foundation
                },
                new Question()
                {
                    QuestionId = 5,
                    DescriptionStem = "lorem5",
                    TopicId = 2, //BackEnd Java Foundation
                },
                new Question()
                {
                    QuestionId = 6,
                    DescriptionStem = "lorem6",
                    TopicId = 2, //BackEnd Java Foundation
                },


                //For ExamId 3  - certificate JavaAdv
                new Question()
                {
                    QuestionId = 7,
                    DescriptionStem = "lorem",
                    TopicId = 3, //FrontEnd Java Advanced
                },
                new Question()
                {
                    QuestionId = 8,
                    DescriptionStem = "lorem",
                    TopicId = 3, //FrontEnd Java Advanced
                },
                new Question()
                {
                    QuestionId = 9,
                    DescriptionStem = "lorem",
                    TopicId = 4, //BackEnd Java Advanced
                },


                //For ExamId 4  - certificate JavaAdv
                new Question()
                {
                    QuestionId = 10,
                    DescriptionStem = "lorem",
                    TopicId = 3, //FrontEnd Java Advanced
                },
                new Question()
                {
                    QuestionId = 11,
                    DescriptionStem = "lorem",
                    TopicId = 4, //BackEnd Java Advanced
                },
                new Question()
                {
                    QuestionId = 12,
                    DescriptionStem = "lorem",
                    TopicId = 4, //BackEnd Java Advanced
                }
            );
        }
    }
}
