using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    UploadedFile = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    SecPass = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    LastLogon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CampaignId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CvId = table.Column<Guid>(nullable: false),
                    MotivationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplication_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplication_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplication_Files_CvId",
                        column: x => x.CvId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplication_Files_MotivationId",
                        column: x => x.MotivationId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplication_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Screening",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    JobApplicationId = table.Column<Guid>(nullable: false),
                    NextScreeningType = table.Column<string>(nullable: true),
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
                values: new object[,]
                {
                    { new Guid("64d133e1-754c-4a4e-bb49-10eecbc7a1b8"), "CM", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("18133035-4ed9-4c55-bac5-f94deb24e361"), "Cegeka", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "java", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c122c24b-1709-4c45-81d4-33a219f8c687"), "OZ", new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "asp.net", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Inactive" },
                    { 2, "active" },
                    { 3, "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_CampaignId",
                table: "JobApplication",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_CandidateId",
                table: "JobApplication",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_CvId",
                table: "JobApplication",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_MotivationId",
                table: "JobApplication",
                column: "MotivationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_StatusId",
                table: "JobApplication",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
