using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EvenlyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false),
                    balance = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.user_id, x.group_id });
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_group_id",
                        column: x => x.group_id,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    expense_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    date_of_expense = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.expense_id);
                    table.ForeignKey(
                        name: "FK_Expenses_UserGroups_user_id_group_id",
                        columns: x => new { x.user_id, x.group_id },
                        principalTable: "UserGroups",
                        principalColumns: new[] { "user_id", "group_id" });
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "group_id", "group_name" },
                values: new object[,]
                {
                    { 1, "Simrishamnsgatan" },
                    { 2, "Familjen Johansson" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "name" },
                values: new object[,]
                {
                    { 1, "Otto" },
                    { 2, "Hilda" },
                    { 3, "Eva" },
                    { 4, "Sören" }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "group_id", "user_id", "balance" },
                values: new object[,]
                {
                    { 1, 1, 0m },
                    { 2, 1, 0m },
                    { 1, 2, 0m },
                    { 2, 3, 0m },
                    { 2, 4, 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_user_id_group_id",
                table: "Expenses",
                columns: new[] { "user_id", "group_id" });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_group_id",
                table: "UserGroups",
                column: "group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
