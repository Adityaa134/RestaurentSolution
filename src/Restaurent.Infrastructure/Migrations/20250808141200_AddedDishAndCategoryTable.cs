using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDishAndCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DishName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_Path = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_Dishes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Status" },
                values: new object[,]
                {
                    { new Guid("4de3cf15-47aa-4fa3-8ecc-265d0a0d04ff"), "Beverages", true },
                    { new Guid("582e8288-4fcb-4c98-98cd-b0fbefe29552"), "Pizza", true }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "DishName", "Image_Path", "Price" },
                values: new object[,]
                {
                    { new Guid("0af2f6d6-a3bd-4b68-9193-1078f696e888"), new Guid("582e8288-4fcb-4c98-98cd-b0fbefe29552"), "a sweet and savory combination of golden corn kernels and melted cheese, often with a flavorful sauce and a perfectly baked crust.", "Corn Pizza", "/Images/corn-pizza.jpg", 110m },
                    { new Guid("34adc259-fc50-4519-bd52-190ce9cfe61e"), new Guid("4de3cf15-47aa-4fa3-8ecc-265d0a0d04ff"), "Cold coffee is a coffee beverage served cold", "Cold Coffee", "/Images/cold-coffee.jpg", 120m },
                    { new Guid("8d64dfb9-1ee5-4e32-97de-6c1edf8506dc"), new Guid("582e8288-4fcb-4c98-98cd-b0fbefe29552"), "a classic dish featuring a baked dough base topped with tomato sauce and a generous layer of melted cheese, typically mozzarella, and sometimes other cheeses like parmesan or provolone.", "Cheese Pizza", "/Images/cheese-pizza.jpg", 150m },
                    { new Guid("f649bdc4-7e9c-4026-a7af-91bdd7db7df2"), new Guid("4de3cf15-47aa-4fa3-8ecc-265d0a0d04ff"), "A rich and creamy Oreo shake, blended to perfection with real Oreo cookies and vanilla ice cream for a delightful and indulgent treat", "Oreo Shake", "/Images/oreo-shake.jpg", 249m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
