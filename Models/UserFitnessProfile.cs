// Models/UserFitnessProfile.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGym.Models
{
    public class UserFitnessProfile
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public double BMI { get; set; }

        [Required]
        public string Goal { get; set; } = "Giữ dáng"; // Hoặc: Giảm cân / Tăng cơ

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
