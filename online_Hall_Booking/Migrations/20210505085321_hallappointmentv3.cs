using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallappointmentv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "HallAppointment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HallAppointment_PId",
                table: "HallAppointment",
                column: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_HallAppointment_packages_PId",
                table: "HallAppointment",
                column: "PId",
                principalTable: "packages",
                principalColumn: "pId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallAppointment_packages_PId",
                table: "HallAppointment");

            migrationBuilder.DropIndex(
                name: "IX_HallAppointment_PId",
                table: "HallAppointment");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "HallAppointment");
        }
    }
}
