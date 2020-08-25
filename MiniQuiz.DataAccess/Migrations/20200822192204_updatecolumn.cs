using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniQuiz.DataAccess.Migrations
{
    public partial class updatecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectOptionId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CorrectOption",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectOption",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CorrectOptionId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
