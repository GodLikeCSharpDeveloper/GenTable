using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class tagadding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagModel", x => x.Id);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryModelTagModel");

            migrationBuilder.DropTable(
                name: "TagModel");
        }
    }
}
