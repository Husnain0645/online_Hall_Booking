using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "cId",
                table: "Halls",
                newName: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CId",
                table: "Halls",
                column: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_cities_CId",
                table: "Halls",
                column: "CId",
                principalTable: "cities",
                principalColumn: "cId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_cities_CId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_CId",
                table: "Halls");

            migrationBuilder.RenameColumn(
                name: "CId",
                table: "Halls",
                newName: "cId");

            migrationBuilder.AddColumn<int>(
                name: "CitycId",
                table: "Halls",
                type: "int",
                nullable: true);

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
    }
}
