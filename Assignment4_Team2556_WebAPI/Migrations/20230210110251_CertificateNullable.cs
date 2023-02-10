using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CertificateNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fde7b5b-71bf-40e3-b489-e3d8856553f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546890c3-4e11-4692-ad12-22f758ae64f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a50caf-7059-4f73-8030-a6b548b791c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b038c471-5fad-4b9b-97cc-d9d6e08c6e4b");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2fde7b5b-71bf-40e3-b489-e3d8856553f1", "e6d1f485-3f8c-4895-9b19-d027e2735b51", "Marker", "MARKER" },
                    { "546890c3-4e11-4692-ad12-22f758ae64f1", "4e233408-6f1f-477a-bd58-743f091e5e18", "Admin", "ADMIN" },
                    { "95a50caf-7059-4f73-8030-a6b548b791c2", "e69a40b4-d76f-4906-a7b8-590f0395d44a", "QualityControl", "QUALITYCONTROL" },
                    { "b038c471-5fad-4b9b-97cc-d9d6e08c6e4b", "1a83c5d9-b3db-46c1-98ad-b55b4d7ad269", "Candidate", "CANDIDATE" }
                });
        }
    }
}
