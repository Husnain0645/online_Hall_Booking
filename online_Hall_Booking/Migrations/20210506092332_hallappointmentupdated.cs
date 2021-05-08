using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallappointmentupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AdvancedAmount",
                table: "HallAppointment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Persons",
                table: "HallAppointment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RemaingAmount",
                table: "HallAppointment",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvancedAmount",
                table: "HallAppointment");

            migrationBuilder.DropColumn(
                name: "Persons",
                table: "HallAppointment");

            migrationBuilder.DropColumn(
                name: "RemaingAmount",
                table: "HallAppointment");
        }
    }
}
