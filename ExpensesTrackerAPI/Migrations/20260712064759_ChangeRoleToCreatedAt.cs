using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoleToCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.RenameColumn(
            //     name: "Role",
            //     table: "Users",
            //     newName: "CreatedAt");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users"
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                nullable: false,
                defaultValue: DateTime.UtcNow
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.RenameColumn(
            //     name: "CreatedAt",
            //     table: "Users",
            //     newName: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users"
            );

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                defaultValue: ""
            );
        }
    }
}
