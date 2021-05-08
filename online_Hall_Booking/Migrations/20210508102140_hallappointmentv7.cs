using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallappointmentv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "HallAppointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "HallAppointment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "HallAppointment");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "HallAppointment");
        }
    }
}
