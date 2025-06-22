using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartGym.Models;

namespace SmartGym.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HealthHistory> HealthHistories { get; set; }
        public DbSet<NutritionLog> NutritionLogs { get; set; } = default!;
        public DbSet<WorkoutActivity> WorkoutActivities { get; set; } = default!;
        public DbSet<SleepLog> SleepLogs { get; set; } = default!;
        public DbSet<WaterIntake> WaterIntakes { get; set; } = default!;
        public DbSet<UserFitnessProfile> UserFitnessProfiles { get; set; }
        public DbSet<ExerciseSuggestion> ExerciseSuggestions { get; set; } = default!;
        public DbSet<SavedExerciseSuggestion> SavedExerciseSuggestions { get; set; }
        public DbSet<MealSuggestion> MealSuggestions { get; set; } = default!;
        public DbSet<SavedMealSuggestion> SavedMealSuggestions { get; set; }




    }
}
