//Author         : Aruneshan S
//Project Title  : Timesheet Management System(Replica)
//Created At     : 15-Feb-2023
//Modified At    : 11-mar-2023
//Reviewed By    : Anitha Manogaran
//Reviewed At    : 23-feb-2023

using Microsoft.EntityFrameworkCore;
using Original.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OriginalContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Database")
    ));

//SwaggerUIBuilderExtensions.UseSwaggerUI();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
   // options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
