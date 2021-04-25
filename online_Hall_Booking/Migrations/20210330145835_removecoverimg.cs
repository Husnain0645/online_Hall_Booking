using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class removecoverimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coverImage",
                table: "Halls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "coverImage",
                table: "Halls",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
