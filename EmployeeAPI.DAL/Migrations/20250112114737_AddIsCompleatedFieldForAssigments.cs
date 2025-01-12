using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCompleatedFieldForAssigments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Assignments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Assignments");
        }
    }
}
