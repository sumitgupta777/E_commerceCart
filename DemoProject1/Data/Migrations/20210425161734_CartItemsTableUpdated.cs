using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoProject1.Data.Migrations
{
    public partial class CartItemsTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "CartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShoppingCartId",
                table: "CartItems",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);
        }
    }
}
