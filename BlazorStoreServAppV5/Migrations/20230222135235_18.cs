using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class _18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Descriptions_DescriptionModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DescriptionModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionModelId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "DescriptionModelProductModel",
                columns: table => new
                {
                    DescriptionModelsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionModelProductModel", x => new { x.DescriptionModelsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DescriptionModelProductModel_Descriptions_DescriptionModelsId",
                        column: x => x.DescriptionModelsId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionModelProductModel_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionModelProductModel_ProductsId",
                table: "DescriptionModelProductModel",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptionModelProductModel");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionModelId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DescriptionModelId",
                table: "Products",
                column: "DescriptionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Descriptions_DescriptionModelId",
                table: "Products",
                column: "DescriptionModelId",
                principalTable: "Descriptions",
                principalColumn: "Id");
        }
    }
}
