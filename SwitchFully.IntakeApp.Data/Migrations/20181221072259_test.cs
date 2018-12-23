using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Campaign",
                columns: new[] { "CampaignId", "Client", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("70d9473d-8000-4f5c-bde1-e3c1761ce7b8"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db042ca0-3ab4-4d9b-a582-1d6e8183ba20"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d621cc0-958d-44c4-b7d9-5bd0b3577cb2"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastLogon", "LastName", "RoleId", "PassWord", "SecPass", "Email" },
                values: new object[] { new Guid("3d75d7b5-532e-474d-a3eb-d1d3f2e9cf73"), "test", null, "user", 1, null, "nhSRFAcAR6lgnY40PZi4iw==", "test@user.be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("3d621cc0-958d-44c4-b7d9-5bd0b3577cb2"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("70d9473d-8000-4f5c-bde1-e3c1761ce7b8"));

            migrationBuilder.DeleteData(
                table: "Campaign",
                keyColumn: "CampaignId",
                keyValue: new Guid("db042ca0-3ab4-4d9b-a582-1d6e8183ba20"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d75d7b5-532e-474d-a3eb-d1d3f2e9cf73"));

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
    }
}
