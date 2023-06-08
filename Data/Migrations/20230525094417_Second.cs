using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Dealers_BuyerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Dealers_SellerId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Dealers_BuyerId",
                table: "Transactions",
                column: "BuyerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Dealers_SellerId",
                table: "Transactions",
                column: "SellerId",
                principalTable: "Dealers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Dealers_BuyerId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Dealers_SellerId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Dealers_BuyerId",
                table: "Transactions",
                column: "BuyerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Dealers_SellerId",
                table: "Transactions",
                column: "SellerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
