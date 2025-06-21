using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGym.Models
{
    public class WorkoutActivity
    {
        public int Id { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        public required string ActivityType { get; set; }

        public int DurationMinutes { get; set; }
        public double CaloriesBurned { get; set; }
        public DateTime ActivityDate { get; set; } = DateTime.Now;
    }
}
