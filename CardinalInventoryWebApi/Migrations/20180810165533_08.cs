using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCustomers_AspNetUsers_ApplicationUserId",
                table: "EventCustomers");

            migrationBuilder.DropIndex(
                name: "IX_EventCustomers_ApplicationUserId",
                table: "EventCustomers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
