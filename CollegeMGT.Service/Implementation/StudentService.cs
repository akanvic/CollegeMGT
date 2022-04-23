using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Core.Views;
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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GenericRepository<StudentGradeVw> _studentGradeVw;

        public StudentService(IUnitOfWork unitOfWork,IConnectionFactory connectionfactory)
        {
            _studentGradeVw = new GenericRepository<StudentGradeVw>(connectionfactory);
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> AddStudent(StudentViewModel studentVm)
        {
            var student = new Student
            {
                StudentName = studentVm.Student!.StudentName,
                CourseId = studentVm.Student.CourseId,
                StudentBirthDate = studentVm.Student.StudentBirthDate,
                StudentRegistrationNumber = "REG" + GenerateRegistrationCode()
            };
            await _unitOfWork.StudentRepository.CreateAsync(student);
            await _unitOfWork.Save();
            return student;
        }

        public async Task DeleteStudent(int studentId)
        {
            _unitOfWork.StudentRepository.Remove(studentId);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = await _unitOfWork.StudentRepository.GetMultiple(IncludeProperties: "Course");
            return students;
        }
        public async Task<int> GetCourseIdByStudentId(int? studentId)
        {
            var studentCourseId = await _unitOfWork.StudentRepository.GetCourseIdByStudentId(studentId);
            return studentCourseId.CourseId;
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            var student = await _unitOfWork.StudentRepository.Get(studentId);
            return student;
        }

        public async Task<StudentGradeVw> GetStudentByStudentId(int? studentId)
        {
            var student = await _studentGradeVw.QueryFirstOrDefaultAsyncSp(StoredProcedures.uspGetStudentByStudentId,
                CommandType.StoredProcedure, new
                {
                    StudentId = studentId
                }); ;
            return student;
        }
        public async Task<Student> UpdateStudent(StudentViewModel studentVm)
        {
            var student = await _unitOfWork.StudentRepository.UpdateStudent(studentVm);
            await _unitOfWork.Save();
            return student;
        }
        public static int GenerateRegistrationCode()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999);
        }
    }
}
