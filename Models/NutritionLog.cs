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

        [Required]
        [StringLength(100)]
        public string FoodName { get; set; } = string.Empty;

        public int Calories { get; set; }

        // 💪 Các chỉ số vi chất (đơn vị: gram)
        [Range(0, 1000)]
        public float Protein { get; set; }

        [Range(0, 1000)]
        public float Carbs { get; set; }

        [Range(0, 1000)]
        public float Fat { get; set; }

        public DateTime LogDate { get; set; } = DateTime.Now;

        // ⏰ Thời gian ghi log (giờ-phút)
        [DataType(DataType.Time)]
        public TimeSpan LogTime { get; set; } = DateTime.Now.TimeOfDay;
    }
}
