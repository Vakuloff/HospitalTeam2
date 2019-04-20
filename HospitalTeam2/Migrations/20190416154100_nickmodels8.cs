using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class nickmodels8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_Departments_DepartmentID1",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Hospitals_HospitalID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_JobPostings_DepartmentID1",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "DepartmentID1",
                table: "JobPostings");

            migrationBuilder.RenameColumn(
                name: "HospitalID",
                table: "Staffs",
                newName: "HospitalId");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_HospitalID",
                table: "Staffs",
                newName: "IX_Staffs_HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Hospitals_HospitalId",
                table: "Staffs",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Hospitals_HospitalId",
                table: "Staffs");

            migrationBuilder.RenameColumn(
                name: "HospitalId",
                table: "Staffs",
                newName: "HospitalID");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_HospitalId",
                table: "Staffs",
                newName: "IX_Staffs_HospitalID");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID1",
                table: "JobPostings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_DepartmentID1",
                table: "JobPostings",
                column: "DepartmentID1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_Departments_DepartmentID1",
                table: "JobPostings",
                column: "DepartmentID1",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Hospitals_HospitalID",
                table: "Staffs",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
