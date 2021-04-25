using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Halls",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "cityId",
                table: "Halls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Halls_cityId",
                table: "Halls",
                column: "cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_cities_cityId",
                table: "Halls",
                column: "cityId",
                principalTable: "cities",
                principalColumn: "cId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_cities_cityId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_cityId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "cityId",
                table: "Halls");
        }
    }
}
