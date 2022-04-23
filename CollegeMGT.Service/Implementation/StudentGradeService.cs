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
    public class StudentGradeService : IStudentGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GenericRepository<StudentGradeVw> _studentGradeVw;

        public StudentGradeService(IConnectionFactory connectionfactory, IUnitOfWork unitOfWork)
        {
            _studentGradeVw = new GenericRepository<StudentGradeVw>(connectionfactory);
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentGrade> AddStudentGrade(RecordStudentGradeVm studentVm)
        {
            var studentGrade = new StudentGrade
            {
                StudentId = studentVm.StudentGradeVw!.StudentId,
                SubjectId = studentVm.StudentGradeVw.SubjectId,
                GradeId = studentVm.StudentGradeVw.GradeId,
            };
            await _unitOfWork.StudentGradeRepository.CreateAsync(studentGrade);
            await _unitOfWork.Save();
            return studentGrade;
        }


        public async Task DeleteStudentGrade(int studentId)
        {
            _unitOfWork.StudentGradeRepository.Remove(studentId);
            await _unitOfWork.Save();
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
        public async Task<StudentGradeVw> GetStudentGradeByStudentId(int studentId)
        {
            var studentGrade = await _studentGradeVw.QueryFirstOrDefaultAsyncSp(StoredProcedures.uspGetStudentGradeByStudentId,
                CommandType.StoredProcedure, new
                {
                    StudentId = studentId
                }); ;
            return studentGrade;
        }
        public async Task<StudentGrade> UpdateStudentGrade(RecordStudentGradeVm studentVm)
        {
            var studentGrade = await _unitOfWork.StudentGradeRepository.UpdateStudentGrade(studentVm);
            await _unitOfWork.Save();
            return studentGrade;
        }
    }
}
