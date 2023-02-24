using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class _12312343 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrder_Orders_OrderModelId",
                table: "ProductsOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrder_Products_ProductModelId",
                table: "ProductsOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrder_Orders_ProductModelId",
                table: "ProductsOrder",
                column: "ProductModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrder_Products_OrderModelId",
                table: "ProductsOrder",
                column: "OrderModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrder_Orders_ProductModelId",
                table: "ProductsOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrder_Products_OrderModelId",
                table: "ProductsOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrder_Orders_OrderModelId",
                table: "ProductsOrder",
                column: "OrderModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrder_Products_ProductModelId",
                table: "ProductsOrder",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
