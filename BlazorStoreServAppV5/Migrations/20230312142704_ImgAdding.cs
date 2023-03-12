using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class ImgAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgSrcString",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgSrcString",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgSrcString",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImgSrcString",
                table: "Products");
        }
    }
}
