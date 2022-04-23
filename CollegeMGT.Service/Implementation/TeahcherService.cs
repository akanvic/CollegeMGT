using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Repo.Dapper.Implementation;
using CollegeMGT.Repo.Dapper.Infrastructure;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CollegeMGT.Repo.Dapper.Infrastructure.Connectionfactory;

namespace CollegeMGT.Service.Implementation
{
    public class TeahcherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GenericRepository<Teacher> _teacherService;

        public TeahcherService(IUnitOfWork unitOfWork, IConnectionFactory connectionfactory)
        {
            _teacherService = new GenericRepository<Teacher>(connectionfactory);
            _unitOfWork = unitOfWork;
        }

        public async Task<Teacher> AddTeacher(TeacherViewModel teacherVm)
        {
            
            var teacher = new Teacher
            {
                TeacherName = teacherVm.Teacher.TeacherName,
                TeacherBirthDate = teacherVm.Teacher.TeacherBirthDate,
                TeacherSalary = teacherVm.Teacher.TeacherSalary
            };
            await _unitOfWork.TeacherRepository.CreateAsync(teacher);
            await _unitOfWork.Save();
            return teacher;
        }

        public async Task DeleteTeacher(int teacherId)
        {
            _unitOfWork.TeacherRepository.Remove(teacherId);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacher()
        {
            var teachers = await _unitOfWork.TeacherRepository.GetMultiple();
            return teachers;
        }
        public async Task<IEnumerable<Teacher>> GetAvailableTeachers(int courseId)
        {
            var teachers = await _teacherService.QueryAsyncSp(StoredProcedures.uspGetAvailableTeachers, 
                                                            CommandType.StoredProcedure,
                                                            new {CourseId = courseId});
            return teachers;
        }
        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            var teacher = await _unitOfWork.TeacherRepository.Get(teacherId);
            return teacher;
        }

        public async Task<Teacher> UpdateTeacher(TeacherViewModel teacherVm)
        {
            var teacher = await _unitOfWork.TeacherRepository.UpdateTeacher(teacherVm);
            await _unitOfWork.Save();
            return teacher;
        }
    }
}
