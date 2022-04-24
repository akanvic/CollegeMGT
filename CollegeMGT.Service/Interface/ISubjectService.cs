using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Interface
{
    public interface ISubjectService
    {
        Task<Subject> AddSubject(SubjectViewModel subjectVm);
        Task<IEnumerable<Subject>> GetAllSubjects();

        Task<Subject> UpdateSubject(SubjectViewModel subjectVm);
        Task<Subject> GetSubjectById(int subjectId);
        Task DeleteSubject(int subjectId);
        Task<IEnumerable<Subject>> GetSubjectsByCourseId(int courseId);
        Task<int> GetCourseIdBySubjectId(int? subjectId);
    }
}
