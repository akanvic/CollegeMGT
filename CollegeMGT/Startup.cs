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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CollegeMGT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
                //.AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler);

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CollegeDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddService();
            services.AddRazorPages();
       
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.SerilogPipelineConfig<Program>();
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
        }
    }
}
