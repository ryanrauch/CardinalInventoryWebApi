using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartWatchSessionData_SmartWatchSession_SmartWatchSessionId",
                table: "SmartWatchSessionData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmartWatchSession",
                table: "SmartWatchSession");

            migrationBuilder.RenameTable(
                name: "SmartWatchSession",
                newName: "SmartWatchSessions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmartWatchSessions",
                table: "SmartWatchSessions",
                column: "SmartWatchSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmartWatchSessionData_SmartWatchSessions_SmartWatchSessionId",
                table: "SmartWatchSessionData",
                column: "SmartWatchSessionId",
                principalTable: "SmartWatchSessions",
                principalColumn: "SmartWatchSessionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartWatchSessionData_SmartWatchSessions_SmartWatchSessionId",
                table: "SmartWatchSessionData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmartWatchSessions",
                table: "SmartWatchSessions");

            migrationBuilder.RenameTable(
                name: "SmartWatchSessions",
                newName: "SmartWatchSession");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmartWatchSession",
                table: "SmartWatchSession",
                column: "SmartWatchSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmartWatchSessionData_SmartWatchSession_SmartWatchSessionId",
                table: "SmartWatchSessionData",
                column: "SmartWatchSessionId",
                principalTable: "SmartWatchSession",
                principalColumn: "SmartWatchSessionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
