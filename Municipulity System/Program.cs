using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseApplicationDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "citizens",
    pattern: "citizens/{action=Index}/{id?}",
    defaults: new { controller = "Citizens" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "staff",
    pattern: "staff/{action=Index}/{id?}",
    defaults: new { controller = "Staff" });
app.MapControllerRoute(
    name: "servicesRequested",
    pattern: "services-requested/{action=Index}/{id?}",
    defaults: new { controller = "ServicesRequested" });
app.MapControllerRoute(
    name: "reports",
    pattern: "reports/{action=Index}/{id?}",
    defaults: new { controller = "Reports" });


app.Run();