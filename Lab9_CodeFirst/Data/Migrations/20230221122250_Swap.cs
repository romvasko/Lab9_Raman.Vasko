using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab9_CodeFirst.Data.Migrations
{
    public partial class Swap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Cars_CarID",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CarID",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "CarModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarID",
                table: "CarModels",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Cars_CarID",
                table: "CarModels",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID");
        }
    }
}
