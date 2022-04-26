using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Income_Service.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 26, 18, 35, 24, 782, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 26, 18, 35, 24, 782, DateTimeKind.Local).AddTicks(1913));
        }
    }
}
