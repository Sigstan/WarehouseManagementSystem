using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseManagementSystem.WEB.Migrations
{
    public partial class UpdatedColumnNameTableInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreDateTime",
                table: "Inventories",
                newName: "StoredDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoredDateTime",
                table: "Inventories",
                newName: "StoreDateTime");
        }
    }
}
