using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SockUnit",
                table: "Products",
                newName: "StockUnit");

            migrationBuilder.CreateIndex(
                name: "Index_Name",
                table: "Suppliers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "Index_Id",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "Index_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "Index_StockUnit",
                table: "Products",
                column: "StockUnit");

            migrationBuilder.CreateIndex(
                name: "Index_UnitPrice",
                table: "Products",
                column: "UnitPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_Name",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "Index_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "Index_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "Index_StockUnit",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "Index_UnitPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "StockUnit",
                table: "Products",
                newName: "SockUnit");
        }
    }
}
