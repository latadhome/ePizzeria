using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ePizzeriaHub.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ItemChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Pizzerias_PizzeriaId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PizzeriaId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PizzeriaId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "PizzeriaId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_PizzeriaId",
                table: "Items",
                column: "PizzeriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Pizzerias_PizzeriaId",
                table: "Items",
                column: "PizzeriaId",
                principalTable: "Pizzerias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pizzerias_PizzeriaId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PizzeriaId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PizzeriaId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "userId");

            migrationBuilder.AddColumn<int>(
                name: "PizzeriaId",
                table: "Categories",
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
    }
}
