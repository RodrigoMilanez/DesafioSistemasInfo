using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DesafioSistemasInfo.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsuarioContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UsuarioContext") ?? throw new InvalidOperationException("Connection string 'UsuarioContext' not found.")));
var serviceProvider = builder.Services.BuildServiceProvider();
try
{
    var dbContext = serviceProvider.GetRequiredService<UsuarioContext>();
    dbContext.Database.Migrate();
}
catch
{
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
