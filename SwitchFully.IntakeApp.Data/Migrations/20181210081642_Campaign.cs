using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class Campaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<Guid>(nullable: false),
                    CampaignName = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    CampaignStartDate = table.Column<DateTime>(nullable: false),
                    CampaignEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}
