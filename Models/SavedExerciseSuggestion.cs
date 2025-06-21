// Models/SavedExerciseSuggestion.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGym.Models
{
    public class SavedExerciseSuggestion
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Goal { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public int Duration { get; set; }
        public double CaloriesBurned { get; set; }
        public DateTime SavedAt { get; set; } = DateTime.Now;
    }
}
