using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class hospital_apr4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.RenameColumn(
                name: "JobPosition",
                table: "Departments",
                newName: "JobPostingTitle");
                */
                /*
            migrationBuilder.RenameColumn(
                name: "DoctorName",
                table: "BookingRequests",
                newName: "StaffLastName");
                
            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "Volunteers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeDoctor",
                table: "Staffs",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "JobPostings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentTitle",
                table: "JobPostings",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "JobPostings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobApplicationID",
                table: "JobPostings",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverLetter",
                table: "JobApplications",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JobPostingID",
                table: "JobApplications",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<string>(
                name: "DepartmentTitle",
                table: "Hospitals",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hospitals",
                maxLength: 2147483647,
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "Departments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HospitalTitle",
                table: "Departments",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "BookingRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StaffFirstName",
                table: "BookingRequests",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "BookingRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_HospitalID",
                table: "Volunteers",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_DepartmentID",
                table: "JobPostings",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_HospitalID",
                table: "JobPostings",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostingID",
                table: "JobApplications",
                column: "JobPostingID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HospitalID",
                table: "Departments",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_HospitalID",
                table: "BookingRequests",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_StaffID",
                table: "BookingRequests",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRequests_Hospitals_HospitalID",
                table: "BookingRequests",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRequests_Staffs_StaffID",
                table: "BookingRequests",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Hospitals_HospitalID",
                table: "Departments",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobPostings_JobPostingID",
                table: "JobApplications",
                column: "JobPostingID",
                principalTable: "JobPostings",
                principalColumn: "JobPostingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Departments_DepartmentID",
                table: "JobPostings",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Hospitals_HospitalID",
                table: "JobPostings",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Hospitals_HospitalID",
                table: "Volunteers",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);
                */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRequests_Hospitals_HospitalID",
                table: "BookingRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRequests_Staffs_StaffID",
                table: "BookingRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Hospitals_HospitalID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobPostings_JobPostingID",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Departments_DepartmentID",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Hospitals_HospitalID",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Hospitals_HospitalID",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_HospitalID",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_DepartmentID",
                table: "JobPostings");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_HospitalID",
                table: "JobPostings");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobPostingID",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HospitalID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_BookingRequests_HospitalID",
                table: "BookingRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookingRequests_StaffID",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "TypeDoctor",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "DepartmentTitle",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "JobApplicationID",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "CoverLetter",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "JobPostingID",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "JobPostingTitle",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DepartmentTitle",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "JobPostingID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "VolunteerID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "HospitalTitle",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "StaffFirstName",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "BookingRequests");

            migrationBuilder.RenameColumn(
                name: "JobPostingTitle",
                table: "Departments",
                newName: "JobPosition");

            migrationBuilder.RenameColumn(
                name: "StaffLastName",
                table: "BookingRequests",
                newName: "DoctorName");
        }
    }
}
