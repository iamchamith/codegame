using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocklyPro.Core.Migrations
{
    public partial class Application_AddGameInstractions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                schema: "Application",
                table: "Game",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructions",
                schema: "Application",
                table: "Game");
        }
    }
}
