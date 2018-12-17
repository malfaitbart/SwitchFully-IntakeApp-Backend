using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    public partial class uploadConnectJobApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CvId",
                table: "JobApplication",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MotivationId",
                table: "JobApplication",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobApplicationId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_CvId",
                table: "JobApplication",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_MotivationId",
                table: "JobApplication",
                column: "MotivationId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_JobApplicationId",
                table: "Files",
                column: "JobApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_JobApplication_JobApplicationId",
                table: "Files",
                column: "JobApplicationId",
                principalTable: "JobApplication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Files_CvId",
                table: "JobApplication",
                column: "CvId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Files_MotivationId",
                table: "JobApplication",
                column: "MotivationId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_JobApplication_JobApplicationId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Files_CvId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Files_MotivationId",
                table: "JobApplication");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_CvId",
                table: "JobApplication");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_MotivationId",
                table: "JobApplication");

            migrationBuilder.DropIndex(
                name: "IX_Files_JobApplicationId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CvId",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "MotivationId",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                table: "Files");
        }
    }
}
