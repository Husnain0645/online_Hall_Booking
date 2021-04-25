using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class faacilitiesv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FAcilities_hallId",
                table: "FAcilities",
                column: "hallId");

            migrationBuilder.AddForeignKey(
                name: "FK_FAcilities_Halls_hallId",
                table: "FAcilities",
                column: "hallId",
                principalTable: "Halls",
                principalColumn: "hId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAcilities_Halls_hallId",
                table: "FAcilities");

            migrationBuilder.DropIndex(
                name: "IX_FAcilities_hallId",
                table: "FAcilities");
        }
    }
}
