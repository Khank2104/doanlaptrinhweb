using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGym.Models
{
    public class SavedMealSuggestion
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = "";

        [Required]
        public string FoodName { get; set; } = "";

        public string MealType { get; set; } = "Trưa";

        public int Calories { get; set; }

        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }

        public DateTime SavedAt { get; set; } = DateTime.Now;
    }
}
