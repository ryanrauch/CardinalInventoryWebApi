using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WristOrientation",
                table: "SmartWatchSessions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WristOrientation",
                table: "SmartWatchSessions");
        }
    }
}
