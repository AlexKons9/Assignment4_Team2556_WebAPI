using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4_Team2556_WebAPI.Data.ConfigurationSeed
{
    public class ExamQuestionsSeed : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.HasData
            (
                 //Exam 1 Questions (certificate JavaFound):
                 new ExamQuestion()
                 {
                     QuestionId = 1,
                     ExamId = 1
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 2,
                     ExamId = 1
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 3,
                     ExamId = 1
                 },

                 //Exam 2 Questions (certificate JavaFound):
                 new ExamQuestion()
                 {
                     QuestionId = 4,
                     ExamId = 2
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 5,
                     ExamId = 2
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 6,
                     ExamId = 2
                 },

                 //Exam 3 Questions (certificate JavaAdv):
                 new ExamQuestion()
                 {
                     QuestionId = 7,
                     ExamId = 3
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 8,
                     ExamId = 3
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 9,
                     ExamId = 3
                 },

                 //Exam 4 Questions (certificate JavaAdv):
                 new ExamQuestion()
                 {
                     QuestionId = 10,
                     ExamId = 4
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 11,
                     ExamId = 4
                 },
                 new ExamQuestion()
                 {
                     QuestionId = 12,
                     ExamId = 4
                 }
             );
        }
    }
}
