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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatagoryId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Catagories_CatagoryId",
                        column: x => x.CatagoryId,
                        principalTable: "Catagories",
                        principalColumn: "Id");
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
