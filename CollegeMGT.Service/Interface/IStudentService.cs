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
    public interface IStudentService
    {
        Task<Student> AddStudent(StudentViewModel subjectVm);
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> UpdateStudent(StudentViewModel subjectVm);
        Task<Student> GetStudentById(int studentId);
        Task DeleteStudent(int studentId);
        Task<int> GetCourseIdByStudentId(int? studentId);
        Task<StudentGradeVw> GetStudentByStudentId(int? studentId);
    }
}
