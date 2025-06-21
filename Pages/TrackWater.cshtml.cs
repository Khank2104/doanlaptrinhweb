using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartGym.Data;
using SmartGym.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SmartGym.Pages
{
    [Authorize]
    public class TrackWaterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TrackWaterModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public double TotalToday { get; set; }
        public string WaterMessage { get; set; } = "";
        public List<WaterIntake> TodaysIntakes { get; set; } = new();
        public List<ChartItem> WaterChart { get; set; } = new();

        public List<string> WaterChartLabels { get; set; } = new();
        public List<double> WaterChartData { get; set; } = new();
        public string WaterChartLabelsJson { get; set; } = "";
        public string WaterChartDataJson { get; set; } = "";


        private const double WaterGoalLiters = 2.0;

        public class InputModel
        {
            [Required(ErrorMessage = "Vui lòng nhập lượng nước")]
            [Range(10, 5000, ErrorMessage = "Giá trị hợp lệ từ 10ml đến 5000ml")]
            public int AmountInMilliliters { get; set; }

            [DataType(DataType.Date)]
            public DateTime LogDate { get; set; } = DateTime.Today;
        }

        public class ChartItem
        {
            public string DateLabel { get; set; } = "";
            public double TotalLiters { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Index");

            TotalToday = await _context.WaterIntakes
                .Where(w => w.UserId == user.Id && w.LogDate.Date == DateTime.Today)
                .SumAsync(w => w.AmountInLiters);

            TodaysIntakes = await _context.WaterIntakes
                .Where(w => w.UserId == user.Id && w.LogDate.Date == DateTime.Today)
                .OrderByDescending(w => w.LogDate)
                .ToListAsync();

            WaterMessage = TotalToday < WaterGoalLiters
                ? "\ud83d\udeb0 Bạn nên uống thêm nước để đạt mục tiêu 2L/ngày!"
                : "\ud83c\udf89 Bạn đã đạt mục tiêu nước hôm nay. Tuyệt vời!";

            var startDate = DateTime.Today.AddDays(-6);
            var rawChart = await _context.WaterIntakes
                .Where(w => w.UserId == user.Id && w.LogDate.Date >= startDate)
                .GroupBy(w => w.LogDate.Date)
                .Select(g => new ChartItem
                {
                    DateLabel = g.Key.ToString("dd/MM"),
                    TotalLiters = g.Sum(x => x.AmountInLiters)
                }).ToListAsync();

            var fullChart = new List<ChartItem>();
            for (int i = 0; i < 7; i++)
            {
                var date = startDate.AddDays(i);
                var label = date.ToString("dd/MM");
                var match = rawChart.FirstOrDefault(x => x.DateLabel == label);
                fullChart.Add(new ChartItem
                {
                    DateLabel = label,
                    TotalLiters = match?.TotalLiters ?? 0
                });
            }

            WaterChart = fullChart;
            WaterChartLabels = WaterChart.Select(x => x.DateLabel).ToList();
            WaterChartData = WaterChart.Select(x => x.TotalLiters).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return await OnGetAsync();

            if (Input.LogDate > DateTime.Today)
            {
                ModelState.AddModelError("Input.LogDate", "Không thể ghi nhận cho ngày trong tương lai.");
                return await OnGetAsync();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Index");

            var intake = new WaterIntake
            {
                UserId = user.Id,
                AmountInLiters = Input.AmountInMilliliters / 1000.0,
                LogDate = Input.LogDate
            };

            _context.WaterIntakes.Add(intake);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"\u2705 Đã ghi nhận {Input.AmountInMilliliters} ml nước!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToPage("/Index");

            var intake = await _context.WaterIntakes
                .FirstOrDefaultAsync(w => w.Id == id && w.UserId == user.Id);

            if (intake != null)
            {
                _context.WaterIntakes.Remove(intake);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "\ud83d\udd91️ Đã xoá bản ghi thành công.";
            }

            return RedirectToPage();
        }
    }
}