using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class nickmodels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "Staffs",
                nullable: true);
            /*
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Departments",
                nullable: false,
                defaultValue: 0);
                */
            migrationBuilder.CreateIndex(
                name: "IX_Staffs_HospitalID",
                table: "Staffs",
                column: "HospitalID");
            /*
            migrationBuilder.CreateIndex(
                name: "IX_Departments_StaffId",
                table: "Departments",
                column: "StaffId");
                */
            //migrationBuilder.AddForeignKey(
            //    name: "FK_Departments_Staffs_StaffId",
            //    table: "Departments",
            //    column: "StaffId",
            //    principalTable: "Staffs",
            //    principalColumn: "StaffId",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Hospitals_HospitalID",
                table: "Staffs",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Staffs_StaffId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Hospitals_HospitalID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_HospitalID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Departments_StaffId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Departments");
        }
    }
}
