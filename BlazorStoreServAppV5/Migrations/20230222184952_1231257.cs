using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class _1231257 : Migration
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

            migrationBuilder.CreateTable(
                name: "OrderModelProductModel",
                columns: table => new
                {
                    OrderModelsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModelProductModel", x => new { x.OrderModelsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderModelProductModel_Orders_OrderModelsId",
                        column: x => x.OrderModelsId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderModelProductModel_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderModelProductModel_ProductsId",
                table: "OrderModelProductModel",
                column: "ProductsId");

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

            migrationBuilder.DropTable(
                name: "OrderModelProductModel");

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
