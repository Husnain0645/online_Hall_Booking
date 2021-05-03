using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallappointment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminRemarks",
                table: "HallAppointment",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "HallAppointment",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminRemarks",
                table: "HallAppointment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HallAppointment");
        }
    }
}
