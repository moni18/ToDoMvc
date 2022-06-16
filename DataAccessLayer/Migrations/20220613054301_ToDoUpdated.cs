using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ToDoUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ToDos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "ToDos",
                newName: "Complete");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ToDos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Complete",
                table: "ToDos",
                newName: "Completed");
        }
    }
}
