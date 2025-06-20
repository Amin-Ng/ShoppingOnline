using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShoppingOnlineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ScarpaDb")));


var app = builder.Build();

// Caricamento iniziale dei dati dal file JSON
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ShoppingOnlineContext>();

    // Assicurati che il DB sia creato
    context.Database.EnsureCreated();

    // Verifica se il database è vuoto
    if (!context.catalogo_Scarpes.Any())
    {
        var jsonData = File.ReadAllText("scarpe.json");
        var scarpe = JsonSerializer.Deserialize<List<CatalogoScarpe>>(jsonData);

        if (scarpe != null)
        {
            context.catalogo_Scarpes.AddRange(scarpe);
            context.SaveChanges();
        }
    }
}

// Configure the HTTP request pipeline.
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
