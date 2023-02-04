using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addnavigationpropertiesvoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "CandidateId",
                table: "Vouchers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_CandidateId",
                table: "Vouchers",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_CertificateId",
                table: "Vouchers",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_AspNetUsers_CandidateId",
                table: "Vouchers",
                column: "CandidateId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Certificates_CertificateId",
                table: "Vouchers",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_AspNetUsers_CandidateId",
                table: "Vouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Certificates_CertificateId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_CandidateId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_CertificateId",
                table: "Vouchers");

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

            migrationBuilder.AlterColumn<string>(
                name: "CandidateId",
                table: "Vouchers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
