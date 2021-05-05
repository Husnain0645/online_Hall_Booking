using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallorderv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallAppointment_packages_PId",
                table: "HallAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_packages_PackagesIdpId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PackagesIdpId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PackagesIdpId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PId",
                table: "HallAppointment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PId",
                table: "Orders",
                column: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_HallAppointment_packages_PId",
                table: "HallAppointment",
                column: "PId",
                principalTable: "packages",
                principalColumn: "pId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_packages_PId",
                table: "Orders",
                column: "PId",
                principalTable: "packages",
                principalColumn: "pId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallAppointment_packages_PId",
                table: "HallAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_packages_PId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PackagesIdpId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PId",
                table: "HallAppointment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PackagesIdpId",
                table: "Orders",
                column: "PackagesIdpId");

            migrationBuilder.AddForeignKey(
                name: "FK_HallAppointment_packages_PId",
                table: "HallAppointment",
                column: "PId",
                principalTable: "packages",
                principalColumn: "pId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_packages_PackagesIdpId",
                table: "Orders",
                column: "PackagesIdpId",
                principalTable: "packages",
                principalColumn: "pId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
