using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class campaignupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Campaign_CampagneId",
                table: "JobApplication");

            migrationBuilder.RenameColumn(
                name: "CampagneId",
                table: "JobApplication",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_CampagneId",
                table: "JobApplication",
                newName: "IX_JobApplication_CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Campaign_CampaignId",
                table: "JobApplication",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Campaign_CampaignId",
                table: "JobApplication");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "JobApplication",
                newName: "CampagneId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_CampaignId",
                table: "JobApplication",
                newName: "IX_JobApplication_CampagneId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Campaign_CampagneId",
                table: "JobApplication",
                column: "CampagneId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
