using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HospitalTeam2.Migrations
{
    public partial class april19migraDivya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "HasPic",
            //    table: "Donors",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPic",
                table: "Donors");
        }
    }
}
