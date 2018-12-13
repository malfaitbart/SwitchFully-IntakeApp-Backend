using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class fileuploads_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");
        }
    }
}
