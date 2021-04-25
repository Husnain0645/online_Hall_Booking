using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class faacilitiesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "FAcilities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "FAcilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "FAcilities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "FAcilities");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "FAcilities");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "FAcilities");
        }
    }
}
