using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense_Service.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 28, 8, 50, 10, 651, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 28, 8, 50, 10, 651, DateTimeKind.Local).AddTicks(8348));
        }
    }
}
