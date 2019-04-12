using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class nickmodels5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Staffs_Departments_DepartmentId",
            //    table: "Staffs");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Staffs",
                newName: "DepartmentID");
            /*
            migrationBuilder.RenameIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                newName: "IX_Staffs_DepartmentID");
                */
            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Departments_DepartmentID",
                table: "Staffs",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Staffs_Departments_DepartmentID",
            //    table: "Staffs");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Staffs",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_DepartmentID",
                table: "Staffs",
                newName: "IX_Staffs_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Departments_DepartmentId",
                table: "Staffs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
