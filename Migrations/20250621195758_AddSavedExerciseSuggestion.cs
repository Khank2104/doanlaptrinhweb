using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGym.Migrations
{
    /// <inheritdoc />
    public partial class AddSavedExerciseSuggestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedExerciseSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CaloriesBurned = table.Column<double>(type: "float", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedExerciseSuggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedExerciseSuggestions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedExerciseSuggestions_UserId",
                table: "SavedExerciseSuggestions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedExerciseSuggestions");
        }
    }
}
