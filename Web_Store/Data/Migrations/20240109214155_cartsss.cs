using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class cartsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartEntries_Carts_CartId",
                table: "CartEntries");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "CartEntries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartEntries_Carts_CartId",
                table: "CartEntries",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartEntries_Carts_CartId",
                table: "CartEntries");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "CartEntries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartEntries_Carts_CartId",
                table: "CartEntries",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
