using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocklyPro.Core.Migrations
{
    public partial class Application_GamePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Identity",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "PlayGame",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    IsCorrectSolution = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayGame_Game_GameId",
                        column: x => x.GameId,
                        principalSchema: "Application",
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGame_User_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameCode",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayGameId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    CodeType = table.Column<int>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCode_PlayGame_PlayGameId",
                        column: x => x.PlayGameId,
                        principalSchema: "Application",
                        principalTable: "PlayGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameCode_PlayGameId",
                schema: "Application",
                table: "GameCode",
                column: "PlayGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGame_GameId",
                schema: "Application",
                table: "PlayGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGame_PlayerId",
                schema: "Application",
                table: "PlayGame",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCode",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "PlayGame",
                schema: "Application");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Identity",
                table: "User",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
