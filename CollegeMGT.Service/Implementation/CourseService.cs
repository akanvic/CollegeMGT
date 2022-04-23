using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Course> AddCourse(CourseDto courseDto)
        {
            var course = new Course
            {
                CourseName = courseDto.CourseName,
            };
            await _unitOfWork.CourseRepository.CreateAsync(course);
            await _unitOfWork.Save();
            return course;
        }
        public async Task<Course> UpdateCourse(CourseDto courseDto)
        {
            var course = await _unitOfWork.CourseRepository.UpdateCourse(courseDto);
            await _unitOfWork.Save();
            return course;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _unitOfWork.CourseRepository.FindAllAsync(true);
            return courses;
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            var course = await _unitOfWork.CourseRepository.Get(courseId);
            return course;
        }

        public async Task DeleteCourse(int courseId)
        {
            _unitOfWork.CourseRepository.Remove(courseId);
            await _unitOfWork.Save();
        }
    }
}
