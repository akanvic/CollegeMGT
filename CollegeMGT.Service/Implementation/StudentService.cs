using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> AddStudent(StudentViewModel studentVm)
        {
            var student = new Student
            {
                StudentName = studentVm.Student.StudentName,
                CourseId = studentVm.Student.CourseId,
                StudentBirthDate = studentVm.Student.StudentBirthDate,
                StudentRegistrationNumber = "REG" + GenerateRegistrationCode()
            };
            await _unitOfWork.StudentRepository.CreateAsync(student);
            await _unitOfWork.Save();
            return student;
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = await _unitOfWork.StudentRepository.GetMultiple(IncludeProperties: "Course");
            return students;
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            var student = await _unitOfWork.StudentRepository.Get(studentId);
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
