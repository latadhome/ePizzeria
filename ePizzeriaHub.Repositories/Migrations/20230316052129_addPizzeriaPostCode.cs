using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ePizzeriaHub.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class addPizzeriaPostCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostCode",
                table: "Pizzerias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PizzeriaId",
                table: "Categories",
                column: "PizzeriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Pizzerias_PizzeriaId",
                table: "Categories",
                column: "PizzeriaId",
                principalTable: "Pizzerias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Pizzerias_PizzeriaId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PizzeriaId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Pizzerias");
        }
    }
}
