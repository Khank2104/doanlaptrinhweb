using SmartGym.Data;
using SmartGym.Models;

public static class DataSeeder
{
    public static void SeedExercises(ApplicationDbContext context)
    {

        // ✅ Xoá toàn bộ dữ liệu cũ
        if (context.ExerciseSuggestions.Any())
            return;

        // ✅ Thêm dữ liệu mới
        var exercises = new List<ExerciseSuggestion>
        {
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy tại chỗ", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Leo núi tại chỗ", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Burpees", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "giảm mỡ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Chạy bộ", Duration = 25, CaloriesBurned = 190 },


                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 // Trung bình
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 // Nâng cao
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Deadlifts", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Đẩy ngực (Bench Press)", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Hít xà đơn (Pull-Ups)", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Tăng cơ", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Chùng chân (Lunges)", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Thể hình", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Chống đẩy cơ bản", Duration = 10, CaloriesBurned = 60 },
                 new() { Goal = "Thể hình", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Squat không tạ", Duration = 15, CaloriesBurned = 90 },
                 new() { Goal = "Thể hình", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Crunches (gập bụng)", Duration = 20, CaloriesBurned = 130 },
                 new() { Goal = "Thể hình", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Plank cơ bản", Duration = 10, CaloriesBurned = 80 },

                 // Cấp độ: Cơ bản
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "người mới", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 // Cấp độ: Trung bình
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "trung cấp", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 // Cấp độ: Nâng cao
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 16.0, BmiMax = 18.4, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 18.5, BmiMax = 24.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 25.0, BmiMax = 29.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },

                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy dây", Duration = 10, CaloriesBurned = 70 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Đấm gió", Duration = 15, CaloriesBurned = 110 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Leo cầu thang", Duration = 20, CaloriesBurned = 150 },
                 new() { Goal = "Giữ dáng", Level = "nâng cao", BmiMin = 30.0, BmiMax = 34.9, Name = "Nhảy squat", Duration = 25, CaloriesBurned = 190 },
        };

        context.ExerciseSuggestions.AddRange(exercises);
        context.SaveChanges();
    }
}