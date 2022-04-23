using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Repo.Data.GenericRepository.Implementations;
using CollegeMGT.Repo.Data.Repository.Interface;
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

        public Task<StudentGrade> UpdateStudentGrade(StudentGradeViewModel studentVm)
        {
            throw new NotImplementedException();
        }
    }
}
