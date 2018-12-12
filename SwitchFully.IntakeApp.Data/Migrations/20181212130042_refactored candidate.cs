using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class refactoredcandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Candidates");
        }
    }
}
