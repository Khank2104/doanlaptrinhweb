using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartGym.Data;
using SmartGym.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình EF Core với SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Cấu hình ASP.NET Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// 3. Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    DataSeeder.SeedExercises(context); // ✅ Gọi hàm seed
}

// 4. Middleware xử lý request
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 5. Kích hoạt Authentication và Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

// ✅ Map "/" về trang Index để tránh vào thẳng Dashboard
app.MapGet("/", context =>
{
    context.Response.Redirect("/Index");
    return Task.CompletedTask;
});

app.Run();
