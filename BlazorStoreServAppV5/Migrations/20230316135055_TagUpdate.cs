using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class TagUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "ProductTagModel",
                columns: table => new
                {
                    TagModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductModelsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTagModel", x => new { x.ProductModelsId, x.TagModelId });
                    table.ForeignKey(
                        name: "FK_ProductTagModel_Products_ProductModelsId",
                        column: x => x.ProductModelsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTagModel_TagModels_TagModelId",
                        column: x => x.TagModelId,
                        principalTable: "TagModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTagModel_TagModelId",
                table: "ProductTagModel",
                column: "TagModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTagModel");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
