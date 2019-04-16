using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class parkingmodelfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VisitorName",
                table: "Parkings",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "VisitoCarNo",
                table: "Parkings",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ParkingContact",
                table: "Parkings",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }

            //migrationBuilder.AddColumn<int>(
            //    name: "HospitalID",
            //    table: "Parkings",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "HospitalID",
            //    table: "Feedback",
            //    nullable: true);
            /*
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Donors",
                nullable: true);
            */
            //migrationBuilder.CreateIndex(
            //    name: "IX_Parkings_HospitalID",
            //    table: "Parkings",
            //    column: "HospitalID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Feedback_HospitalID",
            //    table: "Feedback",
            //    column: "HospitalID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Feedback_Hospitals_HospitalID",
            //    table: "Feedback",
            //    column: "HospitalID", 
            //    principalTable: "Hospitals",
            //    principalColumn: "HospitalID",
            //    onDelete: ReferentialAction.NoAction);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Parkings_Hospitals_HospitalID",
        //        table: "Parkings",
        //        column: "HospitalID",
        //        principalTable: "Hospitals",
        //        principalColumn: "HospitalID",
        //        onDelete: ReferentialAction.Restrict);
        //}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Hospitals_HospitalID",
                table: "Feedback");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Parkings_Hospitals_HospitalID",
            //    table: "Parkings");

            migrationBuilder.DropIndex(
                name: "IX_Parkings_HospitalID",
                table: "Parkings");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_HospitalID",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Feedback");
            /*
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Donors");
            */
            migrationBuilder.AlterColumn<string>(
                name: "VisitorName",
                table: "Parkings",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "VisitoCarNo",
                table: "Parkings",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ParkingContact",
                table: "Parkings",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
