using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class parkfkmod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Hospitals_HospitalID",
                table: "Parkings");

            //migrationBuilder.AlterColumn<int>(
            //    name: "HospitalID",
            //    table: "Parkings",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "FirstName",
            //    table: "AspNetUsers",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LastName",
            //    table: "AspNetUsers",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "NavMenus",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IsShown = table.Column<bool>(nullable: false),
            //        NavMenuItemId = table.Column<int>(nullable: true),
            //        Title = table.Column<string>(maxLength: 255, nullable: false),
            //        Url = table.Column<string>(maxLength: 500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NavMenus", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_NavMenus_NavMenus_NavMenuItemId",
            //            column: x => x.NavMenuItemId,
            //            principalTable: "NavMenus",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_NavMenus_NavMenuItemId",
            //    table: "NavMenus",
            //    column: "NavMenuItemId");

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
                name: "FK_Parkings_Hospitals_HospitalID",
                table: "Parkings");

            migrationBuilder.DropTable(
                name: "NavMenus");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalID",
                table: "Parkings",
                nullable: true,
                oldClrType: typeof(int));

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
