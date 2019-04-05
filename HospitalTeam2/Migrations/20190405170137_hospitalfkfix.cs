using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class hospitalfkfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "JobPostingID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "VolunteerID",
                table: "Hospitals");
                */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobPostingID",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VolunteerID",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);
        }
    }
}
