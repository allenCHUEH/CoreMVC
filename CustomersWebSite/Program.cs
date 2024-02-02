using CustomersWebSite.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddDbContext<NorthwindContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"));
});
//新增Session存值
builder.Services.AddSession(option =>
{
    option.Cookie.Name = ".CustomersWebSite.Seesion";
    option.IdleTimeout = TimeSpan.FromSeconds(5);
    option.Cookie.HttpOnly = true;
    option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
//新增Cache存值
builder.Services.AddDistributedMemoryCache();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//Add
app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
