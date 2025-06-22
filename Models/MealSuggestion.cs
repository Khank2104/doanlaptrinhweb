// Models/MealSuggestion.cs
using System.ComponentModel.DataAnnotations;

namespace SmartGym.Models
{
    public class MealSuggestion
    {
        public int Id { get; set; }

        [Required]
        public string MealName { get; set; } = string.Empty;

        public int Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }

        [Required]
        public string GoalType { get; set; } = string.Empty; // Giảm cân / Tăng cơ / Giữ dáng

        // ✅ Thêm lọc theo BMI
        public double BmiMin { get; set; }
        public double BmiMax { get; set; }
    }
}
