using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class HallPackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    pId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    decription = table.Column<string>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    createdBy = table.Column<string>(nullable: false),
                    updatedBy = table.Column<string>(nullable: false),
                    personCount = table.Column<double>(nullable: false),
                    charges = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    status = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.pId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "packages");
        }
    }
}
