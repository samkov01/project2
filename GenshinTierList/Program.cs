using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GenshinTierList.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreWebApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GenshinTierListContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GenshinTierListContext") ?? throw new InvalidOperationException("Connection string 'GenshinTierListContext' not found.")));
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
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

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
