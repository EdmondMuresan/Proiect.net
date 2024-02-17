using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzazzia.Migrations
{
    /// <inheritdoc />
    public partial class Pizzaaas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Pizza_PizzaId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_PizzaId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "SelectedIngredientId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Ingredient");

            migrationBuilder.CreateTable(
                name: "PizzaIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_IngredientId",
                table: "PizzaIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_PizzaId",
                table: "PizzaIngredient",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngredient");

            migrationBuilder.AddColumn<string>(
                name: "SelectedIngredientId",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_PizzaId",
                table: "Ingredient",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Pizza_PizzaId",
                table: "Ingredient",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id");
        }
    }
}
