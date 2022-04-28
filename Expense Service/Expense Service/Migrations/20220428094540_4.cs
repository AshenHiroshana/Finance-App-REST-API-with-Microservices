using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense_Service.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 28, 15, 15, 40, 361, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 28, 15, 15, 40, 361, DateTimeKind.Local).AddTicks(5680));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 28, 9, 3, 55, 728, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 28, 9, 3, 55, 728, DateTimeKind.Local).AddTicks(7779));
        }
    }
}
