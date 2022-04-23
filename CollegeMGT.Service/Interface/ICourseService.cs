using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Interface
{
    public interface ICourseService
    {
        Task<Course> AddCourse(CourseDto courseDto);
        Task<IEnumerable<Course>> GetAllCourses();

        Task<Course> UpdateCourse(CourseDto courseDto);
        Task<Course> GetCourseById(int courseId);
        Task DeleteCourse(int courseId);
    }
}
