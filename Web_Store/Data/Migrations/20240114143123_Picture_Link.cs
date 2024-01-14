using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class Picture_Link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerId",
                table: "Order",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_BuyerId",
                table: "Order",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_BuyerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BuyerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
