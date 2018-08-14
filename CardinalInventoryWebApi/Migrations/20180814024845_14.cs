using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TimestampUnixMs",
                table: "SmartWatchSessionData",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimestampUnixMs",
                table: "SmartWatchSessionData");
        }
    }
}
