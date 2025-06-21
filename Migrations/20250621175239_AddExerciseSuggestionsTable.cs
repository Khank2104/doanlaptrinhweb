using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGym.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseSuggestionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BmiMin = table.Column<double>(type: "float", nullable: false),
                    BmiMax = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CaloriesBurned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSuggestions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSuggestions");
        }
    }
}
