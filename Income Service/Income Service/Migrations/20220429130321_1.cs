using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Income_Service.Migrations
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
                    table.ForeignKey(
                        name: "FK_Transactions_Catagories_CatagoryId",
                        column: x => x.CatagoryId,
                        principalTable: "Catagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 1, "Home", "Home" });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 2, "Dollar", "Salary" });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 3, "QuestionMark", "Other" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CatagoryId", "Date", "Description" },
                values: new object[] { 1, 100.0, 1, new DateTime(2022, 4, 29, 18, 33, 21, 222, DateTimeKind.Local).AddTicks(9532), "a" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CatagoryId", "Date", "Description" },
                values: new object[] { 2, 100.0, 2, new DateTime(2022, 4, 29, 18, 33, 21, 222, DateTimeKind.Local).AddTicks(9544), "a" });

            migrationBuilder.CreateIndex(
                name: "IX_Catagories_Name",
                table: "Catagories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CatagoryId",
                table: "Transactions",
                column: "CatagoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Catagories");
        }
    }
}
