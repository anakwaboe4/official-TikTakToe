using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TikTakToe.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialMiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Move = table.Column<int>(type: "INTEGER", nullable: false),
                    GridSizeX = table.Column<int>(type: "INTEGER", nullable: false),
                    GridSizeY = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Square = table.Column<int>(type: "INTEGER", nullable: false),
                    Engine = table.Column<int>(type: "INTEGER", nullable: false),
                    GameItemId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_Moves_Games_GameItemId",
                        column: x => x.GameItemId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameItemId",
                table: "Moves",
                column: "GameItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
