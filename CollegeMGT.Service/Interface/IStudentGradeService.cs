using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Interface
{
    public interface IStudentGradeService
    {
        Task<StudentGrade> AddStudentGrade(RecordStudentGradeVm studentVM);
        Task<IEnumerable<StudentGrade>> GetAllStudentGrades();

        Task<StudentGrade> UpdateStudentGrade(RecordStudentGradeVm studentVm);
        Task<StudentGrade> GetStudentGradeByStudentGradeId(int studentGradeId);
        Task<StudentGradeVw> GetStudentGradeByStudentId(int studentId);
        Task DeleteStudentGrade(int studentId);
    }
}
