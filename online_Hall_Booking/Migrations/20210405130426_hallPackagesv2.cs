using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallPackagesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "packages",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "packages",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "hallId",
                table: "packages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_packages_hallId",
                table: "packages",
                column: "hallId");

            migrationBuilder.AddForeignKey(
                name: "FK_packages_Halls_hallId",
                table: "packages",
                column: "hallId",
                principalTable: "Halls",
                principalColumn: "hId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_packages_Halls_hallId",
                table: "packages");

            migrationBuilder.DropIndex(
                name: "IX_packages_hallId",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "hallId",
                table: "packages");

            migrationBuilder.AlterColumn<string>(
                name: "updatedBy",
                table: "packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "createdBy",
                table: "packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
