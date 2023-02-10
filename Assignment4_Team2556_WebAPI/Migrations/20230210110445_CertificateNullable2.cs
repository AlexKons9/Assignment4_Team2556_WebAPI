using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CertificateNullable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ac2bb98-cd58-4e18-9908-fd5f4f2b9095");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "766b0dfb-5ea9-43ae-973c-cfcf0b6047b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84c28756-fe3b-44ed-8c8b-0816b643a649");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8f13b83-ee27-4073-863f-47c13280e5c8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "278e4ebc-138d-4e64-87b5-03028978671b", "24cbb55e-c2f0-4f82-bee7-f44abc97b868", "Admin", "ADMIN" },
                    { "447d5a24-9581-408d-97ff-eda72e2c7544", "419797c3-a065-4b9c-92f0-fd654794c827", "Marker", "MARKER" },
                    { "57f1d749-1a6f-43ed-9d2a-e998c7d2542c", "67a170da-b05e-4226-b207-efeb0d046d8f", "Candidate", "CANDIDATE" },
                    { "dd120164-f690-4a7d-a7de-9713e17623ed", "7e9dca83-0702-4771-b296-e3430eac095f", "QualityControl", "QUALITYCONTROL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "278e4ebc-138d-4e64-87b5-03028978671b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "447d5a24-9581-408d-97ff-eda72e2c7544");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57f1d749-1a6f-43ed-9d2a-e998c7d2542c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd120164-f690-4a7d-a7de-9713e17623ed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ac2bb98-cd58-4e18-9908-fd5f4f2b9095", "39a63021-e9a1-4182-ac06-91e253b42c4f", "Candidate", "CANDIDATE" },
                    { "766b0dfb-5ea9-43ae-973c-cfcf0b6047b8", "e618255c-113a-4eeb-9bbc-6521d96d1e1a", "Admin", "ADMIN" },
                    { "84c28756-fe3b-44ed-8c8b-0816b643a649", "e6d60bbe-25ba-4f7b-8a51-a842339fc162", "QualityControl", "QUALITYCONTROL" },
                    { "b8f13b83-ee27-4073-863f-47c13280e5c8", "f40a1a4f-c34e-405f-886b-9cb2ce0ed2ff", "Marker", "MARKER" }
                });
        }
    }
}
