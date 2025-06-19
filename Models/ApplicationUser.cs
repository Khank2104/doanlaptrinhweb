using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGym.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public double Height { get; set; } // cm

        [Required]
        public double Weight { get; set; } // kg

        [Required]
        public string Gender { get; set; } = "Nam";

        // Tự động tính BMI
        [NotMapped]
        public double BMI => Height > 0 ? Math.Round(Weight / Math.Pow(Height / 100.0, 2), 2) : 0;

        [NotMapped]
        public string BMIStatus
        {
            get
            {
                if (BMI < 18.5) return "Gầy";
                else if (BMI < 24.9) return "Bình thường";
                else if (BMI < 29.9) return "Thừa cân";
                else return "Béo phì";
            }
        }

        // Thông tin dashboard bổ sung
        public double WaterIntake { get; set; } = 0; // Lít
        public int SleepHours { get; set; } = 0;     // Giờ
    }
}
