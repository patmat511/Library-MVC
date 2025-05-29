using Biblioteka_ASP.Data;
using Biblioteka_ASP.Repositories.Classes;
using Biblioteka_ASP.Repositories.Interfaces;
using Biblioteka_ASP.Services.Interfaces;
using Biblioteka_ASP.Services;
using Microsoft.EntityFrameworkCore;
using Biblioteka_ASP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BibliotekaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));


builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<BibliotekaDbContext>();

// Repozytorium
builder.Services.AddScoped<IKsiazkiRepository, KsiazkiRepository>();
builder.Services.AddScoped<IGatunkiRepository, GatunkiRepository>();
builder.Services.AddScoped<IKlienciRepository, KlienciRepository>();
builder.Services.AddScoped<IWypozyczeniaRepository, WypozyczeniaRepository>();

// Serwisy
builder.Services.AddScoped<IGatunkiService, GatunkiService>();
builder.Services.AddScoped<IKlienciService, KlienciService>();
builder.Services.AddScoped<IKsiazkiService, KsiazkiService>();
builder.Services.AddScoped<IWypozyczeniaService, WypozyczeniaService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();