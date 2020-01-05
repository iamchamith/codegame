using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocklyPro.Core.Migrations
{
    public partial class Application_MaintainPublishFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                schema: "Application",
                table: "Game",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublish",
                schema: "Application",
                table: "Game");
        }
    }
}
