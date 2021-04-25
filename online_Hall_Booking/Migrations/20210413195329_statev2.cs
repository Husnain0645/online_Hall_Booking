using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class statev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_states_cities_cityIdcId",
                table: "states");

            migrationBuilder.DropIndex(
                name: "IX_states_cityIdcId",
                table: "states");

            migrationBuilder.DropColumn(
                name: "cityIdcId",
                table: "states");

            migrationBuilder.AddColumn<int>(
                name: "CId",
                table: "states",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_states_CId",
                table: "states",
                column: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_states_cities_CId",
                table: "states",
                column: "CId",
                principalTable: "cities",
                principalColumn: "cId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_states_cities_CId",
                table: "states");

            migrationBuilder.DropIndex(
                name: "IX_states_CId",
                table: "states");

            migrationBuilder.DropColumn(
                name: "CId",
                table: "states");

            migrationBuilder.AddColumn<int>(
                name: "cityIdcId",
                table: "states",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_states_cityIdcId",
                table: "states",
                column: "cityIdcId");

            migrationBuilder.AddForeignKey(
                name: "FK_states_cities_cityIdcId",
                table: "states",
                column: "cityIdcId",
                principalTable: "cities",
                principalColumn: "cId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
