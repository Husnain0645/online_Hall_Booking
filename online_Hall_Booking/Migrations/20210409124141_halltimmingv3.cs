using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class halltimmingv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "timings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "timings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "timings");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "timings");
        }
    }
}
