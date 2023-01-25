using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NativeLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoIdType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfResidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandlineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateId = table.Column<int>(type: "int", nullable: false),
                    MaximumScore = table.Column<int>(type: "int", nullable: false),
                    PassMark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExams",
                columns: table => new
                {
                    CandidateExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssessmentTestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScoreReportDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExamScore = table.Column<int>(type: "int", nullable: true),
                    PercentageScore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfAwardedMarks = table.Column<int>(type: "int", nullable: true),
                    NumberOfPossibleMakrs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExams", x => x.CandidateExamId);
                    table.ForeignKey(
                        name: "FK_CandidateExams_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionStem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId");
                });

            migrationBuilder.CreateTable(
                name: "CandidateCertificates",
                columns: table => new
                {
                    CandidateCertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCertificates", x => x.CandidateCertificateId);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_CandidateExams_CandidateExamId",
                        column: x => x.CandidateExamId,
                        principalTable: "CandidateExams",
                        principalColumn: "CandidateExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => new { x.QuestionId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExamAnswers",
                columns: table => new
                {
                    CandidateExamAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateExamId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExamAnswers", x => x.CandidateExamAnswerId);
                    table.ForeignKey(
                        name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                        column: x => x.CandidateExamId,
                        principalTable: "CandidateExams",
                        principalColumn: "CandidateExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateExamAnswers_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CandidateId", "AddressLine", "AddressLine2", "BirthDate", "City", "CountryOfResidence", "Email", "FirstName", "Gender", "LandlineNumber", "LastName", "MiddleName", "MobileNumber", "NativeLanguage", "PhotoIdNumber", "PhotoIdType", "PhotoIssueDate", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "Korai 5", "2nd Floor", new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Athens", "Greece", "alex@alex.com", "Alexandros", "Male", "+302109090999", "Lepeniotis", "Nikolaos", "+306912345678", "Greek", "AA 123456", "National Id", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345", "Attiki" },
                    { 2, "Axeloou 7", "Ground Floor", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalamaria", "Greece", "mpa@mpampis.com", "Mpampis", "Male", "+30231009090", "Papadimitriou", null, "+306912345678", "Greek", "AB 999999", "National Id", new DateTime(2015, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345", "Thessaloniki" },
                    { 3, "Pentelis 2", "4th Floor", new DateTime(1980, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Athens", "Greece", "kostas@kostopoulos.com", "Kostas", "Male", "+302108888888", "Kostopoulos", null, "+306945454545", "Greek", "AH 111111", "National Id", new DateTime(2015, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "54321", "Attiki" },
                    { 4, "Markou Mpotsari 67", "1st Floor", new DateTime(1972, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Athens", "Greece", "maria-eleni@papadopoulou.com", "Maria", "Female", "+3021000000", "Papadopoulou", "Eleni", "+306989898809", "Greek", "AHQ4567FG", "Passport", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "23456", "Attiki" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "CertificateId", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, true, "Java Foundation" },
                    { 2, true, "Java Advanced" },
                    { 3, false, "C# Foundation" },
                    { 4, false, "C# Advanced" },
                    { 5, false, "Javascript Foundation" },
                    { 6, false, "Javascript Advanced" },
                    { 7, false, "C++" }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "CertificateId", "MaximumScore", "PassMark" },
                values: new object[,]
                {
                    { 1, 1, 3, 2 },
                    { 2, 1, 3, 2 },
                    { 3, 2, 3, 2 },
                    { 4, 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "CertificateId", "TopicDescription" },
                values: new object[,]
                {
                    { 1, 1, "FrontEnd Java Foundation" },
                    { 2, 1, "BackEnd Java Foundation" },
                    { 3, 2, "FrontEnd Java Advanced" },
                    { 4, 2, "BackEnd Java Advanced" },
                    { 5, 3, "FrontEnd C# Foundation" },
                    { 6, 3, "BackEnd C# Foundation" },
                    { 7, 4, "FrontEnd C# Advanced" },
                    { 8, 4, "BacktEnd C# Advanced" },
                    { 9, 5, "FrontEnd Javascript Foundation" },
                    { 10, 5, "BackEnd Javascript Foundation" },
                    { 11, 6, "FrontEnd Javascript Advanced" },
                    { 12, 6, "BacktEnd Javascript Advanced" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "DescriptionStem", "TopicId" },
                values: new object[,]
                {
                    { 1, "lorem1", 1 },
                    { 2, "lorem2", 1 },
                    { 3, "lorem3", 2 },
                    { 4, "lorem4", 1 },
                    { 5, "lorem5", 2 },
                    { 6, "lorem6", 2 },
                    { 7, "lorem", 3 },
                    { 8, "lorem", 3 },
                    { 9, "lorem", 4 },
                    { 10, "lorem", 3 },
                    { 11, "lorem", 4 },
                    { 12, "lorem", 4 }
                });

            migrationBuilder.InsertData(
                table: "ExamQuestions",
                columns: new[] { "ExamId", "QuestionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "Description", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "AnswerA_T", true, 1 },
                    { 2, "AnswerB", false, 1 },
                    { 3, "AnswerC", false, 1 },
                    { 4, "AnswerD", false, 1 },
                    { 5, "AnswerA_T", true, 2 },
                    { 6, "AnswerB", false, 2 },
                    { 7, "AnswerC", false, 2 },
                    { 8, "AnswerD", false, 2 },
                    { 9, "AnswerA_T", true, 3 },
                    { 10, "AnswerB", false, 3 },
                    { 11, "AnswerC", false, 3 },
                    { 12, "AnswerD", false, 3 },
                    { 13, "AnswerA", false, 4 },
                    { 14, "AnswerB_T", true, 4 },
                    { 15, "AnswerC", false, 4 },
                    { 16, "AnswerD", false, 4 },
                    { 17, "AnswerA", false, 5 },
                    { 18, "AnswerB_T", true, 5 },
                    { 19, "AnswerC", false, 5 },
                    { 20, "AnswerD", false, 5 },
                    { 21, "AnswerA", false, 6 },
                    { 22, "AnswerB_T", true, 6 },
                    { 23, "AnswerC", false, 6 },
                    { 24, "AnswerD", false, 6 },
                    { 25, "AnswerA", false, 7 },
                    { 26, "AnswerB", false, 7 },
                    { 27, "AnswerC_T", true, 7 },
                    { 28, "AnswerD", false, 7 },
                    { 29, "AnswerA", false, 8 },
                    { 30, "AnswerB", false, 8 },
                    { 31, "AnswerC_T", true, 8 },
                    { 32, "AnswerD", false, 8 },
                    { 33, "AnswerA", false, 9 },
                    { 34, "AnswerB", false, 9 },
                    { 35, "AnswerC_T", true, 9 },
                    { 36, "AnswerD", false, 9 },
                    { 37, "AnswerA", false, 10 },
                    { 38, "AnswerB", false, 10 },
                    { 39, "AnswerC", false, 10 },
                    { 40, "AnswerD_T", true, 10 },
                    { 41, "AnswerA", false, 11 },
                    { 42, "AnswerB", false, 11 },
                    { 43, "AnswerC", false, 11 },
                    { 44, "AnswerD_T", true, 11 },
                    { 45, "AnswerA", false, 12 },
                    { 46, "AnswerB", false, 12 },
                    { 47, "AnswerC", false, 12 },
                    { 48, "AnswerD_T", true, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CandidateExamId",
                table: "CandidateCertificates",
                column: "CandidateExamId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExamAnswers_CandidateExamId",
                table: "CandidateExamAnswers",
                column: "CandidateExamId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExamAnswers_OptionId",
                table: "CandidateExamAnswers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_ExamId",
                table: "CandidateExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "ExamQuestions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CertificateId",
                table: "Exams",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CertificateId",
                table: "Topics",
                column: "CertificateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCertificates");

            migrationBuilder.DropTable(
                name: "CandidateExamAnswers");

            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "CandidateExams");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Certificates");
        }
    }
}
