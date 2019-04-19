using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class UserHospitalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Hospitals_HospitalID",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "JobPostingTitle",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "HospitalTitle",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "StaffFirstName",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "StaffLastName",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "TypeDoctor",
                table: "BookingRequests");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalID",
                table: "Parkings",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID1",
                table: "JobPostings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_DepartmentID1",
                table: "JobPostings",
                column: "DepartmentID1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HospitalId",
                table: "AspNetUsers",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hospitals_HospitalId",
                table: "AspNetUsers",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Departments_DepartmentID1",
                table: "JobPostings",
                column: "DepartmentID1",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Hospitals_HospitalID",
                table: "Parkings",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hospitals_HospitalId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Departments_DepartmentID1",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Hospitals_HospitalID",
                table: "Parkings");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_DepartmentID1",
                table: "JobPostings");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HospitalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentID1",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalID",
                table: "Parkings",
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "JobPostingTitle",
                table: "JobApplications",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HospitalTitle",
                table: "BookingRequests",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StaffFirstName",
                table: "BookingRequests",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StaffLastName",
                table: "BookingRequests",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeDoctor",
                table: "BookingRequests",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Hospitals_HospitalID",
                table: "Parkings",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
