using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense_Service.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CatagoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "Home", "Home" },
                    { 2, "Car", "Car" },
                    { 3, "Travel", "Travel" },
                    { 4, "Food", "Food" },
                    { 5, "TshirtCrewOutline", "Clothes" },
                    { 6, "Pill", "Medicine" },
                    { 7, "FuelPump", "Fuel" },
                    { 8, "BabyFaceOutline", "Baby" },
                    { 9, "QuestionMark", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CatagoryId", "Date", "Description" },
                values: new object[,]
                {
                    { 1, 100.0, 1, new DateTime(2022, 4, 28, 8, 5, 16, 398, DateTimeKind.Local).AddTicks(7110), "a" },
                    { 2, 100.0, 2, new DateTime(2022, 4, 28, 8, 5, 16, 398, DateTimeKind.Local).AddTicks(7127), "a" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catagories_Name",
                table: "Catagories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catagories");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
