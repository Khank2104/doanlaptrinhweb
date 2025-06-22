using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGym.Migrations
{
    /// <inheritdoc />
    public partial class AddMacrosToNutritionLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Carbs",
                table: "NutritionLogs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fat",
                table: "NutritionLogs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "FoodName",
                table: "NutritionLogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Protein",
                table: "NutritionLogs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "NutritionLogs");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "NutritionLogs");

            migrationBuilder.DropColumn(
                name: "FoodName",
                table: "NutritionLogs");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "NutritionLogs");
        }
    }
}
