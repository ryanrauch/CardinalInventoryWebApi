using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PourSpoutId",
                table: "SmartWatchSessions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PourSpouts",
                columns: table => new
                {
                    PourSpoutId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DurationForOneLiter = table.Column<double>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PourSpouts", x => x.PourSpoutId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmartWatchSessions_PourSpoutId",
                table: "SmartWatchSessions",
                column: "PourSpoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmartWatchSessions_PourSpouts_PourSpoutId",
                table: "SmartWatchSessions",
                column: "PourSpoutId",
                principalTable: "PourSpouts",
                principalColumn: "PourSpoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartWatchSessions_PourSpouts_PourSpoutId",
                table: "SmartWatchSessions");

            migrationBuilder.DropTable(
                name: "PourSpouts");

            migrationBuilder.DropIndex(
                name: "IX_SmartWatchSessions_PourSpoutId",
                table: "SmartWatchSessions");

            migrationBuilder.DropColumn(
                name: "PourSpoutId",
                table: "SmartWatchSessions");
        }
    }
}
