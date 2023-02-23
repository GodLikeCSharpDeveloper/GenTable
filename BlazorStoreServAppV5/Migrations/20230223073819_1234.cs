using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class _1234 : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrderModel",
                table: "ProductOrderModel");

            migrationBuilder.RenameTable(
                name: "ProductOrderModel",
                newName: "ProductOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrderModel_OrderModelId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_OrderModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                columns: new[] { "ProductModelId", "OrderModelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Orders_OrderModelId",
                table: "ProductOrder",
                column: "OrderModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Products_ProductModelId",
                table: "ProductOrder",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Orders_OrderModelId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Products_ProductModelId",
                table: "ProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.RenameTable(
                name: "ProductOrder",
                newName: "ProductOrderModel");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_OrderModelId",
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
    }
}
