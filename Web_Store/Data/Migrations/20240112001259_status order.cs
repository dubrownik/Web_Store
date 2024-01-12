using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class statusorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPriceAtPurchase",
                table: "OrderEntry",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "UnitPriceAtPurchase",
                table: "OrderEntry",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
