using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Income_Service.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Catagories_CatagoryId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CatagoryId",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 26, 14, 23, 46, 142, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 26, 14, 23, 46, 142, DateTimeKind.Local).AddTicks(8260));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 26, 14, 10, 26, 45, DateTimeKind.Local).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 26, 14, 10, 26, 45, DateTimeKind.Local).AddTicks(8836));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CatagoryId",
                table: "Transactions",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Catagories_CatagoryId",
                table: "Transactions",
                column: "CatagoryId",
                principalTable: "Catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
