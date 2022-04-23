using CollegeMGT.Core.Dtos;
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
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public TeacherRepository(CollegeDbContext collegeDbContext) : base(collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<Teacher> UpdateTeacher(TeacherViewModel teacher)
        {
            var teacherFromDb = await _collegeDbContext.Teachers.FirstOrDefaultAsync(c => c.TeacherId == teacher.Teacher.TeacherId);


            if (teacherFromDb != null)
            {
                teacherFromDb.TeacherName = teacher.Teacher.TeacherName;
                teacherFromDb.TeacherBirthDate = teacher.Teacher.TeacherBirthDate;
                teacherFromDb.TeacherSalary = teacher.Teacher.TeacherSalary;
            }
            return teacherFromDb!;
        }
    }
}
