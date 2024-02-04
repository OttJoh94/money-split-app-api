using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvenlyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "expense_id", "amount", "date_of_expense", "description", "group_id", "user_id" },
                values: new object[] { 1, 200m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded expense", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "expense_id",
                keyValue: 1);
        }
    }
}
