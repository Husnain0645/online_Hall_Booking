using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class halltimmingv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hallId",
                table: "timings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_timings_hallId",
                table: "timings",
                column: "hallId");

            migrationBuilder.AddForeignKey(
                name: "FK_timings_Halls_hallId",
                table: "timings",
                column: "hallId",
                principalTable: "Halls",
                principalColumn: "hId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_timings_Halls_hallId",
                table: "timings");

            migrationBuilder.DropIndex(
                name: "IX_timings_hallId",
                table: "timings");

            migrationBuilder.DropColumn(
                name: "hallId",
                table: "timings");
        }
    }
}
