using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocklyPro.Core.Migrations
{
    public partial class Application_AddGameTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Time",
                schema: "Application",
                table: "Game",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                schema: "Application",
                table: "Game");
        }
    }
}
