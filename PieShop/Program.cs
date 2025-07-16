using PieShop.Components;
using PieShop.Data;
using PieShop.Repositories;
using PieShop.Services;
using PieShop.Contracts.Repositories;
using PieShop.Contracts.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services
   .AddRazorComponents()
   .AddInteractiveServerComponents(); // This line is necessary for Blazor Server components  

builder.Services.AddDbContextFactory<AppDbContext>(options =>
       options.UseSqlServer(
           builder.Configuration["ConnectionStrings:DefaultConnection"]
           ));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
