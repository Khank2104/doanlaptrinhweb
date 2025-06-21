using System.ComponentModel.DataAnnotations;

namespace SmartGym.Models
{
    public class ExerciseSuggestion
    {
        public int Id { get; set; }

        [Required]
        public string Goal { get; set; } = string.Empty; // Ví dụ: "Giảm mỡ"

        public string Level { get; set; } = "Cơ bản"; // Cơ bản, Trung bình, Nâng cao

        public double BmiMin { get; set; }
        public double BmiMax { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Duration { get; set; } // Phút
        public int CaloriesBurned { get; set; } // Calo
    }
}
