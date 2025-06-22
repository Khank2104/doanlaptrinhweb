using SmartGym.Models;

namespace SmartGym.Data
{
    public class MealDataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.MealSuggestions.Any())
            {
                var mealSuggestions = new List<MealSuggestion>
                {
                    // 🔽 GIẢM MỠ
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Cháo yến mạch với dâu", Calories = 250, Protein = 35, Carbs = 10, Fat = 5, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Salad ức gà nướng", Calories = 400, Protein = 30, Carbs = 35, Fat = 15, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Rau củ hấp với đậu hũ", Calories = 450, Protein = 40, Carbs = 25, Fat = 20, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Táo với bơ đậu phộng", Calories = 200, Protein = 25, Carbs = 5, Fat = 10, BmiMin = 15, BmiMax = 19 },

                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Sữa chua Hy Lạp với mật ong", Calories = 200, Protein = 25, Carbs = 15, Fat = 5, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Bánh mì cuộn gà tây với rau", Calories = 350, Protein = 30, Carbs = 25, Fat = 10, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Cá tuyết nướng với rau chân vịt", Calories = 450, Protein = 35, Carbs = 30, Fat = 15, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Cà rốt với sốt hummus", Calories = 150, Protein = 15, Carbs = 5, Fat = 7, BmiMin = 20, BmiMax = 23 },

                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Sinh tố rau chân vịt với chuối", Calories = 180, Protein = 30, Carbs = 10, Fat = 3, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Ức gà nướng với bông cải", Calories = 400, Protein = 25, Carbs = 35, Fat = 10, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Mì bí xanh với sốt pesto", Calories = 420, Protein = 30, Carbs = 20, Fat = 15, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "giảm mỡ", MealName = "Phô mai Cottage ít béo", Calories = 160, Protein = 10, Carbs = 15, Fat = 4, BmiMin = 24, BmiMax = 27 },

                    // 🔼 TĂNG CƠ
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Bánh mì bơ đậu phộng với chuối", Calories = 400, Protein = 40, Carbs = 20, Fat = 15, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Cơm trộn gà kiểu Burrito", Calories = 600, Protein = 50, Carbs = 35, Fat = 20, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Thịt bò với khoai lang", Calories = 650, Protein = 45, Carbs = 40, Fat = 25, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Hỗn hợp hạt khô", Calories = 300, Protein = 30, Carbs = 10, Fat = 15, BmiMin = 15, BmiMax = 19 },

                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Trứng và bánh mì nguyên cám", Calories = 400, Protein = 30, Carbs = 25, Fat = 15, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Thịt bò xào rau và cơm", Calories = 600, Protein = 50, Carbs = 35, Fat = 25, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Cá hồi nướng với hạt diêm mạch", Calories = 700, Protein = 45, Carbs = 40, Fat = 30, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Sữa protein lắc", Calories = 300, Protein = 20, Carbs = 30, Fat = 10, BmiMin = 20, BmiMax = 23 },

                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Trứng chiên phô mai và bơ", Calories = 500, Protein = 25, Carbs = 30, Fat = 35, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Mì ý gà sốt Alfredo", Calories = 700, Protein = 55, Carbs = 45, Fat = 30, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Sườn heo với khoai nghiền", Calories = 750, Protein = 50, Carbs = 40, Fat = 35, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "Tăng cơ", MealName = "Thanh granola và sữa", Calories = 350, Protein = 40, Carbs = 15, Fat = 12, BmiMin = 24, BmiMax = 27 },

                    // 🔋 GIỮ DÁNG
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Sinh tố trái cây và bánh mì nướng", Calories = 350, Protein = 50, Carbs = 10, Fat = 8, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Cơm và cà ri gà", Calories = 600, Protein = 55, Carbs = 25, Fat = 18, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Cá ngừ nướng và cơm lứt", Calories = 650, Protein = 45, Carbs = 35, Fat = 20, BmiMin = 15, BmiMax = 19 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Chuối và bơ hạnh nhân", Calories = 250, Protein = 30, Carbs = 5, Fat = 10, BmiMin = 15, BmiMax = 19 },

                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Cháo yến mạch chuối và bơ đậu phộng", Calories = 400, Protein = 45, Carbs = 15, Fat = 12, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Mì Ý gà sốt cà chua", Calories = 650, Protein = 55, Carbs = 30, Fat = 20, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Ớt chuông nhồi thịt", Calories = 700, Protein = 50, Carbs = 35, Fat = 25, BmiMin = 20, BmiMax = 23 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Hỗn hợp trái cây và hạt", Calories = 280, Protein = 35, Carbs = 8, Fat = 12, BmiMin = 20, BmiMax = 23 },

                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Pudding hạt chia với xoài", Calories = 420, Protein = 50, Carbs = 12, Fat = 15, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Bánh mì cá ngừ và súp bắp", Calories = 600, Protein = 50, Carbs = 25, Fat = 20, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Couscous với gà quay", Calories = 750, Protein = 60, Carbs = 35, Fat = 25, BmiMin = 24, BmiMax = 27 },
                    new MealSuggestion { GoalType = "Giữ dáng", MealName = "Thanh đậu phộng và sữa", Calories = 320, Protein = 30, Carbs = 10, Fat = 15, BmiMin = 24, BmiMax = 27 }
                };

                context.MealSuggestions.AddRange(mealSuggestions);
                context.SaveChanges();
            }
        }
    }
}
