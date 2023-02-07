using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class nullablecandidateIdfieldforcandidateExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_AspNetUsers_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "199a6818-4a71-45b3-84a6-1794442a0d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e2886f1-f974-4b2d-9f00-2a91902bf014");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86544e76-407e-4430-a76c-edbeae357b12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e796101c-78bb-47f7-a821-90429b8c6e1f");

            migrationBuilder.AlterColumn<string>(
                name: "CandidateId",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1196b0cd-6103-4074-a2d9-b4674a7c2f53", "aa8a4a69-c635-4251-8d65-015b52e53afb", "QualityControl", "QUALITYCONTROL" },
                    { "434f783a-43ac-4580-bb80-8ea1c7b680cb", "52068be5-e013-4144-9601-a885b1c46edf", "Marker", "MARKER" },
                    { "4a1ee3ce-417f-48ef-8b02-1c1d7de22d6b", "42487519-7a97-47c7-b921-c94e730ffd7d", "Admin", "ADMIN" },
                    { "77c3cd60-c381-4cd3-a508-5f959e4455ab", "38e733ab-9374-4512-86d7-28ea697834e5", "Candidate", "CANDIDATE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_AspNetUsers_CandidateId",
                table: "CandidateExams",
                column: "CandidateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_AspNetUsers_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1196b0cd-6103-4074-a2d9-b4674a7c2f53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "434f783a-43ac-4580-bb80-8ea1c7b680cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a1ee3ce-417f-48ef-8b02-1c1d7de22d6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77c3cd60-c381-4cd3-a508-5f959e4455ab");

            migrationBuilder.AlterColumn<string>(
                name: "CandidateId",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "199a6818-4a71-45b3-84a6-1794442a0d05", "b8ca72ad-e035-4d43-83fd-e983d57ccca8", "Candidate", "CANDIDATE" },
                    { "4e2886f1-f974-4b2d-9f00-2a91902bf014", "6c160b08-eb1d-4a33-b0c7-7b29e603267b", "Marker", "MARKER" },
                    { "86544e76-407e-4430-a76c-edbeae357b12", "fdf3cd9b-a935-48db-b3bc-070ccc7b4a55", "QualityControl", "QUALITYCONTROL" },
                    { "e796101c-78bb-47f7-a821-90429b8c6e1f", "b1a8302d-f118-4c71-b32f-af9c879cf7c9", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_AspNetUsers_CandidateId",
                table: "CandidateExams",
                column: "CandidateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
