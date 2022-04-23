using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Implementation
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GradeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Grade> AddGrade(GradeDto gradeDto)
        {
            var grade = new Grade
            {
                GradeName = gradeDto.GradeName,
                GradeValue = gradeDto.GradeValue
            };
            await _unitOfWork.GradeRepository.CreateAsync(grade);
            await _unitOfWork.Save();
            return grade;
        }

        public async Task DeleteGrade(int gradeId)
        {
            _unitOfWork.GradeRepository.Remove(gradeId);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Grade>> GetAllGrades()
        {
            var grades = await _unitOfWork.GradeRepository.FindAllAsync(true);
            return grades;
        }

        public async Task<Grade> GetGradeById(int gradeId)
        {
            var grade = await _unitOfWork.GradeRepository.Get(gradeId);
            return grade;
        }

        public async Task<Grade> UpdateGrade(GradeDto gradeDto)
        {
            var grade = await _unitOfWork.GradeRepository.UpdateGrade(gradeDto);
            await _unitOfWork.Save();
            return grade;
        }
    }
}
