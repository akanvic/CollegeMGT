using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
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
        void DeleteStudent(int studentId);
    }
}
