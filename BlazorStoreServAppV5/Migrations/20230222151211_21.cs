using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class _21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Orders_ProductModelId",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Products_OrderModelId",
                table: "ProductOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders");

            migrationBuilder.RenameTable(
                name: "ProductOrders",
                newName: "ProductsOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrders_OrderModelId",
                table: "ProductsOrder",
                newName: "IX_ProductsOrder_OrderModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsOrder",
                table: "ProductsOrder",
                columns: new[] { "ProductModelId", "OrderModelId" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsOrder",
                table: "ProductsOrder");

            migrationBuilder.RenameTable(
                name: "ProductsOrder",
                newName: "ProductOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsOrder_OrderModelId",
                table: "ProductOrders",
                newName: "IX_ProductOrders_OrderModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrders",
                table: "ProductOrders",
                columns: new[] { "ProductModelId", "OrderModelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Orders_ProductModelId",
                table: "ProductOrders",
                column: "ProductModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Products_OrderModelId",
                table: "ProductOrders",
                column: "OrderModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
