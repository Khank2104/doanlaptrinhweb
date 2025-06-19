using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGym.Models
{
    public class SleepLog
    {
        public int Id { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public DateTime SleepStart { get; set; }
        public DateTime SleepEnd { get; set; }
        public TimeSpan Duration => SleepEnd - SleepStart;
    }
}
