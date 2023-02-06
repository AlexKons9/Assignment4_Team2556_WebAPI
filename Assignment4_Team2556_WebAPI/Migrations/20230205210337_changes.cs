using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
