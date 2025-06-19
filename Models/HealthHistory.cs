// Models/HealthHistory.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGym.Models
{
    public class HealthHistory
    {
        public int Id { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }

        public DateTime LoggedAt { get; set; } = DateTime.Now;
    }
}
