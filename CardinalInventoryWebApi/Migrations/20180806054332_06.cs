using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketPhysicalType",
                table: "EventTickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "EventCustomers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EventCustomers_ApplicationUserId",
                table: "EventCustomers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCustomers_AspNetUsers_ApplicationUserId",
                table: "EventCustomers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCustomers_AspNetUsers_ApplicationUserId",
                table: "EventCustomers");

            migrationBuilder.DropIndex(
                name: "IX_EventCustomers_ApplicationUserId",
                table: "EventCustomers");

            migrationBuilder.DropColumn(
                name: "TicketPhysicalType",
                table: "EventTickets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "EventCustomers");
        }
    }
}
