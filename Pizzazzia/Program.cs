using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pizzazzia.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    policy.RequireRole("Admin"));
});
// Add services to the container.
builder.Services.AddRazorPages(options=>
{
    options.Conventions.AuthorizeFolder("/Pizzas");
    options.Conventions.AuthorizeFolder("/Ingredients");
    options.Conventions.AuthorizeFolder("/Users");
    options.Conventions.AllowAnonymousToPage("/Pizzas/Index");
    options.Conventions.AllowAnonymousToPage("/Ingredients/Index");
    options.Conventions.AllowAnonymousToPage("/Pizzas/Details");
    options.Conventions.AllowAnonymousToPage("/Ingredients/Details");
    options.Conventions.AuthorizeFolder("/Users", "AdminPolicy");
});
builder.Services.AddDbContext<PizzazziaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PizzazziaContext") ?? throw new InvalidOperationException("Connection string 'PizzazziaContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PizzazziaContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
