using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Income_Service.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 28, 11, 22, 28, 819, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 28, 11, 22, 28, 819, DateTimeKind.Local).AddTicks(9131));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 26, 18, 42, 21, 89, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 26, 18, 42, 21, 89, DateTimeKind.Local).AddTicks(3093));
        }
    }
}
