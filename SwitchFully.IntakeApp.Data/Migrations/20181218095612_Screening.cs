using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class Screening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("370f5ea9-7c14-43a4-9a2c-6d8d33813145"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("5b2a9f6a-fd3c-44e3-8fc7-67f4d7480ac5"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("8250cd92-912b-43a2-9e76-10e0299d4ce8"));

            migrationBuilder.CreateTable(
                name: "Screening",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    JobApplicationId = table.Column<Guid>(nullable: false),
                    AuditUser = table.Column<string>(nullable: true),
                    AuditDateTime = table.Column<DateTime>(nullable: false),
                    screeningType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screening", x => new { x.JobApplicationId, x.Name });
                    table.ForeignKey(
                        name: "FK_Screening_JobApplication_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("26a7ca9f-fd6a-4df2-aa88-73af115a6858"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("6a2eafae-ae2a-4fb5-a996-80fdfc594d96"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("f231efda-6e7d-4d0c-86da-7cb5ec4fffcb"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("26a7ca9f-fd6a-4df2-aa88-73af115a6858"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("6a2eafae-ae2a-4fb5-a996-80fdfc594d96"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("f231efda-6e7d-4d0c-86da-7cb5ec4fffcb"));

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("370f5ea9-7c14-43a4-9a2c-6d8d33813145"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("8250cd92-912b-43a2-9e76-10e0299d4ce8"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("5b2a9f6a-fd3c-44e3-8fc7-67f4d7480ac5"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
