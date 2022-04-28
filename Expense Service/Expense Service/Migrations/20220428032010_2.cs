using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense_Service.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 28, 8, 5, 16, 398, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 28, 8, 5, 16, 398, DateTimeKind.Local).AddTicks(7127));
        }
    }
}
