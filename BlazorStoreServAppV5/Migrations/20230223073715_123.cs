using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "ProductOrderModel");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsOrder_OrderModelId",
                table: "ProductOrderModel",
                newName: "IX_ProductOrderModel_OrderModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrderModel",
                table: "ProductOrderModel",
                columns: new[] { "ProductModelId", "OrderModelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderModel_Orders_ProductModelId",
                table: "ProductOrderModel",
                column: "ProductModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderModel_Products_OrderModelId",
                table: "ProductOrderModel",
                column: "OrderModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderModel_Orders_ProductModelId",
                table: "ProductOrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderModel_Products_OrderModelId",
                table: "ProductOrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderModel",
                table: "ProductOrderModel");

            migrationBuilder.RenameTable(
                name: "ProductOrderModel",
                newName: "ProductsOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrderModel_OrderModelId",
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
    }
}
