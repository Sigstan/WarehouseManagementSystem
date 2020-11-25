using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseManagementSystem.WEB.Migrations
{
    public partial class ChangeColumnNameTableInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Inventories",
                newName: "StoreDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreDateTime",
                table: "Inventories",
                newName: "Type");
        }
    }
}
