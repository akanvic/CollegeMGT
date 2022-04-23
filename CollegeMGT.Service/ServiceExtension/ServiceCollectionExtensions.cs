using CollegeMGT.Repo.Dapper.Infrastructure;
using CollegeMGT.Repo.Data.GenericRepository.Implementations;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Repo.Data.Repository.Implementation;
using CollegeMGT.Repo.Data.Repository.Interface;
using CollegeMGT.Service.Implementation;
using CollegeMGT.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CollegeMGT.Service.ServiceExtension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ITeacherService, TeahcherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentGradeService, StudentGradeService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConnectionFactory, Connectionfactory>();
            services.AddScoped<IPrequisiteService, PrequisiteService>();

            return services;
        }
    }
}
