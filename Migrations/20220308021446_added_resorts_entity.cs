using Microsoft.EntityFrameworkCore.Migrations;

namespace Playground2.Migrations
{
    public partial class added_resorts_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "ResortId",
                table: "Sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Resort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resort", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ResortId",
                table: "Sales",
                column: "ResortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Resort_ResortId",
                table: "Sales",
                column: "ResortId",
                principalTable: "Resort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Resort_ResortId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "Resort");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ResortId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ResortId",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
