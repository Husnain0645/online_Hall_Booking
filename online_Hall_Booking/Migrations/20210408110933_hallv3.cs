using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_cities_cityId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_cityId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "cityId",
                table: "Halls");

            migrationBuilder.AddColumn<int>(
                name: "CitycId",
                table: "Halls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cId",
                table: "Halls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CitycId",
                table: "Halls",
                column: "CitycId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_cities_CitycId",
                table: "Halls",
                column: "CitycId",
                principalTable: "cities",
                principalColumn: "cId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_cities_CitycId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_CitycId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "CitycId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "cId",
                table: "Halls");

            migrationBuilder.AddColumn<int>(
                name: "cityId",
                table: "Halls",
                type: "int",
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
    }
}
