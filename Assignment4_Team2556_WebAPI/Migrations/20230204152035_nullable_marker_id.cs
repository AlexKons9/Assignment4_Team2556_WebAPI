using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class nullablemarkerid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_AspNetUsers_UserId",
                table: "CandidateExams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a07531f-1529-44dc-a840-936c72119e68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cefac68-9001-4a5c-855d-67490c22af99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6e821ba-e927-4089-be4e-47ed8694466d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee327d01-8107-4f50-a9ba-04cc30ed0e06");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CandidateExams",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateExams_UserId",
                table: "CandidateExams",
                newName: "IX_CandidateExams_CandidateId");

            migrationBuilder.AddColumn<bool>(
                name: "IsMarked",
                table: "CandidateExams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MarkerId",
                table: "CandidateExams",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_MarkerId",
                table: "CandidateExams",
                column: "MarkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_AspNetUsers_CandidateId",
                table: "CandidateExams",
                column: "CandidateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_AspNetUsers_MarkerId",
                table: "CandidateExams",
                column: "MarkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_AspNetUsers_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_AspNetUsers_MarkerId",
                table: "CandidateExams");

            migrationBuilder.DropIndex(
                name: "IX_CandidateExams_MarkerId",
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

            migrationBuilder.DropColumn(
                name: "IsMarked",
                table: "CandidateExams");

            migrationBuilder.DropColumn(
                name: "MarkerId",
                table: "CandidateExams");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "CandidateExams",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams",
                newName: "IX_CandidateExams_UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a07531f-1529-44dc-a840-936c72119e68", "4a5da0aa-f5d7-4543-a863-e7407acc90f3", "Candidate", "CANDIDATE" },
                    { "8cefac68-9001-4a5c-855d-67490c22af99", "4b301a81-2e1f-406f-b871-c75f307aef5f", "QualityControl", "QUALITYCONTROL" },
                    { "c6e821ba-e927-4089-be4e-47ed8694466d", "b347750c-8cc6-4526-b73d-ce79be698f78", "Admin", "ADMIN" },
                    { "ee327d01-8107-4f50-a9ba-04cc30ed0e06", "ad8b3a95-0e96-4ad5-ba4e-36b04b97b7ee", "Marker", "MARKER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_AspNetUsers_UserId",
                table: "CandidateExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
