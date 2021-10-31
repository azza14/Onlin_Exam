using Microsoft.EntityFrameworkCore.Migrations;

namespace Onlin_Exam.Migrations
{
    public partial class editTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "CorrectAnswers",
                newName: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "CorrectAnswers",
                newName: "Note");
        }
    }
}
