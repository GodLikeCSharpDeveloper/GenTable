using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    /// <inheritdoc />
    public partial class ord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFullfilled",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFullfilled",
                table: "Orders");
        }
    }
}
