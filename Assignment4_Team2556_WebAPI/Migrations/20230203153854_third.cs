using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_AspNetUsers_UserId1",
                table: "CandidateExams");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_UserId1",
                table: "CandidateExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a1da1ac-8a83-4b97-8d88-f1a4dbdb61cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d15e1ce-07bb-4c2c-8d3f-79e23e72b7bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fb9c0e1-727a-49b1-b16a-da86d5ea0d29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cca6788d-fd12-46bf-b5dd-ed1af91ef6dd");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CandidateExams");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02406a2b-2643-4525-88aa-95e64255210c", "67a5054e-30f3-4656-ac79-628a5605004a", "Candidate", "CANDIDATE" },
                    { "46a031a9-b93f-484c-9e94-6e97090aad00", "d0e5f658-4ab8-4923-b2d6-c6fb031e4775", "Admin", "ADMIN" },
                    { "83e680c6-9791-4041-8f4a-2961cc0fad7a", "491862b5-2d1d-4adf-9749-41fce033ff41", "Marker", "MARKER" },
                    { "fec39825-185c-47c7-a1b7-083ef29b36b3", "b62188a1-1443-4dce-9338-6cd0fc980745", "QualityControl", "QUALITYCONTROL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_UserId",
                table: "CandidateExams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_AspNetUsers_UserId",
                table: "CandidateExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_AspNetUsers_UserId",
                table: "CandidateExams");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_UserId",
                table: "CandidateExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02406a2b-2643-4525-88aa-95e64255210c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46a031a9-b93f-484c-9e94-6e97090aad00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83e680c6-9791-4041-8f4a-2961cc0fad7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec39825-185c-47c7-a1b7-083ef29b36b3");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CandidateExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a1da1ac-8a83-4b97-8d88-f1a4dbdb61cd", "3eb6de33-75a6-4ac0-9716-bc64e3e71c78", "QualityControl", "QUALITYCONTROL" },
                    { "6d15e1ce-07bb-4c2c-8d3f-79e23e72b7bb", "e6c6b9b3-3139-4d43-9761-72352c95e6a0", "Admin", "ADMIN" },
                    { "8fb9c0e1-727a-49b1-b16a-da86d5ea0d29", "be4f0933-ff31-4ac4-9e52-2817fc350ed0", "Marker", "MARKER" },
                    { "cca6788d-fd12-46bf-b5dd-ed1af91ef6dd", "a513d3eb-fcf5-4f0a-a45b-dbcf87d92d2a", "Candidate", "CANDIDATE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_UserId1",
                table: "CandidateExams",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_AspNetUsers_UserId1",
                table: "CandidateExams",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
