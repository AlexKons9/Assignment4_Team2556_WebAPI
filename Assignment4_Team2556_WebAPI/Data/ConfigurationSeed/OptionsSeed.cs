using Assignment4_Team2556_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4_Team2556_WebAPI.Data.ConfigurationSeed
{
    public class OptionsSeed : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasData(

            //ΕΧΑΜ 1 ΅Options (Certificate JavaFound)
                //Question 1 Options:
                new Option()
                {
                    OptionId = 1,
                    QuestionId = 1,
                    Description = "AnswerA_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 2,
                    QuestionId = 1,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 3,
                    QuestionId = 1,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 4,
                    QuestionId = 1,
                    Description = "AnswerD",
                    IsCorrect = false
                },


                //Question 2 Options:
                new Option()
                {
                    OptionId = 5,
                    QuestionId = 2,
                    Description = "AnswerA_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 6,
                    QuestionId = 2,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 7,
                    QuestionId = 2,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 8,
                    QuestionId = 2,
                    Description = "AnswerD",
                    IsCorrect = false
                },


                //Question 3 Options:
                new Option()
                {
                    OptionId = 9,
                    QuestionId = 3,
                    Description = "AnswerA_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 10,
                    QuestionId = 3,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 11,
                    QuestionId = 3,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 12,
                    QuestionId = 3,
                    Description = "AnswerD",
                    IsCorrect = false
                },


            //ΕΧΑΜ 2 ΅Options (Certificate JavaFound)
                //Question 4 Options
                new Option()
                {
                    OptionId = 13,
                    QuestionId = 4,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 14,
                    QuestionId = 4,
                    Description = "AnswerB_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 15,
                    QuestionId = 4,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 16,
                    QuestionId = 4,
                    Description = "AnswerD",
                    IsCorrect = false
                },


                //Question 5 Options:
                new Option()
                {
                    OptionId = 17,
                    QuestionId = 5,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 18,
                    QuestionId = 5,
                    Description = "AnswerB_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 19,
                    QuestionId = 5,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 20,
                    QuestionId = 5,
                    Description = "AnswerD",
                    IsCorrect = false
                },


                //Question 6 Options:
                new Option()
                {
                    OptionId = 21,
                    QuestionId = 6,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 22,
                    QuestionId = 6,
                    Description = "AnswerB_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 23,
                    QuestionId = 6,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 24,
                    QuestionId = 6,
                    Description = "AnswerD",
                    IsCorrect = false
                },


            //ΕΧΑΜ 3 ΅Options (certificate JavaAdv)
            //Question 7 Options
                new Option()
                {
                    OptionId = 25,
                    QuestionId = 7,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 26,
                    QuestionId = 7,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 27,
                    QuestionId = 7,
                    Description = "AnswerC_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 28,
                    QuestionId = 7,
                    Description = "AnswerD",
                    IsCorrect = false
                },


                //Question 8 Options:
                new Option()
                {
                    OptionId = 29,
                    QuestionId = 8,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 30,
                    QuestionId = 8,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 31,
                    QuestionId = 8,
                    Description = "AnswerC_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 32,
                    QuestionId = 8,
                    Description = "AnswerD",
                    IsCorrect = false
                },


                //Question 9 Options:
                new Option()
                {
                    OptionId = 33,
                    QuestionId = 9,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 34,
                    QuestionId = 9,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 35,
                    QuestionId = 9,
                    Description = "AnswerC_T",
                    IsCorrect = true
                },
                new Option()
                {
                    OptionId = 36,
                    QuestionId = 9,
                    Description = "AnswerD",
                    IsCorrect = false
                },

         //ΕΧΑΜ 4 ΅Options (certificate JavaAdv)
                //Question 10 Options
                new Option()
                {
                    OptionId = 37,
                    QuestionId = 10,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 38,
                    QuestionId = 10,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 39,
                    QuestionId = 10,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 40,
                    QuestionId = 10,
                    Description = "AnswerD_T",
                    IsCorrect = true
                },


                //Question 11 Options:
                new Option()
                {
                    OptionId = 41,
                    QuestionId = 11,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 42,
                    QuestionId = 11,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 43,
                    QuestionId = 11,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 44,
                    QuestionId = 11,
                    Description = "AnswerD_T",
                    IsCorrect = true
                },


                //Question 12 Options:
                new Option()
                {
                    OptionId = 45,
                    QuestionId = 12,
                    Description = "AnswerA",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 46,
                    QuestionId = 12,
                    Description = "AnswerB",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 47,
                    QuestionId = 12,
                    Description = "AnswerC",
                    IsCorrect = false
                },
                new Option()
                {
                    OptionId = 48,
                    QuestionId = 12,
                    Description = "AnswerD_T",
                    IsCorrect = true
                }

            );
        }
    }
}
