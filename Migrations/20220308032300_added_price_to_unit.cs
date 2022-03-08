using Microsoft.EntityFrameworkCore.Migrations;

namespace Playground2.Migrations
{
    public partial class added_price_to_unit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Resort");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Unit",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Unit");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Resort",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
