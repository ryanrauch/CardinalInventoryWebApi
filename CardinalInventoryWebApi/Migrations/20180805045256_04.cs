using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "StockItems",
                newName: "SKU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SKU",
                table: "StockItems",
                newName: "Barcode");
        }
    }
}
