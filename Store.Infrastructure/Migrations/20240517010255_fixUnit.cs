using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_UnitId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitId1",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId1",
                table: "Products",
                column: "UnitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_UnitId1",
                table: "Products",
                column: "UnitId1",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
