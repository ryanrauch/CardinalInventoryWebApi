using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AccelerometerX",
                table: "SmartWatchSessionData",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AccelerometerY",
                table: "SmartWatchSessionData",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AccelerometerZ",
                table: "SmartWatchSessionData",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccelerometerX",
                table: "SmartWatchSessionData");

            migrationBuilder.DropColumn(
                name: "AccelerometerY",
                table: "SmartWatchSessionData");

            migrationBuilder.DropColumn(
                name: "AccelerometerZ",
                table: "SmartWatchSessionData");
        }
    }
}
