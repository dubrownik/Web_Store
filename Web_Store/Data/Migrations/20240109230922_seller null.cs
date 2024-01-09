using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class sellernull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_SellerId",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "SellerId",
                table: "Products",
                nullable: false);
            
            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SellerId",
                table: "Products",
                nullable: true);
        }
    }
}
