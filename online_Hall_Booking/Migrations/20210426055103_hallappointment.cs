using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallappointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HallAppointment",
                columns: table => new
                {
                    HapId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    HId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallAppointment", x => x.HapId);
                    table.ForeignKey(
                        name: "FK_HallAppointment_Halls_HId",
                        column: x => x.HId,
                        principalTable: "Halls",
                        principalColumn: "hId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HallAppointment_HId",
                table: "HallAppointment",
                column: "HId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallAppointment");
        }
    }
}
