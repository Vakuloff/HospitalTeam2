using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class feedback_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "HasPic",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "ImgType",
                table: "Hospitals");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Hospitals",
                newName: "DepartmentTitle");

            migrationBuilder.RenameColumn(
                name: "JobPosting",
                table: "Departments",
                newName: "JobPostingTitle");

            migrationBuilder.AddColumn<string>(
                name: "TypeDoctor",
                table: "Staffs",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverLetter",
                table: "JobApplications",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobPostingTitle",
                table: "JobApplications",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "JobApplications",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HospitalTitle",
                table: "Departments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbacksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactNumber = table.Column<string>(maxLength: 255, nullable: false),
                    FeedbacksEmail = table.Column<string>(maxLength: 255, nullable: false),
                    FeedbacksMessage = table.Column<string>(maxLength: 255, nullable: false),
                    FeedbacksSubject = table.Column<string>(maxLength: 255, nullable: false),
                    FullName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbacksId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropColumn(
                name: "TypeDoctor",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CoverLetter",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "JobPostingTitle",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "HospitalTitle",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentTitle",
                table: "Hospitals",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "JobPostingTitle",
                table: "Departments",
                newName: "JobPosting");

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "JobApplications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HasPic",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImgType",
                table: "Hospitals",
                nullable: true);
        }
    }
}
