using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Data;
using ShoppingOnline.Models;
using System.Text.Json;

    var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShoppingOnlineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ScarpaDb")));

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ShoppingOnlineContext>();

    context.Database.EnsureCreated();

    if (!await context.CatalogoScarpe.AnyAsync())
    {
        var path = Path.Combine(AppContext.BaseDirectory, "scarpe.json");
        var jsonData = await File.ReadAllTextAsync(path);
        var scarpe = JsonSerializer.Deserialize<List<CatalogoScarpe>>(jsonData);

        if (scarpe != null)
        {
            await context.CatalogoScarpe.AddRangeAsync(scarpe);
            await context.SaveChangesAsync();
        }
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
