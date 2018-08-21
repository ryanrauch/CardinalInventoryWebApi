using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadCountAverage",
                table: "DeviceScales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReadCountMilliseconds",
                table: "DeviceScales",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadCountAverage",
                table: "DeviceScales");

            migrationBuilder.DropColumn(
                name: "ReadCountMilliseconds",
                table: "DeviceScales");
        }
    }
}
