using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalBankManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[] { 1, "Ahmed@ban.com", "Ahmed Mohamed", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123456789 });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "ManagerId", "Name", "PhoneNumber" },
                values: new object[] { "CAI-01", "Cairo, Egypt", 1, "Cairo Main Branch", 123456789 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "CAI-01");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
