using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class HallOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdAt = table.Column<DateTime>(nullable: false),
                    createdBy = table.Column<string>(nullable: false),
                    personCount = table.Column<double>(nullable: false),
                    totalAmount = table.Column<double>(nullable: false),
                    receivedAmount = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    status = table.Column<short>(nullable: false),
                    PackagesIdpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ordId);
                    table.ForeignKey(
                        name: "FK_Orders_packages_PackagesIdpId",
                        column: x => x.PackagesIdpId,
                        principalTable: "packages",
                        principalColumn: "pId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PackagesIdpId",
                table: "Orders",
                column: "PackagesIdpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
