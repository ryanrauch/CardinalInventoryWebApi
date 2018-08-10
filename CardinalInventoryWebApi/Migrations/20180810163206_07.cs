using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                table: "StockItems",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                table: "SerializedStockItems",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentItemLevel",
                table: "SerializedStockItems",
                type: "decimal(4,3)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InventoryHistories",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemLevel",
                table: "InventoryActionHistories",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "EventTickets",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GateEventTicketAdmissionTypeId",
                table: "EventStationAssignments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventStationAssignments_GateEventTicketAdmissionTypeId",
                table: "EventStationAssignments",
                column: "GateEventTicketAdmissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventStationAssignments_EventTicketAdmissionTypes_GateEventTicketAdmissionTypeId",
                table: "EventStationAssignments",
                column: "GateEventTicketAdmissionTypeId",
                principalTable: "EventTicketAdmissionTypes",
                principalColumn: "EventTicketAdmissionTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStationAssignments_EventTicketAdmissionTypes_GateEventTicketAdmissionTypeId",
                table: "EventStationAssignments");

            migrationBuilder.DropIndex(
                name: "IX_EventStationAssignments_GateEventTicketAdmissionTypeId",
                table: "EventStationAssignments");

            migrationBuilder.DropColumn(
                name: "GateEventTicketAdmissionTypeId",
                table: "EventStationAssignments");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Events");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                table: "StockItems",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                table: "SerializedStockItems",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentItemLevel",
                table: "SerializedStockItems",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InventoryHistories",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemLevel",
                table: "InventoryActionHistories",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "EventTickets",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));
        }
    }
}
