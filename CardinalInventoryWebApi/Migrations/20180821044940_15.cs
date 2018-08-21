using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceScales",
                columns: table => new
                {
                    DeviceScaleId = table.Column<Guid>(nullable: false),
                    DeviceName = table.Column<string>(nullable: true),
                    DeviceScaleType = table.Column<int>(nullable: false),
                    DebugMode = table.Column<bool>(nullable: false),
                    CalibrationConstant = table.Column<int>(nullable: false),
                    CalibrationUnits = table.Column<string>(nullable: true),
                    CalibrationUnitsLong = table.Column<string>(nullable: true),
                    RefreshMilliseconds = table.Column<int>(nullable: false),
                    StableThreshold = table.Column<int>(nullable: false),
                    StableCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceScales", x => x.DeviceScaleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceScales");
        }
    }
}
