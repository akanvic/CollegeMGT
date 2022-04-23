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
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public GradeRepository(CollegeDbContext collegeDbContext) : base(collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<Grade> UpdateGrade(GradeDto grade)
        {
            var gradeFromDb = await _collegeDbContext.Grades.FirstOrDefaultAsync(c => c.GradeId == grade.GradeId);

            if (gradeFromDb != null)
            {
                gradeFromDb.GradeName = grade.GradeName;
                gradeFromDb.GradeValue = grade.GradeValue;
            }
            return gradeFromDb;
        }
    }
}
