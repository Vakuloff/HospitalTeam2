using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class nickmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "ContactForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    AlertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlertMessage = table.Column<string>(maxLength: 255, nullable: false),
                    AlertTitle = table.Column<string>(maxLength: 255, nullable: false),
                    HospitalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.AlertId);
                    table.ForeignKey(
                        name: "FK_Alert_Hospitals_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StaffId",
                table: "Schedules",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactForms_HospitalID",
                table: "ContactForms",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Alert_HospitalID",
                table: "Alert",
                column: "HospitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactForms_Hospitals_HospitalID",
                table: "ContactForms",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Staffs_StaffId",
                table: "Schedules",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactForms_Hospitals_HospitalID",
                table: "ContactForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Staffs_StaffId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_StaffId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_ContactForms_HospitalID",
                table: "ContactForms");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "ContactForms");
        }
    }
}
