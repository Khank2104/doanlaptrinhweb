using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGym.Models
{
    public class NutritionLog
    {
        public int Id { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        public required string MealType { get; set; }

        public int Calories { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
