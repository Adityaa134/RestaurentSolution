using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cat_Image",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4de3cf15-47aa-4fa3-8ecc-265d0a0d04ff"),
                column: "Cat_Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("582e8288-4fcb-4c98-98cd-b0fbefe29552"),
                column: "Cat_Image",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cat_Image",
                table: "Categories");
        }
    }
}
