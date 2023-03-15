using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class tagadding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Orders_OrderModelId",
                table: "Test");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Products_ProductModelId",
                table: "Test");

            migrationBuilder.DropTable(
                name: "CategoryModelTagModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagModel",
                table: "TagModel");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "ProductOrder");

            migrationBuilder.RenameTable(
                name: "TagModel",
                newName: "TagModels");

            migrationBuilder.RenameIndex(
                name: "IX_Test_OrderModelId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_OrderModelId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TagModels",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                columns: new[] { "ProductModelId", "OrderModelId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagModels",
                table: "TagModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TagCategoryModel",
                columns: table => new
                {
                    CategoryModelsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagModelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategoryModel", x => new { x.CategoryModelsId, x.TagModelId });
                    table.ForeignKey(
                        name: "FK_TagCategoryModel_Categories_CategoryModelsId",
                        column: x => x.CategoryModelsId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagCategoryModel_TagModels_TagModelId",
                        column: x => x.TagModelId,
                        principalTable: "TagModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagCategoryModel_TagModelId",
                table: "TagCategoryModel",
                column: "TagModelId");

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

            migrationBuilder.DropTable(
                name: "TagCategoryModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagModels",
                table: "TagModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.RenameTable(
                name: "TagModels",
                newName: "TagModel");

            migrationBuilder.RenameTable(
                name: "ProductOrder",
                newName: "Test");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_OrderModelId",
                table: "Test",
                newName: "IX_Test_OrderModelId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TagModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagModel",
                table: "TagModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                columns: new[] { "ProductModelId", "OrderModelId" });

            migrationBuilder.CreateTable(
                name: "CategoryModelTagModel",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagModelsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModelTagModel", x => new { x.CategoriesId, x.TagModelsId });
                    table.ForeignKey(
                        name: "FK_CategoryModelTagModel_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryModelTagModel_TagModel_TagModelsId",
                        column: x => x.TagModelsId,
                        principalTable: "TagModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelTagModel_TagModelsId",
                table: "CategoryModelTagModel",
                column: "TagModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Orders_OrderModelId",
                table: "Test",
                column: "OrderModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Products_ProductModelId",
                table: "Test",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
