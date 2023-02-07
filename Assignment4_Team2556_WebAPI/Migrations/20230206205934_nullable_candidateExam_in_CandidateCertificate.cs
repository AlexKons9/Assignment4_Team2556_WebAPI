using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class nullablecandidateExaminCandidateCertificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f148665-7264-4ea4-9e90-e872b82ff9a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c127076-f857-4267-a652-b4ba56ec0771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8047cb33-6853-4329-a39d-4e27c801d7eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0567604-6f12-438d-8c18-8f728d36cbe1");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f148665-7264-4ea4-9e90-e872b82ff9a3", "fdda5bcb-8424-4942-9aec-dcd335094d02", "Candidate", "CANDIDATE" },
                    { "6c127076-f857-4267-a652-b4ba56ec0771", "9f2ea4e7-7ff7-414b-8dda-c8efa76d22cd", "Admin", "ADMIN" },
                    { "8047cb33-6853-4329-a39d-4e27c801d7eb", "f4385bac-bab7-43e6-8831-b91f0d515110", "QualityControl", "QUALITYCONTROL" },
                    { "a0567604-6f12-438d-8c18-8f728d36cbe1", "7819fabb-fcbe-4a8a-a7fe-423c7a8bfcef", "Marker", "MARKER" }
                });
        }
    }
}
