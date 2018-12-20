using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class screeningOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("0327279f-e8ce-4a09-9c5d-906d19b13a83"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("6d3f8129-7dfe-4107-ab38-cbf28de9ec7b"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("ccd53f93-098b-4a27-a8e4-fd95cc922f8d"));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Screening",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("134463e4-d964-45aa-b6e9-d61419e865e2"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("c1853eab-343d-4c44-b249-3de07f87bf94"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("5bca94c3-0819-4ce7-b2fa-f2be661f6c66"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("134463e4-d964-45aa-b6e9-d61419e865e2"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("5bca94c3-0819-4ce7-b2fa-f2be661f6c66"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("c1853eab-343d-4c44-b249-3de07f87bf94"));

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Screening");

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("6d3f8129-7dfe-4107-ab38-cbf28de9ec7b"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("0327279f-e8ce-4a09-9c5d-906d19b13a83"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[] { new Guid("ccd53f93-098b-4a27-a8e4-fd95cc922f8d"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
