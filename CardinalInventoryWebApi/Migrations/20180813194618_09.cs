using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartWatchSession",
                columns: table => new
                {
                    SmartWatchSessionId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    IntervalDuration = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    IntervalStart = table.Column<int>(nullable: false),
                    IntervalStop = table.Column<int>(nullable: false),
                    AttitudeRollOffset = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartWatchSession", x => x.SmartWatchSessionId);
                });

            migrationBuilder.CreateTable(
                name: "SmartWatchSessionData",
                columns: table => new
                {
                    Interval = table.Column<int>(nullable: false),
                    SmartWatchSessionId = table.Column<Guid>(nullable: false),
                    AttitudePitch = table.Column<double>(nullable: false),
                    AttitudeRoll = table.Column<double>(nullable: false),
                    AttitudeYaw = table.Column<double>(nullable: false),
                    RotationRateX = table.Column<double>(nullable: false),
                    RotationRateY = table.Column<double>(nullable: false),
                    RotationRateZ = table.Column<double>(nullable: false),
                    UserAccelerationX = table.Column<double>(nullable: false),
                    UserAccelerationY = table.Column<double>(nullable: false),
                    UserAccelerationZ = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartWatchSessionData", x => new { x.Interval, x.SmartWatchSessionId });
                    table.ForeignKey(
                        name: "FK_SmartWatchSessionData_SmartWatchSession_SmartWatchSessionId",
                        column: x => x.SmartWatchSessionId,
                        principalTable: "SmartWatchSession",
                        principalColumn: "SmartWatchSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmartWatchSessionData_SmartWatchSessionId",
                table: "SmartWatchSessionData",
                column: "SmartWatchSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartWatchSessionData");

            migrationBuilder.DropTable(
                name: "SmartWatchSession");
        }
    }
}
