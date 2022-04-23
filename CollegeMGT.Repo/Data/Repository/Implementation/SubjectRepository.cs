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
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public SubjectRepository(CollegeDbContext collegeDbContext) : base(collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }
        public async Task<Subject> UpdateSubject(SubjectViewModel subjectVm)
        {
            var subjectFromDb = await _collegeDbContext.Subjects.FirstOrDefaultAsync(c => c.SubjectId == subjectVm.Subject.SubjectId);

            if (subjectFromDb != null)
            {
                subjectFromDb.SubjectName = subjectVm.Subject.SubjectName;
                subjectFromDb.CourseId = subjectVm.Subject.CourseId;
                subjectFromDb.TeacherId = subjectVm.Subject.TeacherId;
            }
            return subjectFromDb;
        }
        public async Task<Subject> AddTeacherToSubject(AddTeacherToSubjectVm subjectVm)
        {
            var subjectFromDb = await _collegeDbContext.Subjects.FirstOrDefaultAsync(c => c.SubjectId == subjectVm.Subject.SubjectId);

            if (subjectFromDb != null)
            {
                subjectFromDb.TeacherId = subjectVm.Subject.TeacherId;

                //_collegeDbContext.Update(subjectVm.Subject.TeacherId);
            }
            return subjectFromDb;
        }
        public async Task<Subject> GetCourseIdBySubjectId(int? subjectId)
        {
            var subjectFromDb = await _collegeDbContext.Subjects.FirstOrDefaultAsync(c => c.SubjectId == subjectId);
            return subjectFromDb;
        }
    }
}
