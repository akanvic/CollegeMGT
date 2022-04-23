using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Repo.Dapper.Implementation;
using CollegeMGT.Repo.Dapper.Infrastructure;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Implementation
{
    public class StudentGradeService : IStudentGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
       // private readonly GenericRepository<StudentGrade> _studentGrade;

        public StudentGradeService(IConnectionFactory connectionfactory, IUnitOfWork unitOfWork)
        {
           // _studentGrade = new GenericRepository<StudentGrade>(connectionfactory);
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentGrade> AddStudentGrade(StudentGradeViewModel studentVm)
        {
            var studentGrade = new StudentGrade
            {
                StudentId = studentVm.StudentGrade.StudentId,
                SubjectId = studentVm.StudentGrade.SubjectId,
                GradeId = studentVm.StudentGrade.GradeId,
            };
            await _unitOfWork.StudentGradeRepository.CreateAsync(studentGrade);
            await _unitOfWork.Save();
            return studentGrade;
        }


        public void DeleteStudentGrade(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentGrade>> GetAllStudentGrades()
        {
            var students = await _unitOfWork.StudentGradeRepository.GetMultiple(IncludeProperties: "Student,Subject,Grade");
            return students;
        }

        public async Task<StudentGrade> GetStudentGradeByStudentGradeId(int studentGradeId)
        {
            var studentGrade = await _unitOfWork.StudentGradeRepository.Get(studentGradeId);
            return studentGrade;
        }

        public Task<StudentGrade> UpdateStudentGrade(StudentGradeViewModel subjectVm)
        {
            throw new NotImplementedException();
        }
    }
}
