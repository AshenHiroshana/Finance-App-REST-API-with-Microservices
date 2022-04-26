using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Income_Service.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Catagories_CatagoryId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CatagoryId", "Date", "Description" },
                values: new object[] { 1, 100.0, 1, new DateTime(2022, 4, 26, 13, 24, 2, 980, DateTimeKind.Local).AddTicks(7515), "a" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CatagoryId", "Date", "Description" },
                values: new object[] { 2, 100.0, 2, new DateTime(2022, 4, 26, 13, 24, 2, 980, DateTimeKind.Local).AddTicks(7531), "a" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Catagories_CatagoryId",
                table: "Transactions",
                column: "CatagoryId",
                principalTable: "Catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Catagories_CatagoryId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Catagories_CatagoryId",
                table: "Transactions",
                column: "CatagoryId",
                principalTable: "Catagories",
                principalColumn: "Id");
        }
    }
}
