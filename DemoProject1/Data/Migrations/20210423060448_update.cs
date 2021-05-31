using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoProject1.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Products",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");
        }
    }
}
