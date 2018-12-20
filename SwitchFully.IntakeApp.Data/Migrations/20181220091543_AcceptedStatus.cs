using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class AcceptedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("18133035-4ed9-4c55-bac5-f94deb24e361"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("64d133e1-754c-4a4e-bb49-10eecbc7a1b8"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("c122c24b-1709-4c45-81d4-33a219f8c687"));

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("62d01e72-b2a0-4ce1-9189-ec297044ea18"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea353991-9832-4e9e-91e8-38ed67432d23"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6067b06-fb42-4e10-b3c5-63fc3d7994a6"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description" },
                values: new object[] { 4, "Accepted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("62d01e72-b2a0-4ce1-9189-ec297044ea18"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("b6067b06-fb42-4e10-b3c5-63fc3d7994a6"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("ea353991-9832-4e9e-91e8-38ed67432d23"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("64d133e1-754c-4a4e-bb49-10eecbc7a1b8"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("18133035-4ed9-4c55-bac5-f94deb24e361"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("c122c24b-1709-4c45-81d4-33a219f8c687"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
