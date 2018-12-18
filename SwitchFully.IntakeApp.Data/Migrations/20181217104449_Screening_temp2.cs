using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class Screening_temp2 : Migration
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
                    screeningType = table.Column<int>(nullable: false)
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
                values: new object[] { new Guid("b985840f-5e7c-48fa-95cc-f4f950639935"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("4e398d45-7dfc-4e5c-9f0e-16e3a2a4342c"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("6806bf2a-5991-461b-82ca-646ab19d9d5f"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("4e398d45-7dfc-4e5c-9f0e-16e3a2a4342c"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("6806bf2a-5991-461b-82ca-646ab19d9d5f"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("b985840f-5e7c-48fa-95cc-f4f950639935"));

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
