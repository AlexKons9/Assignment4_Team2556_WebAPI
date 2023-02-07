using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedcanddiateExamIDtocandidateCertificatemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_CandidateExams_CandidateExamId",
                table: "CandidateCertificates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "015b75f0-ae2a-4fcc-b8a9-5c0101cd8b4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28c7956e-6407-483b-a1cf-9f2a7b5e1ed9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d94cf47-8be5-4646-b159-50dfc5d39516");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb25212-1ccb-4038-936d-d44eb0534d68");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateExamId",
                table: "CandidateCertificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b8ec9b9-80b8-440b-8c86-969cd0d253c6", "f9818f07-fbc1-4d0c-a4e8-415749d98265", "Marker", "MARKER" },
                    { "6a906e68-884f-4397-ac41-2400c0db9da4", "bee7a846-257f-4d4e-a620-104486ef525f", "Candidate", "CANDIDATE" },
                    { "bfb1a9d4-49b7-41ae-9f24-5a2b5f8b3dec", "84b6c356-bbe9-4ac3-b627-8c564dc18dbe", "QualityControl", "QUALITYCONTROL" },
                    { "f3845112-721f-4e2f-90e6-d8eb6265770f", "40a69613-5e26-4d5e-8506-0ddb76c2ffe1", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_CandidateExams_CandidateExamId",
                table: "CandidateCertificates",
                column: "CandidateExamId",
                principalTable: "CandidateExams",
                principalColumn: "CandidateExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_CandidateExams_CandidateExamId",
                table: "CandidateCertificates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b8ec9b9-80b8-440b-8c86-969cd0d253c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a906e68-884f-4397-ac41-2400c0db9da4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfb1a9d4-49b7-41ae-9f24-5a2b5f8b3dec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3845112-721f-4e2f-90e6-d8eb6265770f");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateExamId",
                table: "CandidateCertificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "015b75f0-ae2a-4fcc-b8a9-5c0101cd8b4d", "bbcd54a1-1edd-4409-bf22-522f4b629677", "Marker", "MARKER" },
                    { "28c7956e-6407-483b-a1cf-9f2a7b5e1ed9", "77ab8212-d546-4407-837c-8b65440d43c5", "Admin", "ADMIN" },
                    { "3d94cf47-8be5-4646-b159-50dfc5d39516", "ff4a1f08-b9fa-44f4-8318-5b83101fdc92", "Candidate", "CANDIDATE" },
                    { "9bb25212-1ccb-4038-936d-d44eb0534d68", "63edcfe9-8589-46ef-832c-4921d8beec9b", "QualityControl", "QUALITYCONTROL" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_CandidateExams_CandidateExamId",
                table: "CandidateCertificates",
                column: "CandidateExamId",
                principalTable: "CandidateExams",
                principalColumn: "CandidateExamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
