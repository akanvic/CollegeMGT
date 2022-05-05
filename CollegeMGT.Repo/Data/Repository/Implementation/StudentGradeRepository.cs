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
    public class StudentGradeRepository : GenericRepository<StudentGrade>, IStudentGradeRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public StudentGradeRepository(CollegeDbContext collegeDbContext) : base(collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<StudentGrade> UpdateStudentGrade(UpdateStudentGradeVm studentVm)
        {
            var studentGradeFromDb = await _collegeDbContext.StudentGrades.FirstOrDefaultAsync(c => c.StudentGradeId == studentVm.StudentGradeVw.StudentGradeId);

            if (studentGradeFromDb != null)
            {
                studentGradeFromDb.GradeId = studentVm.StudentGradeVw!.GradeId;
                //studentGradeFromDb.SubjectId = studentVm.StudentGradeVw.SubjectId;
            }
            return studentGradeFromDb!;
        }
    }
}
