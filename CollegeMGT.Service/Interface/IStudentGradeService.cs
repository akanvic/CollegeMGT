using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Interface
{
    public interface IStudentGradeService
    {
        Task<StudentGrade> AddStudentGrade(StudentGradeViewModel studentVM);
        Task<IEnumerable<StudentGrade>> GetAllStudentGrades();

        Task<StudentGrade> UpdateStudentGrade(StudentGradeViewModel studentVm);
        Task<StudentGrade> GetStudentGradeByStudentGradeId(int studentGradeId);
        void DeleteStudentGrade(int studentId);
    }
}
