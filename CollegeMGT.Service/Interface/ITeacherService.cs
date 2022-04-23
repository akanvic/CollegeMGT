using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Interface
{
    public interface ITeacherService
    {
        Task<Teacher> AddTeacher(TeacherViewModel teacherVm);
        Task<IEnumerable<Teacher>> GetAllTeacher();
        Task<Teacher> UpdateTeacher(TeacherViewModel teacherVm);
        Task<Teacher> GetTeacherById(int teacherId);
        Task<IEnumerable<Teacher>> GetAvailableTeachers(int courseId);
        Task DeleteTeacher(int teacherId);
    }
}
