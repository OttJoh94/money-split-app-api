using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvenlyAPI.Migrations
{
    /// <inheritdoc />
    public partial class addDeleteBehaviors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserGroups_user_id_group_id",
                table: "Expenses");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserGroups_user_id_group_id",
                table: "Expenses",
                columns: new[] { "user_id", "group_id" },
                principalTable: "UserGroups",
                principalColumns: new[] { "user_id", "group_id" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_UserGroups_user_id_group_id",
                table: "Expenses");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_UserGroups_user_id_group_id",
                table: "Expenses",
                columns: new[] { "user_id", "group_id" },
                principalTable: "UserGroups",
                principalColumns: new[] { "user_id", "group_id" });
        }
    }
}
