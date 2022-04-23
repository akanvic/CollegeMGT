using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public StudentRepository(CollegeDbContext collegeDbContext) : base(collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<Student> UpdateStudent(StudentViewModel studentVm)
        {
            var studentFromDb = await _collegeDbContext.Students.FirstOrDefaultAsync(c => c.StudentId == studentVm.Student.StudentId);

            if (studentFromDb != null)
            {
                studentFromDb.StudentName = studentVm.Student!.StudentName;
                studentFromDb.CourseId = studentVm.Student.CourseId;
                studentFromDb.StudentBirthDate = studentVm.Student.StudentBirthDate;
            }
            return studentFromDb!;
        }

        public async Task<Student> GetCourseIdByStudentId(int? studentId)
        {
            var courseFromDb = await _collegeDbContext.Students.FirstOrDefaultAsync(c => c.StudentId == studentId);
            return courseFromDb!;
        }
    }
}
