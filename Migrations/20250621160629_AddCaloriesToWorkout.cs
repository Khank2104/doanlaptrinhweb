using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGym.Migrations
{
    /// <inheritdoc />
    public partial class AddCaloriesToWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CaloriesBurned",
                table: "WorkoutActivities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesBurned",
                table: "WorkoutActivities");
        }
    }
}
