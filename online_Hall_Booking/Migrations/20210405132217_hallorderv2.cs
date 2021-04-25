using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallorderv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "hallId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "updatedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_hallId",
                table: "Orders",
                column: "hallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Halls_hallId",
                table: "Orders",
                column: "hallId",
                principalTable: "Halls",
                principalColumn: "hId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Halls_hallId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_hallId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "hallId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
