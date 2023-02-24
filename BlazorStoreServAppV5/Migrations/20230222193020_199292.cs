using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class _199292 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderModel_Orders_ProductModelId",
                table: "ProductOrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderModel_Products_OrderModelId",
                table: "ProductOrderModel");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderModel_Orders_OrderModelId",
                table: "ProductOrderModel",
                column: "OrderModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderModel_Products_ProductModelId",
                table: "ProductOrderModel",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderModel_Orders_OrderModelId",
                table: "ProductOrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderModel_Products_ProductModelId",
                table: "ProductOrderModel");

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
    }
}
