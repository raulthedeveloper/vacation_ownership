using Microsoft.EntityFrameworkCore.Migrations;

namespace Playground2.Migrations
{
    public partial class added_purchased_to_units : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Purchased",
                table: "Unit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purchased",
                table: "Unit");
        }
    }
}
