using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedvoucherclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29c468e6-283f-4f7a-9d08-888606379736");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e62bc99-6d9a-4caf-beb2-9002ca2c9b4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6ff4524-be9d-41eb-a89e-d95b14983934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f666b326-3895-40ef-bf19-8c504a342406");

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11edd595-dcf1-4aa7-94c5-a033aa6aa437", "71658370-38e9-426c-bf31-b6e8770f2f74", "Candidate", "CANDIDATE" },
                    { "44b51ecb-3959-4fed-9c7c-3643d5321013", "e214521d-d010-4772-9c36-94c285d54639", "QualityControl", "QUALITYCONTROL" },
                    { "452ac734-75ba-41a6-bec2-8c71b00719f6", "260db818-81f3-44c5-951b-fb41f1bbeb2e", "Marker", "MARKER" },
                    { "85698a56-6b69-4608-a467-61fd46c4603a", "93bf58a3-5720-4d3a-a356-aa2b413cc3cf", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11edd595-dcf1-4aa7-94c5-a033aa6aa437");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b51ecb-3959-4fed-9c7c-3643d5321013");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "452ac734-75ba-41a6-bec2-8c71b00719f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85698a56-6b69-4608-a467-61fd46c4603a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29c468e6-283f-4f7a-9d08-888606379736", "4f3655c7-3d36-4552-8da7-7fca8899dd0f", "Candidate", "CANDIDATE" },
                    { "4e62bc99-6d9a-4caf-beb2-9002ca2c9b4e", "a22a99bf-e27b-4568-915b-cca5100e9c92", "QualityControl", "QUALITYCONTROL" },
                    { "d6ff4524-be9d-41eb-a89e-d95b14983934", "7d3650f4-5ec3-4f0f-8059-6fad1532d144", "Admin", "ADMIN" },
                    { "f666b326-3895-40ef-bf19-8c504a342406", "058f21ef-4fed-40db-83d5-750a63b47835", "Marker", "MARKER" }
                });
        }
    }
}
