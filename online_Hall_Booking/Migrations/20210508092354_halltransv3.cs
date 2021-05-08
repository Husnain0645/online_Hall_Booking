using Microsoft.EntityFrameworkCore.Migrations;

namespace online_Hall_Booking.Migrations
{
    public partial class halltransv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_Halls_hId1",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_Orders_ordId1",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_hId1",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_ordId1",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "hId1",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "ordId1",
                table: "transactions");

            migrationBuilder.AlterColumn<int>(
                name: "refId",
                table: "transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdId",
                table: "transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hallId",
                table: "transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_OrdId",
                table: "transactions",
                column: "OrdId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_hallId",
                table: "transactions",
                column: "hallId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_Orders_OrdId",
                table: "transactions",
                column: "OrdId",
                principalTable: "Orders",
                principalColumn: "ordId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_Halls_hallId",
                table: "transactions",
                column: "hallId",
                principalTable: "Halls",
                principalColumn: "hId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_Orders_OrdId",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_Halls_hallId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_OrdId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_hallId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "OrdId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "hallId",
                table: "transactions");

            migrationBuilder.AlterColumn<string>(
                name: "refId",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "hId1",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ordId1",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_hId1",
                table: "transactions",
                column: "hId1");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_ordId1",
                table: "transactions",
                column: "ordId1");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_Halls_hId1",
                table: "transactions",
                column: "hId1",
                principalTable: "Halls",
                principalColumn: "hId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_Orders_ordId1",
                table: "transactions",
                column: "ordId1",
                principalTable: "Orders",
                principalColumn: "ordId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
