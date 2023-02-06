using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class nullableTopicsinCertificatemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "119d864a-58d2-4d63-8872-714548e7e5b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee5f3f5-a81a-4e7f-b11e-4424e6cd66a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf45f66c-271d-4282-ba82-9fe39093e9c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2d14d1a-1531-42f5-9b72-16e409cbd1c0");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "119d864a-58d2-4d63-8872-714548e7e5b6", "f2bb7135-ef46-4eb2-8fca-603cb2d221dc", "Candidate", "CANDIDATE" },
                    { "6ee5f3f5-a81a-4e7f-b11e-4424e6cd66a7", "3794eca1-5382-451c-a430-656d28c97dce", "Marker", "MARKER" },
                    { "bf45f66c-271d-4282-ba82-9fe39093e9c6", "1fe714c1-0623-4e04-bdb6-9b5191267123", "Admin", "ADMIN" },
                    { "c2d14d1a-1531-42f5-9b72-16e409cbd1c0", "61785f24-2061-496a-ba2b-ba65fe7cac9d", "QualityControl", "QUALITYCONTROL" }
                });
        }
    }
}
