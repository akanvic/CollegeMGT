using CollegeMGT.Core.Models;
using CollegeMGT.Repo.Dapper.Infrastructure;
using CollegeMGT.Repo.Data;
using CollegeMGT.Repo.Data.GenericRepository.Implementations;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Repo.Data.Repository.Implementation;
using CollegeMGT.Repo.Data.Repository.Interface;
using CollegeMGT.Service.Implementation;
using CollegeMGT.Service.Interface;
using CollegeMGT.Service.ServiceExtension;
using LoggerLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilogLogger();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation()
    .AddJsonOptions(c=>c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CollegeDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddService();
builder.Services.AddRazorPages();


var app = builder.Build();

app.SerilogPipelineConfig<Program>();
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


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
