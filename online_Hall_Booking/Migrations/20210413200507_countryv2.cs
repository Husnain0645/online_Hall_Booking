using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class countryv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countries_states_sId1",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "IX_countries_sId1",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "sId1",
                table: "countries");

            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "countries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_countries_SId",
                table: "countries",
                column: "SId");

            migrationBuilder.AddForeignKey(
                name: "FK_countries_states_SId",
                table: "countries",
                column: "SId",
                principalTable: "states",
                principalColumn: "sId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countries_states_SId",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "IX_countries_SId",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "countries");

            migrationBuilder.AddColumn<int>(
                name: "sId1",
                table: "countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_sId1",
                table: "countries",
                column: "sId1");

            migrationBuilder.AddForeignKey(
                name: "FK_countries_states_sId1",
                table: "countries",
                column: "sId1",
                principalTable: "states",
                principalColumn: "sId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
