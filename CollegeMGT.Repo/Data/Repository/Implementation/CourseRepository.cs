using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Repo.Data.GenericRepository.Implementations;
using CollegeMGT.Repo.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Repo.Data.Repository.Implementation
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public CourseRepository(CollegeDbContext collegeDbContext) : base(collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<Course> UpdateCourse(CourseDto course)
        {
            var courseFromDb = await _collegeDbContext.Courses.FirstOrDefaultAsync(c => c.CourseId == course.CourseId);

            if (courseFromDb != null)
            {
                courseFromDb.CourseName = course.CourseName;
            }
            return courseFromDb!;
        }
    }
}
