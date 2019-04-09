using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class hospitalTeam4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentTitle",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "HospitalTitle",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "JobApplicationID",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "DepartmentTitle",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "HospitalTitle",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "JobPostingTitle",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentTitle",
                table: "JobPostings",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HospitalTitle",
                table: "JobPostings",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobApplicationID",
                table: "JobPostings",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentTitle",
                table: "Hospitals",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalTitle",
                table: "Departments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobPostingTitle",
                table: "Departments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
