using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class hallTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    treId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    decription = table.Column<string>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    createdBy = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    status = table.Column<short>(nullable: false),
                    ordId1 = table.Column<int>(nullable: true),
                    hId1 = table.Column<int>(nullable: true),
                    refId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.treId);
                    table.ForeignKey(
                        name: "FK_transactions_Halls_hId1",
                        column: x => x.hId1,
                        principalTable: "Halls",
                        principalColumn: "hId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_Orders_ordId1",
                        column: x => x.ordId1,
                        principalTable: "Orders",
                        principalColumn: "ordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_hId1",
                table: "transactions",
                column: "hId1");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_ordId1",
                table: "transactions",
                column: "ordId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}
