using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzazzia.Migrations
{
    /// <inheritdoc />
    public partial class Pizzaaas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedIngredientId",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedIngredientId",
                table: "Pizza");
        }
    }
}
