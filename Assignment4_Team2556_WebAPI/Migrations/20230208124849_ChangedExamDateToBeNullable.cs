using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment4Team2556WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedExamDateToBeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe10528-252e-4205-8247-5d9dd251bb98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0bb4cea-b320-457a-8743-01f2ab1ebea9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2bb237b-2d60-4d92-a0f9-2ee7ad4a6f45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db049375-5ce8-4bdc-b6b0-417769539105");

            migrationBuilder.DropColumn(
                name: "ExaminationDate",
                table: "CandidateExams");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExamDate",
                table: "CandidateExams",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3101f456-720d-4498-9a98-9c3ce0255da3", "bca91029-288d-47ed-8e8c-67d644c90d47", "QualityControl", "QUALITYCONTROL" },
                    { "425d036f-8ef8-4ed0-9ceb-451106e4fec7", "667ce886-9c34-4117-958f-4f81622f76e5", "Admin", "ADMIN" },
                    { "6eff0976-b264-407b-bee9-c94db3520392", "e13681f8-3e3c-48bc-9aba-172f0605f17c", "Candidate", "CANDIDATE" },
                    { "a77caa9d-d0e3-409e-a542-554eefbafe1a", "0c6347fa-4887-4513-9fc8-9c45fdedb49c", "Marker", "MARKER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3101f456-720d-4498-9a98-9c3ce0255da3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "425d036f-8ef8-4ed0-9ceb-451106e4fec7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eff0976-b264-407b-bee9-c94db3520392");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a77caa9d-d0e3-409e-a542-554eefbafe1a");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExamDate",
                table: "CandidateExams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExaminationDate",
                table: "CandidateExams",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe10528-252e-4205-8247-5d9dd251bb98", "2fec73b6-edb1-43a0-8ced-af7fd1c5c26d", "QualityControl", "QUALITYCONTROL" },
                    { "a0bb4cea-b320-457a-8743-01f2ab1ebea9", "5606c772-1ea1-499d-aa31-e859848ecb1c", "Marker", "MARKER" },
                    { "c2bb237b-2d60-4d92-a0f9-2ee7ad4a6f45", "85a5076c-fa68-47e5-a057-1ad7d4f57ab0", "Candidate", "CANDIDATE" },
                    { "db049375-5ce8-4bdc-b6b0-417769539105", "7294a98a-8daa-4ae7-a8ca-3caeacb8ec7d", "Admin", "ADMIN" }
                });
        }
    }
}
