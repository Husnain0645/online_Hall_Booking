using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class State : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_city",
                table: "city");

            migrationBuilder.RenameTable(
                name: "city",
                newName: "cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "cId");

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    sId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    status = table.Column<short>(nullable: false),
                    cityIdcId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.sId);
                    table.ForeignKey(
                        name: "FK_states_cities_cityIdcId",
                        column: x => x.cityIdcId,
                        principalTable: "cities",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_states_cityIdcId",
                table: "states",
                column: "cityIdcId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "city");

            migrationBuilder.AddPrimaryKey(
                name: "PK_city",
                table: "city",
                column: "cId");
        }
    }
}
